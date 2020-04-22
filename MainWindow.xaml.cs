using SpotifyFinder.Data;
using SpotifyFinder.db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SpotifyFinder {
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        HttpGrabber http = new HttpGrabber();
        IDbConnector db = new DbConnector();

        public MainWindow( ) {
            InitializeComponent();
            db.Add("Ciekawe czy to dziala?");
        }

        private void OnWindowLoaded( object sender, RoutedEventArgs e ) {

            //GetData();
        }

        private async Task GetData( string search ) {
            var data = await http.MakeStringGreatAgain(search);
            DataList.ItemsSource = data.playlists.items;
        }

        private void SearchBox_OnKeyUp( object sender, KeyEventArgs e ) {
            string search = searchBox.Text;
            GetData(search);
        }

        private bool TimeBetweenKeyUp(int time, string search ) {
            var searchAfterTime = false;

            return searchAfterTime;
        }

    }
}
