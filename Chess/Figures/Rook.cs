
namespace Chess.Figures
{
    using System.Collections.Generic;

    public class Rook : Figure
    {
        public Rook(bool isWhite) : base(isWhite) { }

        public override FigureType FigureType
        {
            get { return FigureType.Rook; }
        }

        public override IEnumerable<Position> GetLegalMoves(int xPosition, int yPosition, int boardSize)
        {
            IList<Position> legalMoves = new List<Position>();

            for (int i = 0; i < boardSize; i++)
            {
                if (i != xPosition)
                {
                    legalMoves.Add(new Position(i, yPosition));
                }

                if (i != yPosition)
                {
                    legalMoves.Add(new Position(xPosition, i));
                }
            }

            return legalMoves;
        }
    }
}