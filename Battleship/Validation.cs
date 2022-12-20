namespace Battleship;

public class Validation
{
    
    public bool ValidateValueIsNotNothing(string value)
    {
        if (value.Length < 1)
        {
            return false;
        }

        return true;
    }


    public bool ValidateBoardSize(string boardSize)
    {
        bool result = boardSize.Any(char.IsLetter);

        if (result || Convert.ToInt32(boardSize) < 5 || Convert.ToInt32(boardSize) > 10)
        {
            return false;
        }

        return true;
    }


    public bool ValidateMove(string move, int boardSize)
    {
        string alphabet = "abcdefghijklmnopqrstuvwyxz";
        
        string moveLetter = move[0].ToString().ToLower();
        int letterIndex = alphabet.IndexOf(Convert.ToChar(moveLetter));
        
        string rest = move.Remove(0, 1);
        

        if (!moveLetter.Any(char.IsLetter) || letterIndex > boardSize ||
            !TryConvertStringToInt(rest) || Convert.ToInt32(rest) > boardSize)
        {
            return false;
        }

        return true;
    }


    private bool TryConvertStringToInt(string text)
    {
        int number;
        bool success = int.TryParse(text, out number);

        if (success)
            return success;
        return false;
    }

    

    public bool ValidateEnterPressing()
    {
        ConsoleKeyInfo keyInfo;
        do
        {
            keyInfo = Console.ReadKey();
        } while (keyInfo.Key != ConsoleKey.Enter);

        return true;
    }


    public bool ValidateDirection(string direction)
    {
        if (direction.ToLower() != "h" && direction.ToLower() != "v")
        {
            return false;
        }

        return true;
    }


    public bool ValidateShipCanBePlaced(Board board,(int, int) firstPartPlace, string direction, int shipLength)
    {
        int boardSize = Convert.ToInt32(Math.Sqrt(Convert.ToDouble(board.PlayerBoard.Length)));
        
        if (shipLength != 1)
        {
            for (int partNum = 0; partNum < shipLength; partNum++)
            {
                if (direction.ToLower() == "h")
                {
                    if (firstPartPlace.Item2 + partNum >= boardSize || board.PlayerBoard[firstPartPlace.Item1, firstPartPlace.Item2 + partNum].Status == SquareStatus.Ship)
                        return false;
                }
                else if (direction.ToLower() == "v")
                {
                    if (firstPartPlace.Item1 + partNum >= boardSize || board.PlayerBoard[firstPartPlace.Item1 + partNum, firstPartPlace.Item2].Status == SquareStatus.Ship)
                        return false;
                }
            }
        }

        return board.PlayerBoard[firstPartPlace.Item1, firstPartPlace.Item2].Status != SquareStatus.Ship;
    }


    public bool ValidateHit(Player playerBeingHit, (int, int)move)
    {
        foreach (Ship ship in playerBeingHit.Ships)
        {
            foreach ((int, int) coordinate in ship.Coordinates)
            {
                if (coordinate.Item1 == move.Item1 && coordinate.Item2 == move.Item2)
                {
                    return true;
                }
            }
        }

        return false;
    }
    
    
    public bool ValidateSink(Player playerBeingHit)
    {
        foreach (Ship ship in playerBeingHit.Ships)
        {
            int hitPart = 0;
            foreach ((int, int) coordinate in ship.Coordinates)
            {
                if (playerBeingHit.Board.PlayerBoard[coordinate.Item1, coordinate.Item2].Status == SquareStatus.Hit)
                {
                    hitPart += 1;
                }
            }

            if (hitPart == (int)ship.Type)
                return true;
        }

        return false;
    }


    public bool ValidateLost(Player playerBeingHit)
    {
        int shipCount = playerBeingHit.Ships.Count;
        int sunkShip = 0;
        foreach (Ship ship in playerBeingHit.Ships)
        {
            int sunkPart = 0;
            foreach ((int, int) coordinate in ship.Coordinates)
            {
                if (playerBeingHit.Board.PlayerBoard[coordinate.Item1, coordinate.Item2].Status == SquareStatus.Sank)
                {
                    sunkPart += 1;
                }
            }

            if (sunkPart == (int)ship.Type)
                sunkShip += 1;
        }

        if (sunkShip == shipCount)
            return true;
        return false;

    }
}