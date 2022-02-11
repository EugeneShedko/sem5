-- Task 17 --

select * from MV

create materialized view MV 
build immediate 
refresh complete on demand
start with sysdate next sysdate + 2
as select PA.firstname, PB.secondname from PA inner join PB on pa.idperson = pb.idperson

-- Task 16 --

select * from V1
create view V1 as select PA.firstname, PB.secondname from PA inner join PB on pa.idperson = pb.idperson

insert into PB(idcolumn, idperson, secondname) values(1, 12, 'Shedko')
insert into PA(idperson, firstname) values(12, 'Eugene')

drop table PA
drop table PB

create table PB
(
  idcolumn number(10),
  idperson number(10),
  secondname char(20),
  constraint pk_pb primary key(idcolumn),
  constraint fk_pb foreign key(idperson) references PA(idperson)
)

create table PA
(
  idperson number(10),
  firstname char(10),
  constraint pa_pk primary key(idperson)
)

-- Task 15 --

select * from BB
insert into BB(xb, vb, ps) values(1 , 'ss', 1)
create public synonym BB for C##SEA.B

-- Task 14 --

select * from CC
insert into CC(xc, vc, ps) values(1 , 'ss', 1)
create synonym CC for C##SEA.C

-- Task 9 - 13 --

select * from user_clusters
select * from user_tables

create table C
(
  XC number(10),
  VC varchar(12),
  PS number(10)
) cluster ABC(XC,VC);

create table B
(
  XB number(10),
  VB varchar(12),
  PS varchar(10)
) cluster ABC(XB,VB);

create table A
(
  XA number(10),
  VA varchar(12),
  PS varchar(10)
) cluster ABC(XA,VA);

create cluster ABC
(
  X number(10),
  V varchar2(12)
) hashkeys 200

-- Task 8 --

select * from T1
insert into T1(n1, n2, n3, n4) values(S1.CURRVAL, S2.CURRVAL, S3.CURRVAL, S4.CURRVAL)

create table T1
(
  N1 number(20),
  N2 number(20),
  N3 number(20),
  N4 number(20)
) cache storage(buffer_pool keep) 

select * from user_tables

-- Task 7 --

select * from user_sequences

-- Task 6 --

select S4.NEXTVAL from dual

create sequence S4
start with 1
increment by 1
minvalue 0
maxvalue 5
cycle
cache 5
noorder  

-- Task 5 --

select S3.NEXTVAL from dual

create sequence S3
start with 10
increment by -10
minvalue -100
nocycle
order
maxvalue 11

-- Task 3-4 --

select S2.CURRVAL from dual
select S2.NEXTVAL from dual

create sequence S2
start with 10
increment by 10
maxvalue 100
nocycle

-- Task 2 --

select S1.CURRVAL from dual
select S1.NEXTVAL from dual

create sequence S1
start with 1000
increment by 10
nominvalue
nomaxvalue
nocycle
nocache
noorder
