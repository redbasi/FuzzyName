using System.Linq;
using System.Text;

namespace FuzzyNameMatch
{
    public static class Utilities
    {
        /// <summary>
        /// Converts a <code>object[]</code> to a <code>string</code> with spaces inbetween by calling the different object's <code>.ToString()</code> method
        /// </summary>
        /// <param name="objects">Objects to represent in string</param>
        /// <returns>A string with spaces between the result of each object's default <code>.ToString()</code> method</returns>
        public static string Space(params object[] objects)
        {
            //remove null objects
            var parts = objects.Where(c => c != null).ToArray();

            //note the last object to know when to stop
            var lastPart = parts.Last();

            var returnBuilder = new StringBuilder();
            foreach (var part in parts)
            {
                returnBuilder.Append(part);

                if (part != lastPart)
                {
                    returnBuilder.Append(" ");
                }
            }

            return returnBuilder.ToString();
        }
    }
}
