using Lab5.MAUIData.Models;
using Lab5.MAUI.ViewModels;

namespace Lab5.MAUI;

[QueryProperty(nameof(Department), "Department")]
public partial class EmployeesPage : ContentPage
{
    private EmployeesPageViewModel _viewModel;

    Department department;
    public Department Department
    {
        get => department;
        set
        {
            department = value;
            _viewModel.Department = value;
            OnPropertyChanged();
        }
    }

    public EmployeesPage(EmployeesPageViewModel viewModel)
    {
        InitializeComponent();

        _viewModel = viewModel;
        BindingContext = _viewModel;
    }
}
