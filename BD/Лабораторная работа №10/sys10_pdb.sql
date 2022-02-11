-- Task 6 - 9 --

select * from v$parameter where name like '%plsql%'
select * from v$reserved_words where length > 1 order by keyword;
select * from v$reserved_words where length = 1;


-- Task 5 --

select * from v$parameter

show parameter plsql_warnings