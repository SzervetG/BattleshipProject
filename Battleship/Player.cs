namespace Battleship;

public class Player
{
    public string Name { get; }
    public Board Board { get; private set; }
    public List<Ship> Ships { get; }

    public Player(string name)
    {
        Name = name;
        Ships = new List<Ship>();
    }


    public void AddBoard(Board board)
    {
        Board = board;
    }


    public void AddShips(Ship ship)
    {
        Ships.Add(ship);
    }
    
    /* Ship placing rule:
     
       unit = Convert.ToInt32(Math.Floor(boardsize * boardsize / 2 % 15));
       5 Long * unit
       4 Long * unit + 1
       3 Long * unit + 1
       2 Long * unit + 2
       1 Long - Convert.ToInt32(Math.Floor(boardsize * boardsize / 2)) - (5*unit + 4*(unit+1) + 3*(unit+1) + 2*(unit+2))
    */
    public void FillShipListWithNonPlacedShips(int boardSize)
    {
        decimal notRoundedUnit = boardSize * boardSize / 2 / 15;
        int unit = Convert.ToInt32(Math.Floor(notRoundedUnit));

        int threeAndFourPartUnit = unit + 1;
        int twoPartUnit = unit + 2;
        
        AddMoreThanOnePartShips(unit, ShipType.BattleShip);
        AddMoreThanOnePartShips(threeAndFourPartUnit, ShipType.Carrier);
        AddMoreThanOnePartShips(threeAndFourPartUnit, ShipType.Destroyer);
        AddMoreThanOnePartShips(twoPartUnit, ShipType.Cruiser);
        AddOnePartShips(unit, boardSize);
    }


    private void AddMoreThanOnePartShips(int unit, ShipType shipType)
    {
        for (int num = 0; num < unit; num++)
        {
            Ships.Add(new Ship(shipType));
        }
    }
    
    
    private void AddOnePartShips(int unit, int boardSize)
    {
        int halfBoard = Convert.ToInt32(Math.Floor(Convert.ToDecimal(boardSize * boardSize / 2)));
        int oneLongUnit = halfBoard - (unit * 5 + 4 * (unit + 1) + 3 * (unit + 1) + 2 * (unit + 2));

        if (oneLongUnit > 0)
        {
            for (int num = 0; num < oneLongUnit; num++)
            {
                Ships.Add(new Ship(ShipType.SpeedBoat));
            }
        }
    }
}