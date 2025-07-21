using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cc3_1
{
    public class IPLTeam
    {
        public (int matchcnt, double avgscore, int total) Pointscalculation(int noOfMatches)
        {
            List<int> scores = new List<int>();

            Console.WriteLine($"Enter scores for {noOfMatches} matches:");
            
                for (int i = 0; i < noOfMatches; i++)
                {
                    Console.Write($"Enter score for match {i + 1}: ");
                    int score = int.Parse(Console.ReadLine());
                    scores.Add(score);
                }
            

            int totalSum = scores.Sum();
            double averageScore = scores.Average();

            return (noOfMatches, averageScore, totalSum);
        }
    }

    public class IPLStats
    {
        public static void Main(string[] args)
        {
            IPLTeam team = new IPLTeam();

            Console.Write("Enter the number of matches played by the team: ");
            int num=int.Parse(Console.ReadLine());
            

            (int matchesPlayed, double avgPoints, int sumOfPoints) teamStats = team.Pointscalculation(num);

            Console.WriteLine("\nResults");
            Console.WriteLine($"Number of Matches Played: {teamStats.matchesPlayed}");
            Console.WriteLine($"Total  Score: {teamStats.sumOfPoints}");
            Console.WriteLine($"Average Score Per Match: {teamStats.avgPoints:F2}");

            Console.ReadKey();
        }
    }
}
