using System;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using CalendarPetProject.Data.Constants;

namespace CalendarPetProject.BusinessLogic.JSONParse
{
    internal static class JSONSerializer
    {
        static readonly public string FolderName = "SystemConstants";
        static readonly public string FileName = "SystemConstantsContainer.json";
        static readonly string FolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), FolderName);
        static public string FilePath = Path.Combine(FolderPath, FileName);

        private static string SerializeData<T>(T data)
        {
            string serializedObject = JsonSerializer.Serialize(data, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            return serializedObject.ToString();
        }
        public static void SaveAllData<T>(T data)
        {
            if (data != null)
            {
                Directory.CreateDirectory(FolderPath);

                File.Create(FilePath).Close();
                File.WriteAllText(FilePath, SerializeData(data));

            }
            else
            {
                Console.WriteLine("The data are empty");
            }
        }
        public static string GetData()
        {
            string readingFilePath = Path.Combine(FolderPath, FileName);

            if (string.IsNullOrEmpty(readingFilePath) || !File.Exists(readingFilePath))
            {
                throw new ArgumentException("There is no such file or directory");
            }

            var jsonString = File.ReadAllText(readingFilePath);
            if (string.IsNullOrWhiteSpace(jsonString))
            {
                throw new ArgumentException("File is empty");
            }
            return jsonString;
        }

    }
}