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
        public static GuideParameters LoadFile()
        {
            if (!File.Exists(Path.Combine(_directoryPath, _fileName)))
            {
                return new GuideParameters();
            }
            string parameters;
            using (StreamReader reader=new StreamReader(Path.Combine(_directoryPath, _fileName)))
            {
                parameters = reader.ReadToEnd();
            }
            var guideParameters = JsonConvert.DeserializeObject<GuideParameters>(parameters);
            return guideParameters;
        }
    }
}
