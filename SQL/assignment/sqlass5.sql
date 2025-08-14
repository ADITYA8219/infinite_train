create or alter procedure generatePayslip
    @empno int
as
begin
    set nocount on;

    declare 
        @ename varchar(20),
        @sal decimal(10,2),
        @doj date,
        @hra decimal(10,2),
        @da decimal(10,2),
        @pf decimal(10,2),
        @it decimal(10,2),
        @deductions decimal(10,2),
        @gross decimal(10,2),
        @net decimal(10,2);

    -- Get employee details
    select @ename = ename,
           @sal = sal,
           @doj = hiredate
    from employ
    where empno = @empno;

    -- Calculate components
    set @hra = @sal * 0.10;
    set @da  = @sal * 0.20;
    set @pf  = @sal * 0.08;
    set @it  = @sal * 0.05;
    set @deductions = @pf + @it;
    set @gross = @sal + @hra + @da;
    set @net   = @gross - @deductions;

    -- Print formatted payslip
    print '======================================';
    print '           EMPLOYEE PAYSLIP           ';
    print '======================================';
    print 'Employee No  : ' + cast(@empno as varchar);
    print 'Name         : ' + @ename;
    print 'Date of Join : ' + cast(@doj as varchar);
    print '--------------------------------------';
    print 'Basic Salary : ?' + cast(@sal as varchar);
    print 'HRA (10%)    : ?' + cast(@hra as varchar);
    print 'DA  (20%)    : ?' + cast(@da as varchar);
    print 'Gross Salary : ?' + cast(@gross as varchar);
    print '--------------------------------------';
    print 'PF  (8%)     : ?' + cast(@pf as varchar);
    print 'IT  (5%)     : ?' + cast(@it as varchar);
    print 'Deductions   : ?' + cast(@deductions as varchar);
    print '--------------------------------------';
    print 'Net Salary   : ?' + cast(@net as varchar);
    print '======================================';
end;

exec generatePayslip @empno = 7521;
select * from employ

create table holiday (
    holiday_date date primary key,
    holiday_name varchar(50)
);

-- Insert sample holidays
insert into holiday values
('2024-08-15', 'Independence Day'),
('2024-11-01', 'Diwali'),
('2024-01-26', 'Republic Day'),
('2024-10-02', 'Gandhi Jayanti');

create or alter trigger trg_RestrictOnHoliday
on employ
after insert, update, delete
as
begin
    declare @today date = cast(getdate() as date);
    declare @holiday_name varchar(50);

    select @holiday_name = holiday_name
    from holiday
    where holiday_date = @today;

    if @holiday_name is not null
    begin
        raiserror('Due to %s, you cannot manipulate data today.', 16, 1, @holiday_name);
        rollback;
    end
end;

insert into employ values (1111, 'ARJUN', 'ANALYST', 955, '2024-08-15', 3200, null, 10, '1990-03-30');
