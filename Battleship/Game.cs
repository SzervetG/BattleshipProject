namespace Battleship;

public class Game
{
    private readonly Display _display;
    private readonly Input _input;
    private readonly Validation _validation;

    private List<Player> Players { get; }
    private readonly int _numberOfPlayers = 2;


    public Game()
    {
        _display = new Display();
        _input = new Input();
        _validation = new Validation();
        Players = new List<Player>();
    }
    
    
    public void Gameplay()
    {
        string placingShipMark = "X";
        string shootingShipMark = ".";
        
        _display.WelcomeMessage();
        SetPlayers(_numberOfPlayers);
        _display.Clear();
        
        _display.GetBoardSize();
        int boardSize = _input.GetBoardSize();
        SetupPlayersWithBoardAndShipList(boardSize);
        _display.Clear();
        
        _display.PlacementInstructions();
        PlacingPhase(placingShipMark);
    }


    private void SetPlayers(int numOfPlayers)
    {
        for (int num = 0; num < numOfPlayers; num++)
        {
            _display.GetName(num);
            string name = _input.GetName(num);
            _display.GreetPlayer(name);
            Players.Add(new Player(name));
            Thread.Sleep(1000);
        }
    }


    private void SetupPlayersWithBoardAndShipList(int boardSize)
    {
        foreach (Player player in Players)
        {
            player.AddBoard(new Board(boardSize));
            player.FillShipListWithNonPlacedShips(boardSize);
        }
    }


    private void PlacingPhase(string shipMark)
    {
        foreach (Player player in Players)
        {
            foreach (Ship ship in player.Ships)
            {
                // Display the board
                _display.DisplayBorad(player.Board, shipMark);
                
                // Tell the Player how long that ship will be
                _display.NextShipToPlace(ship.Type);
                
                // Ask the Player for first coordinate of the ship
                _display.GetCoordinate();
                (int, int) shipStart = _input.GetMove();
                
                // Ask the player for a direction in which the ship should be placed
                
                _display.GetDirection();
                string direction = _input.GetDirection();
                
                // If the ship for some reason can not be placed there, ask for the inputs again
                while (!_validation.ValidateShipCanBePlaced(player.Board, shipStart, direction, (int)ship.Type))
                {
                    _display.GetCoordinate();
                    shipStart = _input.GetMove();
                    _display.GetDirection();
                    direction = _input.GetDirection();
                }
                
                // Set the Player's board's square's status to "Ship" from "Ocean" for the length of the ship and
                player.Board.PlaceShipToSquare(ship, shipStart, direction, (int)ship.Type);
                

                _display.Clear();
                
                _display.DisplayBorad(player.Board, shipMark);
                _display.GetEnter();
                while (!_validation.ValidateEnterPressing())
                {
                    _display.GetEnter();
                }
                _display.Clear();
            }
        }
    }
}