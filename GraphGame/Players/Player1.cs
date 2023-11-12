using GraphGame.Enums;

namespace GraphGame.Players;

public class Player1
{
    private double _probabilityToGoDown;
    private const double _probabilityToStay = 0.1f;
    private double _probabilityToGoUp;
    public Player1(double probabilityToGoDown)
    {
        _probabilityToGoDown = probabilityToGoDown;
    }

    public Move GenerateAClue(bool possibleToStay)
    {
        Random random = new Random();
        double randomValue = random.NextDouble();

        if (randomValue < _probabilityToGoDown)
        {
            return Move.DOWN;
        }
        else if (randomValue < _probabilityToGoDown + _probabilityToStay)
        {
            return possibleToStay ? Move.STAY : Move.UP;
        }
        else
        {
            return Move.UP;
        }
    }
}