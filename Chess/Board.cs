namespace Chess;

public class Board {
    public bool GameContinue { get => KingsStillAlive(); }
    public Piece?[,] boardArea;
    public Board() {
        boardArea = readFile();
    }

    public Board(string filePath) {
        boardArea = readFile(filePath);
    }

    public string Player = "Red";

    public Piece?[,] readFile(string path = "../Chess.Tests/BoardCases/King.txt") {
        Piece?[,] board = new Piece?[8,8];

        string[] file = File.ReadAllLines(path);

        for (int y = 0; y < 8; y++) {
            for (int x = 0; x < 8; x++) {
                board[x, y] = file[y].Split(",")[x] switch {
                    "O" => new Pawn(x, y, "Red", board),
                    "R" => new Rook(x, y, "Red", board),
                    "K" => new Knight(x, y, "Red", board),
                    "B" => new Bishop(x, y, "Red", board),
                    "Q" => new Queen(x, y, "Red", board),
                    "W" => new King(x, y, "Red", board),

                    "o" => new Pawn(x, y, "Blue", board),
                    "r" => new Rook(x, y, "Blue", board),
                    "k" => new Knight(x, y, "Blue", board),
                    "b" => new Bishop(x, y, "Blue", board),
                    "q" => new Queen(x, y, "Blue", board),
                    "w" => new King(x, y, "Blue", board),

                    _ => null
                };
                
            }
        }

        return board;
    }

    bool KingsStillAlive() {
        int totalKings = 0;
        foreach (Piece? piece in boardArea) {
            if (piece != null) {
                if (piece.symbol == "W") {
                    totalKings++;
                }
            }
        }

        if (totalKings >= 2) {
            return true;
        }

        return false;
    }

    IEnumerable<ConsoleColor> Grid() {
        ConsoleColor[] colors = { ConsoleColor.White, ConsoleColor.Black };
    
        for (int i = 0; i < 64; i++) {
            yield return colors[(i / 8 + i) % 2];
            if (i % 8 == 7) { Console.BackgroundColor = ConsoleColor.Black; Console.WriteLine(); }
        }
    }
    
    public void Display(int? x = null, int? y = null) {
        Console.Clear();
        Console.WriteLine(" 01234567");

        int i = 0;
        foreach (ConsoleColor color in Grid()) {
            if (i % 8 == 0) {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"{i/8}");
            }
            Console.BackgroundColor = color;

            if (x != null && y != null) {
                if (i % 8 == x && i / 8 == y) {
                    Console.BackgroundColor = ConsoleColor.Magenta;
                } else if (boardArea![(int)x, (int)y]!.canMove(i % 8, i / 8)) {
                    Console.BackgroundColor = ConsoleColor.Green;

                    if (boardArea?[i % 8, i / 8] != null) {
                        Console.BackgroundColor = ConsoleColor.Yellow;
                    }
                }
            }
            
            Piece? currentPiece = boardArea?[i % 8, i / 8];
            
            if (boardArea == null) {
                Console.Write(" ");
            } else {
                if (currentPiece == null) {
                    Console.Write(" ");
                } else {
                    if (currentPiece.Color == "Red") {
                        Console.ForegroundColor = ConsoleColor.Red;
                    } else{
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }

                    Console.Write(currentPiece?.symbol);
                }
            }

            i++;
        }

        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.White;
    }

    public void SelectPiece() {
        while (0 == 0) {
            Console.WriteLine($"{Player} turn");
            Console.WriteLine("Which piece do you want to move?");

            string? response = Console.ReadLine();
                    
            if (!int.TryParse(response, out _)) {
                Console.WriteLine("Invalid Response");
            } else {
                int responseX = Convert.ToInt32(Convert.ToString(response[0]));
                int responseY = Convert.ToInt32(Convert.ToString(response[1]));

                Console.WriteLine($"{responseX} {responseY}");

                if (boardArea?[responseX, responseY] == null) {
                    Console.WriteLine("You have you select a piece");
                }

                else if (boardArea?[responseX, responseY]!.Color != Player) {
                    Console.WriteLine("You can only move your own piece");
                }
                else if (MakeMove(responseX, responseY)) {
                    return;
                }
            }

            Console.WriteLine("Press Enter to Continue");
            Console.ReadLine();

            Console.Clear();
            Display();
        }
    }
    public bool MakeMove(int x, int y) {
        Display(x, y);

        Console.WriteLine();
        Console.WriteLine("Where do you want to move?");

        string? response = Console.ReadLine();
        
        if (!int.TryParse(response, out _)) {
            Console.WriteLine("Invalid Response");
            return false;
        }
        int responseX = Convert.ToInt32(Convert.ToString(response[0]));
        int responseY = Convert.ToInt32(Convert.ToString(response[1]));

        if (boardArea[x, y]!.canMove(responseX, responseY)) {
            boardArea[responseX, responseY] = boardArea[x, y];
            boardArea[x, y] = null;
        } else {
            Console.WriteLine("You can't move there.");
            return false;
        }

        for (int i = 0; i < 8; i++) {
            if (boardArea?[i, 0] != null) {
                if (boardArea?[i, 0]!.symbol == "O") {

                    Piece queen = new Queen(i, 0, boardArea[i, 0]!.Color, boardArea);
                    boardArea[i, 0] = queen;
                }
            }
        }

        for (int i = 0; i < 8; i++) {
            if (boardArea?[i, 0] != null) {
                if (boardArea?[i, 7]!.symbol == "O") {

                    Piece queen = new Queen(i, 0, boardArea[i, 0]!.Color, boardArea);
                    boardArea[i, 7] = queen;
                }
            }
        }

        if (Player == "Red") {
            Player = "Blue";
        } else {
            Player = "Red";
        }

        return true;
    }
}