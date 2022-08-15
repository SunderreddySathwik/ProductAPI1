Create database ProductDB
go

USE ProductDB  
go 

CREATE TABLE DBO.Product(ProductID int primary key IDentity(1,1),
ProductName Varchar(100),
ProductFeatures varchar(100),
ProductPrice int,
Status bit)

go

select * from Product
Insert into Product values('Test Name','Test Features',100,1)