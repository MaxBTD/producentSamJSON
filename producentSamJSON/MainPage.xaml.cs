using System.Text.Json;

namespace producentSamJSON
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public class Models
        {
            public int Make_ID { get; set; }
            public string? Make_Name { get; set; }
            public int Model_ID { get; set; }
            public string? Model_Name { get; set; }
        }
        public class Output
        {
            public int Count { get; set; }
            public string? Message { get; set; }
            public string? StringCriteria { get; set; }
            public List<Models> Results { get; set; }
        }


        private async void onDataDownloadClicked(object sender, EventArgs e)
        {
            string content = "";
            Output items = new Output();
            HttpClient client = new HttpClient();
            string URL = $"https://vpic.nhtsa.dot.gov/api/vehicles/getmodelsformake/{entMarka.Text}?format=json";

            HttpResponseMessage response = await client.GetAsync(URL);
            if (response.IsSuccessStatusCode)
            {
                content = await response.Content.ReadAsStringAsync();
                items = JsonSerializer.Deserialize<Output>(content);
            }

            if (items.Results != null)
            {
                lblDane.Text = $"Marka: {items.Results[0].Make_Name} (id: {items.Results[0].Make_ID}) \n\nModele:\n";
                foreach (Models model in items.Results)
                {
                    lblDane.Text += $"{model.Model_Name} (id: {model.Model_ID}) \n";
                }
            }
            else
            {
                lblDane.Text = "Nazwa marki nie poprawnie wpisana";
            }
            
        }
    }

}
