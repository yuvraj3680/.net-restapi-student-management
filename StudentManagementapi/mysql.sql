//DROP DATABASE IF EXISTS student;
create database student;
use student;
create table student(userid integer primary key auto_increment, studentname varchar(50), studentcource varchar(50), studentjoin date);

insert into students values(1, "AlooBhujiya", "6", "700");
insert into students(studentid ,studentname ,studentcource,studentdatejoin)values("0","abhijit", "java"12/5/2022");