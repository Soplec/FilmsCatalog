using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer
{
    static public class Logic
    {


        static public void Create(System.Object myObj, Guid myObjGuid)
        {
            System.Type myObjType = myObj.GetType();
            if (!System.IO.Directory.Exists(myObjType.ToString()))
            {
                System.IO.Directory.CreateDirectory(myObjType.ToString());
                System.IO.File.CreateText(myObjType.ToString()+"\\objectsGuidList");
            }

            string[] uselessMassive = new string[1];
            uselessMassive[0]= myObjGuid.ToString();

            System.IO.File.AppendAllLines(myObjType.ToString() + "\\objectsGuidList", uselessMassive);

            BinaryFile.WriteToNewFile(myObj, myObjType.ToString() + "\\" + myObjGuid.ToString());
        }


        static public void Update(System.Object myChangedObj, Guid myObjGuid)
        {
            BinaryFile.RewriteObject(myChangedObj, myChangedObj.GetType().ToString() + "\\" + myObjGuid.ToString());
        }

        static public System.Object Read (System.Type myType, Guid myObjGuid)
        {
            return BinaryFile.ReadObjectFromFile(myType.ToString() + "\\" + myObjGuid.ToString());
        }


        static public List<System.Object> ReadAll(System.Type myType)
        {
            string[] myMassive = System.IO.File.ReadAllLines(myType.ToString() + "\\objectsGuidList");
            var myList = new List<System.Object>();
            foreach (string item in myMassive)
            {
                myList.Add(BinaryFile.ReadObjectFromFile(myType.ToString() + "\\" + item));
            }
            return myList;
        }


        static public void Delete(System.Type myType, Guid myGuid)
        {
            string[] myMassive = System.IO.File.ReadAllLines(myType.ToString() + "\\objectsGuidList");
            System.IO.File.Delete(myType.ToString() + "\\objectsGuidList");
            //System.IO.File.CreateText(myType.ToString() + "\\objectsGuidList");
            var myList = myMassive.ToList();
            myList.Remove(myGuid.ToString());
            var myNewMassive = myList.ToArray();
            System.IO.File.AppendAllLines(myType.ToString() + "\\objectsGuidList", myNewMassive);

            BinaryFile.Delete(myType.ToString() + "\\" + myGuid.ToString());
        }
    }
}
