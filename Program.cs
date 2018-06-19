﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rubicks_cube_solver {
    class Solver {
        static void Main(string[] args) {
            CubeGenerator.PopulateAvailableColors();
            CubeGenerator.PopulateColors();
            Cube cube = CubeGenerator.GenerateCube();

            cube.PrintCube();
            Console.Read();
        }
    }
}
