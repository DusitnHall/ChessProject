namespace Chess.Tests;

public class BishopTests
{
    Board board;

    [SetUp]
    public void Setup()
    {
        board = new Board("../../../BoardCases/Bishop.txt");
    }

    [Test]
    public void MoveInDirections()
    {
        Assert.IsTrue(board.boardArea[3, 6]!.canMove(4, 7));

        Assert.IsTrue(board.boardArea[3, 6]!.canMove(2, 5));

        Assert.IsTrue(board.boardArea[3, 6]!.canMove(4, 5));

        Assert.IsTrue(board.boardArea[3, 6]!.canMove(2, 7));
    }

    [Test]
    public void NoMovePastObject()
    {
        Assert.IsFalse(board.boardArea[3, 6]!.canMove(5, 4));
    }

    [Test]
    public void NoPerpendicular()
    {
        Assert.IsFalse(board.boardArea[3, 6]!.canMove(3, 5));
        Assert.IsFalse(board.boardArea[3, 6]!.canMove(2, 6));
        Assert.IsFalse(board.boardArea[3, 6]!.canMove(4, 6));
        Assert.IsFalse(board.boardArea[3, 6]!.canMove(3, 7));
    }

}