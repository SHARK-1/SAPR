using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guide
{
    public static class FileManager
    {
        public static readonly string _directoryPath = 
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
            + @"\Guide";
        public static readonly string _fileName = "GuideParameters.json";
        public static void SaveFile(GuideParameters guideParameters, string path)
        {
            var directoryInfo = new DirectoryInfo(path);
            if (!directoryInfo.Exists)
            {
                directoryInfo.Create();
            }
            string parameters = JsonConvert.SerializeObject(guideParameters);

            using (StreamWriter writer = new StreamWriter(Path.Combine(path, _fileName)))
            {
                writer.Write(parameters);
            }
        }
        public static GuideParameters LoadFile(string path)
        {   
            var parameters = new GuideParameters();
            if (!File.Exists(path))
            {
                return parameters;
            }
            JsonSerializer serializer = new JsonSerializer();
            using (StreamReader streamReader=new StreamReader(path))
            using (JsonReader jsonReader=new JsonTextReader(streamReader))
            {
                try
                {
                    parameters = serializer.Deserialize<GuideParameters>(jsonReader);
                }
                catch
                {
                    return parameters;
                }
            }
            return parameters;
        }
    }
}
