using xadrez_console.board;
using xadrez_console.chess;

namespace xadrez_console;

public class Screen
{
    public static void PrintMatch(ChessMatch chessMatch)
    {
        PrintBoard(chessMatch.CurrentBoardChessMatch);
        Console.WriteLine();
        PrintCapturedPieces(chessMatch);
        Console.WriteLine();
        Console.WriteLine("Turn: " + chessMatch.CurrentTurn);
        Console.WriteLine($"Waiting for the {chessMatch.CurrentPlayer} piece to move ");
        if (chessMatch.xeque)
        {
            Console.WriteLine("XEQUE!");
        }
    }

    public static void PrintCapturedPieces(ChessMatch chessMatch)
    {
        Console.WriteLine("Pieces captured: ");
        Console.Write("White: ");
        PrintSetPiece(chessMatch.PiecesCaptured(Color.White));
        Console.WriteLine();
        Console.Write("Black: ");
        ConsoleColor aux = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Cyan;
        PrintSetPiece(chessMatch.PiecesCaptured(Color.Black));
        Console.ForegroundColor = aux;
        Console.WriteLine();
    }

    public static void PrintSetPiece(HashSet<Piece> setPiece)
    {
        Console.Write("[");
        foreach (var piece in setPiece)
        {
            Console.Write(piece + " ");
        }
        Console.Write("]");
    } 
    
    public static void PrintBoard(Board currentBoard)
    {
        for (int i = 0; i < currentBoard.BoardLines; i++)
        {
            Console.Write(8 - i + " ");
            for (int j = 0; j < currentBoard.BoardColumns; j++)
            {
                PrintPiece(currentBoard.GetPiece(i, j));
            }

            Console.WriteLine();
        }

        Console.WriteLine("  a b c d e f g h");
    }

    public static void PrintBoard(Board currentBoard, bool[,] possiblePositions)
    {
        var originBackground = Console.BackgroundColor;
        var backgroundChanged = ConsoleColor.Green;

        for (int i = 0; i < currentBoard.BoardLines; i++)
        {
            Console.Write(8 - i + " ");
            for (int j = 0; j < currentBoard.BoardColumns; j++)
            {
                if (possiblePositions[i, j])
                {
                    Console.BackgroundColor = backgroundChanged;
                }
                else
                {
                    Console.BackgroundColor = originBackground;
                }

                PrintPiece(currentBoard.GetPiece(i, j));
                Console.BackgroundColor = originBackground;
            }

            Console.WriteLine();
        }

        Console.WriteLine("  a b c d e f g h");
        Console.BackgroundColor = originBackground;
    }

    public static ChessPosition GetChessPosition()
    {
        string s = Console.ReadLine();
        char column = s[0];
        int line = int.Parse(s[1] + "");
        return new ChessPosition(column, line);
    }
    
    public static void PrintPiece(Piece piece)
    {
        if (piece == null)
        {
            Console.Write("- ");
        }
        else
        {
            if (piece.PieceColor == Color.White)
            {
                Console.Write(piece);
            }
            else
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(piece);
                Console.ForegroundColor = aux;
            }

            Console.Write(" ");
        }
    }
}