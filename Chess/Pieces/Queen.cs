namespace Chess;

public class Queen : Piece {
    public Queen(int x, int y, string color, Piece?[,] area) : base(x, y, color, area)
    {
        symbol = "Q";
    }

    public override bool canMove(int x, int y) {
        if (x >= 0 && y >= 0 && x < 8 && y < 8) {
            if (RelativeArea?[x, y]?.Color == Color) {
                return false;
            }

            if (Math.Abs(Y - y) == Math.Abs(X - x)) {
                int changeY = (Y - y < 0) ? -1 : 1;
                int changeX = (X - x < 0) ? -1 : 1;

                for (int i = x, j = y; (i - X) != 0; i += changeX, j += changeY) {
                    if (RelativeArea?[i, j] != null && (i, j) != (x, y)) {
                        return false;
                    }
                }

                return true;
            }

            if (X == x) {
                int change = (Y - y < 0) ? -1 : 1;

                for (int i = y; (i - Y) != 0; i += change) {
                    if (RelativeArea?[X, i] != null && (X, i) != (x, y)) {
                        return false;
                    }
                }

                return true;
            }
            if (Y == y) {
                int change = (X - x < 0) ? -1 : 1;
                
                for (int i = x; (i - X) != 0; i += change) {
                    if (RelativeArea?[i, Y] != null && (i, Y) != (x, y)) {
                        return false;
                    }
                }
                return true;
            }
        }
        return false;
    }
}