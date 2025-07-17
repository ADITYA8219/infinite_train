create database ass1
create table Clients (
    Client_ID int primary key,
    Cname varchar(40) not null,
    Address varchar(30),
    Email varchar(30) unique,
    Phone bigint,
    Business varchar(20) not null
);
INSERT INTO Clients (Client_ID, Cname, Address, Email, Phone, Business) VALUES
(1001, 'infinte Solutions', 'Bangalore', 'info@infinte.com', 9876543210, 'Consultant'),
(1002, 'google', 'Mumbai', 'contact@google.in', 9123456789, 'Manufacturer'),
(1003, 'jp morgan', 'Chennai', 'hello@jp.co', 9988776655, 'Professional'),
(1004, 'salesforce', 'Hyderabad', 'support@salesforce.com', 9776655443, 'Reseller');


select * from clients

create table departments (
    deptno int primary key,
    dname varchar(15) not null,
    loc varchar(20)
);

insert into departments values
(10, 'Design', 'Pune'),
(20, 'Development', 'Pune'),
(30, 'Testing', 'Mumbai'),
(40, 'Document', 'Mumbai');

select * from departments;

create table employees (
    empno int primary key,
    ename varchar(20) not null,
    job varchar(15),
    salary decimal(7,2) check (salary > 0),
    deptno int,
    foreign key (deptno) references departments(deptno)
);

insert into employees values
(7001, 'Sandeep', 'Analyst', 25000, 10),
(7002, 'Rajesh', 'Designer', 30000, 10),
(7003, 'Madhav', 'Developer', 40000, 20),
(7004, 'Manoj', 'Developer', 40000, 20),
(7005, 'Abhay', 'Designer', 35000, 10),
(7006, 'Uma', 'Tester', 30000, 30),
(7007, 'Gita', 'Tech. Writer', 30000, 40),
(7008, 'Priya', 'Tester', 35000, 30),
(7009, 'Nutan', 'Developer', 45000, 20),
(7010, 'Smita', 'Analyst', 20000, 10),
(7011, 'Anand', 'Project Mgr', 65000, 10);

select * from employees;
create table projects (
    project_id int primary key,
    descr varchar(30) not null,
    start_date date,
    planned_end_date date,
    actual_end_date date check (actual_end_date > planned_end_date),
    budget decimal(10,2) check (budget > 0),
    client_id int,
    foreign key (client_id) references clients(client_id)
);

insert into projects values
(401, 'Inventory', '2011-04-01', '2011-10-01', '2011-10-31', 150000, 1001),
(402, 'Accounting', '2011-08-01', '2012-01-01', null, 500000, 1002),
(403, 'Payroll', '2011-10-01', '2011-12-31', null, 75000, 1003),
(404, 'Contact Mgmt', '2011-11-01', '2011-12-31', null, 50000, 1004);

select * from projects;

create table empprojecttasks (
    project_id int,
    empno int,
    start_date date,
    end_date date,
    task varchar(25) not null,
    status varchar(15) not null,
    primary key (project_id, empno),
    foreign key (project_id) references projects(project_id),
    foreign key (empno) references employees(empno)
);

insert into empprojecttasks values
(401, 7001, '2011-04-01', '2011-04-20', 'System Analysis', 'Completed'),
(401, 7002, '2011-04-21', '2011-05-30', 'System Design', 'Completed'),
(401, 7003, '2011-06-01', '2011-07-15', 'Coding', 'Completed'),
(401, 7004, '2011-07-18', '2011-09-01', 'Coding', 'Completed'),
(401, 7006, '2011-09-03', '2011-09-15', 'Testing', 'Completed'),
(401, 7009, '2011-09-18', '2011-10-05', 'Code Change', 'Completed'),
(401, 7008, '2011-10-06', '2011-10-16', 'Testing', 'Completed'),
(401, 7007, '2011-10-06', '2011-10-22', 'Documentation', 'Completed'),
(401, 7011, '2011-10-22', '2011-10-31', 'Sign off', 'Completed'),
(402, 7010, '2011-08-01', '2011-08-20', 'System Analysis', 'Completed'),
(402, 7002, '2011-08-22', '2011-09-30', 'System Design', 'Completed'),
(402, 7004, '2011-10-01', null, 'Coding', 'In Progress');

select * from empprojecttasks;
