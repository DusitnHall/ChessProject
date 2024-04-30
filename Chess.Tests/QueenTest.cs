namespace Chess.Tests;

public class QueenTests
{
    Board board;

    [SetUp]
    public void Setup()
    {
        board = new Board("../../../BoardCases/Queen.txt");
    }

    [Test]
    public void NoMovePastObject()
    {
        Assert.IsFalse(board.boardArea[3, 6]!.canMove(5, 4));
        Assert.IsFalse(board.boardArea[3, 6]!.canMove(3, 3));
    }

    [Test]
    public void Perpendicular()
    {
        Assert.IsTrue(board.boardArea[3, 6]!.canMove(3, 5));
        Assert.IsTrue(board.boardArea[3, 6]!.canMove(2, 6));
        Assert.IsTrue(board.boardArea[3, 6]!.canMove(4, 6));
        Assert.IsTrue(board.boardArea[3, 6]!.canMove(3, 7));
    }

    [Test]
    public void Diagonal()
    {
        Assert.IsTrue(board.boardArea[3, 6]!.canMove(4, 5));
        Assert.IsTrue(board.boardArea[3, 6]!.canMove(2, 5));
    }
}