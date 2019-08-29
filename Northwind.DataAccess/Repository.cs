using Northwind.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DataAccess
{
    public class Repository
    {
        private NorthwindModel model;
        public Repository()
        {
            model = new NorthwindModel();
        }
        public List<Employee> GetAllEmployees()
        {
            return model.Employees.ToList();
        }
        public void Update(Employee employee)
        {
            model.Employees.AddOrUpdate(employee);
            model.SaveChanges();
        }
        public void Insert(Employee employee)
        {
            model.Employees.Add(employee);
            model.SaveChanges();
        }
    }
}
