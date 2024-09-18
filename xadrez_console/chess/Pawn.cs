using xadrez_console.board;

namespace xadrez_console.chess;

public class Pawn : Piece
{
    private ChessMatch _chessMatch;

    public Pawn(Board associateBoard, Color pieceColor, ChessMatch chessMatch) : base(associateBoard, pieceColor)
    {
        _chessMatch = chessMatch;
    }

    public override string ToString()
    {
        return "P";
    }

    private bool existeInimigo(Position currentPosition)
    {
        Piece currentPiece = AssociateBoard.GetPiece(currentPosition);
        return currentPiece != null && currentPiece.PieceColor != PieceColor;
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
            if (AssociateBoard.IsValidPosition(currentPosition) && existeInimigo(currentPosition))
            {
                mat[currentPosition.PositionLines, currentPosition.PositionColumns] = true;
            }

            currentPosition.DefineValuesPosition(CurrentPosition.PositionLines - 1,
                CurrentPosition.PositionColumns + 1);
            if (AssociateBoard.IsValidPosition(currentPosition) && existeInimigo(currentPosition))
            {
                mat[currentPosition.PositionLines, currentPosition.PositionColumns] = true;
            }

            // #jogadaespecial en passant
            if (CurrentPosition.PositionLines == 3)
            {
                Position esquerda = new Position(CurrentPosition.PositionLines, CurrentPosition.PositionColumns - 1);
                if (AssociateBoard.IsValidPosition(esquerda) && existeInimigo(esquerda) &&
                    AssociateBoard.GetPiece(esquerda) == _chessMatch.VulnerableEnPassant)
                {
                    mat[esquerda.PositionLines - 1, esquerda.PositionColumns] = true;
                }

                Position direita = new Position(CurrentPosition.PositionLines, CurrentPosition.PositionColumns + 1);
                if (AssociateBoard.IsValidPosition(direita) && existeInimigo(direita) &&
                    AssociateBoard.GetPiece(direita) == _chessMatch.VulnerableEnPassant)
                {
                    mat[direita.PositionLines - 1, direita.PositionColumns] = true;
                }
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
            if (AssociateBoard.IsValidPosition(currentPosition) && existeInimigo(currentPosition))
            {
                mat[currentPosition.PositionLines, currentPosition.PositionColumns] = true;
            }

            currentPosition.DefineValuesPosition(CurrentPosition.PositionLines + 1,
                CurrentPosition.PositionColumns + 1);
            if (AssociateBoard.IsValidPosition(currentPosition) && existeInimigo(currentPosition))
            {
                mat[currentPosition.PositionLines, currentPosition.PositionColumns] = true;
            }

            // #jogadaespecial en passant
            if (CurrentPosition.PositionLines == 4)
            {
                Position esquerda = new Position(CurrentPosition.PositionLines, CurrentPosition.PositionColumns - 1);
                if (AssociateBoard.IsValidPosition(esquerda) && existeInimigo(esquerda) &&
                    AssociateBoard.GetPiece(esquerda) == _chessMatch.VulnerableEnPassant)
                {
                    mat[esquerda.PositionLines + 1, esquerda.PositionColumns] = true;
                }

                Position direita = new Position(CurrentPosition.PositionLines, CurrentPosition.PositionColumns + 1);
                if (AssociateBoard.IsValidPosition(direita) && existeInimigo(direita) &&
                    AssociateBoard.GetPiece(direita) == _chessMatch.VulnerableEnPassant)
                {
                    mat[direita.PositionLines + 1, direita.PositionColumns] = true;
                }
            }
        }

        return mat;
    }
}