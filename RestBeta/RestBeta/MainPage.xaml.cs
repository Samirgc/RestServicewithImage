using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RestBeta
{
    public class play
    {
        public int albumId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public string url { get; set; }
        public string thumbnailUrl { get; set; }
    }
    public partial class MainPage : ContentPage
    {
        private const string Url = "https://jsonplaceholder.typicode.com/photos";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<play> _post;
        public MainPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            string content = await client.GetStringAsync(Url);
            List<play> posts = JsonConvert.DeserializeObject<List<play>>(content);
            _post = new ObservableCollection<play>(posts);
            MyListView.ItemsSource = _post;
            base.OnAppearing();
        }
    }
}