using Lab5.MAUIData.Models;

namespace Lab5.MAUIData.Interfaces;

public interface IDataRepository
{
    Task<Department[]> GetDepartmentsAsync();

    Task<Employee[]> GetDepartmentEmployeesAsync(int departmentId);

    Task DeleteEmployee(int departmentId, int employeeId);

    Task UpdateDepartmentAsync(Department department);
}
