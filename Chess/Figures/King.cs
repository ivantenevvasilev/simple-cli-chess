namespace Chess.Figures
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Chess;

    public class King : Figure
    {
        private readonly IEnumerable<Position> relativePositionLegalMoves;
        public King(bool isWhite) : base(isWhite)
        {
            this.relativePositionLegalMoves = this.getRelativePositionMoves();
        }

        private IEnumerable<Position> getRelativePositionMoves()
        {
            IList<Position> relativePositions = new List<Position>();

            // Top
            relativePositions.Add(new Position(-1, -1));
            relativePositions.Add(new Position(-1, 0));
            relativePositions.Add(new Position(-1, 1));

            // Left+Right
            relativePositions.Add(new Position(0, -1));
            relativePositions.Add(new Position(0, 1));

            // Bottom
            relativePositions.Add(new Position(1, -1));
            relativePositions.Add(new Position(1, 0));
            relativePositions.Add(new Position(1, 1));

            return relativePositions;
        }

        public override FigureType FigureType
        {
            get { return FigureType.King; }
        }

        public override IEnumerable<Position> GetLegalMoves(int xPosition, int yPosition, int boardSize)
        {
            Position p = new Position(xPosition, yPosition);
            return this.relativePositionLegalMoves
                .Select(offset => 
                    new Position(xPosition + offset.x, yPosition + offset.y))
                .Where(position => position.IsValidPosition(boardSize))
                .ToList();
        }
    }
}