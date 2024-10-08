﻿using xadrez_console.board;

namespace xadrez_console.chess;

public class Queen : Piece
{
    public Queen(Board associateBoard, Color pieceColor) : base(associateBoard, pieceColor)
    {
    }

    public override string ToString()
    {
        return "Q";
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


        // direita
        currentPosition.DefineValuesPosition(CurrentPosition.PositionLines, CurrentPosition.PositionColumns + 1);
        while (AssociateBoard.IsValidPosition(currentPosition) && IsValidMove(currentPosition))
        {
            mat[currentPosition.PositionLines, currentPosition.PositionColumns] = true;
            if (AssociateBoard.GetPiece(currentPosition) != null &&
                AssociateBoard.GetPiece(currentPosition).PieceColor != PieceColor)
            {
                break;
            }

            currentPosition.PositionColumns = currentPosition.PositionColumns + 1;
        }

        // esquerda
        currentPosition.DefineValuesPosition(CurrentPosition.PositionLines, CurrentPosition.PositionColumns - 1);
        while (AssociateBoard.IsValidPosition(currentPosition) && IsValidMove(currentPosition))
        {
            mat[currentPosition.PositionLines, currentPosition.PositionColumns] = true;
            if (AssociateBoard.GetPiece(currentPosition) != null &&
                AssociateBoard.GetPiece(currentPosition).PieceColor != PieceColor)
            {
                break;
            }

            currentPosition.PositionColumns = currentPosition.PositionColumns - 1;
        }

        // acima
        currentPosition.DefineValuesPosition(CurrentPosition.PositionLines - 1, CurrentPosition.PositionColumns);
        while (AssociateBoard.IsValidPosition(currentPosition) && IsValidMove(currentPosition))
        {
            mat[currentPosition.PositionLines, currentPosition.PositionColumns] = true;
            if (AssociateBoard.GetPiece(currentPosition) != null &&
                AssociateBoard.GetPiece(currentPosition).PieceColor != PieceColor)
            {
                break;
            }

            currentPosition.PositionLines = currentPosition.PositionLines - 1;
        }

        // abaixo
        currentPosition.DefineValuesPosition(CurrentPosition.PositionLines + 1, CurrentPosition.PositionColumns);
        while (AssociateBoard.IsValidPosition(currentPosition) && IsValidMove(currentPosition))
        {
            mat[currentPosition.PositionLines, currentPosition.PositionColumns] = true;
            if (AssociateBoard.GetPiece(currentPosition) != null &&
                AssociateBoard.GetPiece(currentPosition).PieceColor != PieceColor)
            {
                break;
            }

            currentPosition.PositionLines = currentPosition.PositionLines + 1;
        }

        // Noroeste
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

        // Nordeste
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

        // Sudeste
        currentPosition.DefineValuesPosition(CurrentPosition.PositionLines + 1, CurrentPosition.PositionColumns + 1);
        while (AssociateBoard.IsValidPosition(currentPosition) && IsValidMove(currentPosition))
        {
            mat[currentPosition.PositionLines, currentPosition.PositionColumns] = true;
            if (AssociateBoard.GetPiece(currentPosition) != null &&
                AssociateBoard.GetPiece(currentPosition).PieceColor != PieceColor)
            {
                break;
            }

            currentPosition.DefineValuesPosition(CurrentPosition.PositionLines + 1,
                CurrentPosition.PositionColumns + 1);
        }

        // Sudoeste
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