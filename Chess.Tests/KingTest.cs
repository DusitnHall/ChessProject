namespace Chess.Tests;

public class KingTests
{
    Board board;

    [SetUp]
    public void Setup()
    {
        board = new Board("../../../BoardCases/King.txt");
    }

    [Test]
    public void CanMoveTo()
    {
        List<(int, int)> options = new List<(int, int)> {(2, 5), (2, 6), (2, 7), (3, 7), (4, 7), (4, 6), (4, 5), (3, 5)};

        foreach ((int X, int Y) space in options) {
            Assert.IsTrue(board.boardArea[3, 6]!.canMove(space.X, space.Y));
        }
    }

    [Test]
    public void CanNotMoveTo()
    {
        List<(int, int)> options = new List<(int, int)> {(2, 5), (2, 6), (2, 7), (3, 7), (4, 7), (4, 6), (4, 5), (3, 5)};

        for (int y = 0; y < 8; y++) {
            for (int x = 0; x < 8; x++) {
                if (!options.Contains((x, y))) {
                    Assert.IsFalse(board.boardArea[3, 6]!.canMove(x, y));
                }
            }
        }
    }
}