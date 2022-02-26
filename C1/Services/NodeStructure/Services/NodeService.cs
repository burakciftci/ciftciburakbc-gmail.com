using System.Collections.Generic;
using C1.Services.NodeStructure.Model;

namespace C1.Services.NodeStructure.Services
{
    public class NodeService : INodeService
    {
        public List<Node> Set()
        {
            Node north = new Node();
            Node south = new Node();
            Node east = new Node();
            Node west = new Node();

            north.data = "N";
            north.move = 1;
            north.axis = "y";

            south.data = "S";
            south.move = -1;
            south.axis = "y";

            east.data = "E";
            east.move = 1;
            east.axis = "x";

            west.data = "W";
            west.move = -1;
            west.axis = "x";

            north.R = east;
            north.L = west;

            south.R = west;
            south.L = east;

            east.R = south;
            east.L = north;

            west.R = north;
            west.L = south;

            return new List<Node> { north, south, west, east };
        }
    }
}