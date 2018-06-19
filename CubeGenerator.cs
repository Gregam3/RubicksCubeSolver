using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rubicks_cube_solver {
    class CubeGenerator {
        private static List<ConsoleColor> AvailableColors = new List<ConsoleColor>();
        private static Dictionary<ConsoleColor, int> CornerFacesRemaining = new Dictionary<ConsoleColor, int>();
        private static Dictionary<ConsoleColor, int> SideFacesRemaining = new Dictionary<ConsoleColor, int>();
        private static readonly Random Random = new Random();

        public static Cube GenerateCube() {
            Dictionary<ConsoleColor, Side> sides = new Dictionary<ConsoleColor, Side>();

            foreach (ConsoleColor color in AvailableColors)
                sides.Add(color, GenerateSide());

            return new Cube(sides);
        }

        private static Side GenerateSide() {
            Dictionary<FacePosition, ConsoleColor> faces = new Dictionary<FacePosition, ConsoleColor>();

            foreach (FacePosition position in Enum.GetValues(typeof(FacePosition))) {
                if (position.ToString().Contains("Corner"))
                    faces.Add(position, GenerateColor("corner"));
                else if(position != FacePosition.Centre)
                    faces.Add(position, GenerateColor("side"));
            }


            return new Side(faces);
        }

        private static ConsoleColor GenerateColor(string faceType) {
            bool colorValid = false;

            //Black is used as a color will be sent when something goes wrong, equivalent of returning -1 for something like age.
            ConsoleColor color = ConsoleColor.Black;



            while (!colorValid) {
                //5 as there will only ever be 6 colors (starting at 0)
                color = AvailableColors[Random.Next(6)];

                if (faceType == "side") {
                    if (SideFacesRemaining[color] > 0) {
                        SideFacesRemaining[color]--;
                        colorValid = true;
                    }
                } else if (faceType == "corner") {
                    if (CornerFacesRemaining[color] > 0) {
                        CornerFacesRemaining[color]--;
                        colorValid = true;
                    }
                }
            }


            return color;
        }

        public static void PopulateColors() {
            for (int i = 0; i < 6; i++) {
                SideFacesRemaining.Add(AvailableColors[i], 4);
                CornerFacesRemaining.Add(AvailableColors[i], 4);
            }
        }

        public static void PopulateAvailableColors() {
            AvailableColors.Add(ConsoleColor.Blue);
            AvailableColors.Add(ConsoleColor.Red);
            AvailableColors.Add(ConsoleColor.Green);
            AvailableColors.Add(ConsoleColor.DarkRed);
            AvailableColors.Add(ConsoleColor.Yellow);
            AvailableColors.Add(ConsoleColor.White);
        }
    }
}
