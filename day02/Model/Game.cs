namespace day02;

public class Game
{
    public Game()
    {
        Sets = new List<Set>();
    }

    public int GameNumber { get; set; }
    public List<Set> Sets { get; set; }
    public bool IsValid { get; set; }
}