using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace RedisDemo
{
    public class Translator
    {
        public byte[] ObjectToByteArray(Object obj)
        {
            if (obj == null)
                return null;
            var bf = new BinaryFormatter();
            var ms = new MemoryStream();
            bf.Serialize(ms, obj);
            return ms.ToArray();
        }

        public Tavisca.Frameworks.Logging.MessageLog ByteArrayToObject(byte[] arrBytes)
        {
            if (arrBytes == null)
                return null;

            var memStream = new MemoryStream();
            var binForm = new BinaryFormatter();
            memStream.Write(arrBytes, 0, arrBytes.Length);
                memStream.Seek(0, SeekOrigin.Begin);
                return (Tavisca.Frameworks.Logging.MessageLog) binForm.Deserialize(memStream);            
        }
    }
}
