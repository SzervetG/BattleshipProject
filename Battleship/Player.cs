namespace Battleship;

public class Player
{
    public string Name { get; }
    
    public Board Board { get; }


    public Player(string name)
    {
        Name = name;
    }
}