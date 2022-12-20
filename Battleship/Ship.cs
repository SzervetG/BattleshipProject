namespace Battleship;

public class Ship
{
    public ShipType Type { get; }
    public (int, int)[] Coordinates { get; }

    public Ship(ShipType shipType)
    {
        Type = shipType;
        int length = (int)shipType;
        Coordinates = new (int, int)[(int)shipType];
        Console.WriteLine(Coordinates[0].Item1);
    }


    public void SetShipCoordinates(int xCoord, int yCoord)
    {
        for (int actualPart = 0; actualPart < (int)this.Type; actualPart++)
        {
            Coordinates[0 + actualPart].Item1 = xCoord;
            Coordinates[0 + actualPart].Item2 = yCoord;
        }
    }

}