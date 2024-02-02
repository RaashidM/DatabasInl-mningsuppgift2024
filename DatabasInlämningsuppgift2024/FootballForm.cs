namespace DatabasInlämningsuppgift2024
{
    public partial class Form1 : Form
    {
        DatabaseConnection databaseConnection = new DatabaseConnection();
        Dictionary<int, Player> players = new Dictionary<int, Player>();
        public Form1()
        {
            InitializeComponent();
            players = databaseConnection.GetFootball();
        }

        private void matchListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

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
    }
}
