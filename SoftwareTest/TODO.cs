using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftwareTest
{
    class TODO
    {
        public byte[] EncodeNew(byte[] original)
        {
            List<byte> result = new List<byte>();
            byte bytescount = 0;
            for (int i = 0; i < original.Length; i++)
            {
                bytescount = 1;
                while (bytescount < byte.MaxValue && i + 1 < original.Length && original[i] == original[i + 1])
                {
                    bytescount++;
                    i++;
                }
                result.Add(bytescount);
                result.Add(original[i]);
            }

            return result.ToArray();
        }


        public byte[] Encode(byte[] original)
        {
            if (original == null)
                throw new ArgumentNullException("original");

            IEnumerator<byte> byteEnumerator = ((IEnumerable<byte>)original).GetEnumerator();
            if (!byteEnumerator.MoveNext())
                return null;

            List<byte> results = new List<byte>();
            byte valueCount = 1;
            byte valueInArray = byteEnumerator.Current;

            while (byteEnumerator.MoveNext())
            {
                if (byteEnumerator.Current != valueInArray)
                {
                    results.Add(valueCount);
                    results.Add(valueInArray);
                    valueInArray = byteEnumerator.Current;
                    valueCount = 1;
                }
                else
                    valueCount += 1;
            }

            results.Add(valueCount);
            results.Add(valueInArray);

            return results.ToArray();
        }
    }
}
