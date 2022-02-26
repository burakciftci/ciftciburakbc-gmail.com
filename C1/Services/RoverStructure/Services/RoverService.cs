using System.Collections.Generic;
using C1.Services.RoverStructure.Model;
using C1.Services.RoverStructure.Services;

namespace C1.Services.Rover.Services
{
    public class RoverService : IRoverService
    {
        public List<Rovers> Set()
        {
            var item0 = new Rovers();
            var item1 = new Rovers();
            var item2 = new Rovers();

            item0.CurrentLocationInfo = new string[] { "1", "2", "N" };
            item0.Instructions = "LMLMLMLMM";
            item1.CurrentLocationInfo = new string[] { "3", "3", "E" };
            item1.Instructions = "MMRMMRMRRM";
            item2.CurrentLocationInfo = new string[] { "1", "3", "N" };
            item2.Instructions = "MMRM";
            var roverList = new List<Rovers>();
            roverList.Add(item0);
            roverList.Add(item1);
            roverList.Add(item2);

            return roverList;
        }
    }
}