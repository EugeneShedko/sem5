-- Task 25 --

alter system switch logfile
select * from v$log

-- Task 24 --

select * from v$diag_info

-- Task 23 --

select * from v$pwfile_users

-- Task 22 --

create pfile = 'SEA_PFILE.ORA' from spfile


-- Task 21 --

select * from v$parameter

-- Task 20 --

select * from v$controlfile_record_section

-- Task 19 --

select * from v$controlfile


-- Task 18 --


-- Task 17 --

select name, log_mode from v$database;

-- Task 16 --

alter system switch logfile;
select * from v$log
select * from v$archived_log

-- Task 15 --

select * from v$archived_log

-- Task 14 --

select name, log_mode from v$database;
select instance_name, archiver, active_state from v$instance

-- Task 13 --

alter database drop logfile group 4;

alter database drop logfile member 'C:\APP\ORCALEUSER\ORADATA\ORCL\REDO043.LOG'
alter database drop logfile member 'C:\APP\ORCALEUSER\ORADATA\ORCL\REDO042.LOG'
alter database drop logfile member 'C:\APP\ORCALEUSER\ORADATA\ORCL\REDO041.LOG'
alter database drop logfile member 'C:\APP\ORCALEUSER\ORADATA\ORCL\REDO04.LOG'

-- Task 12 --

alter system switch logfile

alter database add logfile member 'C:\APP\ORCALEUSER\ORADATA\ORCL\REDO041.LOG' to group 4
alter database add logfile member 'C:\APP\ORCALEUSER\ORADATA\ORCL\REDO042.LOG' to group 4
alter database add logfile member 'C:\APP\ORCALEUSER\ORADATA\ORCL\REDO043.LOG' to group 4


alter database add logfile group 4 'C:\APP\ORCALEUSER\ORADATA\ORCL\REDO04.LOG'
size 50m blocksize 512

-- Task 11 -- 

alter system switch logfile

-- Task 10 --

select * from v$logfile

-- Task 9 --

select * from v$log

-- Task 3 --

select * from dba_segments where tablespace_name = 'SEA_QDATA2'

-- Task 2 --

select * from dba_sys_privs
grant drop table to c##ROLE
grant create table to c##ROLE
select * from dba_ts_quotas   -- view quotas in tablespaces
alter user c##SEA quota 2m on SEA_QDATA2

select * from dba_users

alter tablespace SEA_QDATA2 online

create tablespace SEA_QDATA2
datafile 'c:\app\Tablespaces\sea_qdata2.dbf'
size 10m
autoextend on next 500K
maxsize 100M
offline

-- Task 1 --

select * from dba_temp_files
select * from dba_data_files 