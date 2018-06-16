using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rubicks_cube_solver {
    class CubeGenerator {
        private static List<ConsoleColor> AvailableColors = new List<ConsoleColor>();
        private static Dictionary<ConsoleColor, int> FacesRemaining = new Dictionary<ConsoleColor, int>();
        private static readonly Random Random = new Random();

        public static Cube GenerateCube() {
            Dictionary <ConsoleColor, Side> sides = new Dictionary<ConsoleColor, Side>();

            foreach (ConsoleColor color in AvailableColors) 
                sides.Add(color, GenerateSide());

            return new Cube(sides);
            
        }

        private static Side GenerateSide() {
            Dictionary<FacePosition, ConsoleColor> faces = new Dictionary<FacePosition, ConsoleColor>();

            foreach (FacePosition position in Enum.GetValues(typeof(FacePosition)))
                faces.Add(position, GenerateColor());

            return new Side(faces);
        }

        private static ConsoleColor GenerateColor() {
            ConsoleColor color = AvailableColors[Random.Next(FacesRemaining.Count)];
            FacesRemaining[color]--;

            if (FacesRemaining[color] > 0)
                FacesRemaining.Remove(color);

            return color;
        }

        private void PopulateColors() {
            for (int i = 0; i < 6; i++)
                FacesRemaining.Add(AvailableColors[i], 8);
        }
    }
}
