using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqPracticeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // ================================
            // Filtering Operators
            // ================================
            var numbers = new[] { 1, 2, 3, 4, 5, 6 };
            var evenNumbers = numbers.Where(n => n % 2 == 0);
            Console.WriteLine("Even Numbers: " + string.Join(", ", evenNumbers));

            // ================================
            // Projection Operators
            // ================================
            var squaredNumbers = numbers.Select(n => n * n);
            Console.WriteLine("Squared Numbers: " + string.Join(", ", squaredNumbers));

            var words = new[] { "hello", "world" };
            var characters = words.SelectMany(w => w.ToCharArray());
            Console.WriteLine("Characters: " + string.Join(", ", characters));

            // ================================
            // Sorting Operators
            // ================================
            var unsorted = new[] { 5, 1, 4, 2 };
            var sortedNumbers = unsorted.OrderBy(n => n);
            Console.WriteLine("Sorted Asc: " + string.Join(", ", sortedNumbers));

            var sortedDesc = unsorted.OrderByDescending(n => n);
            Console.WriteLine("Sorted Desc: " + string.Join(", ", sortedDesc));

            var people = new[]
            {
                new { Name = "Dhoni", Age = 30 },
                new { Name = "Jaddu", Age = 25 },
                new { Name = "Raina", Age = 22 }
            };

            var sortedPeople = people.OrderBy(p => p.Name).ThenBy(p => p.Age);
            Console.WriteLine("Sorted People: " + string.Join(", ", sortedPeople.Select(p => p.Name + "-" + p.Age)));

            var sortedPeopleDesc = people.OrderBy(p => p.Name).ThenByDescending(p => p.Age);
            Console.WriteLine("Sorted Desc People: " + string.Join(", ", sortedPeopleDesc.Select(p => p.Name + "-" + p.Age)));

            // ================================
            // Aggregation Operators
            // ================================
            Console.WriteLine("Count: " + numbers.Count());
            Console.WriteLine("Sum: " + numbers.Sum());
            Console.WriteLine("Average: " + numbers.Average());
            Console.WriteLine("Min: " + numbers.Min());
            Console.WriteLine("Max: " + numbers.Max());
            Console.WriteLine("Any Even? " + numbers.Any(n => n % 2 == 0));
            Console.WriteLine("All Positive? " + numbers.All(n => n > 0));
            Console.WriteLine("Contains 3? " + numbers.Contains(3));

            var numbersWithDuplicates = new[] { 1, 2, 2, 3, 4, 4 };
            var distinctNumbers = numbersWithDuplicates.Distinct();
            Console.WriteLine("Distinct: " + string.Join(", ", distinctNumbers));

            var set1 = new[] { 1, 2, 3 };
            var set2 = new[] { 3, 4, 5 };
            Console.WriteLine("Union: " + string.Join(", ", set1.Union(set2)));
            Console.WriteLine("Intersect: " + string.Join(", ", set1.Intersect(set2)));
            Console.WriteLine("Except: " + string.Join(", ", set1.Except(set2)));

            // ================================
            // Partitioning Operators
            // ================================
            Console.WriteLine("Take 2: " + string.Join(", ", numbers.Take(2)));
            Console.WriteLine("Skip 2: " + string.Join(", ", numbers.Skip(2)));
            Console.WriteLine("TakeWhile < 4: " + string.Join(", ", numbers.TakeWhile(n => n < 4)));
            Console.WriteLine("SkipWhile < 4: " + string.Join(", ", numbers.SkipWhile(n => n < 4)));

            // ================================
            // Element Operators
            // ================================
            Console.WriteLine("First: " + numbers.First());
            Console.WriteLine("FirstOrDefault Even: " + numbers.FirstOrDefault(n => n % 2 == 0));
            Console.WriteLine("Last: " + numbers.Last());
            Console.WriteLine("LastOrDefault Even: " + numbers.LastOrDefault(n => n % 2 == 0));
            Console.WriteLine("Single > 42: " + new[] { 42, 45 }.Single(e => e > 42));
            Console.WriteLine("SingleOrDefault (Empty): " + new int[] { }.SingleOrDefault());
            Console.WriteLine("ElementAt(1): " + numbers.ElementAt(1));
            Console.WriteLine("ElementAtOrDefault(10): " + numbers.ElementAtOrDefault(10));

            // ================================
            // Join Operators
            // ================================
            var employees = new[]
            {
                new { Id = 1, deptId = 1, Name = "Alice" },
                new { Id = 2, deptId = 2, Name = "Bob" }
            };

            var departments = new[]
            {
                new { Id = 1, Department = "HR" },
                new { Id = 2, Department = "IT" }
            };

            var employeeDepartments = employees.Join(departments,
                emp => emp.deptId,
                dept => dept.Id,
                (emp, dept) => new { emp.Name, dept.Department });

            Console.WriteLine("Join Result: " + string.Join(", ", employeeDepartments.Select(ed => ed.Name + "-" + ed.Department)));

            var grouped = employees.GroupJoin(departments,
                emp => emp.Id,
                dept => dept.Id,
                (emp, depts) => new { emp.Name, Departments = depts });

            foreach (var g in grouped)
            {
                Console.WriteLine($"GroupJoin: {g.Name} -> {string.Join(",", g.Departments.Select(d => d.Department))}");
            }

            // ================================
            // Grouping Operators
            // ================================
            var groupByAge = people.GroupBy(p => p.Age);
            foreach (var group in groupByAge)
            {
                Console.WriteLine($"Age {group.Key}: {string.Join(", ", group.Select(p => p.Name))}");
            }

            // ================================
            // Conversion Operators
            // ================================
            var list = numbers.ToList();
            Console.WriteLine("ToList: " + string.Join(", ", list));

            var array = numbers.ToArray();
            Console.WriteLine("ToArray: " + string.Join(", ", array));

            var dict = people.ToDictionary(p => p.Name + "-" + p.Age);
            Console.WriteLine("ToDictionary Keys: " + string.Join(", ", dict.Keys));

            var emptyNumbers = new int[] { };
            var defaultIfEmpty = emptyNumbers.DefaultIfEmpty(42);
            Console.WriteLine("DefaultIfEmpty: " + string.Join(", ", defaultIfEmpty));

            Console.WriteLine("\n--- End of LINQ Practice ---");
        }
    }
}