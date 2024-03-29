namespace DatabasInlämningsuppgift2024
{
    public partial class Form1 : Form
    {
        DatabaseConnection databaseConnection = new DatabaseConnection();
        Dictionary<int, Match> matches = new Dictionary<int, Match>();
        Dictionary<int, MatchDetails> matchDetailsDictionary = new Dictionary<int, MatchDetails>();
        public Form1()
        {
            InitializeComponent();

            matches = databaseConnection.GetMatches();
            matchDetailsDictionary = databaseConnection.GetMatchDetails();
            UpdateMatchBox();

            
            matchListBox.SelectedIndexChanged += matchListBox_SelectedIndexChanged;
        }




        private void matchListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = matchListBox.SelectedIndex;
            Console.WriteLine($"Selected Index: {selectedIndex}");

            if (selectedIndex == -1)
            {
                teamInfo.Text = "";
                return;
            }

            Match selectedMatch = matches.Values.ToList()[selectedIndex];
            Console.WriteLine($"Selected Match ID: {selectedMatch.Id}");

            if (selectedMatch.Team != null)
            {
                teamInfo.Text = selectedMatch.Team.GetInfo();
            }

            
            MatchDetails matchDetails = matchDetailsDictionary[selectedMatch.Id];

           
            matchDetailsListBox.Items.Clear();

            
            matchDetailsListBox.Items.Add($"Home Team: {matchDetails.HomeTeam}");
            matchDetailsListBox.Items.Add($"Away Team: {matchDetails.AwayTeam}");
            matchDetailsListBox.Items.Add($"Stadium: {matchDetails.Stadium}");
            matchDetailsListBox.Items.Add($"Result: {matchDetails.Result}");
            matchDetailsListBox.Items.Add($"Attendance: {matchDetails.Attendance}");
        }





        private void searchButton_Click(object sender, EventArgs e)
        {
            
            if (int.TryParse(searchBox.Text, out int searchedMatchId))
            {
                
                matchListBox.Items.Clear();
                matchDetailsListBox.Items.Clear();

                
                Match searchedMatch = matches.Values.FirstOrDefault(match => match.Id == searchedMatchId);

                if (searchedMatch != null)
                {
                   
                    matchListBox.Items.Add($"Match: {searchedMatch.Id} Date: {searchedMatch.MatchDate} Attendance: {searchedMatch.Attendance} People");

                  
                    MatchDetails matchDetails = matchDetailsDictionary[searchedMatch.Id];

                   
                    matchDetailsListBox.Items.Add($"Home Team: {matchDetails.HomeTeam}");
                    matchDetailsListBox.Items.Add($"Away Team: {matchDetails.AwayTeam}");
                    matchDetailsListBox.Items.Add($"Stadium: {matchDetails.Stadium}");
                    matchDetailsListBox.Items.Add($"Result: {matchDetails.Result}");
                    matchDetailsListBox.Items.Add($"Attendance: {matchDetails.Attendance}");
                }
                else
                {
                   
                    MessageBox.Show($"No match found with Match ID: {searchedMatchId}");
                }
            }
            else
            {
                
                MessageBox.Show("Please enter a valid Match ID");
            }
        }


        private void updateButton_Click(object sender, EventArgs e)
        {
           
            int selectedIndex = matchListBox.SelectedIndex;

            if (selectedIndex == -1)
            {
                MessageBox.Show("Please select a match to update.", "No Match Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            Match selectedMatch = matches.Values.ToList()[selectedIndex];
            int matchIdToUpdate = selectedMatch.Id;

            
            string newMatchDateText = updateBox.Text.Trim();

            if (DateTime.TryParse(newMatchDateText, out DateTime newMatchDate))
            {
               
                selectedMatch.MatchDate = newMatchDate;

                
                UpdateMatchBox();

                
                databaseConnection.UpdateMatchDate(matchIdToUpdate, newMatchDate);
            }
            else
            {
                MessageBox.Show("Please enter a valid date in the format yyyy-MM-dd HH:mm:ss.", "Invalid Date Format", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            
            int selectedIndex = matchListBox.SelectedIndex;

            if (selectedIndex == -1)
            {
                MessageBox.Show("Please select a match to delete.", "No Match Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            Match selectedMatch = matches.Values.ToList()[selectedIndex];
            int matchIdToDelete = selectedMatch.Id;

           
            matches.Remove(matchIdToDelete);

           
            UpdateMatchBox();

            
            databaseConnection.DeleteMatch(matchIdToDelete);
        }


        private void UpdateMatchBox(IEnumerable<Match> filteredMatches = null)
        {
            matchListBox.Items.Clear();

            if (filteredMatches == null)
            {
                
                foreach (Match match in matches.Values.ToList())
                {
                    matchListBox.Items.Add($"Match {match.Id} Date: {match.MatchDate} Attendance: {match.Attendance} People");
                }
            }
            else
            {
               
                foreach (Match match in filteredMatches)
                {
                    matchListBox.Items.Add($"Match {match.Id} Date: {match.MatchDate} Attendance: {match.Attendance} People");
                }
            }

            matchListBox.Refresh();
            teamInfo.Text = "";
        }

    }
}
