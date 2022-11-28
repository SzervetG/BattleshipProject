namespace Battleship;

public class Board
{
    public Square[,] PlayerBoard { get; private set; }

    public Board(int boardSize)
    {
        InitBoard(boardSize);
    }


    private void InitBoard(int boardSize)
    {
        PlayerBoard = new Square[boardSize, boardSize];
        
        for (int row = 0; row < boardSize; row++)
        {
            for (int col = 0; col < boardSize; col++)
            {
                PlayerBoard[row, col] = new Square();
            }
        }
    }


    public void PlaceShipToSquare((int, int) startIndex, string direction, int shipLength)
    {
        for (int shipPart = 0; shipPart < shipLength; shipPart++)
        {
            if (direction.ToLower() == "h")
                PlayerBoard[startIndex.Item1, startIndex.Item2 + shipPart].ChangeStatus(SquareStatus.Ship);
            PlayerBoard[startIndex.Item1 + shipPart, startIndex.Item2].ChangeStatus(SquareStatus.Ship);
        }
        
    }
}