create table book (
    id int primary key,
    title varchar(50) not null,
    author varchar(30) not null,
    isbn varchar(20) unique not null,
    publishdate DATE
);

alter table book
alter column title varchar(50) not null;


insert into book (id, title, author, isbn, publishdate) values

(1, 'My first sql book', 'Marry Parker', '12345678', '2012-02-22'),

(2, 'My second sql book', 'John Mayor', '87654321', '1972-07-03'),

(3, 'My third sql book', 'Carry Flint', '18273645', '2015-10-18');

--Write a query to fetch the details of the books written by author whose name ends with er
select * from book
where author like '%er';

create table reviews (
    id int primary key,
    book_id int not null,
    reviewer_name varchar(30) not null,
    content varchar(20) unique not null,
	rating int,
    publishdate date
);
insert into reviews (id, book_id, reviewer_name, content, rating,publishdate) values

(1,1,'john smith', 'my first review', '4', '2017-12-10'),

(2,2, 'john smith', 'my second review', '5', '2017-10-13'),

(3,2, 'Alice walker', 'another review', '1', '2017-10-22');


--Display the Title ,Author and ReviewerName for all the books from the above table
select b.title, b.author, r.reviewer_name
from book b
join reviews r on b.id = r.book_id


--Display the reviewer name who reviewed more than one book.
select reviewer_name
from reviews
group by reviewer_name
having count(distinct book_id) > 1;

create table customers (
    id int primary key,
    name varchar(50) NOT NULL,
    age varchar(30) NOT NULL,
    address varchar(20) NOT NULL,
    salary int
);
create table orders (
    oid int primary key,
    date DATE,
    customer_id int,
    amount int,
);
insert into customers (id, name, age, address, salary) values

(1, 'Ramesh', 32, 'Ahmedabad', 2000.00),

(2, 'Khilan', 25, 'Delhi', 1500.00),

(3, 'kaushik', 23, 'kota', 2000.00),

(4, 'chaitali', 25, 'Mumbai', 6500.00),
(5, 'Hardik', 27, 'Bhopal', 8500.00),
(6, 'Komal', 22, 'MP', 4500.00),
(7, 'Muffy', 24, 'indore', 10000.00);

insert into orders (oid, date, customer_id, amount) values

(102, '2009-10-08', 3, 3000),

(100, '2009-10-08', 3,  1500),

(101, '2009-11-20', 2,  1560),

(103, '2008-05-20', 4,  2060);

--Display the Name for the customer from above customer table who live in same address which has character o anywhere in addres
select name
from customers
where address like '%o%';

--Write a query to display the Date,Total no of customer placed order on same Date
select date, count(distinct customer_id) as total_no_customers
from orders
group by date;


update customers
set salary = null
where id in (6, 7);


--Display the Names of the Employee in lower case, whose salary is null
select lower(name) as lowercase_name
from customers
where salary is null;


create table studentdetails (
    registerNo varchar(20) unique not null,
    name varchar(50) not null,
    age int,
    qualification varchar(50),
    mobileNo varchar(15) unique not null,
    mail_id varchar(100),
    location varchar(50),
    gender varchar(10)
);

insert into studentdetails(registerNo,name,age,qualification,mobileNo,mail_id,location,gender) values
(2,'sai',22,'B.E',123456789,'sai@gmail.com','chennai','M'),
(3,'kumar',20,'BSC',123456788,'kumar@gmail.com','Madurai','M'),
(4,'selvi',22,'B.tech',123456798,'selvi@gmail.com','selam','F'),
(5,'nisha',25,'M.E',923456789,'nisha@gmail.com','theni','F'),
(6,'saisaran',21,'B.A',903456789,'saisaran@gmail.com','Madurai','F'),
(7,'tom',23,'BCA',093456789,'tom@gmail.com','pune','M');

--Write a sql server query to display the Gender,Total no of male and female from the above relation
select gender, count(*) as total_count
from studentdetails
group by gender;
