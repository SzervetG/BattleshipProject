namespace Battleship;

public class Square
{
    public SquareStatus Status { get; private set; }

    public Square()
    {
        Status = SquareStatus.Ocean;
    }


    public void ChangeStatus(SquareStatus status)
    {
        this.Status = status;
    }
}