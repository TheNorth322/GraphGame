using GraphGame.Enums;
using GraphGame.Players;

namespace GraphGame;

public class Graph
{
    private GraphNode[] nodes;

    public int position;
    
    public Graph(GraphNode[] nodes)
    {
        if (nodes.Length == 0)
            throw new ArgumentException("Graph nodes can't be empty");
        this.nodes = nodes;
        position = 0;
    }

    public bool MovePlayer(Move move)
    {
        switch (move)
        {
           case Move.UP:
               position++;
               return position == nodes.Length - 1;
           case Move.DOWN:
               position--;
               return false;
           case Move.STAY:
               return false;
           default:
               return false;
        }
    }

    public bool IsItPossibleToStay()
    {
        return nodes[position]._isPossibleToStay;
    }
}