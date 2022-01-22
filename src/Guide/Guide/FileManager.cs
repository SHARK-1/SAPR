using Newtonsoft.Json;
using System;
using System.IO;

namespace Guide
{
    /// <summary>
    /// Класс сохряняющий и загружающий парматры направляющей
    /// </summary>
    public static class FileManager
    {
        /// <summary>
        /// Строка, хронящая путь до файла с сохранением
        /// </summary>
        public static readonly string _directoryPath = 
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
            + @"\Guide\";
        /// <summary>
        /// Имя файла сохранения
        /// </summary>
        public static readonly string _fileName = "GuideParameters.json";
        /// <summary>
        /// Сохранение параметров
        /// </summary>
        /// <param name="guideParameters">Объект с параметрами</param>
        /// <param name="path">Полный пть до файла</param>
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
        /// <summary>
        /// Загрузка параметров из файла
        /// </summary>
        /// <param name="path">Полный путь до файла</param>
        /// <returns></returns>
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
