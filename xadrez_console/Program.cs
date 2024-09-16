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

            while (!chessMatch.Finish)
            {
                Console.Clear();
                Screen.PrintBoard(chessMatch.Board);

                Console.WriteLine();
                Console.Write("Enter the source position: ");
                Position origin = Screen.GetChessPosition().ToPosition();
                Console.Write("Enter the destination position: ");
                Position destination = Screen.GetChessPosition().ToPosition();
                
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