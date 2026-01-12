using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using Lab5.MAUIData.Interfaces;
using Lab5.MAUIData.Models;

namespace Lab5.MAUI.ViewModels;

public class MainPageViewModel : ViewModelBase
{
    private readonly IDataRepository _dataRepository;

    public MainPageViewModel(IDataRepository dataRepository)
    {
        Title = "Loading ...";
        _dataRepository = dataRepository;

        LoadCommand = new RelayCommand(LoadData);
        //SelectDepartmentCommand = new RelayCommand(ShowDetails);

        LoadData();
    }

    public MainPageViewModel()
    {
    }

    public async void ShowDetails()
    {
        var navigationParameter = new ShellNavigationQueryParameters
        {
            { "Department", SelectedDepartment }
        };

        await Shell.Current.GoToAsync("//EmployeesPage", navigationParameter);
    }

    private string _title;

    public string Title
    {
        get => _title;
        set
        {
            _title = value;
            OnPropertyChanged();
        }
    }

    private Department[] _departments;

    public Department[] Departments
    {
        get => _departments;
        set
        {
            _departments = value;
            OnPropertyChanged();
        }
    }

    private Department _selectedDepartment;

    public Department SelectedDepartment
    {
        get => _selectedDepartment;
        set
        {
            _selectedDepartment = value;
            OnPropertyChanged();

            if (value != null)
            {
                ShowDetails();
            }
        }
    }

    public ICommand LoadCommand { get; }

    public ICommand SelectDepartmentCommand { get; }

    public async void LoadData()
    {
        Title = "Loading ...";

        var data = await _dataRepository.GetDepartmentsAsync();
        Departments = data;
        Title = "Number of departments: " + data.Length;
    }
}
