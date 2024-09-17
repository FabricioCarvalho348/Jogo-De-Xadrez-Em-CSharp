using xadrez_console.board;

namespace xadrez_console.chess;

public class ChessPosition
{
    public char ChessColumn { get; set; }
    public int ChessLine { get; set; }

    public ChessPosition(char chessColumn, int chessLine)
    {
        this.ChessColumn = chessColumn;
        this.ChessLine = chessLine;
    }

    public Position ToPositionPiece()
    {
        return new Position(8 - ChessLine, ChessColumn - 'a');
    }

    public override string ToString()
    {
        return "" + ChessColumn + ChessLine;
    }
}