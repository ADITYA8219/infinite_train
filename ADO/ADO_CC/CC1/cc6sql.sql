create table employee_details (
    empid int identity(1001, 1) primary key,
    name varchar(100) not null,
    salary decimal(10, 2) not null,
    gender char(1)
);

create procedure insertempdet
    @name varchar(100),
    @givensalary decimal(10, 2),
    @gender char(1),
    @generatedempid int output
as
begin
    set nocount on;
    declare @finalsalary decimal(10, 2);
    set @finalsalary = @givensalary * 0.90;

    insert into employee_details (name, salary, gender)
    values (@name, @finalsalary, @gender);

    set @generatedempid = scope_identity();
end

select * from employee_details;

create procedure updateempsalary
    @empid int,
    @newsalary decimal(10, 2) output
as
begin
    set nocount on;
	update employee_details
    set salary = salary + 100
    where empid = @empid;

    select @newsalary = salary
    from employee_details
    where empid = @empid;
end