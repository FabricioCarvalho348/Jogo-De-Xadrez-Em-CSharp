namespace xadrez_console.board;

public class Piece
{
    public Position position { get; set; }
    public Color color { get; set; }
    public int moveCount { get; protected set; }
    public Board board { get; protected set; }

    public Piece(Position position, Board board, Color color)
    {
        this.position = position;
        this.board = board;
        this.color = color;
        moveCount = 0;
    }
}