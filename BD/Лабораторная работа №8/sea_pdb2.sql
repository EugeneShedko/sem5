grant create view to c##sea


select * from v$session

select * from dba_segments where owner = 'C##SEA'

grant select on C##SEA.TABLE1 to C##SEA;

select * from dba_tablespaces

alter user C##SEA default tablespace NEWPERTABLESPACE

alter user C##SEA quota unlimited on NEWPERTABLESPACE 