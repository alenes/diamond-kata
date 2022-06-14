using System;
using System.Collections.Generic;

namespace DiamondKata.ConsoleApp
{
    public class DiamondFactory
    {
        private readonly char[] _alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

        public List<string> Create(char size)
        {
            var diamondLines = new List<string>();
            
            var sizeIndex = Array.IndexOf(_alpha, size);
            var content = CreateContent(sizeIndex);
            
            var midIndex = Array.IndexOf(content, size);
            var left = midIndex;
            var right = midIndex;
            var reverse = false;
            
            foreach (var letter in content)
            {
                var lineContent = CreateLineContent(content, letter,  left, right);
                if (left == 0)
                {
                    reverse = true;
                }

                if (reverse)
                {
                    left++;
                    right--;
                }
                else
                {
                    left--;
                    right++;
                }
                diamondLines.Add(new string(lineContent));
            }
            return diamondLines;
        }

        private static char[] CreateLineContent(IReadOnlyCollection<char> content, char letter,  int left,  int right)
        {
            var lineContent = new List<char>();
            for (var i = 0; i < content.Count; i++)
            {
                if ((left == right && left == i) || i == left || i == right)
                {
                    lineContent.Add(letter);
                }
                else
                {
                    lineContent.Add('_');
                }
            }

            return lineContent.ToArray();
        }

        private char[] CreateContent(int sizeIndex)
        {
            var index = 0;
            var reverse = false;
            var content = new List<char>();
            while (true)
            {
                content.Add(_alpha[index]);
                if (index == sizeIndex)
                {
                    reverse = true;
                }

                if (reverse)
                {
                    index--;
                }
                else
                {
                    index++;
                }

                if (index < 0)
                {
                    break;
                }
            }
            return content.ToArray();
        }
    }
}