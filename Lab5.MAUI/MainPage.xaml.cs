using Lab5.MAUI.ViewModels;

namespace Lab5.MAUI;

public partial class MainPage : ContentPage
{
    private MainPageViewModel _viewModel;

    public MainPage(MainPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
        _viewModel = viewModel;
    }
}
