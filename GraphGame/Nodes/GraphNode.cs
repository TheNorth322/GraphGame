using GraphGame.Enums;
using GraphGame.Players;

namespace GraphGame;

public class GraphNode
{
    public bool _isPossibleToStay { get; }

    public GraphNode(bool isPossibleToStay)
    {
        _isPossibleToStay = isPossibleToStay;
    }
}