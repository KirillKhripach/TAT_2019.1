using System;

namespace DevTask4
{
    /// <summary>
    /// Class for string extensions
    /// </summary>
    static class StringExtension
    {
        /// <summary>
        /// Generates new GUID
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns>New GUID</returns>
        public static Guid SetGuid(this string inputString)
        {
            return Guid.NewGuid();
        }
    }
}
