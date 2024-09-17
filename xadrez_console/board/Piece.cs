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

    public void UpdateMoveCount() {
        TotalMovesPiece++;
    }

    public abstract bool[,] MovimentPossibles();
}