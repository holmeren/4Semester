--Opgave1
SELECT * FROM Customers
GO

--Opgave2
SELECT LastName, FirstName, BirthDate, City, Country  FROM dbo.Employees 
GO

--Opgave3
SELECT Country  FROM dbo.Employees GROUP BY Country
GO

--Opgave4
SELECT ContactName, Country FROM Customers WHERE Country = 'UK';
GO

SELECT * FROM Customers ORDER BY Country DESC
GO

--Opgave5
SELECT * FROM [Order Details] WHERE Quantity >= 10  AND Quantity <= 20
GO

--Opgave6
SELECT LastName, FirstName, BirthDate, City, Country  FROM dbo.Employees WHERE Title like '%Sales%'
GO

--Opgave7
SELECT CustomerID, CompanyName, PostalCode FROM Customers WHERE City ='London' ORDER BY PostalCode ASC
GO

--Opgave8
SELECT Country, ContactTitle, CompanyName FROM Customers WHERE ContactTitle = 'Marketing Manager' AND (Country = 'USA' OR Country = 'Spain') ORDER BY CompanyName DESC
GO

--Opgave9
SELECT * FROM Customers WHERE Fax IS NULL AND (Country = 'USA' OR Country = 'Spain' OR Country = 'UK')
GO

--Opgave10
