--problem 01. Employees with Salary Above 35000
USE SoftUni
GO

CREATE PROC usp_GetEmployeesSalaryAbove35000
AS
SELECT 
    e.FirstName
    ,e.LastName
FROM Employees AS e
WHERE e.Salary > 35000
GO

--problem 02. Employees with Salary Above Number