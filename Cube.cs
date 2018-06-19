using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rubicks_cube_solver {
    class Cube {
        private readonly string SquareCharacter = "■";
        private Dictionary<ConsoleColor, Side> Sides = new Dictionary<ConsoleColor, Side>();
        private readonly FacePosition[] positionMap = {
           FacePosition.TopLeftCorner, FacePosition.Top, FacePosition.TopRightCorner,
       FacePosition.CentreLeft, FacePosition.Centre, FacePosition.CentreRight,
       FacePosition.BottomLeftCorner, FacePosition.Bottom, FacePosition.BottomRightCorner
        };

        public Cube(Dictionary<ConsoleColor, Side> sides) {
            Sides = sides;
        }

        public void PrintCube() {
            Dictionary<ConsoleColor, Side>.Enumerator facesEnumerator = Sides.GetEnumerator();
           
            while(facesEnumerator.MoveNext())
                PrintSide(facesEnumerator.Current.Key, facesEnumerator.Current.Value);
        }

        private void PrintSide(ConsoleColor color, Side side) { 
            for (int i = 0; i < 9; i++) {
                if (i % 3 == 0)
                    Console.WriteLine();
                if (i == 4)
                    PrintInColor(color);
                else
                    PrintInColor(side.GetFaces()[positionMap[i]]);
            }

            Console.WriteLine();

        }

        private void PrintInColor(ConsoleColor consoleColor) {
            Console.ForegroundColor = consoleColor;
            Console.Write(SquareCharacter);
        }
    }
}