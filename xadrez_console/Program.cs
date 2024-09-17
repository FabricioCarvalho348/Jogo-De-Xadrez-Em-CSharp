using xadrez_console.board;
using xadrez_console.board.Exceptions;
using xadrez_console.chess;

namespace xadrez_console;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            ChessMatch chessMatch = new ChessMatch();

            while (!chessMatch.matchEnded)
            {
                Console.Clear();
                Screen.PrintBoard(chessMatch.CurrentBoardChessMatch);

                Console.WriteLine();
                Console.Write("Enter the piece you want to move: ");
                Position origin = Screen.GetChessPosition().ToPositionPiece();

                bool[,] possiblePositions = chessMatch.CurrentBoardChessMatch.GetPiece(origin).MovimentPossibles();

                Console.Clear();
                Screen.PrintBoard(chessMatch.CurrentBoardChessMatch, possiblePositions);

                Console.WriteLine();
                Console.Write("Enter the destination position of this piece: ");
                Position destination = Screen.GetChessPosition().ToPositionPiece();

                chessMatch.ExecuteMove(origin, destination);
            }
        }
        catch (BoardException e)
        {
            Console.WriteLine(e.Message);
        }

        Console.ReadLine();
    }
}