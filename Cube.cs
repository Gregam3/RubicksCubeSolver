using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rubicks_cube_solver {
    struct Cube {
        private readonly string SquareCharacter;

        private Dictionary<SidePosition, Side> Sides = new Dictionary<SidePosition, Side>();

        private readonly FacePosition[] PositionMap = {
           FacePosition.TopLeftCorner, FacePosition.Top, FacePosition.TopRightCorner,
       FacePosition.CentreLeft, FacePosition.Centre, FacePosition.CentreRight,
       FacePosition.BottomLeftCorner, FacePosition.Bottom, FacePosition.BottomRightCorner
        };

        public string SquareCharacter1 => SquareCharacter;

        internal Dictionary<SidePosition, Side> Sides1 { get => Sides; set => Sides = value; }

        public Cube(Dictionary<SidePosition, Side> sides) {
            Sides1 = sides;
        }

        public void PrintCube() {
            Dictionary<SidePosition, Side>.Enumerator facesEnumerator = Sides1.GetEnumerator();
           
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
            Console.Write(SquareCharacter1);
            Console.ResetColor();
        }

        public Dictionary<SidePosition, Side> GetSides() {
            return Sides1;
        }

        public void SetSides(Dictionary<SidePosition, Side> sides) {
            Sides1 = sides;
        }
    }
}