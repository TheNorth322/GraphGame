using GraphGame.Enums;
using GraphGame.Players;

namespace GraphGame;

public class Game
{
    private Player1 _player1;
    private Player2 _player2;
    private int _gameLength;
    private Graph _graph;

    public Game(Player1 player1, Player2 player2, int gameLength, Graph graph)
    {
        _player1 = player1 ?? throw new ArgumentNullException("Player1 can't be null");
        _player2 = player2 ?? throw new ArgumentNullException("Player2 can't be null");
        _graph = graph ?? throw new ArgumentNullException("Graph can't be null");
        _gameLength = (gameLength != 0) ? gameLength : 25;
    }

    public GameResult Start()
    {
        for (int i = 1; i <= _gameLength; i++)
        {
            Move move = _player1.GenerateAClue(_graph.IsItPossibleToStay());
            Decision decision = _player2.MakeAMove(i);

            if (_graph.position == 0)
            {
                move = Move.UP;
            }
            else
            {
                move = (decision == Decision.AGREE)
                    ? move
                    : (move == Move.UP)
                        ? Move.DOWN
                        : Move.UP;
            }

            if (_graph.MovePlayer(move))
                return GameResult.PLAYER2;
        }

        return GameResult.PLAYER1;
    }
}