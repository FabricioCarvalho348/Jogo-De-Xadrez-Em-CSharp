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
        Piece positionBishop = AssociateBoard.GetPiece(currentPosition);
        return positionBishop == null || positionBishop.PieceColor != PieceColor;
    }

    public override bool[,] MovimentPossibles()
    {
        bool[,] mat = new bool[AssociateBoard.BoardLines, AssociateBoard.BoardColumns];

        Position currentPosition = new Position(0, 0);

        // NO
        currentPosition.DefineValuesPosition(CurrentPosition.PositionLines - 1, CurrentPosition.PositionColumns - 1);
        while (AssociateBoard.IsValidPosition(currentPosition) && IsValidMove(currentPosition))
        {
            mat[currentPosition.PositionLines, currentPosition.PositionColumns] = true;
            if (AssociateBoard.GetPiece(currentPosition) != null &&
                AssociateBoard.GetPiece(currentPosition).PieceColor != PieceColor)
            {
                break;
            }

            currentPosition.DefineValuesPosition(currentPosition.PositionLines - 1,
                currentPosition.PositionColumns - 1);
        }

        // NE
        currentPosition.DefineValuesPosition(CurrentPosition.PositionLines - 1, CurrentPosition.PositionColumns + 1);
        while (AssociateBoard.IsValidPosition(currentPosition) && IsValidMove(currentPosition))
        {
            mat[currentPosition.PositionLines, currentPosition.PositionColumns] = true;
            if (AssociateBoard.GetPiece(currentPosition) != null &&
                AssociateBoard.GetPiece(currentPosition).PieceColor != PieceColor)
            {
                break;
            }

            currentPosition.DefineValuesPosition(currentPosition.PositionLines - 1,
                currentPosition.PositionColumns + 1);
        }

        // SE
        currentPosition.DefineValuesPosition(CurrentPosition.PositionLines + 1, CurrentPosition.PositionColumns + 1);
        while (AssociateBoard.IsValidPosition(currentPosition) && IsValidMove(currentPosition))
        {
            mat[currentPosition.PositionLines, currentPosition.PositionColumns] = true;
            if (AssociateBoard.GetPiece(currentPosition) != null &&
                AssociateBoard.GetPiece(currentPosition).PieceColor != PieceColor)
            {
                break;
            }

            currentPosition.DefineValuesPosition(currentPosition.PositionLines + 1,
                currentPosition.PositionColumns + 1);
        }

        // SO
        currentPosition.DefineValuesPosition(CurrentPosition.PositionLines + 1, CurrentPosition.PositionColumns - 1);
        while (AssociateBoard.IsValidPosition(currentPosition) && IsValidMove(currentPosition))
        {
            mat[currentPosition.PositionLines, currentPosition.PositionColumns] = true;
            if (AssociateBoard.GetPiece(currentPosition) != null &&
                AssociateBoard.GetPiece(currentPosition).PieceColor != PieceColor)
            {
                break;
            }

            currentPosition.DefineValuesPosition(currentPosition.PositionLines + 1,
                currentPosition.PositionColumns - 1);
        }

        return mat;
    }
}