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
            Dictionary<SidePosition, Side> sides = new Dictionary<SidePosition, Side>();

            //May iterate eventually, position needs to correspond to color.
            sides.Add(SidePosition.Top, GenerateSide(ConsoleColor.Yellow));
            sides.Add(SidePosition.Front, GenerateSide(ConsoleColor.DarkRed));
            sides.Add(SidePosition.Right, GenerateSide(ConsoleColor.Green));
            sides.Add(SidePosition.Back, GenerateSide(ConsoleColor.Red));
            sides.Add(SidePosition.Left, GenerateSide(ConsoleColor.Blue));
            sides.Add(SidePosition.Bottom, GenerateSide(ConsoleColor.White));

            return new Cube(sides);
        }

        private static Side GenerateSide(ConsoleColor color) {
            Dictionary<FacePosition, ConsoleColor> faces = new Dictionary<FacePosition, ConsoleColor>();

            foreach (FacePosition position in Enum.GetValues(typeof(FacePosition))) {
                if (position.ToString().Contains("Corner"))
                    faces.Add(position, GenerateColor("corner"));
                else if (position != FacePosition.Centre)
                    faces.Add(position, GenerateColor("side"));
                else
                    faces.Add(FacePosition.Centre, color);
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
