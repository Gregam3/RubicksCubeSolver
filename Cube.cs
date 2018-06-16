using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rubicks_cube_solver {
    class Cube {
        private readonly string SquareCharacter = "■";
        private Dictionary<ConsoleColor, Side> Faces = new Dictionary<ConsoleColor, Side>();
        private readonly FacePosition[] positionMap = {
           FacePosition.TopLeft, FacePosition.Top, FacePosition.TopRight,
       FacePosition.CentreLeft, FacePosition.Centre, FacePosition.CentreRight,
       FacePosition.BottomLeft, FacePosition.Bottom, FacePosition.BottomRight
        };

        public Cube(Dictionary<ConsoleColor, Side> faces) {
            Faces = faces;
        }

        public void PrintCube() {
            Dictionary<ConsoleColor, Side>.Enumerator facesEnumerator = Faces.GetEnumerator();
           
            while(facesEnumerator.MoveNext())
                PrintSide(facesEnumerator.Current.Key, facesEnumerator.Current.Value);
        }

        private void PrintSide(ConsoleColor color, Side side) {
            foreach (FacePosition position in Enum.GetValues(typeof(FacePosition))) {

                for (int i = 0; i < 9; i++) {
                    if (i + 1 % 3 == 0)
                        Console.WriteLine();
                    if (i == 4)
                        PrintInColor(SquareCharacter, color);
                    PrintInColor(SquareCharacter, side.GetFaces()[positionMap[i]]);
                }


            }
        }

        private void PrintInColor(string textToPrint, ConsoleColor consoleColor) {
            Console.ForegroundColor = consoleColor;
            Console.Write(textToPrint);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}