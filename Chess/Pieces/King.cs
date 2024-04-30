namespace Chess;

public class King : Piece {
    public King(int x, int y, string color, Piece?[,] area) : base(x, y, color, area)
    {
        symbol = "W";
    }

    public override bool canMove(int x, int y) {
        if (x >= 0 && y >= 0 && x < 8 && y < 8) {
            if (Math.Abs(X - x) <= 1 && Math.Abs(Y - y) <= 1) {
                if (RelativeArea?[x, y] != null) {
                    if (RelativeArea[x, y]!.Color != Color) {
                        return true;
                    }
                } else {
                    return true;
                }
            }
        }
        
        return false;
    }
}