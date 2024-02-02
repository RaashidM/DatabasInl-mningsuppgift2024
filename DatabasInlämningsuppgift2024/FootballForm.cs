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

            // Add this line to wire up the event handler
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

            // Get match details for the selected match
            MatchDetails matchDetails = matchDetailsDictionary[selectedMatch.Id];

            // Clear existing items in matchDetailsListBox
            matchDetailsListBox.Items.Clear();

            // Display match details in matchDetailsListBox
            matchDetailsListBox.Items.Add($"Home Team: {matchDetails.HomeTeam}");
            matchDetailsListBox.Items.Add($"Away Team: {matchDetails.AwayTeam}");
            matchDetailsListBox.Items.Add($"Stadium: {matchDetails.Stadium}");
            matchDetailsListBox.Items.Add($"Result: {matchDetails.Result}");
            matchDetailsListBox.Items.Add($"Attendance: {matchDetails.Attendance}");
        }





        private void searchButton_Click(object sender, EventArgs e)
        {

        }

        private void updateButton_Click(object sender, EventArgs e)
        {

        }

        private void deleteButton_Click(object sender, EventArgs e)
        {

        }

        private void UpdateMatchBox()
{
         matchListBox.Items.Clear();

         foreach (Match match in matches.Values.ToList())
         {
             matchListBox.Items.Add("Match: " + match.Id + " Date: " + match.MatchDate + " Attendance: " + match.Attendance + " People");
         }
         
         matchListBox.Refresh();
         teamInfo.Text = "";
}
        
    }
}
