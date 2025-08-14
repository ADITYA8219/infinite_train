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
-- 1. retrieve a list of managers. 
select ename
from employ
where job = 'manager';

-- 2. find out the names and salaries of all employees earning more than 1000 per month. 
select ename, sal
from employ
where sal > 1000;

-- 3. display the names and salaries of all employees except james. 
select ename, sal
from employ
where ename != 'james';

-- 4. find out the details of employees whose names begin with ‘s’. 
select *
from employ
where ename like 's%';

-- 5. find out the names of all employees that have ‘a’ anywhere in their name. 
select ename
from employ
where ename like '%a%';

-- 6. find out the names of all employees that have ‘l’ as their third character in their name. 
select ename
from employ
where ename like '__l%';

-- 7. compute daily salary of jones. 
select ename, sal / 30 as daily_salary
from employ
where ename = 'jones';

-- 8. calculate the total monthly salary of all employees. 
select sum(sal) as total_monthly_salary
from employ;

-- 9. print the average annual salary. 
select avg(sal * 12) as average_annual_salary
from employ;

-- 10. select the name, job, salary, department number of all employees except salesman from department number 30. 
select ename, job, sal, deptno
from employ
where job != 'salesman' and deptno = 30;

-- 11. list unique departments of the emp table. 
select distinct deptno
from employ;

-- 12. list the name and salary of employees who earn more than 1500 and are in department 10 or 30. label the columns employee and monthly salary respectively.
select ename as employee, sal as "monthly salary"
from employ
where sal > 1500 and (deptno = 10 or deptno = 30);

-- 13. display the name, job, and salary of all the employees whose job is manager or analyst and their salary is not equal to 1000, 3000, or 5000. 
select ename, job, sal
from employ
where (job = 'manager' or job = 'analyst')
  and sal not in (1000, 3000, 5000);

  -- 14. display the name, salary and commission for all employees whose commission amount is greater than their salary increased by 10%. 
select ename, sal, comm
from employ
where comm > (sal * 1.10);

-- 15. display the name of all employees who have two ls in their name and are in department 30 or their manager is 7782. 
select ename
from employ
where (ename like '%l%l%' and ename not like '%l%l%l%') and (deptno = 30 or mgr = 7782);

-- 16. display the names of employees with experience of over 30 years and under 40 yrs. count the total number of employees. 

-- names of employees with experience of over 30 years and under 40 years:
-- (assuming current year is 2025 for calculation)
select ename
from employ
where (2025 - extract(year from hiredate)) > 30
  and (2025 - extract(year from hiredate)) < 40;

-- count the total number of employees:
select count(*) as total_employees
from employ;

-- 17. retrieve the names of departments in ascending order and their employees in descending order. 
select d.dname, e.ename
from dpmnt d
join employ e on d.deptno = e.deptno
order by d.dname asc, e.ename desc;

-- 18. find out experience of miller. 
-- (assuming current year is 2025 for calculation)
select ename, (2025 - extract(year from hiredate)) as years_of_experience
from employ
where ename = 'miller';





