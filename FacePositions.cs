using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rubicks_cube_solver {
    enum SidePosition {
        Top, Front, Right, Back, Left, Bottom
    }

    enum FacePosition {
       TopLeftCorner, Top, TopRightCorner,
       CentreLeft, Centre, CentreRight,
       BottomLeftCorner, Bottom, BottomRightCorner 
    } 
}