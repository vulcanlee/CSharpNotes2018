using BlazorCRUD.Share.Models;
using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorCRUD.App.Pages
{
    public class EmployeeDataTestModel : BlazorComponent
    {
        [Inject]
        protected HttpClient Http { get; set; }
        protected List<Employee> empList = new List<Employee>();
        protected List<Cities> cityList = new List<Cities>();
        protected Employee emp = new Employee();
        protected string modalTitle { get; set; }
        protected string searchString { get; set; }

        protected override async Task OnInitAsync()
        {
            //try
            //{
            //    var foo = await Http.GetJsonAsync<List<Employee>>("/api/employees");
            //    await Http.SendJsonAsync(HttpMethod.Post, "/api/Employees/", new Employee()
            //    {
            //        EmployeeName = "vulcan",
            //        CityName = "Kaohsiug",
            //        Designation = "NN",
            //        Gender = "M"
            //    });
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            await GetEmployeeList();
            await GetCityList();
        }

        protected async Task GetCityList()
        {
            try
            {
                cityList = await Http.GetJsonAsync<List<Cities>>("/api/Cities");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        protected async Task GetEmployeeList()
        {
            try
            {
                empList = await Http.GetJsonAsync<List<Employee>>("api/Employees/");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        protected void AddEmployee()
        {
            emp = new Employee();
            this.modalTitle = "Add Employee";
        }

        protected async Task EditEmployee(int empID)
        {
            emp = await Http.GetJsonAsync<Employee>("/api/Employees/" + empID);
            this.modalTitle = "Edit Employee";
        }

        protected async Task SaveEmployee()
        {
            if (emp.EmployeeId != 0)
            {
                await Http.SendJsonAsync(HttpMethod.Put, "/api/Employees", emp);
            }
            else
            {
                try
                {
                    await Http.SendJsonAsync(HttpMethod.Post, "/api/Employees", emp);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            await GetEmployeeList();
        }

        protected async Task DeleteConfirm(int empID)
        {
            emp = await Http.GetJsonAsync<Employee>("/api/Employees/" + empID);
        }

        protected async Task DeleteEmployee(int empID)
        {
            await Http.DeleteAsync("/api/Employees/" + empID);
            await GetEmployeeList();
        }

        protected async Task SearchEmployee()
        {
            await GetEmployeeList();
            if (searchString != "")
            {
                empList = empList.Where(x => x.EmployeeName.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) != -1).ToList();
            }
        }
        public void OnGet()
        {
        }
    }
}