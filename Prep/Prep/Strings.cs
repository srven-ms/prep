
public class Strings
{
    // 175: https://leetcode.com/problems/valid-palindrome/description/
    public bool IsPalindrome(string s)
    {
        s = s.Trim();

        if (s.Length == 0 || s.Length == 1)
        {
            return true;
        }

        string newString = "";

        for (int i = 0; i < s.Length; i++)
        {
            char currentChar = s[i];

            if (IsAlbhabet(currentChar))
            {
                if (currentChar >= 65 && currentChar <= 90)
                {
                    currentChar = (char)(currentChar + 32);
                }

                newString += currentChar;
            }
            else if ((currentChar - '0') >= 0 && (currentChar - '0') <= 9)
            {
                newString += currentChar;
            }
        }

        int start = 0;
        int end = newString.Length - 1;

        while (start <= end)
        {
            char startChar = newString[start];
            char endChar = newString[end];

            if (startChar != endChar)
            {
                return false;
            }
            else
            {
                start++;
                end--;
            }
        }

        return true;
    }

    private static bool IsAlbhabet(char c)
    {
        return (c >= 65 && c <= 90) || (c >= 97 && c <= 122);
    }
}
