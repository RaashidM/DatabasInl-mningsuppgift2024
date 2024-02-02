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
            string searchTerm = searchBox.Text.Trim();

            if (int.TryParse(searchTerm, out int searchMatchId))
            {
                // Filter matches based on the search matchId
                var filteredMatches = matches.Values
                    .Where(match => match.Id == searchMatchId)
                    .ToList();

                // Update the matchListBox with filtered matches
                UpdateMatchBox(filteredMatches);
            }
            else
            {
                MessageBox.Show("Please enter a valid match ID.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {

        }

        private void deleteButton_Click(object sender, EventArgs e)
        {

        }

        private void UpdateMatchBox(IEnumerable<Match> filteredMatches = null)
        {
            matchListBox.Items.Clear();

            if (filteredMatches == null)
            {
                // If no filtered matches provided, use all matches
                foreach (Match match in matches.Values.ToList())
                {
                    matchListBox.Items.Add($"Match {match.Id} Date: {match.MatchDate} Attendance: {match.Attendance} People");
                }
            }
            else
            {
                // Use filtered matches
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
