using xadrez_console.board;

namespace xadrez_console.chess;

public class Bishop : Piece
{
    public Bishop(Board associateBoard, Color pieceColor) : base(associateBoard, pieceColor)
    {
    }

    public override string ToString()
    {
        return "B";
    }
    
    private bool IsValidMove(Position currentPosition)
    {
        Piece currentPiece = AssociateBoard.GetPiece(currentPosition);
        return currentPiece == null || currentPiece.PieceColor != PieceColor;
    }

    public override bool[,] MovimentPossibles()
    {
        bool[,] mat = new bool[AssociateBoard.BoardLines, AssociateBoard.BoardColumns];

        Position currentPosition = new Position(0, 0);
        
        // Noroeste
        currentPosition.DefineValuesPosition(currentPosition.PositionLines - 1, currentPosition.PositionColumns - 1);
        while (AssociateBoard.IsValidPosition(currentPosition) && IsValidMove(currentPosition))
        {
            mat[currentPosition.PositionLines, currentPosition.PositionColumns] = true;
            if (AssociateBoard.GetPiece(currentPosition) != null && AssociateBoard.GetPiece(currentPosition).PieceColor != PieceColor)
            {
                break;
            }
            currentPosition.DefineValuesPosition(currentPosition.PositionLines - 1, currentPosition.PositionColumns - 1);
        }
        
        // Nordeste
        currentPosition.DefineValuesPosition(currentPosition.PositionLines - 1, currentPosition.PositionColumns + 1);
        while (AssociateBoard.IsValidPosition(currentPosition) && IsValidMove(currentPosition))
        {
            mat[currentPosition.PositionLines, currentPosition.PositionColumns] = true;
            if (AssociateBoard.GetPiece(currentPosition) != null && AssociateBoard.GetPiece(currentPosition).PieceColor != PieceColor)
            {
                break;
            }
            currentPosition.DefineValuesPosition(currentPosition.PositionLines - 1, currentPosition.PositionColumns + 1);
        }
        
        // Sudeste
        currentPosition.DefineValuesPosition(currentPosition.PositionLines + 1, currentPosition.PositionColumns + 1);
        while (AssociateBoard.IsValidPosition(currentPosition) && IsValidMove(currentPosition))
        {
            mat[currentPosition.PositionLines, currentPosition.PositionColumns] = true;
            if (AssociateBoard.GetPiece(currentPosition) != null && AssociateBoard.GetPiece(currentPosition).PieceColor != PieceColor)
            {
                break;
            }
            currentPosition.DefineValuesPosition(currentPosition.PositionLines + 1, currentPosition.PositionColumns + 1);
        }
       
        // Sudoeste
        currentPosition.DefineValuesPosition(currentPosition.PositionLines + 1, currentPosition.PositionColumns - 1);
        while (AssociateBoard.IsValidPosition(currentPosition) && IsValidMove(currentPosition))
        {
            mat[currentPosition.PositionLines, currentPosition.PositionColumns] = true;
            if (AssociateBoard.GetPiece(currentPosition) != null && AssociateBoard.GetPiece(currentPosition).PieceColor != PieceColor)
            {
                break;
            }
            currentPosition.DefineValuesPosition(currentPosition.PositionLines + 1, currentPosition.PositionColumns - 1);
        }

        return mat;
    }
}