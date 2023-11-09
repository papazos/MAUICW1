namespace MobileCW1
{
    public partial class EditHike : ContentPage
    {
        private SQLiteDatabase _db;
        private int target;

        public EditHike(int hikeId)
        {
            InitializeComponent();
            target = hikeId;
            _db = new SQLiteDatabase();

            Hike hike = _db.getHike(hikeId);

            hikeName.Text = hike.Name;
            hikeLocation.Text = hike.Location;
            parkingAvailable.IsToggled = hike.ParkingAvailable;
            hikeDate.Date = hike.Date;
            hikeLength.Text = hike.Length;
            hikeDifficulty.SelectedItem = hike.Difficulty;
            hikeDescription.Text = hike.Description;
        }

        private async void OnUpdateCheck(object sender, EventArgs e)
        {
            string name = hikeName.Text;
            string location = hikeLocation.Text;
            bool isParkingAvailable = parkingAvailable.IsToggled;
            DateTime date = hikeDate.Date;
            string length = hikeLength.Text;
            string difficulty = hikeDifficulty.SelectedItem?.ToString();
            string description = hikeDescription.Text;

            if (string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(location) ||
                string.IsNullOrWhiteSpace(length) ||
                string.IsNullOrWhiteSpace(difficulty) ||
                string.IsNullOrWhiteSpace(description))
            {
                await DisplayAlert("Error", "Please fill in all the required fields.", "OK");
            }
            else
            {
                // Create a new Hike object with the edited data
                Hike updatedHike = new Hike(target, name, location, date, isParkingAvailable, length, difficulty, description);

                // Update the Hike in the database
                _db.updateHike(updatedHike);

                await DisplayAlert("Information", "Hike updated successfully", "OK");

                // Return to the previous page
                await Navigation.PushAsync(new HikeList(), true);
            }
        }
    }
}
