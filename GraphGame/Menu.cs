using GraphGame.Enums;
using GraphGame.Players;

namespace GraphGame;

public class Menu
{
    public void Listen()
    {
        while (true)
        {
            int player1Wins = 0;
            int player2Wins = 0;

            Console.WriteLine("Введите количество игр: ");
            int gamesAmount = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите длину игры: ");
            int gameLength = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите вероятность пойти вниз: ");
            double probabilityToGoDown = Convert.ToDouble(Console.ReadLine());
            
            for (int i = 0; i < gamesAmount; i++)
            {
                Game game = new Game(
                    new Player1(probabilityToGoDown),
                    new Player2(new[]
                        { -3, +4, -2, +1, +5, -6, +9, -4, +2, -5, -4, +4, -8, +9, -2, +4, -6, +7, -5, +5, -5 }),
                    gameLength,
                    new Graph(
                        new GraphNode[]
                        {
                            new GraphNode(false),
                            new GraphNode(true),
                            new GraphNode(false),
                            new GraphNode(false),
                            new GraphNode(false),
                            new GraphNode(false)
                        }
                    ));

                if (game.Start() == GameResult.PLAYER1)
                    player1Wins++;
                else
                    player2Wins++;
            }

            Console.WriteLine(
                $"Победы первого игрока: {player1Wins} Процент побед: {(double)player1Wins * 100 / (double)gamesAmount}%");
            Console.WriteLine(
                $"Победы второго игрока: {player2Wins} Процент побед: {(double)player2Wins * 100 / (double)gamesAmount}%");
        }
    }
}