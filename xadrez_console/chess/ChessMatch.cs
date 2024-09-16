using xadrez_console.board;

namespace xadrez_console.chess;

public class ChessMatch
{
    public Board Board { get; private set; }
    private int _turn;
    private Color _currentPlayer;
    public bool Finish { get; private set; }

    public ChessMatch()
    {
        Board = new Board(8, 8);
        _turn = 1;
        _currentPlayer = Color.White;
        PlacePieces();
    }

    public void ExecuteMove(Position origin, Position destination)
    {
        Piece p = Board.RemovePiece(origin);
        p.IncrementMoveCount();
        Piece capturedPiece = Board.RemovePiece(destination);
        Board.PlacePiece(p, destination);
    }

    private void PlacePieces()
    {
        Board.PlacePiece(new Rook(Board, Color.White), new ChessPosition('c', 1).ToPosition());
        Board.PlacePiece(new Rook(Board, Color.White), new ChessPosition('c', 2).ToPosition());
        Board.PlacePiece(new Rook(Board, Color.White), new ChessPosition('d', 2).ToPosition());
        Board.PlacePiece(new Rook(Board, Color.White), new ChessPosition('e', 2).ToPosition());
        Board.PlacePiece(new Rook(Board, Color.White), new ChessPosition('e', 1).ToPosition());
        Board.PlacePiece(new King(Board, Color.White), new ChessPosition('d', 1).ToPosition());
        
        Board.PlacePiece(new Rook(Board, Color.Black), new ChessPosition('c', 7).ToPosition());
        Board.PlacePiece(new Rook(Board, Color.Black), new ChessPosition('c', 8).ToPosition());
        Board.PlacePiece(new Rook(Board, Color.Black), new ChessPosition('d', 7).ToPosition());
        Board.PlacePiece(new Rook(Board, Color.Black), new ChessPosition('e', 7).ToPosition());
        Board.PlacePiece(new Rook(Board, Color.Black), new ChessPosition('e', 8).ToPosition());
        Board.PlacePiece(new King(Board, Color.Black), new ChessPosition('d', 8).ToPosition());
    }
}