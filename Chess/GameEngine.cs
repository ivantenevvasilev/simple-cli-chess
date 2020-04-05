using System;
using System.Text;
using Chess.Exceptions;

namespace Chess
{
    public class GameEngine
    {
        public const int CellWidth = 3;
        public const char Wall = '#';
        public const char Seperator = ' ';

        private Board board;

        public bool IsWhite { get; private set; }

        public bool IsBlack
        {
            get { return !this.IsWhite; }
        }

        public string Player
        {
            get
            {
                if (this.IsBlack)
                {
                    return "Black";
                }
                else
                {
                    return "White";
                }
            }
        }

        public GameEngine(int boardSize = 8)
        {
            this.board = new Board(boardSize);
        }

        public void Run()
        {
            while (true)
            {
                Console.Clear();

                this.PrintBoard();

                Console.Write("Waiting for Player {0}'s move: ", this.Player);
                string positionFrom = Console.ReadLine();
                positionFrom = positionFrom?.ToLower();
                Console.Write("Move {0} to: ", positionFrom);
                string positionTo = Console.ReadLine();
                positionTo = positionTo?.ToLower();

                try
                {
                    Position origin = this.getPositionFromString(positionFrom);
                    if (!this.board.IsOwnedBy(origin.x, origin.y, this.IsWhite))
                    {
                        throw new IllegalPositionException();
                    }
                    Position destination = this.getPositionFromString(positionTo);
                    if (this.board.Move(origin, destination))
                    {
                        this.IsWhite = !this.IsWhite;
                    }
                    else
                    {
                        throw new IllegalPositionException();
                    }

                }
                catch (IllegalPositionException e)
                {
                    Console.WriteLine("Illegal move: {0} to {1}", positionFrom, positionTo);
                    Console.ReadKey();
                }

           
            }
        }

        private Position getPositionFromString(string position)
        {
            if (position.Length != 2)
            {
                throw new IllegalPositionException();
            }

            char columnLetter = position[0];
            char rowDigit = position[1];
            if (!char.IsLetter(columnLetter))
            {
                throw new IllegalPositionException();
            }

            if (!char.IsDigit(rowDigit))
            {
                throw new IllegalPositionException();
            }

            int columnIndex = (columnLetter - 'a');
            int rowIndex = this.board.BoardSize - (rowDigit - '0');

            return new Position(rowIndex, columnIndex);
        }

        public void PrintBoard()
        {
            StringBuilder boardStringBuilder = new StringBuilder();

            this.AppendHeaderLine(boardStringBuilder);

            this.AppendWallLine(boardStringBuilder);



            for (int row = 0; row < this.board.BoardSize; row++)
            {
                for (int i = 0; i < CellWidth / 2; i++)
                {
                    this.AppendEmptyCellLine(boardStringBuilder);
                }
                for (int i = 0; i < CellWidth / 2; i++)
                {
                    boardStringBuilder.Append(Seperator);
                }
                boardStringBuilder.Append(this.board.BoardSize - row);
                for (int i = 0; i < CellWidth / 2; i++)
                {
                    boardStringBuilder.Append(Seperator);
                }


                for (int col = 0; col < this.board.BoardSize; col++)
                {

                    boardStringBuilder.Append(Wall);
                    for (int i = 0; i < CellWidth / 2; i++)
                    {
                        boardStringBuilder.Append(Seperator);
                    }

                    boardStringBuilder.Append(this.board
                                     .GetBoardState()[row][col]
                                     ?.GetChesspieceSymbolUnicode() ?? Seperator);
                    for (int i = 0; i < CellWidth / 2; i++)
                    {
                        boardStringBuilder.Append(Seperator);
                    }
                }
                boardStringBuilder.Append(Wall);
                for (int i = 0; i < CellWidth / 2; i++)
                {
                    boardStringBuilder.Append(Seperator);
                }
                boardStringBuilder.Append(this.board.BoardSize - row);
                boardStringBuilder.Append(Environment.NewLine);
                for (int i = 0; i < CellWidth / 2; i++)
                {
                    this.AppendEmptyCellLine(boardStringBuilder);
                }
                this.AppendWallLine(boardStringBuilder);

            }

            Console.WriteLine(boardStringBuilder);
        }

        private void AppendWallLine(StringBuilder boardStringBuilder)
        {
            for (int i = 0; i < CellWidth; i++)
            {
                boardStringBuilder.Append(Seperator);
            }
            for (int i = 0; i < 1 + this.board.BoardSize * (CellWidth + 1); i++)
            {
                boardStringBuilder.Append(Wall);
            }

            boardStringBuilder.Append(Environment.NewLine);
        }


        private void AppendEmptyCellLine(StringBuilder boardStringBuilder)
        {
            for (int i = 0; i < CellWidth; i++)
            {
                boardStringBuilder.Append(Seperator);
            }

            boardStringBuilder.Append(Wall);

            for (int i = 0; i < this.board.BoardSize; i++)
            {
                for (int j = 0; j < CellWidth; j++)
                {
                    boardStringBuilder.Append(Seperator);
                }
                boardStringBuilder.Append(Wall);
            }

            boardStringBuilder.Append(Environment.NewLine);
        }

        private void AppendHeaderLine(StringBuilder boardStringBuilder)
        {
            for (int i = 0; i < CellWidth / 2; i++)
            {
                boardStringBuilder.AppendLine();
            }

            for (int i = 0; i < CellWidth + 1; i++)
            {
                boardStringBuilder.Append(Seperator);
            }
            for (int col = 0; col < this.board.BoardSize; col++)
            {
                for (int i = 0; i < CellWidth/2; i++)
                {
                    boardStringBuilder.Append(Seperator);
                }

                char letter = (char) (((int)'a') + col);
                boardStringBuilder.Append(letter);
                for (int i = 0; i < CellWidth / 2 + 1; i++)
                {
                    boardStringBuilder.Append(Seperator);
                }

            }


            for (int i = 0; i < CellWidth / 2; i++)
            {
                boardStringBuilder.AppendLine();
            }

        }
    }
}