namespace xadrez_console.board;

public class Board
{
    public int Lines { get; set; }
    public int Columns { get; set; }
    private Piece[,] _pieces;

    public Board(int lines, int columns)
    {
        this.Lines = lines;
        this.Columns = columns;
        _pieces = new Piece[lines,columns];
    }

    public Piece Piece(int line, int column)
    {
        return _pieces[line, column];
    }
}