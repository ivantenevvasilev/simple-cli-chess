using System.Collections.Generic;
using System.Linq;

namespace Chess.Figures
{
    public class Knight : Figure
    {
        public Knight(bool isWhite) : base(isWhite) {}

        public override FigureType FigureType
        {
            get { return FigureType.Knight; }
        }

        public override IEnumerable<Position> GetLegalMoves(int xPosition, int yPosition, int boardSize)
        {
            IList<Position> legalMoves = new List<Position>();

            // Top Left
            legalMoves.Add(new Position(xPosition - 1, yPosition - 2));
            legalMoves.Add(new Position(xPosition - 2, yPosition - 1));

            // Top Right
            legalMoves.Add(new Position(xPosition - 1, yPosition + 2));
            legalMoves.Add(new Position(xPosition - 2, yPosition + 1));

            // Bot Left
            legalMoves.Add(new Position(xPosition + 1, yPosition - 2));
            legalMoves.Add(new Position(xPosition + 2, yPosition - 1));

            // Top Right
            legalMoves.Add(new Position(xPosition + 1, yPosition + 2));
            legalMoves.Add(new Position(xPosition + 2, yPosition + 1));

            return legalMoves.Where(position => position.IsValidPosition(boardSize)).ToList();
        }
    }
}