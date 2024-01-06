namespace C_Sharp_.Net_Address_Book.Intefaces;

public interface IFileService
{
    bool SaveContentToFile(string content);
    string GetContentFromFile();
}
