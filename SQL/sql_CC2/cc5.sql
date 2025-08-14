create database ass2

create table dpmnt (
    deptno int primary key,
    dname varchar(20),
    loc varchar(20)
);

create table employ (
    empno int primary key,
    ename varchar(20),
    job varchar(20),
    mgr int,
    hiredate date,
    sal decimal(7,2),
    comm decimal(7,2),
    deptno int,
    foreign key (deptno) references dept(deptno)
);

insert into dpmnt values
(10, 'ACCOUNTING', 'NEW YORK'),
(20, 'RESEARCH', 'DALLAS'),
(30, 'SALES', 'CHICAGO'),
(40, 'OPERATIONS', 'BOSTON');

insert into employ values
(7369, 'SMITH', 'CLERK', 7902, '1980-12-17', 800, null, 20),
(7499, 'ALLEN', 'SALESMAN', 7698, '1981-02-20', 1600, 300, 30),
(7521, 'WARD', 'SALESMAN', 7698, '1981-02-22', 1250, 500, 30),
(7566, 'JONES', 'MANAGER', 7839, '1981-04-02', 2975, null, 20),
(7654, 'MARTIN', 'SALESMAN', 7698, '1981-09-28', 1250, 1400, 30),
(7698, 'BLAKE', 'MANAGER', 7839, '1981-05-01', 2850, null, 30),
(7782, 'CLARK', 'MANAGER', 7839, '1981-06-09', 2450, null, 10),
(7788, 'SCOTT', 'ANALYST', 7566, '1987-04-19', 3000, null, 20),
(7839, 'KING', 'PRESIDENT', null, '1981-11-17', 5000, null, 10),
(7844, 'TURNER', 'SALESMAN', 7698, '1981-09-08', 1500, 0, 30),
(7876, 'ADAMS', 'CLERK', 7788, '1987-05-23', 1100, null, 20),
(7900, 'JAMES', 'CLERK', 7698, '1981-12-03', 950, null, 30),
(7902, 'FORD', 'ANALYST', 7566, '1981-12-03', 3000, null, 20),
(7934, 'MILLER', 'CLERK', 7782, '1982-01-23', 1300, null, 10);

select * from employ

alter table employ
add dob date;

update employ set dob = '1970-03-15' where empno = 7369; 
update employ set dob = '1975-07-22' where empno = 7499;  
update employ set dob = '1978-11-05' where empno = 7521;  
select * from employ

--Write a query to display your birthday( day of week)
select datename(weekday, cast('2002-03-30' as date)) as mybirthdate ;
--Write a query to display your age in days
select datediff(day, '2002-03-30', getdate()) as ageInDays;

--Write a query to display all employees information those who joined before 5 years in the current month
update employ
set hiredate = '2017-07-01'
where empno in (7499, 7369, 7788);



select *
from employ
where 
    datediff(year, hiredate, getdate()) >= 5
    and month(hiredate) = month(getdate());



insert into employ (empno, ename, job, mgr, hiredate, sal, comm, deptno, dob)
values
(9001, 'VIRAT', 'SDE', 7566, '2016-05-11', 3200, null, 20, '1999-05-02'),
(9002, 'ROHIT', 'MANAGER', 7839, '2016-04-20', 4500, null, 30, '1988-12-22'),
(9003, 'HARDIK', 'HR', 7788, '2020-02-20', 1800, null, 10, '1991-04-21');




update employ
set sal = sal + sal * 0.15
where empno = 9001;


declare @backup table (
    empno int primary key,
    ename varchar(20),
    job varchar(20),
    mgr int,
    hiredate date,
    sal decimal(7,2),
    comm decimal(7,2),
    deptno int,
    dob date
);


insert into @backup
select * from employ where empno = 9001;


delete from employ where empno = 9001;

insert into employ
select * from @backup;

select empno, ename, sal, hiredate, dob from employ 
where empno in (3232, 9001);  

select * from employ;

--5.      Create a user defined function calculate Bonus for all employees of a  given dept using 	following conditions
-- For Deptno 10 employees 15% of sal as bonus.
--For Deptno 20 employees  20% of sal as bonus
--For Others employees 5%of sal as bonus
create function calbonus (@sal decimal(7,2), @deptno int)
returns decimal(7,2)
as
begin
    declare @bonus decimal(7,2);

    if @deptno = 10
        set @bonus = @sal * 0.15;
    else if @deptno = 20
        set @bonus = @sal * 0.20;
    else
        set @bonus = @sal * 0.05;

    return @bonus;
end;

select 
    empno, 
    ename, 
    sal, 
    deptno,
    dbo.calbonus(sal, deptno) as bonus
from employ;


--6. Create a procedure to update the salary of employee by 500 whose dept name is Sales and current salary is below 1500 (use emp table)
create or alter procedure updatesalary
as
begin
    set nocount on;

    update employ
    set sal = sal + 500
    where deptno = (
        select deptno from dpmnt where dname = 'SALES'
    )
    and sal < 1500;
end;

exec updatesalary;


create table employee2 (
    empno int primary key,
    ename varchar(20),
    sal decimal(7,2),
    doj date
);
select empno, ename, sal, deptno
from employ
where deptno = (
    select deptno from dpmnt where dname = 'SALES'
);


begin transaction;

  
    insert into employee2 values 
    (100, 'NICK', 1000, '2021-01-12'),
    (101, 'JONES', 1200, '2020-06-18'),
    (103, 'SAM', 1500, '2019-03-23');

    update employee2
    set sal = sal + sal * 0.15
    where empno = 101;

    declare @deletedRow table (
        empno int,
        ename varchar(20),
        sal decimal(7,2),
        doj date
    );

    insert into @deletedRow
    select * from employee2 where empno = 100;

    delete from employee2 where empno = 100;

    insert into employee2
    select * from @deletedRow;

commit;

select * from employee2;

