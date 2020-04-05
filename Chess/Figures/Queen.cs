namespace Chess.Figures
{
    using System.Collections.Generic;

    public class Queen : Figure
    {
        public Queen(bool isWhite) : base(isWhite)
        {
        }

        public override FigureType FigureType
        {
            get { return FigureType.Queen; }
        }

        public override IEnumerable<Position> GetLegalMoves(int xPosition, int yPosition, int boardSize)
        {
            List<Position> legalMoves = new List<Position>();
           
            legalMoves.AddRange(new King(this.IsWhite).GetLegalMoves(xPosition, yPosition, boardSize));

            legalMoves.AddRange(new Bishop(this.IsWhite).GetLegalMoves(xPosition, yPosition, boardSize));

            legalMoves.AddRange(new Rook(this.IsWhite).GetLegalMoves(xPosition, yPosition, boardSize));

            return legalMoves;
        }

    }
}