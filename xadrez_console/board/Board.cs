using xadrez_console.board.Exceptions;

namespace xadrez_console.board;

public class Board
{
    public int BoardLines { get; set; }
    public int BoardColumns { get; set; }
    private Piece[,] _boardPieces;

    public Board(int boardLines, int boardColumns)
    {
        this.BoardLines = boardLines;
        this.BoardColumns = boardColumns;
        _boardPieces = new Piece[boardLines, boardColumns];
    }

    public Piece GetPiece(int currentLines, int currentColumns)
    {
        return _boardPieces[currentLines, currentColumns];
    }

    public Piece GetPiece(Position currentPosition)
    {
        return _boardPieces[currentPosition.PositionLines, currentPosition.PositionColumns];
    }

    public bool HasPieceOnBoard(Position currentPosition)
    {
        ValidatePosition(currentPosition);
        return GetPiece(currentPosition) != null;
    }

    public void PlacePieceBoard(Piece p, Position currentPosition)
    {
        if (HasPieceOnBoard(currentPosition))
        {
            throw new BoardException("Já existe uma peça nessa posição!");
        }

        _boardPieces[currentPosition.PositionLines, currentPosition.PositionColumns] = p;
        p.CurrentPosition = currentPosition;
    }

    public Piece RemovePieceBoard(Position currentPosition)
    {
        if (GetPiece(currentPosition) == null)
        {
            return null;
        }

        Piece aux = GetPiece(currentPosition);
        aux.CurrentPosition = null;
        _boardPieces[currentPosition.PositionLines, currentPosition.PositionColumns] = null;
        return aux;
    }

    public bool IsValidPosition(Position currentPosition)
    {
        if (currentPosition.PositionLines < 0 || currentPosition.PositionLines >= BoardLines ||
            currentPosition.PositionColumns < 0 || currentPosition.PositionColumns >= BoardColumns)
        {
            return false;
        }

        return true;
    }

    public void ValidatePosition(Position pos)
    {
        if (!IsValidPosition(pos))
        {
            throw new BoardException("Invalid position!");
        }
    }
}