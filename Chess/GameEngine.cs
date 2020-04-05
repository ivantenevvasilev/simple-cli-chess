using System;
using System.Text;

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



                string line = Console.ReadLine();
                if (line == null || String.IsNullOrEmpty(line))
                {
                    break;
                }

                
            }
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