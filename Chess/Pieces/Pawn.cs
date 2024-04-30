namespace Chess;

public class Pawn : Piece {
    public Pawn(int x, int y, string color, Piece?[,] area) : base(x, y, color, area)
    {
        symbol = "O";
    }

    public override bool canMove(int x, int y) {
        
        if (x >= 0 && y >= 0 && x < 8 && y < 8) {
            if (Y + Direction == y && x == X && RelativeArea?[x, y] == null) {
                return true;
            } else if (Y + Direction * 2 == y && X == x && (Y == 1 || Y == 6) && RelativeArea?[x, y] == null) {
                return true;
            } else if (Y + Direction == y && RelativeArea?[x, y] != null && (X + 1 == x || X - 1 == x)) {
                if (RelativeArea?[x, y]?.Color != Color) {
                    return true;
                }
            }
        }
        return false;
    }
}