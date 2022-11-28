namespace Battleship;

public class Input
{
    private Validation _validation = new Validation();
    public string GetName()
    {
        string name = Console.ReadLine();
        while (!_validation.ValidateName(name))
        {
            name = Console.ReadLine();
        }
        return name;
    }


    public int GetBoardSize()
    {
        int boardSize = Convert.ToInt32(Console.ReadLine());

        while (!_validation.ValidateBoardSize(boardSize))
        {
            boardSize = Convert.ToInt32(Console.ReadLine());
        }

        return boardSize;
    }


    public (int, int) GetMove(int boardSize)
    {
        string move = Console.ReadLine();

        while (!_validation.ValidateMove(move, boardSize))
        {
            move = Console.ReadLine();
        }
        (int, int) convertedMove = ConvertMove(move);

        return convertedMove;
    }


    private (int, int) ConvertMove(string move)
    {
        (int, int) convertedMove;

        convertedMove.Item1 = move[0];
        convertedMove.Item2 = Convert.ToInt32(move.Remove(0, 1));
        
        return convertedMove;
    }


    public string GetDirection()
    {
        string direction = Console.ReadLine();

        while (!_validation.ValidateDirection(direction))
        {
            direction = Console.ReadLine();
        }

        return direction;
    }
}