using EmployeeManagement.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace EmploymentManagement.Web.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly HttpClient httpClient;
        public DepartmentService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<Department> GetDepartment(int id)
        {
            var response = await httpClient.GetAsync($"api/department/{id}");

            if (response.IsSuccessStatusCode)
            {
                Stream contentStream = await response.Content.ReadAsStreamAsync();
                Department data = getDataFromStream<Department>(contentStream);
                return data;
            }
            return null;
        }

        public async Task<IEnumerable<Department>> GetDepartments()
        {
            var response = await httpClient.GetAsync("api/department");

            if (response.IsSuccessStatusCode)
            {
                Stream contentStream = await response.Content.ReadAsStreamAsync();
                IEnumerable<Department> data = getDataFromStream<IEnumerable<Department>>(contentStream);
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
    }
}
