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
--List all employees whose name begins with 'A'. 
select * from employ where ename like 'A%';

--Select all those employees who don't have a manager. 
select * from employ where mgr is null;

-- List employee name, number and salary for those employees who earn in the range 1200 to 1400.
select ename, empno, sal from employ where sal between 1200 and 1400;

-- Give all the employees in the RESEARCH department a 10% pay rise. Verify that this has been done by listing all their details before and after the rise
select * from employ where deptno = (select deptno from dpmnt where dname = 'RESEARCH');
--
update employ set sal = sal * 1.10 where deptno = (select deptno from dpmnt where dname = 'RESEARCH');

select * from employ where deptno = (select deptno from dpmnt where dname = 'RESEARCH');
-- Find the number of CLERKS employed. Give it a descriptive heading. 
select count(*) as 'Number of Clerks' from employ where job = 'CLERK';
-- Find the average salary for each job type and the number of people employed in each job. 
select job, avg(sal) as 'Average Salary', count(*) as 'Total Employees' from employ group by job;
-- List the employees with the lowest and highest salary. 
select * from employ where sal = (select min(sal) from employ)
union
select * from employ where sal = (select max(sal) from employ);

--List full details of departments that don't have any employees. 
select * from dpmnt where deptno not in (select distinct deptno from employ);
--Get the names and salaries of all the analysts earning more than 1200 who are based in department 20. Sort the answer by ascending order of name
select ename, sal from employ where job = 'ANALYST' and sal > 1200 and deptno = 20 order by ename asc;
--For each department, list its name and number together with the total salary paid to employees in that department. 
select d.dname, d.deptno, sum(e.sal) as 'Total Salary'
from dpmnt d left join employ e on d.deptno = e.deptno
group by d.dname, d.deptno;

-- Find out salary of both MILLER and SMITH.
select ename, sal from employ where ename in ('MILLER', 'SMITH');

--Find out the names of the employees whose name begin with ‘A’ or ‘M’. 
select * from employ where ename like 'A%' or ename like 'M%';
--Compute yearly salary of SMITH. 
select ename, sal * 12 as 'Yearly Salary' from employ where ename = 'SMITH';
-- List the name and salary for all employees whose salary is not in the range of 1500 and 2850. 
select ename, sal from employ where sal not between 1500 and 2850;
--Find all managers who have more than 2 employees reporting to them
select mgr, count(*) as 'Reportees'
from employ
where mgr is not null
group by mgr
having count(*) > 2;








