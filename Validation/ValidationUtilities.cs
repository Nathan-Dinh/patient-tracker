using System.Text.RegularExpressions;

namespace Validation
{
    public class ValidationUtilities
    {
        public static string Capitalize(string word)
        {
            string[] wordArray = word.Trim().Split(" ");
            var partialWord = string.Empty;
            var newWord = string.Empty;

            //Checks if the string is null or empty
            if (string.IsNullOrEmpty(word))
            {
                return "";
            }

            //This converts the first letter of the string to a capital lowercasing the rest
            for (int i = 0; i < wordArray.Length; i++)
            {
                partialWord = wordArray[i];
                partialWord = partialWord.ToLower();
                newWord += partialWord.Remove(1).ToUpper() + partialWord.Substring(1) + " ";
            }
            return newWord.Trim();
        }

        public static bool IsNameValid(string word)
        {
            if (!string.IsNullOrEmpty(word) && Regex.IsMatch(word, Constants.RegName))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}