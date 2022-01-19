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
        private static readonly string _directoryPath = 
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
            + @"\Guide";
        private static readonly string _fileName = "GuideParameters.json";
        public static void SaveFile(GuideParameters guideParameters)
        {
            var directoryInfo = new DirectoryInfo(_directoryPath);
            if (!directoryInfo.Exists)
            {
                directoryInfo.Create();
            }
            string parameters = JsonConvert.SerializeObject(guideParameters);

            using (StreamWriter writer = new StreamWriter(Path.Combine(_directoryPath, _fileName)))
            {
                writer.Write(parameters);
            }
        }
        public static GuideParameters LoadFile(string path = "")
        {   
            path=string.IsNullOrEmpty(path)
                ? Path.Combine(_directoryPath, _fileName)
                : path;
            var parameters = new GuideParameters();
            if (!File.Exists(path))
            {
                return new GuideParameters();
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
                if(parameters==null)
                {
                    return new GuideParameters();
                }
            }
            return parameters;
        }
    }
}
