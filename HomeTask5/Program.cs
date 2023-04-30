using HomeTask5;
using System.Text;

StringBuilder sb = new StringBuilder();

sb.Append("salsjhgfjdjhfdjfbjhbvam");
sb.Remove(3, 13);
sb.Replace("sal", "salma");

Console.WriteLine(sb);




CustomBuilder customBuilder = new CustomBuilder();

customBuilder.Append('a');
customBuilder.Append('a');
customBuilder.Append('a');
customBuilder.Append('a');
customBuilder.Append(55);
customBuilder.Append('a');
customBuilder.Append('a');
customBuilder.Append('a');
customBuilder.Replace("55", "66");


Console.WriteLine(customBuilder.ToString());
