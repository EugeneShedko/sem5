create tablespace TS_SSA_PDB
  datafile 'C:\Labs\Lab3\TS_SSA_PDB.dbf'
  size 7 m
  autoextend on next 5 m
  maxsize 20 m;

create temporary tablespace TS_SSA_TEMP_PDB
  tempfile 'C:\Labs\Lab3\TS_SSA_TEMP_PDB.dbf'
  size 5 m
  autoextend on next 3 m
  maxsize 30 m;
  
create role RL_SSACORE_PDB;
grant create session,
      create table,
      drop any table,
      create view,
      drop any view,
      create procedure,
      drop any procedure to RL_SSACORE_PDB;
      
      
create profile PF_SSACORE_PDB limit
  password_life_time 180
  sessions_per_user 3
  failed_login_attempts 7
  password_lock_time 1
  password_reuse_time 10
  password_grace_time default
  connect_time 180
  idle_time 30;
  
create user U1_SSA_PDB IDENTIFIED BY 1122
default tablespace TS_SSA_PDB quota unlimited on TS_SSA_PDB
temporary tablespace TS_SSA_TEMP_PDB
profile PF_SSACORE_PDB
account unlock;

grant RL_SSACORE_PDB to U1_SSA_PDB;

--8
select * from SYS.dba_tablespaces;

select FILE_NAME, TABLESPACE_NAME, STATUS from DBA_DATA_FILES
UNION
select FILE_NAME, TABLESPACE_NAME, STATUS from DBA_TEMP_FILES;

select * from SYS.dba_roles;

select * from Sys.dba_profiles;

select * from sys.dba_users;

select * from SYS.dba_role_privs where grantee like '%PDB%'

--9
grant create session to C##SSA;