namespace MobileCW1;

public partial class HikeList : ContentPage
{
    SQLiteDatabase db;
    public HikeList()
	{
		InitializeComponent();
        db = new SQLiteDatabase();
        var hikeList = db.getHikeList();
		hikesCollectionView.ItemsSource = hikeList;
	}

    private void EditHikeClick(object sender, EventArgs e)
    {
        // Get the selected hike from the button's BindingContext
        var selectedHike = (Hike)((Button)sender).BindingContext;

        // Navigate to the edit page with the selected hike data and its ID
        Navigation.PushAsync(new EditHike(selectedHike.Id), true);
    }

    private async void DeleteHikeClick(object sender, EventArgs e)
    {
        var selectedHike = (Hike)((Button)sender).BindingContext;
        var response = await DisplayAlert("Confirmation", "You are going to delete this hike", "OK", "Cancel");
        if (response)
        {
            db.deleteHike(selectedHike);
        }

    }

    private async void DeleteAllClick (object sender, EventArgs e)
    {
        var request = await DisplayAlert("Confirmation", "You are going to delete all of the hikes.", "OK", "Cancel");
        if (request)
        {
            db.deleteAllHike();
            _ = DisplayAlert("Information", "All of hikes have been deleted", "OK");
            await Navigation.PopToRootAsync();
        }
    }
}