
grant create session to c##sea

-- Task 8 --

select * from dba_tablespaces
select * from dba_data_files
select * from dba_temp_files
select * from dba_roles
select * from dba_sys_privs
select * from dba_profiles
select * from dba_users

-- Task 6 --

grant newrole to U1_SEA_PDB

grant create session, 
      create table to newrole 

select * from dba_users where username='U1_SEA_PDB'

create user U1_SEA_PDB identified by 11111
default tablespace newpertablespace quota unlimited on newpertablespace
temporary tablespace newtemptablespace
profile newprofile
account unlock

create profile newprofile limit
password_life_time 180
sessions_per_user 3
failed_login_attempts 7
password_lock_time 1
password_reuse_time 10
password_grace_time default
connect_time 180
idle_time 30

select * from dba_roles
create role newrole

create temporary tablespace newtemptablespace
tempfile 'C:\app\Tablespaces\newtemptablespace.dbf'
size 10m
autoextend on next 500K
maxsize 100M
extent management local

create tablespace newpertablespace
datafile 'C:\app\Tablespaces\newpertablespace.dbf'
size 10m
autoextend on next 500K
maxsize 100M
extent management local 

select * from dba_tablespaces