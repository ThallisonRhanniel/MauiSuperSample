using MauiSuperSample.Viewmodel;

namespace MauiSuperSample.View;

public partial class View1 : ContentPage
{
	public View1(View1ViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}