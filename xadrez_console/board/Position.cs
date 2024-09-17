namespace xadrez_console.board;

public class Position
{
    public int PositionLines { get; set; }
    public int PositionColumns { get; set; }

    public Position(int lines, int columns) {
        this.PositionLines = lines;
        this.PositionColumns = columns;
    }

    public void DefineValuesPosition(int lines, int columns) {
        this.PositionLines = lines;
        this.PositionColumns = columns;
    }

    public override string ToString() {
        return PositionLines
               + ", "
               + PositionColumns;
    }
}