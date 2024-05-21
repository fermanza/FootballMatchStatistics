using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Team
{
    public string Name { get; set; }
    public int Goals { get; set; }
}

class Match
{
    public string TeamName1 { get; set; }
    public int GoalsTeam1 { get; set; }
    public int ScoreTeam1 { get; set; }
    public string TeamName2 { get; set; }
    public int GoalsTeam2 { get; set; }
    public int ScoreTeam2 { get; set; }
    public DateTime GameDate { get; set; }
}

class Statistic
{
    public string Name { get; set; }
    public int Points { get; set; }
}

class FileNameReader
{
    static void Main()
    {
        string filePath = @"/Users/fernandomanzano/Code/CS/ConsoleApp1/ConsoleApp1/File.txt";
        try
        {
            string[] lines = File.ReadAllLines(filePath);
            List<Match> matches = lines.Select(line => CreateMatch(line.Split(',')[0].Trim(), line.Split(',')[1].Trim())).ToList();
            List<Statistic> stats = Stats(matches);

            for (int i = 0; i < stats.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {stats[i].Name}, {stats[i].Points} pts");
            }
        }
        catch (IOException e)
        {
            Console.WriteLine("The file could not be read:");
            Console.WriteLine(e.Message);
        }
    }

    static Match CreateMatch(string teamInfo1, string teamInfo2)
    {
        var teamInfoSubs1 = teamInfo1.Split(' ');
        var teamInfoSubs2 = teamInfo2.Split(' ');
        var team1 = CreateTeam(teamInfoSubs1);
        var team2 = CreateTeam(teamInfoSubs2);

        return new Match
        {
            TeamName1 = team1.Name,
            GoalsTeam1 = team1.Goals,
            ScoreTeam1 = GetGameScore(team1.Goals, team2.Goals),
            TeamName2 = team2.Name,
            GoalsTeam2 = team2.Goals,
            ScoreTeam2 = GetGameScore(team2.Goals, team1.Goals),
            GameDate = DateTime.Now
        };
    }

    static Team CreateTeam(string[] teamInfo)
    {
        var team = new Team
        {
            Name = string.Join(" ", teamInfo.Take(teamInfo.Length - 1)),
            Goals = int.Parse(teamInfo.Last())
        };

        return team;
    }

    static int GetGameScore(int goals1, int goals2) => goals1 > goals2 ? 3 : goals1 == goals2 ? 1 : 0;

    static List<Statistic> Stats(List<Match> matches)
    {
        var stats = new List<Statistic>();

        foreach (var match in matches)
        {
            UpdateStats(stats, match.TeamName1, match.ScoreTeam1);
            UpdateStats(stats, match.TeamName2, match.ScoreTeam2);
        }

        return stats;
    }

    static void UpdateStats(List<Statistic> stats, string teamName, int score)
    {
        var existingStat = stats.FirstOrDefault(stat => stat.Name == teamName);
        
        if (existingStat != null)
        {
            existingStat.Points += score;
        }
        else
        {
            stats.Add(new Statistic { Name = teamName, Points = score });
        }
    }
}
