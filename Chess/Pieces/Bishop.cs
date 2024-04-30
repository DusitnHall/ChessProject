namespace Chess;

public class Bishop : Piece {
    public Bishop(int x, int y, string color, Piece?[,] area) : base(x, y, color, area)
    {
        symbol = "B";
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

        }
        return false;
    }
}