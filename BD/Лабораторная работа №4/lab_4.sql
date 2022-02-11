-- Task 9 --

grant create session to C##sea

alter pluggable database sea_pdb open

select * from dba_pdbs

select * from dba_sys_privs
select * from dba_roles
grant c##role to c##SEA
grant create session to c##role

select * from dba_roles
create role c##role

select * from dba_users

create user C##SEA identified by 11111
default tablespace ts_sea quota unlimited on ts_sea
temporary tablespace ts_sea_temp
account unlock

select * from dba_tablespaces

-- Task 6 --
-- Task 5 --

select * from v$pdbs

-- Task 4 --



-- Task 3 --

select comp_name, version, status from dba_registry;

-- Task 2 --

select * from v$instance;

-- Task 1--

select * from v$pdbs;

