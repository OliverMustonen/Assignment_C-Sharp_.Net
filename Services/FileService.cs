using C_Sharp_.Net_Address_Book.Intefaces;
using System.Diagnostics;

namespace C_Sharp_.Net_Address_Book.Services;

/// <summary>
/// Save content to file
/// </summary>
/// <param name="filePath"></param>
public class FileService(string filePath) : IFileService
{
    private readonly string _filePath = filePath;

    public bool SaveContentToFile(string content )
    {
        try
        {
            using (var sw = new StreamWriter(_filePath))
            {
                sw.WriteLine(content);
            }

            return true;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return false;
    }


    /// <summary>
    /// Read content from filepath
    /// </summary>
    /// <returns></returns>
    public string GetContentFromFile()
    {
        try
        {
            if (File.Exists(_filePath))
            {
                using var sr = new StreamReader(_filePath);
                return sr.ReadToEnd();
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }


}
