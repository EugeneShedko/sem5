
select * from dba_tables where table_name = 'NEWUSERTABLE'
select * from dba_ts_quotas
select * from dba_users where username = 'SEACORE'
select * from dba_tablespaces


-- Task 11 --

alter user SEACORE quota 2M on SEA_QDATA

-- Task 8 --

create user SEACORE identified by 12345
default tablespace TS_SEA 
quota unlimited on TS_SEA
temporary tablespace TS_SEA_TEMP
profile PR_SEACORE
account unlock
password expire

grant RL_SEACORE to SEACORE

-- Task 7 --

select * from dba_profiles 

select * from dba_profiles where profile = 'PR_SEACORE'
select * from dba_profiles where profile = 'DEFAULT'

-- Task 6 --

create profile PR_SEACORE limit
       password_life_time 180  -- day
       sessions_per_user 3 
       failed_login_attempts 7
       password_lock_time 1
       password_reuse_time 10
       password_grace_time default
       connect_time 180
       idle_time 30

-- Task 5 --

select * from DBA_SYS_PRIVS

select * from dba_roles where role = 'RL_SEACORE'

-- Task 4 --

create role RL_SEACORE

select * from dba_sys_privs where grantee = 'RL_SEACORE'

grant create tablespace to RL_SEACORE
grant alter tablespace to RL_SEACORE


grant create session,
      create table,
      create view,
      drop any table,
      drop any view,
      drop any procedure,
      create procedure to RL_SEACORE

select * from dba_roles

delete from dba_roles where role = 'RL_SEACORE'

alter session set "_ORACLE_SCRIPT"= true;

-- Task 3 --

select file_name, tablespace_name from DBA_DATA_FILES

select file_name, tablespace_name from DBA_TEMP_FILES

-- Task 2 --
 create temporary tablespace TS_SEA_TEMP
 tempfile 'C:\app\Tablespaces\ts_sea_temp.dbf'
 size 5M
 autoextend on next 3M
 maxsize 30M

--  Task1 --
 create tablespace TS_SEA
 datafile 'C:\app\Tablespaces\ts_sea.dbf'
 size 10 M
 autoextend on next 500k 
 maxsize 100M