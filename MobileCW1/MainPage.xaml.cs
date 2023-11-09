using System.Collections.ObjectModel;

namespace MobileCW1
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        App thisApp = Microsoft.Maui.Controls.Application.Current as App;
        private SQLiteDatabase db;
        public MainPage()
        {
            InitializeComponent();

            thisApp.HikeList = new ObservableCollection<Hike>();
            db = new SQLiteDatabase();
        }

        private async void OnSubmitClicked(object sender, EventArgs e)
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
                var response = await DisplayAlert("Confirmation", "Do you want to submit?", "OK", "Cancel");
                if (response)
                {
                    Hike hike = new Hike(count++, name, location, date, isParkingAvailable, length, difficulty, description);
                    thisApp.HikeList.Add(hike);
                    db.insertHike(hike);
                    await DisplayAlert("Information", "A new hike has been added", "OK");
                }
            }
        }

        private void OnViewDetailsClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new HikeList(), true);
        }
    }
}