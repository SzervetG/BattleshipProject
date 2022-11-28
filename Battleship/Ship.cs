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


    public void SetShipCoordinates(int xCoord, int yCoord)
    {
        for (int actualPart = 0; actualPart < (int)this.Type; actualPart++)
        {
            Coordinates[0 + actualPart, 0] = xCoord;
            Coordinates[0 + actualPart, 1] = yCoord;
        }
    }

}