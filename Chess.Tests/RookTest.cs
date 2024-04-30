namespace Chess.Tests;

public class RookTests
{
    Board board;

    [SetUp]
    public void Setup()
    {
        board = new Board("../../../BoardCases/Rook.txt");
    }

    [Test]
    public void MoveInDirections()
    {
        Assert.IsTrue(board.boardArea[3, 6]!.canMove(3, 5));

        Assert.IsTrue(board.boardArea[3, 6]!.canMove(2, 6));

        Assert.IsTrue(board.boardArea[3, 6]!.canMove(4, 6));

        Assert.IsTrue(board.boardArea[3, 6]!.canMove(3, 7));
    }

    [Test]
    public void NoMovePastObject()
    {
        Assert.IsFalse(board.boardArea[3, 6]!.canMove(3, 3));
    }

    [Test]
    public void NoDiagonal()
    {
        Assert.IsFalse(board.boardArea[3, 6]!.canMove(4, 5));
        Assert.IsFalse(board.boardArea[3, 6]!.canMove(2, 5));
    }

}