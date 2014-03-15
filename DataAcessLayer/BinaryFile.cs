using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace DataAcessLayer
{
    static internal class BinaryFile
    {
        static public void WriteToNewFile(System.Object writedObject, string path)
        {
            var formatter = new BinaryFormatter();
            using (Stream s = File.Create(path))
                formatter.Serialize(s, writedObject);
        }

        static public System.Object ReadObjectFromFile(string path)
        {
            var formatter = new BinaryFormatter();
            using (Stream s = File.OpenRead(path))
                return (System.Object)formatter.Deserialize(s);
        }

        static public void RewriteObject(System.Object writedObject, string path)
        {
            File.Delete(path);
            BinaryFile.WriteToNewFile(writedObject, path);
        }
        static public void Delete(string path)
        {
            File.Delete(path);
        }
    }
}
