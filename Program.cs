using System;
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
            CubeManipulator cubeManipulator = new CubeManipulator();


            Console.WriteLine("MOVED RIGHT");
            Console.WriteLine();

            cubeManipulator.Right(cube).PrintCube();

            Console.Read();
        }

        //First directive create white cross with yellow centre
        static void SurroundYellowCentreWithWhiteSides(Cube cube) {

        }
    }
}
