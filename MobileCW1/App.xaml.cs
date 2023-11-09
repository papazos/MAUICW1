using System.Collections.ObjectModel;

namespace MobileCW1
{
    public partial class App : Application
    {
        public ObservableCollection<Hike> HikeList;
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}