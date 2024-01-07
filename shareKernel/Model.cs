namespace shareKernel;

public class Model(string path)
{
    public  string[] GameData = File.ReadAllLines(path);
    //how get all the lines from the file in a string not an array
    public string GameDataText = File.ReadAllText(path);
    
}