using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Pokemon
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Pokemon> PokeList { get; } = new ObservableCollection<Pokemon>
        {   
        };

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;

        }

        public async void LoadPokemon()
        {
            foreach(var pokemon in await GetPokemon.Get()){
                PokeList.Add(pokemon);
            }
        }

        private List<string> PokeNameValue;
        public List<string> PokeName
        {
            get => PokeNameValue;
            set
            {
                PokeNameValue = value;
                OnPropertyChanged(nameof(PokeName));
            }
        }

        private void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public event PropertyChangedEventHandler PropertyChanged;

        private void Button_Clicked(object sender, EventArgs e)
        {

        }
        private void LoadPokemons(object sender, EventArgs e)
        {
            LoadPokemon();
        }

        private async void DetailEvent(object s, SelectedItemChangedEventArgs e)
        {
            var pokemon = (Pokemon)e.SelectedItem;
            var detailPage = new Details();
            detailPage.BindingContext = pokemon;
            await Navigation.PushAsync(detailPage);
        }
    }
}
