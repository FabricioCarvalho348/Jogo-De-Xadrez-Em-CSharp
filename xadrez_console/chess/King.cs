using xadrez_console.board;

namespace xadrez_console.chess;

public class King : Piece
{
    private ChessMatch _chessMatch;

    public King(Board associateBoard, Color colorPiece, ChessMatch chessMatch) : base(associateBoard, colorPiece)
    {
        this._chessMatch = chessMatch;
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

    private bool TestRookForRoque(Position currentPosition)
    {
        Piece currentPiece = AssociateBoard.GetPiece(currentPosition);
        return currentPiece != null && currentPiece is Rook && currentPiece.PieceColor == PieceColor &&
               TotalMovesPiece == 0;
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

        // #specialplay roque
        if (TotalMovesPiece == 0 && !_chessMatch.Xeque)
        {
            // #specialplay roque pequeno
            Position positionTowerOne =
                new Position(CurrentPosition.PositionLines, CurrentPosition.PositionColumns + 3);
            if (TestRookForRoque(positionTowerOne))
            {
                Position p1 = new Position(CurrentPosition.PositionLines, CurrentPosition.PositionColumns + 1);
                Position p2 = new Position(CurrentPosition.PositionLines, CurrentPosition.PositionColumns + 2);
                if (AssociateBoard.GetPiece(p1) == null && AssociateBoard.GetPiece(p2) == null)
                {
                    mat[CurrentPosition.PositionLines, CurrentPosition.PositionColumns + 2] = true;
                }
            }
            // #specialplay roque grande
            Position positionTowerTwo =
                new Position(CurrentPosition.PositionLines, CurrentPosition.PositionColumns - 4);
            if (TestRookForRoque(positionTowerTwo))
            {
                Position p1 = new Position(CurrentPosition.PositionLines, CurrentPosition.PositionColumns - 1);
                Position p2 = new Position(CurrentPosition.PositionLines, CurrentPosition.PositionColumns - 2);
                Position p3 = new Position(CurrentPosition.PositionLines, CurrentPosition.PositionColumns - 3);
                if (AssociateBoard.GetPiece(p1) == null && AssociateBoard.GetPiece(p2) == null &&
                    AssociateBoard.GetPiece(p3) == null)
                {
                    mat[CurrentPosition.PositionLines, CurrentPosition.PositionColumns - 2] = true;
                }
            }
        }

        return mat;
    }
}