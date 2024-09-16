namespace xadrez_console.board;

public class Piece
{
    public Position Position { get; set; }
    public Color Color { get; set; }
    public int MoveCount { get; protected set; }
    public Board Board { get; protected set; }

    public Piece(Position position, Board board, Color color)
    {
        Position = position;
        Board = board;
        Color = color;
        MoveCount = 0;
    }
}