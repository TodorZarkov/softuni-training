﻿namespace SoftUni;

using Data;
using Microsoft.EntityFrameworkCore;
using System.Text;

public class StartUp
{
    private static void Main(string[] args)
    {
        SoftUniContext dbContext = new SoftUniContext();
        //string result = GetEmployeesFullInformation(dbContext);
        //Console.WriteLine(result);


    }

    //03. Employees Full Information
    public static string GetEmployeesFullInformation(SoftUniContext context)
    {
        var query = context
            .Employees
            .AsNoTracking()
            .OrderBy(e => e.EmployeeId)
            .Select(e => new
            {
                e.FirstName
                ,
                e.LastName
                ,
                e.MiddleName
                ,
                e.JobTitle
                ,
                e.Salary
            });

        //Console.WriteLine(query.ToQueryString());
        //Console.WriteLine(Environment.NewLine);

        var employees = query
            .ToArray();

        StringBuilder sb = new StringBuilder();
        foreach (var e in employees)
        {
            sb.AppendLine($"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary:f2}");
        }

        return sb.ToString().TrimEnd();
    }

    //04. Employees with Salary Over 50 000
    public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
    {
        throw new NotImplementedException();
    }
}
