namespace Battleship;

public class Validation
{
    
    public bool ValidateName(string name)
    {
        if (name.Length < 1)
        {
            return false;
        }

        return true;
    }


    public bool ValidateBoardSize(int boardSize)
    {
        bool result = boardSize.ToString().Any(char.IsLetter);

        if (result || boardSize < 1 || boardSize > 10)
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
        

        if (!moveLetter.Any(char.IsLetter) || letterIndex >= boardSize ||
            !TryConvertStringToInt(rest) || Convert.ToInt32(rest) >= boardSize)
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
        if (direction.ToLower() != "h" || direction.ToLower() != "v")
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
                    if (board.PlayerBoard[firstPartPlace.Item1, firstPartPlace.Item2 + partNum].Status == SquareStatus.Ship ||
                        firstPartPlace.Item2 + partNum >= boardSize)
                        return false;
                }
                if (board.PlayerBoard[firstPartPlace.Item1 + partNum, firstPartPlace.Item2].Status == SquareStatus.Ship ||
                    firstPartPlace.Item1 + partNum >= boardSize)
                    return false;
            }
        }

        return board.PlayerBoard[firstPartPlace.Item1, firstPartPlace.Item2].Status != SquareStatus.Ship;
    }
}