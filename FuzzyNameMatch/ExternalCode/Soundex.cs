/*
The MIT License (MIT)

Copyright (c) 2020 Basi Angulo
Copyright (c) 2015 Ravinder Singh

Permission is hereby granted, free of charge, to any person obtaining a copy of
this software and associated documentation files (the "Software"), to deal in
the Software without restriction, including without limitation the rights to
use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
the Software, and to permit persons to whom the Software is furnished to do so,
subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/

using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace FuzzyNameMatch.ExternalCode
{
    /// <summary>
    /// Provides functionality to retrieve a soundex code for a given word.
    /// </summary>
    public static class Soundex
    {
        /// <summary>
        /// Returns the soundex code for a specified word.
        /// </summary>
        /// <param name="word">Word to get the soundex for.</param>
        /// <returns>Soundex code for word.</returns>
        public static string For(string word)
        {
            const int maxSoundexCodeLength = 4;

            var soundexCode = new StringBuilder();
            var previousWasHOrW = false;

            // Upper case all letters in word and remove any punctuation
            word = Regex.Replace(
                word == null ? string.Empty : word.ToUpper(),
                    @"[^\w\s]",
                        string.Empty);

            if (string.IsNullOrEmpty(word))
                return string.Empty.PadRight(maxSoundexCodeLength, '0');

            // Retain the first letter
            soundexCode.Append(word.First());

            for (var i = 1; i < word.Length; i++)
            {
                var numberCharForCurrentLetter = GetCharNumberForLetter(word[i]);

                // Skip this number if it matches the number for the first character
                if (i == 1 &&
                        numberCharForCurrentLetter == GetCharNumberForLetter(soundexCode[0]))
                    continue;

                // Skip this number if the previous letter was a 'H' or a 'W' 
                // and this number matches the number assigned before that
                if (soundexCode.Length > 2 && previousWasHOrW &&
                        numberCharForCurrentLetter == soundexCode[soundexCode.Length - 2])
                    continue;

                // Skip this number if it was the last added
                if (soundexCode.Length > 0 &&
                        numberCharForCurrentLetter == soundexCode[soundexCode.Length - 1])
                    continue;

                soundexCode.Append(numberCharForCurrentLetter);

                previousWasHOrW = "HW".Contains(word[i]);
            }

            return soundexCode
                    .Replace("0", string.Empty)
                        .ToString()
                            .PadRight(maxSoundexCodeLength, '0')
                                .Substring(0, maxSoundexCodeLength);
        }

        /// <summary>
        /// Retrieves the soundex number for a given letter.
        /// </summary>
        /// <param name="letter">Letter to get the soundex number for.</param>
        /// <returns>Soundex number (as a character) for letter.</returns>
        private static char GetCharNumberForLetter(char letter)
        {
            switch (Char.ToUpper(letter))
            {
                case 'B':
                case 'F':
                case 'P':
                case 'V':
                    return '1';
                case 'C':
                case 'G':
                case 'J':
                case 'K':
                case 'Q':
                case 'S':
                case 'X':
                case 'Z':
                    return '2';
                case 'D':
                case 'T':
                    return '3';
                case 'L':
                    return '4';
                case 'M':
                case 'N':
                    return '5';
                case 'R':
                    return '6';
                default:  //aeiouwh
                    return '0';
            }
        }
    }
}