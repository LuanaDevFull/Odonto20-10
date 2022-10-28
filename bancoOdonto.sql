create database bdOdonto;
use bdOdonto;

create table tbLogin(
usuario varchar(50) primary key,
senha varchar(10),
tipo int);

insert into tbLogin values("draAna","crm125971",2);
insert into tbLogin values("pudim","chocolate",1);

drop table tbPaciente;
create table tbPaciente(
codPaciente int primary key auto_increment,
nmPaciente varchar(50),
CPFPaciente varchar(11),
emailPaciente varchar(50),
telPaciente varchar(24),
sexoPaciente varchar(2));

create table tbEspecialidade(
codEspecialidade int primary key auto_increment,
tipoEspecialidade varchar(50)
);

create table tbDentista(
codDentista int primary key auto_increment,
nmDentista varchar(50),
codEspecialidade int,
foreign key (codEspecialidade) references tbEspecialidade(codEspecialidade)
);

create table tbAtendimento(
codAtendimento int primary key auto_increment,
dataAtendimento varchar(10),
horaDentista varchar(5),
codPaciente int, 
codDentista int,
foreign key (codPaciente) references tbPaciente(codPaciente),
foreign key (codDentista)  references tbDentista(codDentista));


create view vwDentista as select
tbDentista.nmDentista,
tbEspecialidade.tipoEspecialidade
from tbDentista inner join tbEspecialidade
	on tbDentista.codEspecialidade = tbEspecialidade.codEspecialidade;

create view vwAtendimento as select
tbAtendimento.dataAtendimento,
tbAtendimento.horaDentista,
tbPaciente.nmPaciente,
tbDentista.nmDentista
from tbAtendimento inner join tbPaciente 
	on tbAtendimento.codPaciente = tbPaciente.codPaciente
inner join tbDentista on tbAtendimento.codDentista = tbDentista.codDentista; 

select * from tbPaciente;
select * from tbLogin;
