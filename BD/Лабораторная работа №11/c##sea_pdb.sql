select * from auditorium;
select * from auditorium_type;

-- Task 20 --

declare
cursor teachers is select teacher_name from teacher;
i numeric(5);
begin
i := 0;
for teacher in teachers
loop
dbms_output.put_line(teacher.teacher_name);
i := i + 1;
if mod(i, 3) = 0
then dbms_output.put_line('-----------');
end if;
end loop;
end;

-- Task 19 --

reate sequence S1
start with 1
increment by 10
nominvalue
nomaxvalue
nocycle;

create table some_table (x numeric(30));

begin
for x in 1..10
loop
insert into some_table values(S1.nextval);
end loop;
end;

drop sequence S1;
select * from some_table;

declare
cursor cur is select x, rowid from some_table;
begin
for x in cur
loop
case
when x.x >= 50
then delete some_table where rowid = x.rowid;
when x.x <= 50
then update some_table set x = x + 5 where rowid = x.rowid;
end case;
end loop;
end;

select * from some_table;

drop table some_table;

-- Task 18 --

declare
cursor c_auditorum (min_bound auditorium.auditorium_capacity%type, max_bound auditorium.auditorium_capacity%type)
is select auditorium_capacity
from auditorium
where auditorium_capacity between min_bound and max_bound
for update;
begin
for aum_capacity in c_auditorum(0, 20)
loop
delete auditorium where current of c_auditorum;
end loop;
rollback;
end;


-- Task 17 --

declare
cursor c_auditorum (min_bound auditorium.auditorium_capacity%type, max_bound auditorium.auditorium_capacity%type)
is select auditorium_capacity
from auditorium
where auditorium_capacity between min_bound and max_bound
for update;
begin
for aum_capacity in c_auditorum(40, 80)
loop
update auditorium set auditorium_capacity = auditorium_capacity * 0.9 where current of c_auditorum;
end loop;
rollback;
end;

-- Task 16 --

cursor curs_aut
is select auditorium_type,
cursor(select auditorium
from auditorium aum
where aut.auditorium_type = aum.auditorium_type
)
from auditorium_type aut;
curs_aum sys_refcursor;
aut auditorium_type.auditorium_type%TYPE;
txt varchar2(1000);
aum auditorium.auditorium%TYPE;
begin
open curs_aut;
fetch curs_aut into aut, curs_aum;
while(curs_aut%found)
loop
txt := rtrim(aut)||':';
loop
fetch curs_aum into aum;
exit when curs_aum%notfound;
txt := txt||','||rtrim(aum);
end loop;
dbms_output.put_line(txt);
fetch curs_aut into aut, curs_aum;
end loop;
close curs_aut;
exception
when others
then dbms_output.put_line(sqlerrm);
end;

-- Task 16

select * from auditorium
select * from auditorium_type

declare
  cursor parent_cursor is select  auditorium_type, cursor ( select auditorium from auditorium where auditorium_type = audt.auditorium_type ) from auditorium_type audt;
  audtype auditorium_type.auditorium_type%type;
  cursaud sys_refcursor;
  audnum auditorium.auditorium%type;
  resultstring varchar(1000);
  begin
    open parent_cursor;
    fetch parent_cursor into audtype, cursaud;
    while(parent_cursor%found)
    loop
      resultstring := rtrim(audtype) || ':';
      -- Do Fetch before while
      loop
      fetch cursaud into audnum;
      exit when cursaud%notfound;
      resultstring := resultstring || ',' || rtrim(audnum);
      end loop;
      dbms_output.put_line(resultstring);
      fetch parent_cursor into audtype, cursaud;
    end loop;
    close parent_cursor;
    exception
    when others 
    then dbms_output.put_line(sqlerrm);
  end;

-- Task 15 --

declare
  type some_type is ref cursor;
  cursor_var some_type;
  auditorium_var auditorium%rowtype;
  begin
  open cursor_var for select * from auditorium;
  fetch cursor_var into auditorium_var;
  while(cursor_var%found)
  loop
  dbms_output.put_line(auditorium_var.auditorium);
  fetch cursor_var into auditorium_var;
  end loop;
  close cursor_var;
  exception
  when others
  then dbms_output.put_line(sqlerrm);
  end;

-- Task 14 --

declare
  cursor auditorium_cursor (capacity C##SEA.auditorium.auditorium_capacity%type) is select * from auditorium where auditorium_capacity < capacity;
  auditorium_row C##SEA.auditorium%rowtype;
  begin
  open auditorium_cursor(20);
  loop
    fetch auditorium_cursor into auditorium_row;
    exit when auditorium_cursor%notfound;
    dbms_output.put_line(auditorium_row.auditorium || auditorium_row.auditorium_name || auditorium_row.auditorium_capacity || auditorium_row.auditorium_type);
  end loop;
  close auditorium_cursor;
  end;


select * from auditorium

-- Task 13 --
-- in cycle don't need open, fetch and close cursor

declare 
  cursor subtechhh is select pulpit.pulpit, teacher.teacher_name from pulpit inner join teacher on pulpit.pulpit = teacher.pulpit;
  begin
    for subtech_row in subtechhh
    loop
      dbms_output.put_line(subtech_row.pulpit || ' ' || subtech_row.teacher_name);
    end loop;
  end;

-- Task 12 --

declare 
  cursor subject_cursor is select * from subject;
  subject_row C##SEA.subject%rowtype;
  begin
    open subject_cursor;
    fetch subject_cursor into subject_row;
    while subject_cursor%found
    loop
      dbms_output.put_line(subject_row.subject || ' ' || subject_row.subject_name || ' ' || subject_row.pulpit);
      fetch subject_cursor into subject_row;
    end loop;
    close subject_cursor;
  end;

select * from  subject

-- Task 11 --

declare
  cursor teacher_cursor is select teacher, teacher_name, pulpit, birthday, salary from teacher;
  teacher C##SEA.teacher.teacher%type;
  teacher_name C##SEA.teacher.teacher_name%type;
  pulpit C##SEA.teacher.pulpit%type;
  birthday C##SEA.teacher.birthday%type;
  salary C##SEA.teacher.salary%type;
  begin
      open teacher_cursor;
      loop
      fetch teacher_cursor into teacher, teacher_name, pulpit, birthday, salary;
      exit when teacher_cursor%notfound;
      dbms_output.put_line(teacher || ' ' || teacher_name || ' ' || pulpit || ' ' || birthday || ' ' || salary);
      end loop;
      close teacher_cursor;
  end;

select * from teacher

-- Task 10 --

begin
  delete from auditorium_type where auditorium_type = 'LK';
  exception
  when others
  then dbms_output.put_line(sqlerrm);
end;



-- Task 9 --

declare
  b1 boolean;
  b2 boolean;
  b3 boolean;
  b4 pls_integer;
  auditorium_var auditorium%rowtype;
  begin
    delete from auditorium where  auditorium = '304-4';
    rollback;
     --commit;
     b1 := sql%found;
     b2 := sql%isopen;
     b3 := sql%notfound;
     b4 := sql%rowcount;
     if b1
     then
     dbms_output.put_line('true');
     else
     dbms_output.put_line('false');
     end if;
      if b2
     then
     dbms_output.put_line('true');
     else
     dbms_output.put_line('false');
     end if;
      if b3
     then
     dbms_output.put_line('true');
     else
     dbms_output.put_line('false');
     end if;
     dbms_output.put_line(b4);
     --commit;
     exception
     when no_data_found
     then dbms_output.put_line('the select did not return anything ORA' || sqlcode );
     when others
     then dbms_output.put_line(sqlerrm);
  end;

-- Task 8 --

begin
  insert into auditorium(auditorium, auditorium_name, auditorium_capacity, auditorium_type) values(206-4, 206-1, 15, 'LB-K');
  exception
  when others
  then dbms_output.put_line(sqlerrm);
end;

-- Task 7 --

declare
  b1 boolean;
  b2 boolean;
  b3 boolean;
  b4 pls_integer;
  auditorium_var auditorium%rowtype;
  begin
    insert into auditorium(auditorium, auditorium_name, auditorium_capacity, auditorium_type) values('100-2', '100-1', 20, 'LK');
    --rollback;
     commit;
     b1 := sql%found;
     b2 := sql%isopen;
     b3 := sql%notfound;
     b4 := sql%rowcount;
     if b1
     then
     dbms_output.put_line('true');
     else
     dbms_output.put_line('false');
     end if;
      if b2
     then
     dbms_output.put_line('true');
     else
     dbms_output.put_line('false');
     end if;
      if b3
     then
     dbms_output.put_line('true');
     else
     dbms_output.put_line('false');
     end if;
     dbms_output.put_line(b4);
     --commit;
     exception
     when no_data_found
     then dbms_output.put_line('the select did not return anything ORA' || sqlcode );
     when others
     then dbms_output.put_line(sqlerrm);
  end;

-- Task 6 --

begin
  update auditorium set auditorium = '206-1' where auditorium = '301-2';
  exception
  when others
  then dbms_output.put_line(sqlerrm);
end;

-- Task 5 --

declare
  b1 boolean;
  b2 boolean;
  b3 boolean;
  b4 pls_integer;
  auditorium_var auditorium%rowtype;
  begin
    update auditorium set auditorium = '206-4' where auditorium = '206-1';
    rollback;
     b1 := sql%found;
     b2 := sql%isopen;
     b3 := sql%notfound;
     b4 := sql%rowcount;
     if b1
     then
     dbms_output.put_line('true');
     else
     dbms_output.put_line('false');
     end if;
      if b2
     then
     dbms_output.put_line('true');
     else
     dbms_output.put_line('false');
     end if;
      if b3
     then
     dbms_output.put_line('true');
     else
     dbms_output.put_line('false');
     end if;
     dbms_output.put_line(b4);
     --commit;
     exception
     when no_data_found
     then dbms_output.put_line('the select did not return anything ORA' || sqlcode );
     when others
     then dbms_output.put_line('error');
  end;


declare
  b1 boolean;
  b2 boolean;
  b3 boolean;
  b4 pls_integer;
  auditorium_var auditorium%rowtype;
  begin
    update auditorium set auditorium = '206-4' where auditorium = '206-1';
    commit;
     b1 := sql%found;
     b2 := sql%isopen;
     b3 := sql%notfound;
     b4 := sql%rowcount;
     if b1
     then
     dbms_output.put_line('true');
     else
     dbms_output.put_line('false');
     end if;
      if b2
     then
     dbms_output.put_line('true');
     else
     dbms_output.put_line('false');
     end if;
      if b3
     then
     dbms_output.put_line('true');
     else
     dbms_output.put_line('false');
     end if;
     dbms_output.put_line(b4);
     --commit;
     exception
     when no_data_found
     then dbms_output.put_line('the select did not return anything ORA' || sqlcode );
     when others
     then dbms_output.put_line('error');
  end;

-- Task 4 --

declare
  b1 boolean;
  b2 boolean;
  b3 boolean;
  b4 pls_integer;
  auditorium_var auditorium%rowtype;
  begin
    select * into auditorium_var from auditorium where auditorium = '206-1';
     b1 := sql%found;
     b2 := sql%isopen;
     b3 := sql%notfound;
     b4 := sql%rowcount;
     if b1
     then
     dbms_output.put_line('true');
     else
     dbms_output.put_line('false');
     end if;
      if b2
     then
     dbms_output.put_line('true');
     else
     dbms_output.put_line('false');
     end if;
      if b3
     then
     dbms_output.put_line('true');
     else
     dbms_output.put_line('false');
     end if;
     dbms_output.put_line(b4);
     exception
     when no_data_found
     then dbms_output.put_line('the select did not return anything ORA' || sqlcode );
     when others
     then dbms_output.put_line('error');
  end;


declare
  b1 boolean;
  b2 boolean;
  b3 boolean;
  b4 pls_integer;
  auditorium_var auditorium%rowtype;
  begin
    select * into auditorium_var from auditorium where auditorium = '505-4';
     b1 := sql%found;
     b2 := sql%isopen;
     b3 := sql%notfound;
     b4 := sql%rowcount;
     if b1
     then
     dbms_output.put_line('true');
     else
     dbms_output.put_line('true');
     end if;
      if b2
     then
     dbms_output.put_line('true');
     else
     dbms_output.put_line('true');
     end if;
      if b3
     then
     dbms_output.put_line('true');
     else
     dbms_output.put_line('true');
     end if;
     dbms_output.put_line(b4);
     exception
     when no_data_found
     then dbms_output.put_line('the select did not return anything ORA' || sqlcode );
  end;

-- Task 3 --

declare
  auditorium_var auditorium%rowtype;
  begin
     select * into auditorium_var from auditorium where auditorium_capacity = 15;
    exception
    when too_many_rows
    then dbms_output.put_line('Select return more than 1 row ORA ' || sqlcode);
  end;

-- Task 2 --

declare 
  auditorium_var auditorium%rowtype;
  begin
    select * into auditorium_var from auditorium where auditorium_capacity = 15;
    exception
    when others
    then dbms_output.put_line(sqlcode);
    dbms_output.put_line(sqlerrm);
  end;

-- Task 1 --

declare 
  auditorium_var auditorium%rowtype;
  begin
  select * into auditorium_var from auditorium where auditorium = '206-1';
  dbms_output.put_line(auditorium_var.auditorium);
  end;



select * from table1
select * from user_tables