using MauiSuperSample.View;

namespace MauiSuperSample
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(View1), typeof(View1));
            Routing.RegisterRoute(nameof(View2), typeof(View2));
        }
    }
}