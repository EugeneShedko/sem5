select * from orders;

select * from customers;

select * from salesreps;

select * from offices;

select * from products;

select  orders.cust,  sum(amount) as sss from orders group by cust order by sss desc;

-- zadanie10 --

create or replace function zadanie10(customername in varchar2, ordersyear in varchar2) return number
is
ordersnumber number;
begin
  select count(*) into ordersnumber from customers inner join orders on customers.cust_num = orders.cust where customers.company = customername and to_char(orders.order_date, 'YYYY') = ordersyear;
  return ordersnumber;
end;

select zadanie10('JCP Inc.', '2008') from dual;

-- zadanie9 --

create procedure zadanie9(productname in varchar2)
is
begin
  update products set price = price + (price * 0.2) where description = productname;
end;

begin
  zadanie9('Ratchet Link');
end;
-- zadanie8 --

select count(*) from (select customers.company from customers inner join orders on customers.cust_num = orders.cust inner join products on orders.mfr = products.mfr_id 
and orders.product = products.product_id where products.description = '900-LB Brace' group by customers.company);

create or replace function zadanie8(productname in varchar2) return number
is
 companynumber number;
begin
 select count(*) into companynumber from (select customers.company from customers inner join orders on customers.cust_num = orders.cust inner join products on orders.mfr = products.mfr_id 
and orders.product = products.product_id where products.description = productname group by customers.company);
return companynumber;
end;

select zadanie8('900-LB Brace') from dual;
-- zadanie7 --

create or replace procedure zadanie7(firstdate in orders.order_date%type, seconddate in orders.order_date%type)
is
  resulttable sys_refcursor;
  customername customers.company%type;
  sss number;
begin
  open resulttable for select customers.company from customers inner join orders on customers.cust_num = orders.cust where orders.order_date between firstdate and seconddate group by customers.company;
  dbms_output.put_line(sss);
  fetch resulttable into customername;
  while(resulttable%found)
  loop
  dbms_output.put_line(customername);
  fetch resulttable into customername;
  end loop;
  close resulttable;
end;

begin
  zadanie7('17-DEC-07', '11-JAN-08');
end;
-- zadanie6 --

create or replace function zadanie6(firstdate in orders.order_date%type, seconddate in orders.order_date%type) return number
is
ordersnumber number;
begin
  select count(*) into ordersnumber from orders where orders.order_date between firstdate and seconddate;
  return ordersnumber;
end;

 select zadanie6('17-DEC-07', '11-JAN-08') from dual;

-- zadanie5 --

create or replace procedure zadanie5(firstdate in orders.order_date%type, seconddate in orders.order_date%type)
is
  resulttable sys_refcursor;
  companyname customers.company%type;
  amount orders.amount%type;
  cust orders.cust%type;
begin
  open resulttable for select customers.company, sum(orders.amount) as summ from customers inner join orders on customers.cust_num = orders.cust where orders.order_date between firstdate and seconddate 
  group by customers.company order by summ desc;
  
  fetch resulttable into  companyname, amount;
  while(resulttable%found)
  loop
    dbms_output.put_line(companyname || ' ' || amount);
     fetch resulttable into  companyname, amount;
  end loop;
  close resulttable;
end;

begin
  zadanie5('17-DEC-07', '11-JAN-08');
end;

-- zadanie4 --

create or replace function zadanie4(firstdate in orders.order_date%type, seconddate in orders.order_date%type) return number
is
ordersnumber number;
begin
  select count(*) into ordersnumber from orders where orders.order_date between firstdate and seconddate;
  return ordersnumber;
end;

select zadanie4('17-DEC-07' , '11-JAN-08') from dual;
-- zadanie3 --


select orders.order_num,orders.amount from customers inner join orders
  on customers.cust_num = orders.cust  where customers.company = 'JCP Inc.';


create or replace procedure zadanie3(customername in varchar2) 
is
resulttable sys_refcursor;
ordernumber orders.order_num%type;
product products.description %type;
amount orders.amount%type;
begin
  open resulttable for  select orders.order_num, products.description, orders.amount from customers inner join orders
  on customers.cust_num = orders.cust inner join products on orders.product = products.product_id and orders.mfr = products.mfr_id where customers.company = customername  order by orders.amount desc;
  
  fetch resulttable into ordernumber, product, amount;
  while(resulttable%found)
  loop
  dbms_output.put_line(ordernumber || ' ' || product || ' ' || amount);
  fetch resulttable into ordernumber, product, amount;
  end loop;
  
  close resulttable;
  
  exception
  when others
  then dbms_output.put_line(sqlcode || ' ' || sqlerrm);
  
end;

begin
  zadanie3('JCP Inc.');
end;

-- zadanie2 --

create function zadanie2(firstdate in date, seconddate in date, customername in varchar2) return number
is
ordernumber number;
begin
  select count(*) into ordernumber from customers inner join orders on  customers.cust_num = orders.cust where customers.company = customername and orders.order_date between firstdate and seconddate;
  return ordernumber;
end;

select zadanie2('12-SEP-07', '12-NOV-07', 'JCP Inc.') from dual;

select * from orders where cust = 2111;

-- zadanie1 --

create or replace procedure zadanie1(customername in varchar2)
is
avgvalue orders.amount%type;
resulttable sys_refcursor;
companyname customers.company %type;
ordernumber orders.order_num%type;
product products.description % type;
begin 
open resulttable  for select customers.company, orders.order_num, products.description from customers inner join orders 
 on customers.cust_num = orders.cust inner join products
 on orders.product = products.product_id
 where customers.company = customername; 
 fetch resulttable into companyname, ordernumber, product;
 while(resulttable%found)
 loop
 dbms_output.put_line(companyname || ' ' || ordernumber || ' ' || product);
 fetch resulttable into companyname, ordernumber, product;
 end loop;
 close resulttable;

select avg(orders.amount) into avgvalue from customers inner join orders 
on customers.cust_num = orders.cust inner join products
on orders.product = products.product_id
where customers.company = customername; 

dbms_output.put_line(avgvalue);

exception
when others
then dbms_output.put_line(sqlcode || ' ' || sqlerrm);
end;

begin
  zadanie1('JCP Inc.');
end;
