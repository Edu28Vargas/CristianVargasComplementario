using System;
using System.Collections.Generic;
using System.Text;

namespace CristianVargasComplementario.Models
{
    using System;
    using System.IO;
    public static class FromFile
    {
        public static byte[] ToArray(Stream input)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                input.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }
    }
}
