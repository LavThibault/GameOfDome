using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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

namespace WpfApp
{
    /// <summary>
    /// Logique d'interaction pour Home.xaml
    /// </summary>
    public partial class Home : Page
    {
        public Home()
        {
            InitializeComponent();
        }

        private System.Collections.ObjectModel.ObservableCollection<GeneralObservable> _liste;

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            detailPane.Children.Clear();
            CharacterDetail cd = new CharacterDetail();
            detailPane.Children.Add(cd);

            _liste = new System.Collections.ObjectModel.ObservableCollection<GeneralObservable>();
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:54197");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.GetAsync("api/character");
                    if (response.IsSuccessStatusCode)
                    {
                        string temp = await response.Content.ReadAsStringAsync();
                        IEnumerable<CharacterModel> characList = new List<CharacterModel>();
                        characList = JsonConvert.DeserializeObject<IEnumerable<CharacterModel>>(temp);
                        foreach (CharacterModel item in characList)
                        {
                            _liste.Add(new GeneralObservable(item.Id, item.FirstName, item.LastName));
                        }
                    }
                }
            }
            catch (Exception ex) { }








            listeAffichage.ItemsSource = _liste;
            listeAffichage.SelectedIndex = 0;
        }

        private void listeAffichage_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void listeAffichage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            detailPane.DataContext = listeAffichage.SelectedItem;
            /*WindowCharacterDetail w = new WindowCharacterDetail();
            
            w.Show();*/
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            detailPane.Children.Clear();
            HouseDetail cd = new HouseDetail();
            detailPane.Children.Add(cd);

            _liste = new System.Collections.ObjectModel.ObservableCollection<GeneralObservable>();
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:54197");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.GetAsync("api/house");
                    if (response.IsSuccessStatusCode)
                    {
                        string temp = await response.Content.ReadAsStringAsync();
                        IEnumerable<HouseModel> characList = new List<HouseModel>();
                        characList = JsonConvert.DeserializeObject<IEnumerable<HouseModel>>(temp);
                        foreach (HouseModel item in characList)
                        {
                            _liste.Add(new GeneralObservable(item.Id, item.Name, item.Gold.ToString(), item.NumberOfUnities.ToString()));
                        }
                    }
                }
            }
            catch (Exception ex) { }








            listeAffichage.ItemsSource = _liste;
            listeAffichage.SelectedIndex = 0;
        }
    }
}
