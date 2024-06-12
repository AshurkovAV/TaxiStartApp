using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiStartApp.Common.Data
{
    public class EmployeesRepository
    {
        public IList<Employee> Employees { get; private set; }

        public EmployeesRepository()
        {
            System.Reflection.Assembly assembly = GetType().Assembly;
            Stream stream = assembly.GetManifestResourceStream("TaxiStartApp.Common.Data.Employees.json");
            
            JObject jObject = JObject.Parse(new StreamReader(stream).ReadToEnd());
            Employees = jObject[nameof(Employees)].ToObject<List<Employee>>();
        }
    }
}
