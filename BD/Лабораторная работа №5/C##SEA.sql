-- Task 7 --

select * from user_extents

-- Task 6 --

select * from SEA_T1 order by firstcolumn


declare counter number := 4;
begin
while (counter < 10000)
loop
  insert into SEA_T1(firstcolumn, secondcolumn) values(counter, 'ttttt');
  counter := counter + 1;
end loop;
end;

-- Task 5 --

flashback table SEA_T1 to before drop

-- Task 4 --

select * from user_recyclebin
drop table sea_t1

-- Task 2 --

select * from sea_t1
insert into sea_t1 values(1, 'qqqqq')
insert into sea_t1 values(2, 'wwwww')
insert into sea_t1 values(3, 'eeeee')

select * from user_tables

create table SEA_T1 
(
  firstcolumn number primary key,
  secondcolumn char(10)
) tablespace SEA_QDATA2