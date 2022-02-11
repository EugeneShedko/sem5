-- Task 26 --

declare 
  x number(3):= 0;
  begin
  while( x < 5)
  loop
  x:= x+1;
  dbms_output.put_line(x);
  end loop;
  end;

-- Task 25 --

declare 
  x number(3):= 0;
  begin
  for x in 1..5
  loop
  dbms_output.put_line(x);
  end loop;
  end;

-- Task 24 --

declare 
  x number(3):= 0;
  begin
  loop
    x := x+1;
    dbms_output.put_line(x);
  exit when x > 5;
  end loop;
  end;

-- Task 23 --

declare 
  x number(3):= 5;
  begin
  case x
  when 2 then dbms_output.put_line(2);
  when 5 then dbms_output.put_line(5);
  else  dbms_output.put_line(1);
  end case;
  end;

-- Task 21 - 22 --

declare 
  x number(10):=5;
  begin
  if x > 10
  then
  dbms_output.put_line(x);
  else if x > 6
  then
  dbms_output.put_line(x + 1);
  else
   dbms_output.put_line(x + 2);
  end if;
  end if;
  end;

declare 
  x number(10):= 5;
  begin
  if x > 10
  then
  dbms_output.put_line(x);
  else
  dbms_output.put_line(x+1);
  end if;
  end;

declare 
  x number(10):= 5;
  begin
  if 10 > x
  then
  dbms_output.put_line(x);
  end if;
  end;

-- Task 20 --

declare
  newvalue mv%rowtype;
begin
  newvalue.firstname:= 'Shedko';
  newvalue.secondname:='Eugne';
  dbms_output.put_line(newvalue.firstname);
  dbms_output.put_line(newvalue.secondname);
end;


-- Task 19 --

declare 
  newvalue mv.firstname%type;
  begin
  newvalue := 'Shedko';
  dbms_output.put_line(newvalue);
  end;

select * from MV
select * from user_tables

-- Task 18 --

declare 
  q constant number(3):= 150;
  w constant varchar2(10) := 'Shedko';
  e constant char(10):= 'Eugene';
begin
  dbms_output.put_line(q);
  dbms_output.put_line(w);
  dbms_output.put_line(e);
end;

-- Task 6 - 17 --

declare 
  x number(3);
  y number(3):= 10;
  z number(3,2):= 5.25;
  q number(3,-1):= 191;
  w binary_float:= 12351.135131;
  e binary_double:=1146513.34534534;
  r number(10,4):= 1e-4;
  t boolean := true;
  begin
   x := 5;
  dbms_output.put_line(x);
  dbms_output.put_line(y + x);
  dbms_output.put_line(y - x);
  dbms_output.put_line(y / x);
  dbms_output.put_line(y * x);
  dbms_output.put_line(z);
  dbms_output.put_line(q);
  dbms_output.put_line(w);
  dbms_output.put_line(e);
  dbms_output.put_line(r);
  end;

-- Task 5 --

show parameter plsql_warnings

-- Task 4 --

declare
 x number(3):= 5;
 y number(3):= 0;
 z number(3);
 begin
  begin
    z:= x/y;
  end;
   exception
    when others
    then dbms_output.put_line(sqlcode || sqlerrm);
 end;

declare
 x number(3):= 5;
 y number(3):= 0;
 z number(3);
 begin
  begin
    z:= x/y;
    exception
    when others
    then dbms_output.put_line(sqlcode || sqlerrm);
  end;
 end;

-- Task 3 --

declare 
  x number(3) := 5;
  y number(3) := 0;
  z number(3);
begin
  z := x/y;
  exception
  when others
  then dbms_output.put_line(sqlcode || ' ' || sqlerrm);
end;

-- Task 2 --

begin
  dbms_output.put_line('Hello World');
end;

-- Task 1 --

begin

end;