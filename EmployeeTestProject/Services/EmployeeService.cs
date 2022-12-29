using EmployeeTestProject.Models;

namespace EmployeeTestProject.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IDbService _dbService;

        public EmployeeService(IDbService dbService)
        {
            _dbService = dbService;
        }

        public async Task<bool> CreateEmployee(Employee employee)
        {
            var result =
                await _dbService.EditData(
                    "INSERT INTO public.employee (empid,empname, empage, empaddress, empphone) VALUES (@Id, @Name, @Age, @Address, @MobileNumber)",
                    employee);
            return true;
        }

        public async Task<List<Employee>> GetEmployeeList()
        {
            var employeeList = await _dbService.GetAll<Employee>("SELECT * FROM public.employee", new { });
            return employeeList;
        }


        public async Task<Employee> GetEmployee(int id)
        {
            var employeeList = await _dbService.GetAsync<Employee>("SELECT * FROM public.employee where empid=@id", new { id });
            return employeeList;
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            var updateEmployee =
                await _dbService.EditData(
                    "Update public.employee SET empname=@Name, empage=@Age, empaddress=@Address, empphone=@MobileNumber WHERE empid=@Id",
                    employee);
            return employee;
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            var deleteEmployee = await _dbService.EditData("DELETE FROM public.employee WHERE empid=@Id", new { id });
            return true;
        }
    }
}
