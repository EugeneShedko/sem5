select * from v$sgainfo   -- mayby this

select * from v$sga_dynamic_components
select * from v$sgastat group by pool

-- Task 11 - 12 --

select username, service_name, server from v$session

-- Task 10 --

select * from v$sgastat where pool = 'large pool' and name = 'free memory';

-- Task 9 --

select * from v$sgastat
select * from ( select * from v$sgastat where  pool = 'shared pool' order by bytes desc) where rownum <=10;

-- Task 8 --

show parameter log_buffer

-- Task 7 --

select * from v$sga_dynamic_components

-- Task 6 --

select * from v$buffer_pool;
select segment_name, buffer_pool from user_segments where segment_name = 'KEEPTABLE';
create table keeptable( k number primary key ) storage(buffer_pool keep);

-- Task 5 --

select component, current_size from v$sga_dynamic_components where component = 'RECYCLE buffer cache' or  component = 'DEFAULT buffer cache' or 
component = 'KEEP buffer cache';

-- Task 4 --

select * from v$sga_dynamic_free_memory

-- Task 3 --

select component, granule_size from v$sga_dynamic_components

-- Task 2 --

select * from v$sga_dynamic_components

-- Task 1 --

select sum(value) from v$sga
select * from v$sga