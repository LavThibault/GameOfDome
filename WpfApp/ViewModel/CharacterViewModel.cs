using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;


namespace WpfApp.ViewModel
{
    class CharacterViewModel : ViewModelBase
    {
        private CharacterModel _character;

        public CharacterModel Character
        {
            get { return _character; }
            private set { _character = value;}
        }

        public CharacterViewModel ( CharacterModel m)
        {
            _character = m;
        }

        public String FirstName
        {
            get { return _character.FirstName; }
            set
            {
                if (_character.FirstName == value) return;
                _character.FirstName = value;
                base.OnPropertyChanged("FirstName");
            }
        }

        public String LastName
        {
            get { return _character.LastName; }
            set
            {
                if (_character.LastName == value) return;
                _character.LastName = value;
                base.OnPropertyChanged("LastName");
            }
        }

        private RelayCommand _validCommand;

        public System.Windows.Input.ICommand ValidateCommand
        {
            get
            {
                if (_validCommand == null)
                {
                    _validCommand = new RelayCommand(() => this.Validate(), () => this.CanValidate());
                }
                return _validCommand;
            }
        }

        private void Validate()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:54197/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.PostAsync("api/Character", new StringContent(new JavaScriptSerializer().Serialize(new CharacterDto(_character.Id,_character.FirstName,_character.LastName)), Encoding.UTF8, "application/json")).Result;
            
        }

        private bool CanValidate()
        {
            return true;
        }

        
       
    }
}
