using System;
using System.Collections.Generic;
using System.Linq;
using C1.Infrastructure.BaseResult;
using C1.Services.NodeStructure.Model;

namespace C1.Infrastructure.Utils
{
    public static class ActionHelper
    {
        public static Result 
        Find(int[] plateau, string[] currentLocationInfo, string instructions, List<Node> nodeList)
        {
            var result = new Result();
            var completedList = new List<int[]>();
            var direciton = currentLocationInfo.Last();
            var currentNode = nodeList.FirstOrDefault(i => i.data == direciton);
            int[] axis = Array.ConvertAll(currentLocationInfo.Take(currentLocationInfo.Count() - 1).ToArray(), s => int.Parse(s));
            foreach (var item in instructions)
            {
                if (item == 'M')
                {
                    var isComplete = OperationHelper.Move(currentNode, ref axis, completedList, plateau);
                    if (!isComplete)
                    {
                        result.IsSucces = false;
                        result.Message = "!!!!!! Rovers May Bupm or Out of Bounds. ARE U SURE YOU WANT DO THIS !!!!!";
                        return result;
                    }

                }
                else
                {
                    currentNode = OperationHelper.GetHead(direciton, item, nodeList);
                    direciton = currentNode.data;
                }
                int[] addAxis = { axis[0], axis[1] };
                completedList.Add(addAxis);

            }

            result.FinalCoordinate = axis[0].ToString() + axis[1].ToString() + currentNode.data;
            result.IsSucces = true;
            result.Message = "COMPLETED";
            return result;

        }
    }
}