--1. get all size SGA
select sum(value) from v$sga;

--2.get all pools SGA
select * from v$sga_dynamic_components where current_size > 0;

--3.get granules for each pool
select component, granule_size from v$sga_dynamic_components where current_size > 0;

--4. get free memory SGA
select current_size from v$sga_dynamic_free_memory;

--5.get size pools KEEP, DEFAULT, RECYCLE and buffer cash
select component, current_size, min_size from v$sga_dynamic_components where component ='KEEP buffer cache' or component = 'DEFAULT buffer cache' or component = 'RECYCLE buffer cache';

--6.create table that fits into the KEEP pool. get segment table
create table Mytable(x int) storage(buffer_pool keep);
select segment_name, segment_type, tablespace_name, buffer_pool from user_segments where lower(segment_name)='mytable';

--7.reate table that fits into the default pool. get segment table
create table Mytable2(x int) cache storage(buffer_pool default);
select segment_name, segment_type, tablespace_name, buffer_pool from user_segments where lower(segment_name)='mytable2';

--8. get the size of replay logs
show parameter log_buffer;

--9.fined the 10 largest objects in the shared pool
select *from (select pool, name, bytes from v$sgastat where pool = 'shared pool' order by bytes desc) where rownum <=10;

--10. get free size in the pool
select pool, name, bytes from v$sgastat where pool = 'large pool' and name = 'free memory';

--11.get current connection with instans
select * from v$session;

--12. get the modes current connection with instans
select username, server from v$session;

