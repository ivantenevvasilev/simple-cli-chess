namespace Chess.Figures
{
    using System.Collections.Generic;

    public abstract class Figure : IFigure
    {
        protected Figure(bool isWhite)
        {
            this.IsBlack = !isWhite;
            this.IsWhite = isWhite;
        }
        public bool IsWhite { get; private set; }
        public bool IsBlack { get; private set; }
        public abstract FigureType FigureType { get; }
        public abstract IEnumerable<Position> GetLegalMoves(int xPosition, int yPosition, int boardSize);
    }
}