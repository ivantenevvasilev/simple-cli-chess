using Chess.Figures;

namespace Chess
{
    public static class IFigureExtension
    {
        public static string GetFigureName(this IFigure figure)
        {
            return figure.FigureType.ToString();
        }

        public static char GetChesspieceSymbolUnicode(this IFigure figure)
        {
            switch (figure.FigureType)
            {
                case FigureType.Pawn:
                    if (figure.IsWhite)
                    {
                        return '\u2659';
                    }
                    else
                    {
                        return '\u265F';
                    }
                case FigureType.Rook:
                    if (figure.IsWhite)
                    {
                        return '\u2656';
                    }
                    else
                    {
                        return '\u265C';
                    }
                case FigureType.Bishop:
                    if (figure.IsWhite)
                    {
                        return '\u2657';
                    }
                    else
                    {
                        return '\u265D';
                    }
                case FigureType.Knight:
                    if (figure.IsWhite)
                    {
                        return '\u2658';
                    }
                    else
                    {
                        return '\u265E';
                    }
                case FigureType.Queen:
                    if (figure.IsWhite)
                    {
                        return '\u2655';
                    }
                    else
                    {
                        return '\u265B';
                    }
                case FigureType.King:
                    if (figure.IsWhite)
                    {
                        return '\u2654';
                    }
                    else
                    {
                        return '\u265A';
                    }

            }
            return '?';
        }
    }
}