namespace Battleship;

public class Ship
{
    public ShipType Type { get; }
    
    public int[,] Coordinates { get; }

    public Ship(ShipType shipType)
    {
        Type = shipType;
        int length = (int)shipType;
        Coordinates = new int[length,2];
    }

}