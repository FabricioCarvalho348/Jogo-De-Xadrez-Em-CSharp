using xadrez_console.board;
using xadrez_console.chess;

namespace xadrez_console;

class Program
{
    static void Main(string[] args)
    {
        Board board = new Board(8, 8);
        
        board.PlacePiece(new Rook(board, Color.Black) , new Position(0, 0));
        board.PlacePiece(new Rook(board, Color.Black) , new Position(1, 3));
        board.PlacePiece(new King(board, Color.Black) , new Position(2, 4));
        
        Screen.PrintBoard(board);

        Console.ReadLine();
    }
}