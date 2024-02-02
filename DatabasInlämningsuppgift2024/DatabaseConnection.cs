using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabasInlämningsuppgift2024
{
    public class DatabaseConnection
    {
        string server = "localhost";
        string database = "databasInlämning2024";
        string username = "root";
        string password = "Raashido99";

        string connectionString = "";
        

        public DatabaseConnection()
        {
            connectionString = "SERVER=" + server + ";" +
                               "DATABASE=" + database + ";" +
                               "UID=" + username + ";" +
                               "PASSWORD=" + password + ";";
           
            
        }

        public Dictionary<int, Player> GetFootball()
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
            return players;
        }

        



    }
}
