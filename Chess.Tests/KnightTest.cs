namespace Chess.Tests;

public class KnightTests
{
    Board board;

    [SetUp]
    public void Setup()
    {
        board = new Board("../../../BoardCases/Knight.txt");
    }

    [Test]
    public void CanMoveTo()
    {
        List<(int, int)> options = new List<(int, int)> {(1, 4), (1, 6), (2, 7), (4, 7), (5, 6), (5, 4), (2, 3), (4, 3)};

        foreach ((int X, int Y) space in options) {
            Assert.IsTrue(board.boardArea[3, 5]!.canMove(space.X, space.Y));
        }
    }

    [Test]
    public void CanNotMoveTo()
    {
        List<(int, int)> options = new List<(int, int)> {(1, 4), (1, 6), (2, 7), (4, 7), (5, 6), (5, 4), (2, 3), (4, 3)};

        for (int y = 0; y < 8; y++) {
            for (int x = 0; x < 8; x++) {
                if (!options.Contains((x, y))) {
                    Assert.IsFalse(board.boardArea[3, 5]!.canMove(x, y));
                }
            }
        }
    }
}