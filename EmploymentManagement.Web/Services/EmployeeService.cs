using EmployeeManagement.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using System.IO;
using Newtonsoft.Json;

namespace EmploymentManagement.Web.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly HttpClient httpClient;
        public EmployeeService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
           var response =  await httpClient.GetAsync("api/employee");

            if (response.IsSuccessStatusCode)
            {
                Stream contentStream = await response.Content.ReadAsStreamAsync();
                IEnumerable<Employee> data = getDataFromStream<IEnumerable<Employee>>(contentStream);
                return data;
            }
            return null;
        }

        public T getDataFromStream<T>(Stream stream)
        {
            using var streamReader = new StreamReader(stream);
            using var jsonReader = new JsonTextReader(streamReader);
            JsonSerializer serializer = new JsonSerializer();
            return serializer.Deserialize<T>(jsonReader);
        }

        public async Task<Employee> GetEmployee(int id)
        {
            var response = await httpClient.GetAsync($"api/employee/{id}");

            if (response.IsSuccessStatusCode)
            {
                Stream contentStream = await response.Content.ReadAsStreamAsync();
                Employee data = getDataFromStream<Employee>(contentStream);
                return data;
            }
            return null;
        }
    }
}
