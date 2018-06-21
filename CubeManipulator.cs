using System.Collections.Generic;

namespace rubicks_cube_solver {
    /**
        * The white centre face is always facing downwards
        * The Yellow and the White faces are always opposite
        * Orange (Red) always has Blue right of it 
        * Blue always has Red (Dark Red) right of it
        * Red (Dark Red) always has Green right of it
        * Manipulation include
        *  -Right Clockwise (R)
        *  -Left Clockwise (L)
        *  -Front Clockwise (F)
        *  -Up Clockwise (U)
        *  -Bottom Clockwise (B) (likely not needed)
        * The " ' " follows after a manipulation to indicate it is counter clockwise viz. reversed
        * e.g. L' is Left counter-clockwise
        **/

    class CubeManipulator {
        private List<FacePosition> RightFaceOrder = new List<FacePosition> (
            new FacePosition[]{
                FacePosition.TopRightCorner,
                FacePosition.CentreRight,
                FacePosition.BottomRightCorner
            }
        );

        private List<SidePosition> RightSideOrder = new List<SidePosition>(
            new SidePosition[]{
                SidePosition.Top,
                SidePosition.Back,
                SidePosition.Bottom,
                SidePosition.Front
            }
        );

        public Cube Right(Cube cube) {
            Dictionary<SidePosition, Side> newSides = new Dictionary<SidePosition, Side>();

            Side tempSide;

            for (int i = 0;  i < RightSideOrder.Count; i++) {
                tempSide = new Dictionary<SidePosition, Side>(cube.GetSides())[RightSideOrder[i]];

                for (int j = 0; j < RightFaceOrder.Count; j++) {
                    tempSide.GetFaces()[RightFaceOrder[j]] =
                        cube.GetSides()[RightSideOrder[GetAntecedantSideIndex(i)]]
                        .GetFaces()[RightFaceOrder[j]];
                }

                newSides.Add(RightSideOrder[i], tempSide);
            }

            Dictionary<SidePosition, Side>.Enumerator changedSideEnumerator = newSides.GetEnumerator();

            while (changedSideEnumerator.MoveNext())
                cube.GetSides()[changedSideEnumerator.Current.Key] = changedSideEnumerator.Current.Value;

            return cube;
        }

        private int GetAntecedantSideIndex(int currentIndex) {
            if (currentIndex == 0)
                return 3;
            return currentIndex - 1;
        }
    }
}
