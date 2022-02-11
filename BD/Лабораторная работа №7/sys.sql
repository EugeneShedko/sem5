-- Task 12 --

select * from v$listener_network

-- Task 10 - 11 --



-- Task 9 --

select * from v$session where username is not null

-- Task 8 --



-- Task 7 --

show parameters dispatcher

-- Task 6 --

select * from v$services

-- Task 4 - 5 --

select username, server from v$session

-- Task 3--

select * from v$bgprocess where name like '%DBW%' and paddr != '00'

-- Task 2 --

select * from v$bgprocess where paddr != '00'

-- Task 1 --

select * from v$bgprocess