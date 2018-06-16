using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rubicks_cube_solver {
    class Side {
        private Dictionary<FacePosition, ConsoleColor> Faces = new Dictionary<FacePosition, ConsoleColor>();

        public Side(Dictionary<FacePosition, ConsoleColor> faces) {
            Faces = faces;
        }

        public Dictionary<FacePosition, ConsoleColor> GetFaces() {
            return Faces;
        }
    }
}
