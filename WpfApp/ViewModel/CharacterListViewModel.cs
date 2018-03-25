using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.ViewModel
{
    class CharacterListViewModel : ViewModelBase
    {

        public event EventHandler<EventArgs> CloseNotified;

        protected void OnCloseNotified(EventArgs e)
        {
            this.CloseNotified(this, e);
        }

        private ObservableCollection<CharacterViewModel> _characters;

        public ObservableCollection<CharacterViewModel> Characters {
            get{ return _characters;}
            private set
            {
                _characters = value;
                base.OnPropertyChanged("Characters");
            }
        }


        private CharacterViewModel _selectedItem;

        public CharacterViewModel SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                OnPropertyChanged("SelectedItem");
            }

        }

        public CharacterListViewModel()
        {
            _characters = new ObservableCollection<CharacterViewModel>();
            this.populateWithApi();




        }


        public async void populateWithApi()
        {

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
                            _characters.Add(new CharacterViewModel(item));
                           // _liste.Add(new GeneralObservable(item.Id, item.FirstName, item.LastName));
                        }
                    }
                }
            }
            catch (Exception ex) { }

            //listeAffichage.ItemsSource = _liste;
            //listeAffichage.SelectedIndex = 0;
        }

        public CharacterListViewModel ( List<CharacterModel> characModel)
        {
            _characters = new ObservableCollection<CharacterViewModel>();
            foreach(CharacterModel a in characModel)
            {
                _characters.Add(new CharacterViewModel(a));
            }
        }

        private RelayCommand _addCommand;
        private RelayCommand _suppCommand;

        public System.Windows.Input.ICommand AddCommand
        {
            get
            {
                if(_addCommand == null)
                {
                    _addCommand = new RelayCommand(() => this.Add(),
                                                    () => this.CanAdd());
                }
                return _addCommand;
            }
        }

        public System.Windows.Input.ICommand SuppCommand
        {
            get
            {
                if (_suppCommand == null)
                {
                    _suppCommand = new RelayCommand(() => this.Supp(),
                                                    () => this.CanSupp());
                }
                
                return _suppCommand;
            }
        }

        public void Supp()
        {
           
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:54197/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.DeleteAsync("api/Character/" + SelectedItem.Character.Id).Result;
            _characters.Remove(this.SelectedItem);

        }

        public Boolean CanSupp()
        {
            return true;
        }

        public void Add()
        {
            CharacterModel m = new CharacterModel("<new>", "<new>",0);
            this.SelectedItem = new CharacterViewModel(m);
            _characters.Add(this.SelectedItem);

        }

        public Boolean CanAdd()
        {
            return true;
        }
    }
}
