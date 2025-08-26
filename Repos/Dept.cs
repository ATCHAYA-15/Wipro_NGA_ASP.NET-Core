using Microsoft.EntityFrameworkCore;
using Models;
using Repos.Repos;
using System;
using System.Collections.Generic;
using RepoContextNamespace;

namespace Repos
{
    public class Dept : IDept
    {
        private readonly RepoContext _context;

        public Dept(RepoContext context)
        {
            _context = context;
        }

        public string AddDept(Department dept)
        {
            try
            {
                _context.Departments.Add(dept);
                _context.SaveChanges();
                return $" Successful addition of department!";
            }
            catch (Exception ex)
            {
                return "Department Addition failed with error: " + ex.Message;
            }
        }

        public string EditDept(Department dept)
        {
            try
            {
                _context.Departments.Update(dept);
                _context.SaveChanges();
                return "Department updated successfully!";
            }
            catch (Exception ex)
            {
                return "Department Update failed: " + ex.Message;
            }
        }

        public List<Department> GetDepartment()
        {
            try
            {
                return _context.Departments.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching departments: " + ex.Message);
            }
        }

        public string RemoveDept(int id)
        {
            try
            {
                var dept = _context.Departments.Find(id);
                if (dept == null)
                {
                    return "Department not found!";
                }

                _context.Departments.Remove(dept);
                _context.SaveChanges();
                return "Department removed successfully!";
            }
            catch (Exception ex)
            {
                return "Department deletion failed: " + ex.Message;
            }
        }
    }
}
