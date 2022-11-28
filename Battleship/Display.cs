namespace Battleship;

public class Display
{
    public void WelcomeMessage()
    {
        string message = "Greetings Player(s)! Welcome to the famous BattleShip game!" +
                                "\n\nHow many of you want to play?" +
                                "\n(Please type a number from 1 to 2)";
        
        Console.WriteLine(message);
    }


    public void GetName(int playerNum)
    {
        string message = $"Player{playerNum}, what is Your name?";
        Console.WriteLine(message);
    }


    public void GreetPlayer(string playerName)
    {
        string greet1 = $"Greetings {playerName}";
        string greet2 = $"It's nice to meet you {playerName}";
        string greet3 = $"It's a pleasure meeting you {playerName}";

        string[] greetings = new[] { greet1, greet2, greet3 };

        int greetNum = RandomGreeter();
        
        Console.WriteLine(greetings[greetNum+1]);
    }


    private int RandomGreeter()
    {
        Random random = new Random();
        int randNum = random.Next(1, 3);

        return randNum;
    }


    public void GetBoardSize()
    {
        string message = "What size of board would you play on?";
        Console.WriteLine(message);
    }


    public void PlaceThem()
    {
        string message = "Now comes the placement. Please follow the instructions below!";
        Console.WriteLine(message);
    }


    public void PlacementInstructions()
    {
        string message = "Instructions:\n\n1: Ships can be placed horizontally or vertically within your board." +
                         "\n\n2: If you place horizontally, you will be able to choose the leftmost coordinate of the ship" +
                         " and it will be automatically placed to the right." +
                         "\nIf vertically, you will be able to choose the top coordinate" +
                         " and it will be automatically placed downwards." +
                         "\nFirs you will be asked for a first coordinate and then the direction." +
                         "\n\n3: Each ship has different size what will be displayed when you place that ship." +
                         "\n\n4: Choose wisely...";
        
        Console.WriteLine(message);
    }


    public void GetContinue()
    {
        string message = "Press the Enter button to continue";
        Console.WriteLine(message);
    }
    
    
    public void NextShipToPlace(ShipType ship)
    {
        switch (ship)
        {
            case ShipType.Carrier:
                Console.WriteLine($"You are about to place a {ship}");
                Console.WriteLine("This ship occupies 3 field(s)");
                break;
            case ShipType.Cruiser:
                Console.WriteLine($"You are about to place a {ship}");
                Console.WriteLine("This ship occupies 2 field(s)");
                break;
            case ShipType.SpeedBoat:
                Console.WriteLine($"You are about to place a {ship}");
                Console.WriteLine("This ship occupies 1 field(s)");
                break;
            case ShipType.BattleShip:
                Console.WriteLine($"You are about to place a {ship}");
                Console.WriteLine("This ship occupies 5 field(s)");
                break;
            case ShipType.Destroyer:
                Console.WriteLine($"You are about to place a {ship}");
                Console.WriteLine("This ship occupies 4 field(s)");
                break;
                
        }
    }


    public void GetFirstCoordinate()
    {
        string message = "Please enter a coordinate from where your ship will start!\n";
        Console.WriteLine(message);
    }
    
    
    public void GetDirection()
    {
        string message = "Please enter a direction!\n\nEnter \"h\" for horizontal or \"v\" for vertical placement";
        
        Console.WriteLine(message);
    }


    public void ShipHasBeenPlaced()
    {
        string message = "Your ship has been placed";
        Console.WriteLine(message);
    }
    
    
    public void EnterMove()
    {
        string message = "Where to shoot?";
        Console.WriteLine(message);
    }
    
    
    public void MoveCorrection()
    {
        string message = "Invalid coordinate :(\nTry again!";
        
        Console.WriteLine(message);
    }
    
    
    public void Hit()
    {
        string message = "Good job! That was a hit!";
        Console.WriteLine(message);
    }

    
    public void Sink(string opponentName)
    {
        string message = $"Nicely done! You just sank one of {opponentName}'s ships!\n\nKeep up the good work General!";
        
        Console.WriteLine(message);
    }


    public void DisplayBorad(Board board)
    {
        DrawFirstLine(board);
        DrawLines(board);
    }
    
    
    private void DrawFirstLine(Board board)
    {
        // 
        int boardSize = Convert.ToInt32(Math.Sqrt(Convert.ToDouble(board.PlayerBoard.Length)));
        Console.Write("    ");
        for (int cols = 0; cols < boardSize; cols++)
        {
            if (cols < 10)
            {
                Console.Write($" {cols + 1} ");
            }
            else
            {
                Console.Write($"{cols + 1} ");
            }
        }

        Console.WriteLine();
    }

    private void DrawLines(Board board)
    {
        // 
        string alphabet = "abcdefghijklmnopqrstuvwxyz".ToUpper();
        int boardSize = Convert.ToInt32(Math.Sqrt(Convert.ToDouble(board.PlayerBoard.Length)));

        for (int rows = 0; rows < boardSize; rows++)
        {

            Console.Write($"  {alphabet[rows]}|");
            for (int cols = 0; cols < boardSize; cols++)
            {
                switch (board.PlayerBoard[rows, cols].Status)
                {
                    case SquareStatus.Ocean:
                        Console.Write(" . ");
                        break;
                    case SquareStatus.Ship:
                        Console.Write(" . ");
                        break;
                    case SquareStatus.Hit:
                        Console.Write(" H ");
                        break;
                    case SquareStatus.Sank:
                        Console.Write(" X ");
                        break;
                    case SquareStatus.Miss:
                        Console.Write(" O ");
                        break;
                }
            }

            Console.WriteLine();
        }
    }
}