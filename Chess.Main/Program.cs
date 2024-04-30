using Chess;

Board board = new Board();

do {
    board.Display();

    board.SelectPiece();
} while(board.GameContinue);

if (board.Player == "Red") {
    board.Player = "Blue";
} else {
    board.Player = "Red";
}

board.Display();

Console.WriteLine($"{board.Player} wins!");