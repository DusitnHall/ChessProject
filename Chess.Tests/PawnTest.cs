namespace Chess.Tests;

public class PawnTests
{
    Board board;

    [SetUp]
    public void Setup()
    {
        board = new Board("../../../BoardCases/Pawn.txt");
    }

    [Test]
    public void MoveOneOrTwo()
    {
        Assert.IsTrue(board.boardArea[3, 6]!.canMove(3, 5));
        Assert.IsTrue(board.boardArea[3, 6]!.canMove(3, 4));
    }

    [Test]
    public void NoMoveBack()
    {
        Assert.IsTrue(!board.boardArea[3, 6]!.canMove(3, 7));
    }

    [Test]
    public void Diagonal()
    {
        Assert.IsTrue(board.boardArea[3, 6]!.canMove(4, 5));
        Assert.IsFalse(board.boardArea[3, 6]!.canMove(2, 5));
    }

}