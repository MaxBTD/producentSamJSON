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
            var Items =
            HttpClient client = new HttpClient();
            string URL = "https://vpic.nhtsa.dot.gov/api/vehicles/getmodelsformake/saab?format=json";
            HttpResponseMessage response = await client.GetAsync(URL);
            if (response.IsSuccessStatusCode)
            {
                content = await response.Content.ReadAsStringAsync();
                
            }
            lblDane.Text = content;
             //Models modelOutput = JsonSerializer.Deserialize();
        }
    }

}
