--create database Company_Info
use Company_Info

--Company details table
create table Company_Details(Company_ID Char(15) Primary key not null,
Company_Name varchar(35) not null unique ,
Company_Address varchar(50) not null,
Company_Contact char(20) not null,
Company_logo varchar(10) not null)
select * from Company_Details


--Employee management table 
create table Employee_Management(Company_ID Char(15) foreign key(Company_ID) references Company_Details(Company_ID),
Company_Name varchar(35) foreign key(Company_Name) references Company_Details(Company_Name),
Emp_ID char(15) primary key,
Emp_Name varchar(20) not null,
Emp_Address varchar(30) not null, 
Emp_Date_of_Birth date not null,
Emp_Contact char(15) not null,
Emp_Profession varchar(25) not null,
Emp_Date_of_joining date not null,
Emp_Resume varchar(30) null,
Emp_Offer_letter varchar(25) null)
select * from Employee_Management

--Attendance Management table 
create table Attendance_Management(Emp_id char(15) foreign key(Emp_ID) references Employee_Management(Emp_ID),
Date date not null,
In_time time not null,
Out_time time not null,
Late_hours time null,
Half_Day_leave char(5) not null,
Notes varchar(15) null)
create rule Half_Day_rule
as @rule in('Yes','No')
go
exec sp_bindrule Half_Day_rule,'Attendance_Management.Half_Day_Leave'
--Payroll table
create table Pay_roll_Systems(Emp_id char(15) foreign key(Emp_ID) references Employee_Management(Emp_ID),
Basic_Salary money not null,
P_funds money null,
Deductions money null,
Actual_Salary as (Basic_Salary+P_funds-Deductions))





