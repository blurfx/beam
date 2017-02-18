using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Beam.TwitterCore.Helper
{
    public class Json
    {

        public static string Serialize<TSourceObject>(TSourceObject sourceObject)
        {
            DataContractJsonSerializer dataContractJsonSerializer = new DataContractJsonSerializer(sourceObject.GetType());
            MemoryStream memoryStream = new MemoryStream();
            dataContractJsonSerializer.WriteObject(memoryStream, sourceObject);
            string result = Encoding.UTF8.GetString(memoryStream.ToArray());
            return result;
        }

        public static TTargetObject Deserialize<TTargetObject>(string jsonString)
        {
            TTargetObject targetObject = Activator.CreateInstance<TTargetObject>();
            MemoryStream memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(jsonString));
            DataContractJsonSerializer dataContractJsonSerializer = new DataContractJsonSerializer(targetObject.GetType());
            targetObject = (TTargetObject)dataContractJsonSerializer.ReadObject(memoryStream);
            memoryStream.Close();
            return targetObject;
        }


    }
}
