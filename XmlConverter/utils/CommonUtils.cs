using System;
using System.Text;

namespace XmlConverter.utils
{
    public static class CommonUtils
    {
        public static string ToHexString(this byte[] bytes)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                sb.Append(bytes[i].ToString("X4"));
            }
            return sb.ToString();
        }

        public static byte[] ToByteArrayExt(this string byteArrayStr)
        {
            byte[] newBCh = new byte[byteArrayStr.Length / 4];
            for (int i = 0; i <= byteArrayStr.Length - 4; i += 4)
            {
                newBCh[i / 4] = Convert.ToByte(byteArrayStr.Substring(i, 4), 16);
            }
            return newBCh;
        }
    }
}