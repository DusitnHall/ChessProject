namespace Chess;

public abstract class Piece {
    public string symbol = "P";

    protected int X;
    protected int Y;

    protected Piece?[,] RelativeArea;
    
    public string Color;
    protected int Direction { get => checkDirection(); }

    public Piece(int x, int y, string color, Piece?[,] area) {
        X = x;
        Y = y;
        Color = color;
        RelativeArea = area;
    }

    int checkDirection() {
        if(Color == "Blue") {
            return 1;
        } else {
            return -1;
        }
    }

    public abstract bool canMove(int x, int y);
}

