
-- Task 11 --

INSERT INTO newusertable(first_column, second_column) values(1, 'aaa')
INSERT INTO newusertable(first_column, second_column) values(1, 'bbb')
INSERT INTO newusertable(first_column, second_column) values(1, 'ccc')

create table NewUserTable
(
  First_column int,
  Second_column char(10)
) tablespace SEA_QDATA

alter tablespace SEA_QDATA online

create tablespace SEA_QDATA
datafile 'C:\\app\Tablespaces\sea_qdata.dbf'
size 10M
autoextend on next 500K
maxsize 100M
offline
extent management local

-- Task 10 --

select * from mynewtable

create view mynewview as select * from mynewtable

select * from mynewtable

insert into mynewtable(first_column, second_column) values(1, 'aaa')
insert into mynewtable(first_column, second_column) values(2, 'bbb')
insert into mynewtable(first_column, second_column) values(3, 'ccc')

create table MyNewTable
(
  First_column int,
  Second_column char(10)
)


select * from user_objects