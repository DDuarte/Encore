using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Trinity.Encore.Framework.Core
{
    public static class Utility
    {
        public static string ToCamelCase(string input)
        {
            Contract.Requires(!string.IsNullOrEmpty(input));
            Contract.Ensures(!string.IsNullOrEmpty(Contract.Result<string>()));

            const char space = ' ';
            var newName = new StringBuilder();
            var upperCase = true;

            foreach (var chr in input)
            {
                var c = chr;

                if (c == '_')
                    c = space;

                c = upperCase ? char.ToUpper(c) : char.ToLower(c);

                if (c == space)
                {
                    upperCase = true;
                    continue;
                }

                upperCase = false;

                newName.Append(c);
            }

            var newNameStr = newName.ToString();
            Contract.Assume(!string.IsNullOrEmpty(newNameStr));
            return newNameStr;
        }

        public static byte[] HexStringToBinary(string data)
        {
            Contract.Requires(data != null);
            Contract.Requires(data.Length % 2 == 0);
            Contract.Ensures(Contract.Result<byte[]>() != null);

            var bytes = new List<byte>();

            for (var i = 0; i < data.Length; i += 2)
            {
                Contract.Assume(i + 2 < data.Length);
                bytes.Add(byte.Parse(data.Substring(i, 2), NumberStyles.HexNumber));
            }

            return bytes.ToArray();
        }

        public static string BinaryToHexString(byte[] data)
        {
            Contract.Requires(data != null);
            Contract.Ensures(Contract.Result<string>() != null);

            var str = string.Empty;

            for (var i = 0; i < data.Length; ++i)
                str += data[i].ToString("X2", CultureInfo.InvariantCulture);

            return str;
        }
    }
}
