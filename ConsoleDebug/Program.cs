using System;
using System.Text;
using Chess;
using Chess.Figures;

namespace ConsoleDebug
{
    class Program
    {
        static void Main(string[] args)
        {
            Board chessBoard = new Board();
            var board = chessBoard.GetBoardState();
            
            Console.OutputEncoding = Encoding.Unicode;
            
            GameEngine engine = new GameEngine();
            engine.Run();

        }
    }
}
