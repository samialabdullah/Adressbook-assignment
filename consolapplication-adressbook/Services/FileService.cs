﻿namespace consolapplication_adressbook.Services;

    internal class FileService
    {
        public void Save(string filePath, string content)
        {
            using var sw = new StreamWriter(filePath);
            sw.WriteLine(content);
        }

        public static string Read(string filePath)
        {
            try
            {
                using var sr = new StreamReader(filePath);
                return sr.ReadToEnd();
            }
            catch
            { 
                return null!;
            }
        }

  
    }

