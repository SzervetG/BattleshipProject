namespace Battleship;

public class Input
{
    private int _boardSize;
    private Display _display = new ();
    
    private Validation _validation = new ();
    public string GetName(int playerNum)
    {
        string name = Console.ReadLine();
        while (!_validation.ValidateValueIsNotNothing(name))
        {
            _display.GetName(playerNum);
            name = Console.ReadLine();
        }
        return name;
    }


    public int GetBoardSize()
    {
        string boardSize = Console.ReadLine();

        
        while (!_validation.ValidateValueIsNotNothing(boardSize) || !_validation.ValidateBoardSize(boardSize))
        {
            _display.GetBoardSize();
            boardSize = Console.ReadLine();
        }

        _boardSize = Convert.ToInt32(boardSize);

        return Convert.ToInt32(boardSize);
    }


    public (int, int) GetMove()
    {
        string move = Console.ReadLine();

        while (!_validation.ValidateValueIsNotNothing(move) || !_validation.ValidateMove(move, _boardSize))
        {
            _display.GetCoordinate();
            move = Console.ReadLine();
        }
        (int, int) convertedMove = ConvertMove(move);

        return convertedMove;
    }


    private (int, int) ConvertMove(string move)
    {
        (int, int) convertedMove;

        convertedMove.Item1 = ConvertLetterToBoardIndex(move[0]);
        convertedMove.Item2 = Convert.ToInt32(move.Remove(0, 1)) - 1;
        
        return convertedMove;
    }


    private int ConvertLetterToBoardIndex(char letter)
    {
        string alphabet = "abcdefghijklmnopqrstuvwxyz";

        int result = -1;
        
        for (int index = 0; index < alphabet.Length; index++)
        {
            if (letter == alphabet[index])
            {
                result = index;
            }
        }

        return result;
    }


    public string GetDirection()
    {
        string direction = Console.ReadLine();

        while (!_validation.ValidateValueIsNotNothing(direction) || !_validation.ValidateDirection(direction))
        {
            _display.GetDirection();
            direction = Console.ReadLine();
        }

        return direction;
    }
}