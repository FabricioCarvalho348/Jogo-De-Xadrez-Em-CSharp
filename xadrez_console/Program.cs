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

            while (!chessMatch.MatchEnded)
            {
                try
                {
                    Console.Clear();
                    Screen.PrintMatch(chessMatch);

                    Console.WriteLine();
                    Console.Write("Enter the piece you want to move: ");
                    Position origin = Screen.GetChessPosition().ToPositionPiece();
                    chessMatch.ValidatePositionOrigin(origin);

                    bool[,] possiblePositions = chessMatch.CurrentBoardChessMatch.GetPiece(origin).MovimentPossibles();

                    Console.Clear();
                    Screen.PrintBoard(chessMatch.CurrentBoardChessMatch, possiblePositions);

                    Console.WriteLine();
                    Console.Write("Enter the destination position of this piece: ");
                    Position destination = Screen.GetChessPosition().ToPositionPiece();
                    chessMatch.ValidatePositionDestination(origin, destination);

                    chessMatch.MakePlay(origin, destination);
                }
                catch (BoardException e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadLine();
                }
            }
            Console.Clear();
            Screen.PrintMatch(chessMatch);
        }
        catch (BoardException e)
        {
            Console.WriteLine(e.Message);
        }

        Console.ReadLine();
    }
}