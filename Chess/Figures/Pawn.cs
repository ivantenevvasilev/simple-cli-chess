namespace Chess.Figures
{
    using System.Collections.Generic;
    using System.Linq;

    public class Pawn : Figure
    {
        public Pawn(bool isWhite) : base(isWhite) {}

        public override FigureType FigureType
        {
            get { return FigureType.Pawn; }
        }

        public override IEnumerable<Position> GetLegalMoves(int xPosition, int yPosition, int boardSize)
        {
            IList<Position> legalMoves = new List<Position>();

            // Moving position is based on color (e.g. white player is bottom side and black player is top side)
            int direction = IsWhite ? -1 : 1;

            legalMoves.Add(new Position(xPosition + direction , yPosition - 1));
            legalMoves.Add(new Position(xPosition + direction, yPosition));
            legalMoves.Add(new Position(xPosition + direction, yPosition + 1));

            return legalMoves.Where(position => position.IsValidPosition(boardSize)).ToList();
        }
    }
}