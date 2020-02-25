/*
Copyright (c) 2020 Basi Angulo
Copyright (c) 2010, 2012 Matt Enright

Permission is hereby granted, free of charge, to any person obtaining
a copy of this software and associated documentation files (the
"Software"), to deal in the Software without restriction, including
without limitation the rights to use, copy, modify, merge, publish,
distribute, sublicense, and/or sell copies of the Software, and to
permit persons to whom the Software is furnished to do so, subject to
the following conditions:

The above copyright notice and this permission notice shall be
included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/

/*
Original: https://gist.github.com/wickedshimmy/449595/c9fc5c6e8f1018288eec0964da3864ce3c1eeaab
*/

using System;
using System.Linq;

namespace FuzzyNameMatch.ExternalCode
{
    public static class StringDistance
    {
        public static int GetDamerauLevenshteinDistance(string original, string modified)
        {
			if (original == modified)
                return 0;

            int lenOrig = original.Length;
            int lenDiff = modified.Length;

            if (lenOrig == 0)
                return lenDiff;

            if (lenDiff == 0)
                return lenOrig;

            var matrix = new int[lenOrig + 1, lenDiff + 1];

            for (int i = 1; i <= lenOrig; i++)
            {
                matrix[i, 0] = i;
                for (int j = 1; j <= lenDiff; j++)
                {
                    int cost = modified[j - 1] == original[i - 1] ? 0 : 1;
                    if (i == 1)
                        matrix[0, j] = j;

                    var vals = new int[] {
                        matrix[i - 1, j] + 1,
                        matrix[i, j - 1] + 1,
                        matrix[i - 1, j - 1] + cost
                    };
                    matrix[i, j] = vals.Min();
                    if (i > 1 && j > 1 && original[i - 1] == modified[j - 2] && original[i - 2] == modified[j - 1])
                        matrix[i, j] = Math.Min(matrix[i, j], matrix[i - 2, j - 2] + cost);
                }
            }
            return matrix[lenOrig, lenDiff];
		}
    }
}
