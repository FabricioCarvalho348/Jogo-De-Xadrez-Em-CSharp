using xadrez_console.board;

namespace xadrez_console.chess;

public class King : Piece
{
    public King(Board associateBoard, Color colorPiece) : base(associateBoard, colorPiece)
    {
    }

    public override string ToString()
    {
        return "K";
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

        // acima
        currentPosition.DefineValuesPosition(CurrentPosition.PositionLines - 1, CurrentPosition.PositionColumns);
        if (AssociateBoard.IsValidPosition(currentPosition) && IsValidMove(currentPosition))
        {
            mat[currentPosition.PositionLines, currentPosition.PositionColumns] = true;
        }

        // ne
        currentPosition.DefineValuesPosition(CurrentPosition.PositionLines - 1, CurrentPosition.PositionColumns + 1);
        if (AssociateBoard.IsValidPosition(currentPosition) && IsValidMove(currentPosition))
        {
            mat[currentPosition.PositionLines, currentPosition.PositionColumns] = true;
        }

        // direita
        currentPosition.DefineValuesPosition(CurrentPosition.PositionLines, CurrentPosition.PositionColumns + 1);
        if (AssociateBoard.IsValidPosition(currentPosition) && IsValidMove(currentPosition))
        {
            mat[currentPosition.PositionLines, currentPosition.PositionColumns] = true;
        }

        // se
        currentPosition.DefineValuesPosition(CurrentPosition.PositionLines + 1, CurrentPosition.PositionColumns + 1);
        if (AssociateBoard.IsValidPosition(currentPosition) && IsValidMove(currentPosition))
        {
            mat[currentPosition.PositionLines, currentPosition.PositionColumns] = true;
        }

        // abaixo
        currentPosition.DefineValuesPosition(CurrentPosition.PositionLines + 1, CurrentPosition.PositionColumns);
        if (AssociateBoard.IsValidPosition(currentPosition) && IsValidMove(currentPosition))
        {
            mat[currentPosition.PositionLines, currentPosition.PositionColumns] = true;
        }

        // so
        currentPosition.DefineValuesPosition(CurrentPosition.PositionLines + 1, CurrentPosition.PositionColumns - 1);
        if (AssociateBoard.IsValidPosition(currentPosition) && IsValidMove(currentPosition))
        {
            mat[currentPosition.PositionLines, currentPosition.PositionColumns] = true;
        }

        // esquerda
        currentPosition.DefineValuesPosition(CurrentPosition.PositionLines, CurrentPosition.PositionColumns - 1);
        if (AssociateBoard.IsValidPosition(currentPosition) && IsValidMove(currentPosition))
        {
            mat[currentPosition.PositionLines, currentPosition.PositionColumns] = true;
        }

        // no
        currentPosition.DefineValuesPosition(CurrentPosition.PositionLines - 1, CurrentPosition.PositionColumns - 1);
        if (AssociateBoard.IsValidPosition(currentPosition) && IsValidMove(currentPosition))
        {
            mat[currentPosition.PositionLines, currentPosition.PositionColumns] = true;
        }

        return mat;
    }
}