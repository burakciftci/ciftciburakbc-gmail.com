using System;
using System.Collections.Generic;
using C1.Infrastructure.BaseResult;
using C1.Infrastructure.Utils;
using C1.Services.NodeStructure.Services;
using C1.Services.Rover.Services;

namespace C1.Services.Action
{
    public class ActionService : IActionService
    {
        public void Run()
        {
            var _nodeService = new NodeService();
            var _roverService = new RoverService();
            var nodeList = _nodeService.Set();
            var roverList = _roverService.Set();
            var resultList = new List<Result>();
            int[] plateau = { 5, 5 };

            foreach (var item in roverList)
            {
                var result = ActionHelper.Find(plateau, item.CurrentLocationInfo, item.Instructions, nodeList);
                if (!result.IsSucces)
                {

                    Console.WriteLine(result.Message);
                    resultList = null;
                    break;
                }
                resultList.Add(result);
            }

            if (resultList != null)
            {
                foreach (var item in resultList)
                {
                    Console.WriteLine(item.FinalCoordinate + " " + item.Message);
                }

            }
        }
    }
}