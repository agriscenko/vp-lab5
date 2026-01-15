using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using Lab5.MAUIData.Interfaces;
using Lab5.MAUIData.Models;

namespace Lab5.MAUI.ViewModels;

public class EmployeesPageViewModel : ViewModelBase
{
    private readonly IDataRepository _dataRepository;

    public EmployeesPageViewModel()
    {
    }

    public EmployeesPageViewModel(IDataRepository dataRepository)
    {
        _dataRepository = dataRepository;

        DeleteCommand = new RelayCommand(DeleteEmployee);
        //SelectEmployeeCommand = new RelayCommand(EmployeeSelected);

        DeleteConfirmCommand = new RelayCommand(ConfirmDeleteEmployee);
        DeleteCancelCommand = new RelayCommand(CancelDeleteEmployee);

        EditDepartmentCommand = new RelayCommand(EditDepartmentDetails);

        UpdateConfirmCommand = new RelayCommand(ConfirmUpdateDepartment);
        UpdateCancelCommand = new RelayCommand(CancelUpdateDepartment);

        ValidateCommand = new RelayCommand(ValidateDepartment);

        IsEditEnabled = false;
        IsReadOnly = !IsEditEnabled;
    }

    private void ValidateDepartment()
    {
        IsDepartmentDataValid();
    }

    Department department;
    public Department Department
    {
        get => department;
        set
        {
            department = value;

            IsDeleteEnabled = false;
            Employees = Array.Empty<Employee>();

            OnPropertyChanged();

            LoadData();
        }
    }

    private Employee[] _employees;

    public Employee[] Employees
    {
        get => _employees;
        set
        {
            _employees = value;
            OnPropertyChanged();
        }
    }

    public async Task LoadData()
    {
        var data = await _dataRepository.GetDepartmentEmployeesAsync(Department.Id);
        Employees = data;
    }

    public ICommand DeleteCommand { get; }

    public ICommand SelectEmployeeCommand { get; }

    public ICommand DeleteConfirmCommand { get; }

    public ICommand DeleteCancelCommand { get; }

    public ICommand EditDepartmentCommand { get; }

    public ICommand UpdateConfirmCommand { get; }

    public ICommand UpdateCancelCommand { get; }

    public ICommand ValidateCommand { get; }

    public void DeleteEmployee()
    {
        IsDeleteConfirmationVisible = true;
    }

    public void EmployeeSelected()
    {
        IsDeleteEnabled = true;
    }

    public void EditDepartmentDetails()
    {
        IsEditEnabled = true;
        IsReadOnly = !IsEditEnabled;
    }

    private Employee _selectedEmployee;
    public Employee SelectedEmployee
    {
        get
        {
            return _selectedEmployee;
        }
        set
        {
            _selectedEmployee = value;
            OnPropertyChanged();

            if (value is null) return;

            EmployeeSelected();
        }
    }

    private bool _isDeleteEnabled;
    public bool IsDeleteEnabled
    {
        get
        {
            return _isDeleteEnabled;
        }
        set
        {
            _isDeleteEnabled = value;
            OnPropertyChanged();
        }
    }

    private bool _isDeleteConfirmationVisible;
    public bool IsDeleteConfirmationVisible
    {
        get
        {
            return _isDeleteConfirmationVisible;
        }
        set
        {
            _isDeleteConfirmationVisible = value;
            OnPropertyChanged();
        }
    }

    private bool _isEditEnabled;
    public bool IsEditEnabled
    {
        get
        {
            return _isEditEnabled;
        }
        set
        {
            _isEditEnabled = value;
            OnPropertyChanged();
        }
    }

    private bool _isReadOnly;
    public bool IsReadOnly
    {
        get
        {
            return _isReadOnly;
        }
        set
        {
            _isReadOnly = value;
            OnPropertyChanged();
        }
    }

    private bool _isCodeInvalid;
    public bool IsCodeInvalid
    {
        get
        {
            return _isCodeInvalid;
        }
        set
        {
            _isCodeInvalid = value;
            OnPropertyChanged();
        }
    }

    private bool _isNameInvalid;
    public bool IsNameInvalid
    {
        get
        {
            return _isNameInvalid;
        }
        set
        {
            _isNameInvalid = value;
            OnPropertyChanged();
        }
    }

    private bool _isFloorNumberInvalid;
    public bool IsFloorNumberInvalid
    {
        get
        {
            return _isFloorNumberInvalid;
        }
        set
        {
            _isFloorNumberInvalid = value;
            OnPropertyChanged();
        }
    }

    private bool _isPhoneNumberInvalid;
    public bool IsPhoneNumberInvalid
    {
        get
        {
            return _isPhoneNumberInvalid;
        }
        set
        {
            _isPhoneNumberInvalid = value;
            OnPropertyChanged();
        }
    }

    private bool _isEmailInvalid;
    public bool IsEmailInvalid
    {
        get
        {
            return _isEmailInvalid;
        }
        set
        {
            _isEmailInvalid = value;
            OnPropertyChanged();
        }
    }

    private void CancelDeleteEmployee()
    {
        IsDeleteConfirmationVisible = false;
    }

    private async void ConfirmDeleteEmployee()
    {
        await _dataRepository.DeleteEmployee(SelectedEmployee.Id);
        IsDeleteConfirmationVisible = false;
        IsDeleteEnabled = false;

        await LoadData();
    }

    private void CancelUpdateDepartment()
    {
        IsEditEnabled = false;
        IsReadOnly = !IsEditEnabled;
    }

    private async void ConfirmUpdateDepartment()
    {
        if (!IsDepartmentDataValid())
        {
            return;
        }

        await _dataRepository.UpdateDepartmentAsync(Department);

        OnPropertyChanged(nameof(Department));

        IsEditEnabled = false;
        IsReadOnly = !IsEditEnabled;
    }

    private bool IsDepartmentDataValid()
    {
        IsCodeInvalid = string.IsNullOrEmpty(Department.Code) || Department.Code.Length != 2;
        IsNameInvalid = string.IsNullOrEmpty(Department.Name);
        IsFloorNumberInvalid = Department.FloorNumber < 1 || Department.FloorNumber > 5;
        IsPhoneNumberInvalid = string.IsNullOrEmpty(Department.PhoneNumber);
        IsEmailInvalid = string.IsNullOrEmpty(Department.Email);

        if (IsCodeInvalid || IsNameInvalid || IsFloorNumberInvalid || IsPhoneNumberInvalid || IsEmailInvalid)
        {
            return false;
        }

        return true;
    }
}
