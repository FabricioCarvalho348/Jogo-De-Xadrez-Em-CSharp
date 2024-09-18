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
        if (!chessMatch.MatchEnded)
        {
            Console.WriteLine($"Waiting for the {chessMatch.CurrentPlayer} piece to move ");
            if (chessMatch.xeque)
            {
                Console.WriteLine("XEQUE!");
            }
        }
        else
        {
            Console.WriteLine("XEQUE MATE!");
            Console.WriteLine("Vencedor: " + chessMatch.CurrentPlayer);
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
        Console.ForegroundColor = ConsoleColor.Black;
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
    var originBackground = Console.BackgroundColor;
    var whiteSquareBackground = ConsoleColor.Gray;
    var blackSquareBackground = ConsoleColor.DarkGray;

    // Imprime as linhas do tabuleiro
    for (int i = 0; i < currentBoard.BoardLines; i++)
    {
        Console.Write(8 - i + " "); // Número da linha

        for (int j = 0; j < currentBoard.BoardColumns; j++)
        {
            // Alterna entre quadrados brancos e pretos
            if ((i + j) % 2 == 0)
            {
                Console.BackgroundColor = whiteSquareBackground;
            }
            else
            {
                Console.BackgroundColor = blackSquareBackground;
            }

            PrintPiece(currentBoard.GetPiece(i, j));
            Console.BackgroundColor = originBackground; // Resetar cor de fundo após imprimir quadrado
        }

        Console.WriteLine();
    }

    // Linha de coordenadas
    Console.WriteLine("   a  b  c  d  e  f  g  h");
    Console.BackgroundColor = originBackground; // Resetar cor de fundo
}

public static void PrintBoard(Board currentBoard, bool[,] possiblePositions)
{
    var originBackground = Console.BackgroundColor;
    var whiteSquareBackground = ConsoleColor.Gray;
    var blackSquareBackground = ConsoleColor.DarkGray;
    var highlightBackground = ConsoleColor.Green;

    // Imprime as linhas do tabuleiro
    for (int i = 0; i < currentBoard.BoardLines; i++)
    {
        Console.Write(8 - i + " "); // Número da linha

        for (int j = 0; j < currentBoard.BoardColumns; j++)
        {
            // Alterna entre quadrados brancos e pretos
            if ((i + j) % 2 == 0)
            {
                Console.BackgroundColor = whiteSquareBackground;
            }
            else
            {
                Console.BackgroundColor = blackSquareBackground;
            }

            // Destaca casas onde o movimento é possível
            if (possiblePositions[i, j])
            {
                Console.BackgroundColor = highlightBackground;
            }

            PrintPiece(currentBoard.GetPiece(i, j));
            Console.BackgroundColor = originBackground; // Resetar cor de fundo após imprimir quadrado
        }

        Console.WriteLine();
    }

    // Linha de coordenadas
    Console.WriteLine("   a  b  c  d  e  f  g  h");
    Console.BackgroundColor = originBackground; // Resetar cor de fundo
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
            Console.Write(" - ");
        }
        else
        {
            if (piece.PieceColor == Color.White)
            {
                Console.Write(" " + piece);
            }
            else
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write(" " + piece);
                Console.ForegroundColor = aux;
            }

            Console.Write(" ");
        }
    }
}