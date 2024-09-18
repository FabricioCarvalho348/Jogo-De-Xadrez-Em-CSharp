using xadrez_console.board;

namespace xadrez_console.chess;

public class Pawn : Piece
{
    public Pawn(Board associateBoard, Color pieceColor) : base(associateBoard, pieceColor)
    {
    }

    public override string ToString()
    {
        return "P";
    }

    private bool OpponentExists(Position currentPosition)
    {
        Piece piece = AssociateBoard.GetPiece(currentPosition);

        return piece != null && piece.PieceColor == PieceColor;
    }

    private bool FreePosition(Position currentPosition)
    {
        return AssociateBoard.GetPiece(currentPosition) == null;
    }

    public override bool[,] MovimentPossibles()
    {
        bool[,] mat = new bool[AssociateBoard.BoardLines, AssociateBoard.BoardColumns];

        Position currentPosition = new Position(0, 0);

        if (PieceColor == Color.White)
        {
            currentPosition.DefineValuesPosition(CurrentPosition.PositionLines - 1, CurrentPosition.PositionColumns);
            if (AssociateBoard.IsValidPosition(currentPosition) && FreePosition(currentPosition))
            {
                mat[currentPosition.PositionLines, currentPosition.PositionColumns] = true;
            }

            currentPosition.DefineValuesPosition(CurrentPosition.PositionLines - 2, CurrentPosition.PositionColumns);
            Position p2 = new Position(CurrentPosition.PositionLines - 1, CurrentPosition.PositionColumns);
            if (AssociateBoard.IsValidPosition(p2) && FreePosition(p2) &&
                AssociateBoard.IsValidPosition(currentPosition) && FreePosition(currentPosition) &&
                TotalMovesPiece == 0)
            {
                mat[currentPosition.PositionLines, currentPosition.PositionColumns] = true;
            }

            currentPosition.DefineValuesPosition(CurrentPosition.PositionLines - 1,
                CurrentPosition.PositionColumns - 1);
            if (AssociateBoard.IsValidPosition(currentPosition) && OpponentExists(currentPosition))
            {
                mat[currentPosition.PositionLines, currentPosition.PositionColumns] = true;
            }

            currentPosition.DefineValuesPosition(CurrentPosition.PositionLines - 1,
                CurrentPosition.PositionColumns + 1);
            if (AssociateBoard.IsValidPosition(currentPosition) && OpponentExists(currentPosition))
            {
                mat[currentPosition.PositionLines, currentPosition.PositionColumns] = true;
            }
        }
        else
        {
            currentPosition.DefineValuesPosition(CurrentPosition.PositionLines + 1, CurrentPosition.PositionColumns);
            if (AssociateBoard.IsValidPosition(currentPosition) && FreePosition(currentPosition))
            {
                mat[currentPosition.PositionLines, currentPosition.PositionColumns] = true;
            }

            currentPosition.DefineValuesPosition(CurrentPosition.PositionLines + 2, CurrentPosition.PositionColumns);
            Position p2 = new Position(CurrentPosition.PositionLines + 1, CurrentPosition.PositionColumns);
            if (AssociateBoard.IsValidPosition(p2) && FreePosition(p2) &&
                AssociateBoard.IsValidPosition(currentPosition) && FreePosition(currentPosition) &&
                TotalMovesPiece == 0)
            {
                mat[currentPosition.PositionLines, currentPosition.PositionColumns] = true;
            }

            currentPosition.DefineValuesPosition(CurrentPosition.PositionLines + 1,
                CurrentPosition.PositionColumns - 1);
            if (AssociateBoard.IsValidPosition(currentPosition) && OpponentExists(currentPosition))
            {
                mat[currentPosition.PositionLines, currentPosition.PositionColumns] = true;
            }

            currentPosition.DefineValuesPosition(CurrentPosition.PositionLines + 1,
                CurrentPosition.PositionColumns + 1);
            if (AssociateBoard.IsValidPosition(currentPosition) && OpponentExists(currentPosition))
            {
                mat[currentPosition.PositionLines, currentPosition.PositionColumns] = true;
            }
        }

        return mat;
    }
}