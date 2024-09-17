using xadrez_console.board;

namespace xadrez_console.chess;

public class ChessMatch
{
    public Board CurrentBoardChessMatch { get; private set; }
    private int _turn;
    private Color _currentPlayer;
    public bool matchEnded { get; private set; }

    public ChessMatch()
    {
        CurrentBoardChessMatch = new Board(8, 8);
        _turn = 1;
        _currentPlayer = Color.White;
        matchEnded = false;
        PlacesPiecesInBoard();
    }

    public void ExecuteMove(Position origem, Position destino)
    {
        Piece p = CurrentBoardChessMatch.RemovePieceBoard(origem);
        p.UpdateMoveCount();
        Piece capturedPiece = CurrentBoardChessMatch.RemovePieceBoard(destino);
        CurrentBoardChessMatch.PlacePieceBoard(p, destino);
    }

    private void PlacesPiecesInBoard()
    {
        CurrentBoardChessMatch.PlacePieceBoard(new Rook(CurrentBoardChessMatch, Color.White), new ChessPosition('c', 1).ToPositionPiece());
        CurrentBoardChessMatch.PlacePieceBoard(new Rook(CurrentBoardChessMatch, Color.White), new ChessPosition('c', 2).ToPositionPiece());
        CurrentBoardChessMatch.PlacePieceBoard(new Rook(CurrentBoardChessMatch, Color.White), new ChessPosition('d', 2).ToPositionPiece());
        CurrentBoardChessMatch.PlacePieceBoard(new Rook(CurrentBoardChessMatch, Color.White), new ChessPosition('e', 2).ToPositionPiece());
        CurrentBoardChessMatch.PlacePieceBoard(new Rook(CurrentBoardChessMatch, Color.White), new ChessPosition('e', 1).ToPositionPiece());
        CurrentBoardChessMatch.PlacePieceBoard(new King(CurrentBoardChessMatch, Color.White), new ChessPosition('d', 1).ToPositionPiece());

        CurrentBoardChessMatch.PlacePieceBoard(new Rook(CurrentBoardChessMatch, Color.Black), new ChessPosition('c', 7).ToPositionPiece());
        CurrentBoardChessMatch.PlacePieceBoard(new Rook(CurrentBoardChessMatch, Color.Black), new ChessPosition('c', 8).ToPositionPiece());
        CurrentBoardChessMatch.PlacePieceBoard(new Rook(CurrentBoardChessMatch, Color.Black), new ChessPosition('d', 7).ToPositionPiece());
        CurrentBoardChessMatch.PlacePieceBoard(new Rook(CurrentBoardChessMatch, Color.Black), new ChessPosition('e', 7).ToPositionPiece());
        CurrentBoardChessMatch.PlacePieceBoard(new Rook(CurrentBoardChessMatch, Color.Black), new ChessPosition('e', 8).ToPositionPiece());
        CurrentBoardChessMatch.PlacePieceBoard(new King(CurrentBoardChessMatch, Color.Black), new ChessPosition('d', 8).ToPositionPiece());
    }
}
