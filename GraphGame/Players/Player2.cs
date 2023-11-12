using GraphGame.Enums;

namespace GraphGame.Players;

public class Player2
{
    private int[] _moves;
    private int _totalMoves;

    public Player2(int[] moves)
    {
        if (moves.Length == 0)
            throw new ArgumentException("Moves can't be empty");
        _moves = moves;

        _totalMoves = 0;
        foreach (int move in moves)
            _totalMoves += Int32.Abs(move);
    }

    public Decision MakeAMove(int globalTurn)
    {
        int turn = GetCurrentTurn(globalTurn);
        return MakeADecision(turn);
    }

    private int GetCurrentTurn(int globalTurn)
    {
        globalTurn %= _totalMoves;
        for (int i = 0; i < _moves.Length; i++)
        {
            globalTurn -= Int32.Abs(_moves[i]);
            if (globalTurn <= 0)
                return _moves[i];
        }
        
        throw new ApplicationException("Game was aborted");
    }

    private Decision MakeADecision(int turn)
    {
        return (turn > 0) ? Decision.AGREE : Decision.DISAGREE;
    }
}