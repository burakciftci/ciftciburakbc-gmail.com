using System.Collections.Generic;
using System.Linq;
using C1.Services.NodeStructure.Model;

namespace C1.Infrastructure.Utils
{
    public static class OperationHelper
    {
        public static bool Move(Node node, ref int[] axis, List<int[]> list, int[] plateau)
        {
            getMove(node, ref axis);
            if (list.Count != 0)
            {
                var checkPointOne = checkConflict(list, axis);
                var checkPointTwo = checkBoundary(plateau, axis);
                if (checkPointOne != true && checkPointTwo != true)
                    return false;
            }
            return true;

        }

        public static Node GetHead(string currentHead, char instruction, List<Node> nodeList)
        {
            var node = nodeList.FirstOrDefault(i => i.data == currentHead);
            if (instruction == 'L')
                return node.L;
            else
                return node.R;
        }
        private static void getMove(Node node, ref int[] axis)
        {
            if (node.axis == "x")
                axis[0] += node.move;
            else
                axis[1] += node.move;

        }

        private static bool checkConflict(List<int[]> list, int[] axis)
        {
            var x = axis[0];
            var y = axis[1];
            return list.Any(i => i[0] == x && i[1] == y);
        }

        private static bool checkBoundary(int[] plateau, int[] axis)
        {
            if (axis[0] < 0)
                return false;
            else if (axis[0] > plateau[0])
                return false;
            else if (axis[1] < 0)
                return false;
            else if (axis[1] > plateau[1])
                return false;
            return true;
        }

    }
}