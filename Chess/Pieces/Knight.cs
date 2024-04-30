namespace Chess;

public class Knight : Piece {
    public Knight(int x, int y, string color, Piece?[,] area) : base(x, y, color, area)
    {
        symbol = "K";
    }

    public override bool canMove(int x, int y) {
        if (x >= 0 && y >= 0 && x < 8 && y < 8) {
            if (RelativeArea?[x, y]?.Color != Color) {
                if ((X + 1 == x || X - 1 == x) && (Y + 2 == y || Y - 2 == y)) {
                    return true;
                } else if ((Y + 1 == y || Y - 1 == y) && (X + 2 == x || X - 2 == x)) {
                    return true;
                }
            }
        }
        return false;
    }
}