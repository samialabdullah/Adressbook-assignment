using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.IO;
using WpfApp.MVVM.Models;

namespace WpfApp.Services;

internal class FileService
{
    private string filePath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\content.json";

    public ObservableCollection<ContactModel> ReadFromFile()
    {
        try
        {
            using var sr = new StreamReader(filePath);
            return JsonConvert.DeserializeObject<ObservableCollection<ContactModel>>(sr.ReadToEnd())!;
        }
        catch { return new ObservableCollection<ContactModel>(); }
    }

    public void SaveToFile(ObservableCollection<ContactModel> contacts)
    {
        using var sw = new StreamWriter(filePath);
        sw.WriteLine(JsonConvert.SerializeObject(contacts));
    }
}
