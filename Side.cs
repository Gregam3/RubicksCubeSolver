using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rubicks_cube_solver {
    struct Side {
        private Dictionary<FacePosition, ConsoleColor> Faces;

        public Side(Dictionary<FacePosition, ConsoleColor> faces) {
            Faces = faces;
        }

        internal Dictionary<FacePosition, ConsoleColor> Faces1 { get => Faces; set => Faces = value; }

        public Dictionary<FacePosition, ConsoleColor> GetFaces() {
            return Faces1;
        }
    }
}
