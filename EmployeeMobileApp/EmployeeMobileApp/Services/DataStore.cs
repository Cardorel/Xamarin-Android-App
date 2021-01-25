using EmployeeMobileApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeMobileApp.Services
{
    public class DataStore
    {
         public static List<Employee> GetEmployees = new List<Employee>()
        {
                new Employee() 
                {
                    Id = Guid.NewGuid().ToString() , 
                    Name="Jean Paul" , 
                    Birthday= new DateTime(1991 , 06 , 08) , 
                    Position="Director" , Photo="User.jpg"
                },
                new Employee() 
                {
                    Id = Guid.NewGuid().ToString() , 
                    Name="John Cousi" , 
                    Birthday= new DateTime(1981 , 07 , 08) , 
                    Position="Developer" , Photo="User.jpg"
                },
                new Employee() 
                {
                    Id = Guid.NewGuid().ToString() , 
                    Name="Does Marc" , 
                    Birthday= new DateTime(1999 , 06 , 10) , 
                    Position="Secretary" , 
                    Photo="User.jpg"
                },
        };
    }
}
