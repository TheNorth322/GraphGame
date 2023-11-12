using GraphGame.Enums;

namespace GraphGame.Players;

public class Player1
{
    private double _probabilityToGoUp;
    private double _probabilityToStay;

    public Player1(double probabilityToGoUp, double probabilityToStay)
    {
        _probabilityToStay = probabilityToStay;
        _probabilityToGoUp = probabilityToGoUp;
    }

    public Move GenerateAClue(bool possibleToStay)
    {
        Random random = new Random();
        double randomValue = random.NextDouble();
        
        if (possibleToStay && randomValue > _probabilityToGoUp &&
            randomValue <= _probabilityToStay + _probabilityToGoUp)
            return Move.STAY;
        
        return randomValue <= _probabilityToGoUp
            ? Move.UP
            : Move.DOWN;
    }
}