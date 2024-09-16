using xadrez_console.board.Exceptions;

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

    public Piece Piece(Position pos)
    {
        return _pieces[pos.Line, pos.Column];
    }

    public bool PieceExists(Position pos)
    {
        ValidatePosition(pos);
        return Piece(pos) != null;
    }
    
    public void PlacePiece(Piece p, Position pos)
    {
        if (PieceExists(pos))
        {
            throw new BoardException("There is already a piece in this position!");
        }
        _pieces[pos.Line, pos.Column] = p;
        p.Position = pos;
    }

    public bool ValidPosition(Position pos)
    {
        return pos.Line >= 0 && pos.Line < Lines && pos.Column >= 0 && pos.Column < Columns;
    }

    public void ValidatePosition(Position pos)
    {
        if (!ValidPosition(pos))
        {
            throw new BoardException("Invalid position!");
        }
    }
}