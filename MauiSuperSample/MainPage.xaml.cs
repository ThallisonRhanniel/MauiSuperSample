using MauiSuperSample.View;

namespace MauiSuperSample
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnCounterClicked(object sender, EventArgs e)
        {
            await GoBackAsync();
            SemanticScreenReader.Announce(CounterBtn.Text);
        }

        async Task GoBackAsync()
        {
            //..?id=1 //Passa um parametro de volta para pagina
            //../DetailsPAge //Ele volta e depois navega para essa pagina
            //".." //Volta uma pagina
            //../.. //Volta duas paginas
            await Shell.Current.GoToAsync(nameof(View1), true, new Dictionary<string, object>
            {
                {"TaskStatusName", "started" }
            });
        }
    }
}