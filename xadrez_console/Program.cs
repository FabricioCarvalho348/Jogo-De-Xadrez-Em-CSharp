using xadrez_console.board;
using xadrez_console.board.Exceptions;
using xadrez_console.chess;

namespace xadrez_console;

class Program
{
    static void Main(string[] args)
    {
        ChessPosition pos = new ChessPosition('a', 1);

        Console.WriteLine(pos);

        Console.WriteLine(pos.ToPosition());
        
        Console.ReadLine();
    }
}