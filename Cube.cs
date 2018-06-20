using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rubicks_cube_solver {
    class Cube {
        private readonly string SquareCharacter = "■";
        private Dictionary<SidePosition, Side> Sides = new Dictionary<SidePosition, Side>();
        private readonly FacePosition[] positionMap = {
           FacePosition.TopLeftCorner, FacePosition.Top, FacePosition.TopRightCorner,
       FacePosition.CentreLeft, FacePosition.Centre, FacePosition.CentreRight,
       FacePosition.BottomLeftCorner, FacePosition.Bottom, FacePosition.BottomRightCorner
        };

        public Cube(Dictionary<SidePosition, Side> sides) {
            Sides = sides;
        }

        public void PrintCube() {
            Dictionary<SidePosition, Side>.Enumerator facesEnumerator = Sides.GetEnumerator();
           
            while(facesEnumerator.MoveNext())
                PrintSide(facesEnumerator.Current.Key, facesEnumerator.Current.Value);
        }

        private void PrintSide(SidePosition sidePosition, Side side) { 
            for (int i = 0; i < 9; i++) {
                if (i % 3 == 0)
                    Console.WriteLine();

                PrintInColor(side.GetFaces()[positionMap[i]]);
            }

            Console.WriteLine();

        }

        private void PrintInColor(ConsoleColor consoleColor) {
            Console.ForegroundColor = consoleColor;
            Console.Write(SquareCharacter);
        }

        public Dictionary<SidePosition, Side> GetSides() {
            return Sides;
        }

        public void SetSides(Dictionary<SidePosition, Side> sides) {
            Sides = sides;
        }
    }
}