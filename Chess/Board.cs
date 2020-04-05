using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Chess.Figures;

namespace Chess
{
    public class Board
    {
        private readonly Figure[][] boardState;

        public Board(int boardSize = 8)
        {
            this.BoardSize = boardSize;
            this.boardState = new Figure[this.BoardSize][];
            for (int i = 0; i < boardSize; i++)
            {
                this.boardState[i] = new Figure[this.BoardSize];
            }

            this.initializeEmptyBoard();
            this.resetBoard();
        }

        private void resetBoard()
        {
            // Place rooks
            this.boardState[0][0] = new Rook(isWhite: false);
            this.boardState[this.BoardSize - 1][0] = new Rook(isWhite: true);
            this.boardState[0][this.BoardSize - 1] = new Rook(isWhite: false);
            this.boardState[this.BoardSize - 1][this.BoardSize - 1] = new Rook(isWhite: true);

            // Place knights
            this.boardState[0][1] = new Knight(isWhite: false);
            this.boardState[this.BoardSize - 1][1] = new Knight(isWhite: true);
            this.boardState[0][this.BoardSize - 2] = new Knight(isWhite: false);
            this.boardState[this.BoardSize - 1][this.BoardSize - 2] = new Knight(isWhite: true);

            // Place bishops
            this.boardState[0][2] = new Bishop(isWhite: false);
            this.boardState[this.BoardSize - 1][2] = new Bishop(isWhite: true);
            this.boardState[0][this.BoardSize - 3] = new Bishop(isWhite: false);
            this.boardState[this.BoardSize - 1][this.BoardSize - 3] = new Bishop(isWhite: true);

            // Place queens
            this.boardState[0][3] = new Queen(isWhite: false);
            this.boardState[this.BoardSize - 1][3] = new Queen(isWhite: true);

            // Place kings
            this.boardState[0][this.BoardSize - 4] = new King(isWhite: false);
            this.boardState[this.BoardSize - 1][this.BoardSize - 4] = new King(isWhite: true);

            for (int i = 0; i < this.BoardSize; i++)
            {
                this.boardState[1][i] = new Pawn(isWhite: false);

                this.boardState[this.BoardSize - 2][i] = new Pawn(isWhite: true);
            }
        }


        private void initializeEmptyBoard()
        {
            for (int i = 0; i < this.BoardSize; i++)
            {
                for (int j = 0; j < this.BoardSize; j++)
                {
                    this.boardState[i][j] = null;
                }
            }
            
        }

        private bool isPathObstructed(Position origin, Position destination)
        {
            Figure figure = this.boardState[origin.x][origin.y];

            if (figure == null)
            {
                return false;
            }

            // Bishop same-row move
            if (origin.x == destination.x && origin.x - destination.x > 1)
            {
                int smallerOfTheTwo = origin.y > destination.y ? destination.y : origin.y;
                int largerOfTheTwo = origin.y > destination.y ? origin.y : destination.y;
                for (int i = smallerOfTheTwo; i < largerOfTheTwo; i++)
                {
                    if (this.boardState[i][origin.y] != null)
                    {
                        // There is a piece that is in between therefore in this board state it is illegal.
                        return false;
                    }
                }
            }
            else if (origin.y == destination.y && origin.y - destination.y > 1)
            {
                int smallerOfTheTwo = origin.x > destination.x ? destination.x : origin.x;
                int largerOfTheTwo = origin.x > destination.x ? origin.x : destination.x;
                for (int i = smallerOfTheTwo; i < largerOfTheTwo; i++)
                {
                    if (this.boardState[origin.x][i] != null)
                    {
                        // There is a piece that is in between therefore in this board state it is illegal.
                        return false;
                    }
                }
            }
            else // Must be either a bishop or knight specific move
                 // Out of those, only a bishop move can be obstructed
            {
                int xDelta;
                if (destination.x > origin.x)
                {
                    xDelta = -1;
                }
                else
                {
                    xDelta = 1;
                }

                int yDelta;
                if (destination.y > origin.y)
                {
                    yDelta = -1;
                }
                else
                {
                    yDelta = 1;
                }

                Position startPosition = origin;
                while (startPosition.IsValidPosition(this.BoardSize) && startPosition.x != destination.x && startPosition.y != destination.y)
                {
                    if (this.boardState[startPosition.x][startPosition.y] != null)
                    {
                        // This diagonal is obstructed and this move is illegal
                        return false;
                    }
                    startPosition.x += xDelta;
                    startPosition.y += yDelta;
                }

            }



            return true;
        }

        public bool CanMove(Position origin, Position destination)
        {
            Figure figureToMove = this.boardState[origin.x][origin.y];

            if (figureToMove == null)
            {
                return false;
            }

            IEnumerable<Position> legalPositions = figureToMove.GetLegalMoves(origin.x, origin.y, this.BoardSize);
            if (!legalPositions.Contains(destination))
            {
                return false;
            }

            if (this.isPathObstructed(origin, destination))
            {
                return false;
            }


       
            Figure destinationFigure = this.boardState[destination.x][destination.y];
            if (destinationFigure == null)
            {
                if (figureToMove is Pawn)
                {
                    return origin.y == destination.y;
                }
                // This position is free and not obstructed, therefore we can move
                return true;
            }
            else
            {
                if (destinationFigure.IsBlack && figureToMove.IsBlack)
                {
                    // Same colour figures, can't step on own figures
                    return false;
                }

                if (destinationFigure.IsWhite && figureToMove.IsWhite)
                {
                    // Same colour figures, can't step on own figures
                    return false;
                }
            }

            // Hate to do it, but a pawn is the only piece that gets extra moves depending on the board


            return true;

        }

        public void Move(Position origin, Position destination)
        {
            if (this.CanMove(origin, destination))
            {
                this.boardState[destination.x][destination.y] = this.boardState[origin.x][origin.y];
                this.boardState[origin.x][origin.y] = null;
            }
        }

        public Figure[][] GetBoardState()
        {
            return this.boardState;
        }

    
        public int BoardSize { get; private set; }

        public int FigureCount { get; private set; }


    }
}