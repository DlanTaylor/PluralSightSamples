using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Features
{
    class Program
    {

        static void Main(string[] args)
        {
            Func<int, int> square = x => x * x;

            Action<int> write = x => Console.WriteLine(x);

            Console.WriteLine(square(3));

            var developers = new Employee[]
            {
                new Employee{Id = 1, Name = "Jimmy" },
                new Employee{Id = 2, Name = "Bobby" }
            };

            var sales = new List<Employee>()
            {
                new Employee{Id = 3, Name = "Alex" }
            };

            var query = from developer in developers
                        where developer.Name.Length == 5
                        orderby developer.Name
                        select developer;

            foreach(var employee in query)
            {
                Console.WriteLine(employee.Name);
            }
        }

        private static int Square(int arg)
        {
            throw new NotImplementedException();
        }
    }
}
