namespace xadrez_console.board;

public abstract class Piece
{
    public Position CurrentPosition { get; set; }
    public Color PieceColor { get; protected set; }
    public int TotalMovesPiece { get; protected set; }
    public Board AssociateBoard { get; protected set; }
         
    public Piece(Board associateBoard, Color pieceColor) {
        this.CurrentPosition = null;
        this.AssociateBoard = associateBoard;
        this.PieceColor = pieceColor;
        this.TotalMovesPiece = 0;
    }

    public void IncrementMoveCount() {
        TotalMovesPiece++;
    }
    
    public void DecrementMoveCount() {
        TotalMovesPiece--;
    }

    public bool ExistsMovePossibles()
    {
        bool[,] mov = MovimentPossibles();
        for (int i = 0; i < AssociateBoard.BoardLines; i++)
        {
            for (int j = 0; j < AssociateBoard.BoardColumns; j++)
            {
                if (mov[i, j])
                {
                    return true;
                }
            }
        }

        return false;
    }

    public bool CanMoveTo(Position currentPosition)
    {
        return MovimentPossibles()[currentPosition.PositionLines, currentPosition.PositionColumns];
    }

    public abstract bool[,] MovimentPossibles();
}