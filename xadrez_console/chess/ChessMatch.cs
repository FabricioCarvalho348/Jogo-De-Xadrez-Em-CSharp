using xadrez_console.board;
using xadrez_console.board.Exceptions;

namespace xadrez_console.chess;

public class ChessMatch
{
    public Board CurrentBoardChessMatch { get; private set; }
    public int CurrentTurn { get; private set; }
    public Color CurrentPlayer { get; private set; }
    public bool MatchEnded { get; private set; }
    private HashSet<Piece> _matchPieces = new HashSet<Piece>();
    private HashSet<Piece> _capturedPieces = new HashSet<Piece>();
    public bool xeque { get; private set; }

    public ChessMatch()
    {
        CurrentBoardChessMatch = new Board(8, 8);
        CurrentTurn = 1;
        CurrentPlayer = Color.White;
        MatchEnded = false;
        xeque = false;
        _matchPieces = new HashSet<Piece>();
        _capturedPieces = new HashSet<Piece>();
        PlacesPiecesInBoard();
    }

    public Piece ExecuteMove(Position origin, Position destination)
    {
        Piece currentPiece = CurrentBoardChessMatch.RemovePieceBoard(origin);
        currentPiece.IncrementMoveCount();
        Piece capturedPiece = CurrentBoardChessMatch.RemovePieceBoard(destination);
        CurrentBoardChessMatch.PlacePieceBoard(currentPiece, destination);
        if (capturedPiece != null)
        {
            _capturedPieces.Add(capturedPiece);
        }

        return capturedPiece;
    }

    public void UndoMove(Position origin, Position destination, Piece capturedPiece)
    {
        Piece currentPiece = CurrentBoardChessMatch.RemovePieceBoard(destination);
        currentPiece.DecrementMoveCount();
        if (capturedPiece != null)
        {
            CurrentBoardChessMatch.PlacePieceBoard(capturedPiece, destination);
            _capturedPieces.Remove(capturedPiece);
        }
        CurrentBoardChessMatch.PlacePieceBoard(currentPiece, origin);
    }

    public void MakePlay(Position origin, Position destination)
    {
        Piece capturedPiece = ExecuteMove(origin, destination);
        
        if(IsInCheck(CurrentPlayer))
        {
            UndoMove(origin, destination, capturedPiece);
            throw new BoardException("You can't put yourself in check!");
        }

        if (IsInCheck(Opponent(CurrentPlayer)))
        {
            xeque = true;
        }
        else
        {
            xeque = false;
        }
        
        CurrentTurn++;
        SwitchPlayer();
    }

    public void ValidatePositionOrigin(Position currentPosition)
    {
        if (CurrentBoardChessMatch.GetPiece(currentPosition) == null)
        {
            throw new BoardException("there is no piece in the original position chosen!");
        }

        if (CurrentPlayer != CurrentBoardChessMatch.GetPiece(currentPosition).PieceColor)
        {
            throw new BoardException("the chosen source piece is not yours!");
        }

        if (!CurrentBoardChessMatch.GetPiece(currentPosition).ExistsMovePossibles())
        {
            throw new BoardException("There are no possible movements for the chosen source piece!");
        }
    }

    public void ValidatePositionDestination(Position origin, Position destination)
    {
        if (!CurrentBoardChessMatch.GetPiece(origin).CanMoveTo(destination))
        {
            throw new BoardException("Destination position invalid!");
        }
    }

    private void SwitchPlayer()
    {
        if (CurrentPlayer == Color.White)
        {
            CurrentPlayer = Color.Black;
        }
        else
        {
            CurrentPlayer = Color.White;
        }
    }

    public HashSet<Piece> PiecesCaptured(Color color)
    {
        HashSet<Piece> aux = new HashSet<Piece>();
        foreach (var pieces in _capturedPieces)
        {
            if (pieces.PieceColor == color)
            {
                aux.Add(pieces);
            }
        }

        return aux;
    }

    public HashSet<Piece> PiecesInMatch(Color color)
    {
        HashSet<Piece> aux = new HashSet<Piece>();
        foreach (var matchPiece in _matchPieces)
        {
            if (matchPiece.PieceColor == color)
            {
                aux.Add(matchPiece);
            }
        }
        aux.ExceptWith(PiecesCaptured(color));
        return aux;
    }

    private Color Opponent(Color color)
    {
        if (color == Color.White) 
        {
            return Color.Black;
        }
        else
        {
            return Color.White;
        }
    }

    private Piece KingSomeColor(Color color)
    {
        foreach (var piece in PiecesInMatch(color))
        {
            if (piece is King)
            {
                return piece;
            }
        }
        return null;
    }

    public bool IsInCheck(Color color)
    {
        Piece king = KingSomeColor(color);
        if (king == null)
        {
            throw new BoardException("King not found!");
        }

        foreach (var piece in PiecesInMatch(Opponent(color)))
        {
            bool[,] mat = piece.MovimentPossibles();
            if (mat[king.CurrentPosition.PositionLines, king.CurrentPosition.PositionColumns])
            {
                return true;
            }
        }

        return false;
    }
    

    public void PlaceNewPiece(char column, int line, Piece piece)
    {
        CurrentBoardChessMatch.PlacePieceBoard(piece, new ChessPosition(column, line).ToPositionPiece());
        _matchPieces.Add(piece);
    }

    private void PlacesPiecesInBoard()
    {
        PlaceNewPiece('c', 1, new Rook(CurrentBoardChessMatch, Color.White));
        PlaceNewPiece('c', 2, new Rook(CurrentBoardChessMatch, Color.White));
        PlaceNewPiece('d', 2, new Rook(CurrentBoardChessMatch, Color.White));
        PlaceNewPiece('e', 2, new Rook(CurrentBoardChessMatch, Color.White));
        PlaceNewPiece('e', 1, new Rook(CurrentBoardChessMatch, Color.White));
        PlaceNewPiece('d', 1, new King(CurrentBoardChessMatch, Color.White));

        PlaceNewPiece('c', 7, new Rook(CurrentBoardChessMatch, Color.Black));
        PlaceNewPiece('c', 8, new Rook(CurrentBoardChessMatch, Color.Black));
        PlaceNewPiece('d', 7, new Rook(CurrentBoardChessMatch, Color.Black));
        PlaceNewPiece('e', 7, new Rook(CurrentBoardChessMatch, Color.Black));
        PlaceNewPiece('e', 8, new Rook(CurrentBoardChessMatch, Color.Black));
        PlaceNewPiece('d', 8, new King(CurrentBoardChessMatch, Color.Black));
    }
}