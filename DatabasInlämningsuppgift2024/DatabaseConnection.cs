using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DatabasInlämningsuppgift2024
{
    public class DatabaseConnection
    {
        string server = "localhost";
        string database = "databasInlämning2024";
        string username = "user1";
        string password = "password";

        string connectionString = "";


        public DatabaseConnection()
        {
            connectionString = "SERVER=" + server + ";" +
                               "DATABASE=" + database + ";" +
                               "UID=" + username + ";" +
                               "PASSWORD=" + password + ";";


        }

        public Dictionary<int, Match> GetMatches()
        {
            Dictionary<int, Player> players = new Dictionary<int, Player>();
            Dictionary<int, Team> teams = new Dictionary<int, Team>();
            Dictionary<int, Stadium> stadiums = new Dictionary<int, Stadium>();
            Dictionary<int, Match> matches = new Dictionary<int, Match>();

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            string querey = "SELECT * FROM team;";

            MySqlCommand command = new MySqlCommand(querey, connection);

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Team team = new Team((int)reader["team_id"], (string)reader["team_name"],
                                     (int)reader["founded_year"], (string)reader["coach"]);
                teams.Add(team.Id, team);
            }
            reader.Close();

            querey = "SELECT * FROM stadium;";

            command = new MySqlCommand(querey, connection);
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                Stadium stadium = new Stadium((int)reader["stadium_id"], (string)reader["stadium_name"], (int)reader["capacity"],
                                             (string)reader["city"]);
                stadiums.Add(stadium.Id, stadium);
            }

            reader.Close();


            querey = "SELECT * FROM player;";

            command = new MySqlCommand(querey, connection);

            reader = command.ExecuteReader();

            while (reader.Read())
            {
                Team team = teams[(int)reader["team_id"]];
                Player player = new Player((int)reader["player_id"], (string)reader["player_name"], (int)reader["age"],
                                          (string)reader["nationality"], (string)reader["position"]);

                team.Players.Add(player);
                players.Add(player.Id, player);
            }

            reader.Close();

            querey = "SELECT * FROM match1;";

            command = new MySqlCommand(querey, connection);
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                Stadium stadium = stadiums[(int)reader["stadium_id"]];
                Match match = new Match((int)reader["match_id"], (DateTime)reader["match_date"], (int)reader["attendance"]);

                stadium.Games.Add(match);
                matches.Add(match.Id, match);
            }

            reader.Close();

            querey = "SELECT * FROM team_has_match;";

            command = new MySqlCommand(querey, connection);
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                int teamId = (int)reader["team_id"];
                int matchId = (int)reader["match_id"];

                Team aTeam = teams[teamId];
                Match aMatch = matches[matchId];

                TeamHasMatch teamHasMatch = new TeamHasMatch((bool)reader["is_hometeam"],
                             (string)reader["result"], aTeam, aMatch);

                aTeam.Matches.Add(teamHasMatch);
                aMatch.Matches.Add(teamHasMatch);
            }


            connection.Close();
            return matches;
        }
        public Dictionary<int, MatchDetails> GetMatchDetails()
        {
            Dictionary<int, MatchDetails> matchDetails = new Dictionary<int, MatchDetails>();

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            string query = @"
                           SELECT
                               team_has_match.match_id,
                               MAX(CASE WHEN team_has_match.is_hometeam = TRUE THEN team.team_name END) AS home_team,
                               MAX(CASE WHEN team_has_match.is_hometeam = FALSE THEN away_team.team_name END) AS away_team,
                               stadium.stadium_name,
                               MAX(team_has_match.result) AS result,
                               match1.attendance
                           FROM
                               team_has_match
                           JOIN
                               match1 ON team_has_match.match_id = match1.match_id
                           LEFT JOIN
                               team ON team_has_match.team_id = team.team_id AND team_has_match.is_hometeam = TRUE
                           LEFT JOIN
                               team away_team ON team_has_match.team_id = away_team.team_id AND team_has_match.is_hometeam = FALSE
                           JOIN
                               stadium ON match1.stadium_id = stadium.stadium_id
                           GROUP BY
                               team_has_match.match_id, stadium.stadium_name, match1.attendance;
                       ";

            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                MatchDetails details = new MatchDetails
                {
                    MatchId = (int)reader["match_id"],
                    HomeTeam = (string)reader["home_team"],
                    AwayTeam = (string)reader["away_team"],
                    Stadium = (string)reader["stadium_name"],
                    Result = (string)reader["result"],
                    Attendance = (int)reader["attendance"]
                };

                matchDetails.Add(details.MatchId, details);
            }

            connection.Close();
            return matchDetails;
        }

        public void UpdateMatchDate(int matchId, DateTime newMatchDate)
        {
            string updateQuery = "UPDATE match1 SET match_date = @newMatchDate WHERE match_id = @matchId";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                using (MySqlCommand command = new MySqlCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@newMatchDate", newMatchDate);
                    command.Parameters.AddWithValue("@matchId", matchId);

                    int rowsAffected = command.ExecuteNonQuery();

                    
                   
                }

            }
        }

        public void DeleteMatch(int matchId)
        {
            
            string deleteTeamHasMatchQuery = "DELETE FROM team_has_match WHERE match_id = @matchId";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                using (MySqlCommand command = new MySqlCommand(deleteTeamHasMatchQuery, connection))
                {
                    command.Parameters.AddWithValue("@matchId", matchId);

                    int rowsAffectedTeamHasMatch = command.ExecuteNonQuery();

                  
                }
            }

           
            string deleteMatchQuery = "DELETE FROM match1 WHERE match_id = @matchId";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                using (MySqlCommand command = new MySqlCommand(deleteMatchQuery, connection))
                {
                    command.Parameters.AddWithValue("@matchId", matchId);

                    int rowsAffectedMatch = command.ExecuteNonQuery();

                   
                }
            }
        }

    }


}

