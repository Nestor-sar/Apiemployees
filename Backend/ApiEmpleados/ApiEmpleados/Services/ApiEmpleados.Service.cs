using ApiEmpleados.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace ApiEmpleados.Services
{
    public class EmployeeServices
    {
        private readonly AppDbContext _context;
        public EmployeeServices(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<EmployeeModel> GetEmployee()
        {
            return _context.employees.ToList();
        }

        public void Add(EmployeeModel entity)
        {
            _context.employees.Add(entity);
            _context.SaveChanges();
        }
    }
}
