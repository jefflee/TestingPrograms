using System.Text;
using System.Text.RegularExpressions;

namespace MyCore.StringReplacement
{
    public class StringReplacement
    {
        public string ReplaceByRegx(string input, string replacement)
        {
            string pattern = "[\\W^_]";
            string result = Regex.Replace(input, pattern, replacement);

            return result;
        }

        public string ReplaceWithALoop(string input, string replacement)
        {
            StringBuilder sb = new StringBuilder(input.Length);
            foreach (char character in input)
            {
                int charDec = character;
                if (charDec is >= 48 and <= 57
                    or >= 65 and <= 90
                    or >= 97 and <= 122)
                {
                    sb.Append(character);
                }
            }

            return sb.ToString();
        }
    }
}