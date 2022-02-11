CREATE TABLE FACULTY
  (
   FACULTY      VARCHAR(30)      NOT NULL,
   FACULTY_NAME VARCHAR2(80), 
   CONSTRAINT PK_FACULTY PRIMARY KEY(FACULTY) 
  );
--drop table faculty;
insert into FACULTY   (FACULTY,   FACULTY_NAME )
             values  ('IDiP', 'Publishing and Printing');
insert into FACULTY   (FACULTY,   FACULTY_NAME )
            values  ('KhTiT', 'Chemical technology and equipment');
insert into FACULTY   (FACULTY,   FACULTY_NAME )
            values  ('LHF', 'Faculty of Forestry');
insert into FACULTY   (FACULTY,   FACULTY_NAME )
            values  ('IEF', 'Faculty of Engineering and Economics');
insert into FACULTY   (FACULTY,   FACULTY_NAME )
            values  ('TTLP', 'Technology and equipment of the forest industry');
insert into FACULTY   (FACULTY,   FACULTY_NAME )
            values  ('TOV', 'Technology of organic substances');
insert into FACULTY   (FACULTY,   FACULTY_NAME )
            values  ('FIT', 'Faculty of Information Technology');

--------------------------------------------------------------------------------------------
 --DROP TABLE PULPIT;
CREATE TABLE PULPIT 
(
 PULPIT       VARCHAR(30)      NOT NULL,
 PULPIT_NAME  VARCHAR2(100), 
 FACULTY      VARCHAR(40)      NOT NULL, 
 CONSTRAINT FK_PULPIT_FACULTY FOREIGN KEY(FACULTY)   REFERENCES FACULTY(FACULTY), 
 CONSTRAINT PK_PULPIT PRIMARY KEY(PULPIT) 
 ); 
 

insert into PULPIT   (PULPIT,    PULPIT_NAME,                                                   FACULTY )
             values  ('ISiT', 'Information systems and technologies', 'IDiP');
insert into PULPIT   (PULPIT,    PULPIT_NAME,                                                   FACULTY )
             values  ('POiSOI', 'Printing information processing', 'IDiP');
insert into PULPIT   (PULPIT,    PULPIT_NAME,                                                   FACULTY)
              values  ('LV', 'Forestry', 'LHF') ;         
insert into PULPIT   (PULPIT,    PULPIT_NAME,                                                   FACULTY)
             values  ('ОВ', 'Hunting', 'LHF') ;   
insert into PULPIT   (PULPIT,    PULPIT_NAME,                                                   FACULTY)
             values  ('LU', 'Forest inventory', 'LHF');           
insert into PULPIT   (PULPIT,    PULPIT_NAME,                                                   FACULTY)
             values  ('LZIDV', 'Forest protection and wood science', 'LHF');                
insert into PULPIT   (PULPIT,    PULPIT_NAME,                                                   FACULTY)
             values  ('LPiSPS', 'Landscape design and landscape gardening', 'LHF');                  
insert into PULPIT   (PULPIT,    PULPIT_NAME,                                                   FACULTY)
             values  ('TL', 'Forest transport', 'TTLP');                        
insert into PULPIT   (PULPIT,    PULPIT_NAME,                                                   FACULTY)
             values  ('LMiLZ', 'Forest machines and logging technologies', 'TTLP');                        
insert into PULPIT   (PULPIT,    PULPIT_NAME,                                                   FACULTY)
             values  ('ОХ', 'Organic chemistry', 'TOV');            
insert into PULPIT   (PULPIT,    PULPIT_NAME,                                                              FACULTY)
             values  ('TNKhSiPM', 'Technologies for petrochemical synthesis and processing of polymer materials', 'TOV');             
insert into PULPIT   (PULPIT,    PULPIT_NAME,                                                      FACULTY)
             values  ('TNViOKhT', 'Technologies of inorganic substances and general chemical technology', 'HTiT');                    
insert into PULPIT   (PULPIT,    PULPIT_NAME,                                                                         FACULTY)
             values  ('KhTEPiMEE', 'Chemistry, technologies of electrochemical production and electronic materials', 'KhTiT');
insert into PULPIT   (PULPIT,    PULPIT_NAME,                                                      FACULTY)
             values  ('ETiM', 'economic theory and marketing', 'IEF');   
insert into PULPIT   (PULPIT,    PULPIT_NAME,                                                      FACULTY)
             values  ('MiEP', 'Management and economics of environmental management', 'IEF');    
------------------------------------------------------------------------------------------------------------------------        - DROP  TABLE TEACHER
CREATE TABLE TEACHER
 (
  TEACHER VARCHAR (40) NOT NULL,
  TEACHER_NAME VARCHAR2 (70),
  PULPIT VARCHAR (40) NOT NULL,
  BIRTHDAY DATE,
  SALARY NUMBER (5),
  CONSTRAINT PK_TEACHER PRIMARY KEY (TEACHER),
  CONSTRAINT FK_TEACHER_PULPIT FOREIGN KEY (PULPIT) REFERENCES PULPIT (PULPIT)
 );

alter session set nls_date_format = 'DD-MM-YYYY';  -- !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

insert into TEACHER (TEACHER, TEACHER_NAME, PULPIT, BIRTHDAY, SALARY)
                       values ('SMLV', 'Smelov Vladimir Vladislavovich', 'ISiT', '02-01-1990', 1000);
insert into TEACHER (TEACHER, TEACHER_NAME, PULPIT, BIRTHDAY, SALARY)
                       values ('AKNVCH', 'Akunovich Stanislav Ivanovich', 'ISiT', '04.07.1961', 600);
insert into TEACHER (TEACHER, TEACHER_NAME, PULPIT, BIRTHDAY, SALARY)
                       values ('KLSNV', 'Kolesnikov Leonid Valerievich', 'ISiT', '05.08.1955', 500);
insert into TEACHER (TEACHER, TEACHER_NAME, PULPIT, BIRTHDAY, SALARY)
                       values ('GRMN', 'Oleg Vitoldovich German', 'ISiT', '05/06/1961', 550);
insert into TEACHER (TEACHER, TEACHER_NAME, PULPIT, BIRTHDAY, SALARY)
                       values ('LSHNK', 'Anatoly Pvalovich Laschenko', 'ISiT', '08/01/1963', 620);
insert into TEACHER (TEACHER, TEACHER_NAME, PULPIT, BIRTHDAY, SALARY)
                       values ('BRKVCH', 'Brakovich Andrey Igorievich', 'ISiT', '03.03.1971', 480);
insert into TEACHER (TEACHER, TEACHER_NAME, PULPIT, BIRTHDAY, SALARY)
                       values ('DDC', 'Dedko Alexander Arkadievich', 'ISiT', '09/11/1965', 490);
insert into TEACHER (TEACHER, TEACHER_NAME, PULPIT, BIRTHDAY, SALARY)
                       values ('KBL', 'Kabailo Alexander Serafimovich', 'ISiT', '13.02.1960', 530);
insert into TEACHER (TEACHER, TEACHER_NAME, PULPIT, BIRTHDAY, SALARY)
                       values ('URB', 'Urbanovich Pavel Pavlovich', 'ISiT', '04.21.1964', 710);
insert into TEACHER (TEACHER, TEACHER_NAME, PULPIT, BIRTHDAY, SALARY)
                       values ('RMNK', 'Romanenko Dmitry Mikhailovich', 'ISiT', '07.17.1973', 670);
insert into TEACHER (TEACHER, TEACHER_NAME, PULPIT, BIRTHDAY, SALARY)
                       values ('PSTVLV', 'Pustovalova Natalia Nikolaevna', 'ISiT', '13 .10.1968 ', 460);
insert into TEACHER (TEACHER, TEACHER_NAME, PULPIT, BIRTHDAY, SALARY)
                       values ('ZhLK', 'Zhilyak Nadezhda Aleksandrovna', 'ISiT', '01/12/1980', 490);
insert into TEACHER (TEACHER, TEACHER_NAME, PULPIT, BIRTHDAY, SALARY)
                       values ('BRTSHVCH', 'Bartashevich Svyatoslav Alexandrovich', 'POISOI', '04/09/1972', 390);
insert into TEACHER (TEACHER, TEACHER_NAME, PULPIT, BIRTHDAY, SALARY)
                       values ('YUDNKV', 'Yudenkov Viktor Stepanovich', 'POiSOI', '17.02.1974', 380);
insert into TEACHER (TEACHER, TEACHER_NAME, PULPIT, BIRTHDAY, SALARY)
                       values ('BRNVSK', 'Baranovskiy Stanislav Ivanovich', 'ETiM', '01.21.1982', 440);
insert into TEACHER (TEACHER, TEACHER_NAME, PULPIT, BIRTHDAY, SALARY)
                       values ('NVRV', 'Neverov Alexander Vasilievich', 'MiEP', '26 .10.1975 ', 430);
insert into TEACHER (TEACHER, TEACHER_NAME, PULPIT, BIRTHDAY, SALARY)
                       values ('RVKCH', 'Rovkach Andrey Ivanovich', 'OV', '02.19.1973', 395);
insert into TEACHER (TEACHER, TEACHER_NAME, PULPIT, BIRTHDAY, SALARY)
                       values ('DMDK', 'Demidko Marina Nikolaevna', 'LPiSPS', '12/26/1978', 320);
insert into TEACHER (TEACHER, TEACHER_NAME, PULPIT, BIRTHDAY, SALARY)
                       values ('MShKVSK', 'Mashkovsky Vladimir Petrovich', 'LU', '23.10.1974', 750);
insert into TEACHER (TEACHER, TEACHER_NAME, PULPIT, BIRTHDAY, SALARY)
                       values ('LBH', 'Labokha Konstantin Valentinovich', 'LV', '03/28/1968', 630);
insert into TEACHER (TEACHER, TEACHER_NAME, PULPIT, BIRTHDAY, SALARY)
                       values ('ZVGTSV', 'Zvyagintsev Vyacheslav Borisovich', 'LZIDV', '11/26/1974', 410);
insert into TEACHER (TEACHER, TEACHER_NAME, PULPIT, BIRTHDAY, SALARY)
                       values ('BZBRDV', 'Bezborodov Vladimir Stepanovich', 'ОХ', '05.05.1972', 610);
insert into TEACHER (TEACHER, TEACHER_NAME, PULPIT, BIRTHDAY, SALARY)
                       values ('PRKPCHK', 'Nikolay Romanovich Prokopchuk', 'TNKhSiPM', '08/07/1968', 630);
insert into TEACHER (TEACHER, TEACHER_NAME, PULPIT, BIRTHDAY, SALARY)
                       values ('NSKVTs', 'Naskovets Mikhail Trofimovich', 'TL', '08/12/1969', 465);
insert into TEACHER (TEACHER, TEACHER_NAME, PULPIT, BIRTHDAY, SALARY)
                       values ('ESCHNK', 'Eschenko Lyudmila Semyonovna', 'TNViOKhT', '07/28/1972', 415);
insert into TEACHER (TEACHER, TEACHER_NAME, PULPIT, BIRTHDAY, SALARY)
                       values ('ZhRSK', 'Zharskiy Ivan Mikhailovich', 'KhTEPiMEE', '13.04.1955', 860);
---------------------------------------------------------------------------------------------------------------------
CREATE TABLE SUBJECT
    (
     SUBJECT      VARCHAR(40)     NOT NULL, 
     SUBJECT_NAME VARCHAR2(70)  NOT NULL,
     PULPIT       VARCHAR(40)     NOT NULL,  
     CONSTRAINT PK_SUBJECT PRIMARY KEY(SUBJECT),
     CONSTRAINT FK_SUBJECT_PULPIT FOREIGN  KEY(PULPIT)  REFERENCES PULPIT(PULPIT)
    );

--drop table subject;
insert into SUBJECT (SUBJECT, SUBJECT_NAME, PULPIT)
                       values ('DBMS', 'Database Management Systems', 'ISiT');
insert into SUBJECT (SUBJECT, SUBJECT_NAME, PULPIT)
                       values ('DB', 'Databases', 'ISiT');
insert into SUBJECT (SUBJECT, SUBJECT_NAME, PULPIT)
                       values ('INF', 'Information Technologies', 'ISiT');
insert into SUBJECT (SUBJECT, SUBJECT_NAME, PULPIT)
                       values ('OAiP', 'Fundamentals of Algorithmization and Programming', 'ISiT');
insert into SUBJECT (SUBJECT, SUBJECT_NAME, PULPIT)
                       values ('PZ', 'Representation of knowledge in computer systems', 'ISiT');
insert into SUBJECT (SUBJECT, SUBJECT_NAME, PULPIT)
                       values ('PSP', 'Programming network applications', 'ISiT');
insert into SUBJECT (SUBJECT, SUBJECT_NAME, PULPIT)
                       values ('MSOI', 'Modeling of information processing systems', 'ISiT');
insert into SUBJECT (SUBJECT, SUBJECT_NAME, PULPIT)
                       values ('PIS', 'Information systems design', 'ISiT');
insert into SUBJECT (SUBJECT, SUBJECT_NAME, PULPIT)
                       values ('KG', 'Computer Geometry', 'ISiT');
insert into SUBJECT (SUBJECT, SUBJECT_NAME, PULPIT)
                       values ('PMAPL', 'Printing machines, automatic machines and production lines', 'POISOI');
insert into SUBJECT (SUBJECT, SUBJECT_NAME, PULPIT)
                       values ('KMS', 'Computer multimedia systems', 'ISiT');
insert into SUBJECT (SUBJECT, SUBJECT_NAME, PULPIT)
                       values ('OPP', 'Organization of printing production', 'POiSOI');
insert into SUBJECT (SUBJECT, SUBJECT_NAME, PULPIT)
               values ('DM', 'Discrete mathematics', 'ISiT');
insert into SUBJECT (SUBJECT, SUBJECT_NAME, PULPIT)
               values ('MP', 'Mathematical programming', 'ISiT');
insert into SUBJECT (SUBJECT, SUBJECT_NAME, PULPIT)
               values ('LEC', 'Logical foundations of a computer', 'ISiT');
insert into SUBJECT (SUBJECT, SUBJECT_NAME, PULPIT)
               values ('OOP', 'Object Oriented Programming', 'ISiT');
insert into SUBJECT (SUBJECT, SUBJECT_NAME, PULPIT)
               values ('EP', 'Environmental Economics', 'MEP');
insert into SUBJECT (SUBJECT, SUBJECT_NAME, PULPIT)
               values ('ET', 'Economic Theory', 'ETiM');
insert into SUBJECT (SUBJECT, SUBJECT_NAME, PULPIT)
               values ('OSPiLPH', 'Fundamentals of garden and forestry', 'LPiSPS');
insert into SUBJECT (SUBJECT, SUBJECT_NAME, PULPIT)
               values ('IG', 'Engineering Geodesy', 'LU');
insert into SUBJECT (SUBJECT, SUBJECT_NAME, PULPIT)
                       values ('THREE', 'Technology of rubber products', 'TNKhSiPM');
insert into SUBJECT (SUBJECT, SUBJECT_NAME, PULPIT)
                       values ('VTL', 'Water transport of the forest', 'TL');
insert into SUBJECT (SUBJECT, SUBJECT_NAME, PULPIT)
                       values ('TiOL', 'Technology and equipment for logging', 'LMiLZ');
insert into SUBJECT (SUBJECT, SUBJECT_NAME, PULPIT)
                       values ('TOPI', 'Mineral processing technology', 'TNViOKhT');
---------------------------------------------------------------------------------------------------------------------
--DROP TABLE AUDITORIUM_TYPE ;
create table AUDITORIUM_TYPE 
(
  AUDITORIUM_TYPE   varchar(30) constraint AUDITORIUM_TYPE_PK  primary key,  
  AUDITORIUM_TYPENAME  varchar2(50) constraint AUDITORIUM_TYPENAME_NOT_NULL not null         
);

--delete AUDITORIUM_TYPE;
insert into AUDITORIUM_TYPE (AUDITORIUM_TYPE, AUDITORIUM_TYPENAME)
                        values ('LK', 'Lecture');
insert into AUDITORIUM_TYPE (AUDITORIUM_TYPE, AUDITORIUM_TYPENAME)
                        values ('LB-K', 'Computer class');
insert into AUDITORIUM_TYPE (AUDITORIUM_TYPE, AUDITORIUM_TYPENAME)
                        values ('LK-K', 'Lecture with computers');
insert into AUDITORIUM_TYPE (AUDITORIUM_TYPE, AUDITORIUM_TYPENAME)
                        values ('LB-X', 'Chemical laboratory');
insert into AUDITORIUM_TYPE (AUDITORIUM_TYPE, AUDITORIUM_TYPENAME)
                        values ('LB-SK', 'Special computer class');
---------------------------------------------------------------------------------------------------------------------

create table AUDITORIUM 
(
 AUDITORIUM           varchar(40) primary key,  -- код аудитории
 AUDITORIUM_NAME      varchar2(200),          -- аудитори�? 
 AUDITORIUM_CAPACITY  number(4),              -- вме�?тимо�?ть
 AUDITORIUM_TYPE      varchar(40) not null      -- тип аудитории
                      references AUDITORIUM_TYPE(AUDITORIUM_TYPE)  
);

--drop table AUDITORIUM;
insert into AUDITORIUM (AUDITORIUM, AUDITORIUM_NAME, AUDITORIUM_TYPE, AUDITORIUM_CAPACITY)
                       values ('206-1', '206-1', 'LB-K', 15);
insert into AUDITORIUM (AUDITORIUM, AUDITORIUM_NAME, AUDITORIUM_TYPE, AUDITORIUM_CAPACITY)
                       values ('301-1', '301-1', 'LB-K', 15);
insert into AUDITORIUM (AUDITORIUM, AUDITORIUM_NAME, AUDITORIUM_TYPE, AUDITORIUM_CAPACITY)
                       values ('236-1', '236-1', 'LC', 60);
insert into AUDITORIUM (AUDITORIUM, AUDITORIUM_NAME, AUDITORIUM_TYPE, AUDITORIUM_CAPACITY)
                       values ('313-1', '313-1', 'LC', 60);
insert into AUDITORIUM (AUDITORIUM, AUDITORIUM_NAME, AUDITORIUM_TYPE, AUDITORIUM_CAPACITY)
                       values ('324-1', '324-1', 'LC', 50);
insert into AUDITORIUM (AUDITORIUM, AUDITORIUM_NAME, AUDITORIUM_TYPE, AUDITORIUM_CAPACITY)
                       values ('413-1', '413-1', 'LB-K', 15);
insert into AUDITORIUM (AUDITORIUM, AUDITORIUM_NAME, AUDITORIUM_TYPE, AUDITORIUM_CAPACITY)
                       values ('423-1', '423-1', 'LB-K', 90);
insert into AUDITORIUM (AUDITORIUM, AUDITORIUM_NAME, AUDITORIUM_TYPE, AUDITORIUM_CAPACITY)
                       values ('408-2', '408-2', 'LC', 90);
insert into AUDITORIUM (AUDITORIUM, AUDITORIUM_NAME, AUDITORIUM_TYPE, AUDITORIUM_CAPACITY)
                       values ('103-4', '103-4', 'LK', 90);
insert into AUDITORIUM (AUDITORIUM, AUDITORIUM_NAME, AUDITORIUM_TYPE, AUDITORIUM_CAPACITY)
                       values ('105-4', '105-4', 'LC', 90);
insert into AUDITORIUM (AUDITORIUM, AUDITORIUM_NAME, AUDITORIUM_TYPE, AUDITORIUM_CAPACITY)
                       values ('107-4', ​​'107-4', ​​'LC', 90);
insert into AUDITORIUM (AUDITORIUM, AUDITORIUM_NAME, AUDITORIUM_TYPE, AUDITORIUM_CAPACITY)
                       values ('110-4', '110-4', 'LC', 30);
insert into AUDITORIUM (AUDITORIUM, AUDITORIUM_NAME, AUDITORIUM_TYPE, AUDITORIUM_CAPACITY)
                       values ('111-4', '111-4', 'LK', 30);
insert into AUDITORIUM (AUDITORIUM, AUDITORIUM_NAME, AUDITORIUM_TYPE, AUDITORIUM_CAPACITY)
                      values  ('114-4', '114-4', 'LK-K', 90);
insert into AUDITORIUM (AUDITORIUM, AUDITORIUM_NAME, AUDITORIUM_TYPE, AUDITORIUM_CAPACITY)
                       values ('132-4', '132-4', 'LK', 90);
insert into AUDITORIUM (AUDITORIUM, AUDITORIUM_NAME, AUDITORIUM_TYPE, AUDITORIUM_CAPACITY)
                       values ('02 B-4 ', '02 B-4', 'LK', 90);
insert into AUDITORIUM (AUDITORIUM, AUDITORIUM_NAME, AUDITORIUM_TYPE, AUDITORIUM_CAPACITY)
                       values ('229-4', '229-4', 'LC', 90);
insert into AUDITORIUM (AUDITORIUM, AUDITORIUM_NAME, AUDITORIUM_TYPE, AUDITORIUM_CAPACITY)
                       values ('304-4', '304-4', 'LB-K', 90);
insert into AUDITORIUM (AUDITORIUM, AUDITORIUM_NAME, AUDITORIUM_TYPE, AUDITORIUM_CAPACITY)
                       values ('314-4', '314-4', 'LC', 90);
insert into AUDITORIUM (AUDITORIUM, AUDITORIUM_NAME, AUDITORIUM_TYPE, AUDITORIUM_CAPACITY)
                       values ('320-4', '320-4', 'LC', 90);
insert into AUDITORIUM (AUDITORIUM, AUDITORIUM_NAME, AUDITORIUM_TYPE, AUDITORIUM_CAPACITY)
                       values ('429-4', '429-4', 'LC', 90);
-------------------------------------------------------------------------------------------------------------------------------------------------

drop table AUDITORIUM_TYPE;
drop table FACULTY;
drop table AUDITORIUM;
drop table PULPIT;
drop table TEACHER;
drop table SUBJECT;

select * from FACULTY
select * from AUDITORIUM_TYPE
select * from AUDITORIUM
select * from SUBJECT
select * from TEACHER
select * from PULPIT
                        
                        

select * from faculty
SELECT * FROM NLS_SESSION_PARAMETERS
ALTER SESSION SET NLS_LANGUAGE= 'RUSSIAN';
                        
                        
