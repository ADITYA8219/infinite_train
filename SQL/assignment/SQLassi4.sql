--Write a T-SQL Program to find the factorial of a given number.
declare @number int = 7;         
declare @factorial bigint = 1;
declare @counter int = 1;

while @counter <= @number
begin
    set @factorial = @factorial * @counter;
    set @counter = @counter + 1;
end

print 'Factorial of ' + cast(@number as varchar) + ' is ' + cast(@factorial as varchar);


--Create a stored procedure to generate multiplication table that accepts a number and generates up to a given number.
create procedure generateMultiplicationTable
    @bn int,   
    @mx int     
as
begin
    declare @c int = 1;  

    print 'Multiplication Table for ' + cast(@bn as varchar) + ' up to ' + cast(@mx as varchar);

    while @c <= @mx
    begin
        print cast(@bn as varchar) + ' x ' + cast(@c as varchar) + ' = ' + cast(@bn * @c as varchar);
        set @c = @c + 1;
    end
end;

exec generateMultiplicationTable @bn = 5, @mx = 10;

-- Create a function to calculate the status of the student. If student score >=50 then pass, else fail. Display the data neatly

create table student (
    sid int primary key,
    sname varchar(50)
);

insert into student values
(1, 'Jack'),
(2, 'Rithvik'),
(3, 'Jaspreeth'),
(4, 'Praveen'),
(5, 'Bisa'),
(6, 'Suraj');

create table marks (
    mid int primary key,
    sid int foreign key references student(sid),
    score int
);

insert into marks values
(1, 1, 23),
(2, 6, 95),
(3, 4, 98),
(4, 2, 17),
(5, 3, 53),
(6, 5, 13);

create function getStatus (@score int)
returns varchar(10)
as
begin
    return case 
        when @score >= 50 then 'Pass'
        else 'Fail'
    end
end;

select 
    s.sid,
    s.sname,
    m.score,
    dbo.getStatus(m.score) as status
from student s
join marks m on s.sid = m.sid;


