using System;
using System.Collections;
using System.Collections.Generic;

namespace Chess.Figures
{
    public interface IFigure
    {
        bool IsWhite { get; }
        bool IsBlack { get; }

        FigureType FigureType { get; }

        IEnumerable<Position> GetLegalMoves(int xPosition, int yPosition, int boardSize);
    }
}