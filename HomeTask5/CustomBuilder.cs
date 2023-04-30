namespace HomeTask5;

public class CustomBuilder
{
    private char[] _arr;
    private int _capacity = 16;
    private int _length = 0;
    private int _count = 0;
    public int Length
    {
        get
        {
            return _length;
        }
        set
        {
            if (value < _length)
            {
                throw new Exception($"Length must be more than {_length}");
            }
            if (value > _capacity && value <= 2 * _capacity)
            {
                Capacity *= 2;
            }
            if (value > 2 * _capacity)
            {
                Capacity = value;
            }
            _length = value;
        }
    }
    public int Capacity
    {
        get
        {
            return _capacity;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("value cannot be less than zero");
            }
            if (value < Length)
            {
                throw new Exception($"Capacity must be more than {Length}");
            }
            _capacity = value;
            Array.Resize(ref _arr, _capacity);
        }
    }

    public CustomBuilder()
    {
        _arr = new char[_capacity];
    }
    public void Append(char item)
    {
        if (Length == Capacity)
        {
            Capacity = Capacity * 2;
        }
        _arr[_count] = item;
        _count++;
        Length = _count;
    }
    public void Append(int item)
    {
        if (Length == Capacity)
        {
            Capacity = Capacity * 2;
        }
        foreach (char c in item.ToString())
        {
            _arr[_count] = c;
            _count++;
        }
        Length = _count;
    }
    public void Remove(int index, int count)
    {
        if(count < 0 || count > Length || index < 0 || index >= Length)
        {
            throw new ArgumentOutOfRangeException("Index was out of range. Must be non-negative and less than the size of the collection");
        }
        char[] temp = new char[Length - count];
        int ind = 0;
        for (int i = 0; i < Length; i++)
        {
            if(i < index || i > index + count)
            {
                temp[ind] = _arr[i];
                ind++;
            }
        }
        _arr = temp;
        _count = temp.Length;
    }
    public void Replace(char oldC, char newC)
    {
        for (int i = 0; i < _arr.Length; i++)
        {
            if (_arr[i]==oldC)
            {
                _arr[i] = newC;
            }
        }
    }
    public void Replace(string oldV, string newV)
    {
        char[] temp = new char[_arr.Length - oldV.Length + newV.Length];
        int ind = 0;
        for (int i = 0; i < _arr.Length; i++)
        {
            bool res = true;
            for (int j = 0; j < oldV.Length; j++)
            {
                if (_arr[i + j] != oldV[j])
                {
                    res = false;
                    break;
                }
            }
            if (res)
            {
                foreach (char c in newV)
                {
                    temp[ind] = c;
                    ind++;
                }
                i += oldV.Length-1;
                continue;
            }
            temp[ind] = _arr[i];
            ind++;
        }
        _arr = temp;
    }
    public string ToString()
    {
        string result = string.Empty;
        foreach (char item in _arr)
        {
            result += item;
        }
        return result;
    }

}