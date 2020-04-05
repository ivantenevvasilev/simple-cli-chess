using System.Collections;
using System.Collections.Generic;

namespace Chess.Figures
{
    public class Bishop : Figure
    {
        public Bishop(bool isWhite) : base(isWhite) {}

        public override FigureType FigureType
        {
            get { return FigureType.Bishop; }
        }

        public override IEnumerable<Position> GetLegalMoves(int xPosition, int yPosition, int boardSize)
        {
            IList<Position> legalMoves = new List<Position>();

            // Position is a struct therefore will be passed as a value. Win-win
            Position diagonalTraverser = new Position(xPosition - 1, yPosition - 1);
            
            // Top Left
            while (diagonalTraverser.IsValidPosition(boardSize))
            {
                legalMoves.Add(diagonalTraverser);

                diagonalTraverser.x--;
                diagonalTraverser.y--;
            }

            // Top Right
            diagonalTraverser.x = xPosition + 1;
            diagonalTraverser.y = yPosition - 1;
            while (diagonalTraverser.IsValidPosition(boardSize))
            {
                legalMoves.Add(diagonalTraverser);

                diagonalTraverser.x++;
                diagonalTraverser.y--;
            }      
            
            // Bottom Left
            diagonalTraverser.x = xPosition - 1;
            diagonalTraverser.y = yPosition + 1;
            while (diagonalTraverser.IsValidPosition(boardSize))
            {
                legalMoves.Add(diagonalTraverser);

                diagonalTraverser.x--;
                diagonalTraverser.y++;
            }

            // Bottom Right
            diagonalTraverser.x = xPosition + 1;
            diagonalTraverser.y = yPosition + 1;
            while (diagonalTraverser.IsValidPosition(boardSize))
            {
                legalMoves.Add(diagonalTraverser);

                diagonalTraverser.x++;
                diagonalTraverser.y++;
            }

            return legalMoves;
        }

    }
}