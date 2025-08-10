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
        static readonly string FolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), FolderName);

        private static string SerializeData<T>(T data)
        {
            string serializedObject = JsonSerializer.Serialize(data, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            return serializedObject.ToString();
        }
        public static void SaveAllData<T>(T data, string fileName)
        {
            string FilePath = Path.Combine(FolderPath, fileName);

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
        public static T GetData<T>(string fileName)
        {
            string FilePath = Path.Combine(FolderPath, fileName);

            if (string.IsNullOrEmpty(FilePath) || !File.Exists(FilePath))
            {
                throw new ArgumentException("There is no such file or directory");
            }

            var jsonString = File.ReadAllText(FilePath);
            if (string.IsNullOrWhiteSpace(jsonString))
            {
                throw new ArgumentException("File is empty");
            }

            var result = JsonSerializer.Deserialize<T>(jsonString);
            if (result == null)
            {
                throw new InvalidOperationException("Failed to deserialize JSON to the requested type");
            }

            return result;
        }

    }
}