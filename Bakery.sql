--���� ������ "�������" ������� �1 ���������� �.�. ����� �.�. ������� �.�.
set ansi_padding on
go

set quoted_identifier on
go

set ansi_nulls on
go

create database [Bakery]
go

use [Bakery]
go

--select * from [dbo].[History]
--select * from [dbo].[Documents] 
--select * from [dbo].[Postavhik] 
--select * from [dbo].[Sirie]  
--select * from [dbo].[Type_Tovar] 
--select * from [dbo].[Doljnost] 
--select * from [dbo].[Sotrudnik] 
--select * from [dbo].[Tovar]  
--select * from [dbo].[Status_Zakaza] 
--select * from [dbo].[Klient] 
--select * from [dbo].[Zakaz]
--select * from [dbo].[Type_Zakaz] 
--select * from [dbo].[Tovar_Zakaz] 
--select * from [dbo].[Chek] 

--EXEC [dbo].[Documents_Delete] @ID_Normativnie_Documenti = '3'
go

--������� "�������"
create table [dbo].[History] 
(
    [ID_History] [int] not null identity(1,1),
	[ProductId] [int] not null,
    [Operation] [varchar] (400) not null,
    [CreateAt] DATETIME NOT NULL DEFAULT GETDATE(),
)
go 

--������� "����������� ���������"
create table [dbo].[Documents]
(
	[ID_Normativnie_Documenti] [int] not null identity(1,1),
	[Name_Normativnie_Documenti] [varchar] (30) not null,
	[Srok_Deistviya] [varchar] (10) not null,
	constraint [PK_ID_Normativnie_Documenti] primary key clustered ([ID_Normativnie_Documenti] ASC) on [PRIMARY],
	constraint [CH_Name_Normativnie_Documenti] check ([Name_Normativnie_Documenti] like '%[�-�]%' OR [Name_Normativnie_Documenti] like '%[�-�]%'),
	constraint [CH_Srok_Deistviya] check ([Srok_Deistviya] like '[0-9][0-9].[0-9][0-9].[0-9][0-9][0-9][0-9]')
)
go

--��������� ������ � ������� "����������� ���������"
insert into [dbo].[Documents] ([Name_Normativnie_Documenti],[Srok_Deistviya])
values ('����������','00.00.2020'),
	   ('������� �����-������� ','03.05.2020'),
	   ('������� �������� 2','08.01.2020'),
	   ('������� ���������� �� �������','19.03.2020'),
	   ('������� ����������� �����','16.06.2020'),
	   ('������� ���� 649','12.09.2020'),
	   ('������� ������ ��������','21.07.2020'),
	   ('������� ������� ���������','11.02.2020'),
	   ('������� �������� �����','09.08.2020'),
	   ('������� ����������� �����','13.04.2020')
go

--��������� ���������� ������ � ������� "����������� ���������"
create procedure [dbo].[Documents_Insert]
@Name_Normativnie_Documenti [varchar] (30), @Srok_Deistviya [varchar] (10)
as
	insert into [dbo].[Documents] 
	([Name_Normativnie_Documenti], [Srok_Deistviya]) 
	values
	(@Name_Normativnie_Documenti, @Srok_Deistviya)
go 

--��������� ��������� ������ � ������� "����������� ���������"
create procedure [dbo].[Documents_Update]
@ID_Normativnie_Documenti [int], @Name_Normativnie_Documenti [varchar] (30), @Srok_Deistviya [varchar] (10)
as
	update [dbo].[Documents] set
		[Name_Normativnie_Documenti] = @Name_Normativnie_Documenti,
		[Srok_Deistviya] = @Srok_Deistviya
	where 
		[ID_Normativnie_Documenti] = @ID_Normativnie_Documenti
go

--��������� �������� ������ �� ������� "����������� ���������"
create procedure [dbo].[Documents_Delete]
@ID_Normativnie_Documenti [int]
as
	delete from [dbo].[Documents]
	where 
		[ID_Normativnie_Documenti] = @ID_Normativnie_Documenti
go

--������� "����������"
create table [dbo].[Postavhik]
(
	[ID_Postavhik] [int] not null identity(1,1),
	[Familiya_Postavhik] [varchar] (30) not null,
	[Name_Postavhik] [varchar] (30) not null,
	[Otchestvo_Postavhik] [varchar] (30) not null,
	[Normativnie_Documenti_ID] [int] not null,
	constraint [PK_ID_Postavhik] primary key clustered ([ID_Postavhik] ASC) on [PRIMARY],
	constraint [CH_Familiya_Postavhik] check ([Familiya_Postavhik] like '%[�-�]%' OR [Familiya_Postavhik] like '%[�-�]%'),
	constraint [CH_Name_Postavhik] check ([Name_Postavhik] like '%[�-�]%' OR [Name_Postavhik] like '%[�-�]%'),
	constraint [CH_Otchestvo_Postavhik] check ([Otchestvo_Postavhik] like '%[�-�]%' OR [Otchestvo_Postavhik] like '%[�-�]%'),
	constraint [FK_Postavhik_Documents] foreign key ([Normativnie_Documenti_ID]) references [dbo].[Documents] ([ID_Normativnie_Documenti])
)
go

--��������� ������ � ������� "����������"
insert into [dbo].[Postavhik] ([Familiya_Postavhik],[Name_Postavhik],[Otchestvo_Postavhik],[Normativnie_Documenti_ID])
values ('������','����','��������','1'),
	   ('������','����','��������','2'),
	   ('�������','�����','���������','3'),
	   ('��������','����','���������','4'),
	   ('��������','�������','���������','5'),
	   ('�������','�������','�����������','6'),
	   ('�������','������','���������','7'),
	   ('���������','������','�������������','8'),
	   ('��������','������','����������','9'),
	   ('���������','������','��������','10')	   
go

--��������� ���������� ������ � ������� "����������"
create procedure [dbo].[Postavhik_Insert]
@Familiya_Postavhik [varchar] (30), @Name_Postavhik [varchar] (30), @Otchestvo_Postavhik [varchar] (30), @Normativnie_Documenti_ID [int]
as
	insert into [dbo].[Postavhik] 
	([Familiya_Postavhik], [Name_Postavhik], [Otchestvo_Postavhik], [Normativnie_Documenti_ID]) 
	values
	(@Familiya_Postavhik, @Name_Postavhik, @Otchestvo_Postavhik, @Normativnie_Documenti_ID)
go 

--��������� ��������� ������ � ������� "����������"
create procedure [dbo].[Postavhik_Update]
@ID_Postavhik [int], @Familiya_Postavhik [varchar] (30), @Name_Postavhik [varchar] (30), @Otchestvo_Postavhik [varchar] (30), @Normativnie_Documenti_ID [int]
as
	update [dbo].[Postavhik] set
		[Familiya_Postavhik] = @Familiya_Postavhik,
		[Name_Postavhik] = @Name_Postavhik,
		[Otchestvo_Postavhik] = @Otchestvo_Postavhik,
		[Normativnie_Documenti_ID] = @Normativnie_Documenti_ID
	where 
		[ID_Postavhik] = @ID_Postavhik
go

--��������� �������� ������ �� ������� "����������"
create procedure [dbo].[Postavhik_Delete]
@ID_Postavhik [int]
as
	delete from [dbo].[Postavhik]
	where 
		[ID_Postavhik] = @ID_Postavhik
go

--������� "�����"
create table [dbo].[Sirie]
(
	[ID_Sirie] [int] not null identity(1,1),
	[Name_Sirie]  [varchar] (30) not null,
	[Date_Postavki] [varchar] (10) not null,
	[Postavhik_ID] [int] not null,
	constraint [PK_ID_Sirie] primary key clustered ([ID_Sirie] ASC) on [PRIMARY],
	constraint [CH_Name_Sirie] check ([Name_Sirie] like '%[�-�]%' OR [Name_Sirie] like '%[�-�]%'),
	constraint [CH_Date_Postavki] check ([Date_Postavki] like '[0-9][0-9].[0-9][0-9].[0-9][0-9][0-9][0-9]'),
	constraint [FK_Sirie_Postavhik] foreign key ([Postavhik_ID]) references [dbo].[Postavhik] ([ID_Postavhik])
)
go

--��������� ������ � ������� "�����"
insert into [dbo].[Sirie] ([Name_Sirie],[Date_Postavki],[Postavhik_ID])
values ('����','09.04.2020','1'),
	   ('�����','19.03.2020','2'),
	   ('�������','08.04.2020','3'),
	   ('�����','03.04.2020','4'),
	   ('����','01.04.2020','5'),
	   ('���','05.04.2020','6'),
	   ('���������� ����','12.03.2020','7'),
	   ('������','17.03.2020','8'),
	   ('�����','21.03.2020','9'),
	   ('������ ��� �����','25.03.2020','10')
go

--��������� ���������� ������ � ������� "�����"
create procedure [dbo].[Sirie_Insert]
@Name_Sirie [varchar] (30), @Date_Postavki [varchar] (10), @Postavhik_ID [int]
as
	insert into [dbo].[Sirie] 
	([Name_Sirie], [Date_Postavki], [Postavhik_ID]) 
	values
	(@Name_Sirie, @Date_Postavki, @Postavhik_ID)
go 

--��������� ��������� ������ � ������� "�����"
create procedure [dbo].[Sirie_Update]
@ID_Sirie [int], @Name_Sirie [varchar] (30), @Date_Postavki [varchar] (10), @Postavhik_ID [int]
as
	update [dbo].[Sirie] set
		[Name_Sirie] = @Name_Sirie,
		[Date_Postavki] = @Date_Postavki,
		[Postavhik_ID] = @Postavhik_ID
	where 
		[ID_Sirie] = @ID_Sirie
go

--��������� �������� ������ �� ������� "����������"
create procedure [dbo].[Sirie_Delete]
@ID_Sirie [int]
as
	delete from [dbo].[Sirie]
	where 
		[ID_Sirie] = @ID_Sirie
go

--������� "��� ������"
create table [dbo].[Type_Tovar]
(
	[ID_Type_Tovar] [int] not null identity(1,1),
	[Name_Type_Tovar] [varchar] (30) not null,
	constraint [PK_ID_Type_Tovar] primary key clustered ([ID_Type_Tovar] ASC) on [PRIMARY],
	constraint [CH_Name_Type_Tovar] check ([Name_Type_Tovar] like '%[�-�]%' OR [Name_Type_Tovar] like '%[�-�]%'),
)
go

--��������� ������ � ������� "��� ������"
insert into [dbo].[Type_Tovar] ([Name_Type_Tovar])
values ('������������'),
	   ('��������������'),
	   ('�����'),
	   ('� ������'),
	   ('�� �������'),
	   ('� ��������'),
	   ('���� �����'),
	   ('������'),
	   ('���'),
	   ('�� ��������')
go

--��������� ���������� ������ � ������� "��� ������"
create procedure [dbo].[Type_Tovar_Insert]
@Name_Type_Tovar [varchar] (30)
as
	insert into [dbo].[Type_Tovar] 
	([Name_Type_Tovar]) 
	values
	(@Name_Type_Tovar)
go 

--��������� ��������� ������ � ������� "��� ������"
create procedure [dbo].[Type_Tovar_Update]
@ID_Type_Tovar [int], @Name_Type_Tovar [varchar] (30)
as
	update [dbo].[Type_Tovar] set
		[Name_Type_Tovar] = @Name_Type_Tovar
	where 
		[ID_Type_Tovar] = @ID_Type_Tovar
go

--��������� �������� ������ �� ������� "��� ������"
create procedure [dbo].[Type_Tovar_Delete]
@ID_Type_Tovar [int]
as
	delete from [dbo].[Type_Tovar]
	where 
		[ID_Type_Tovar] = @ID_Type_Tovar
go

--������� "���������"
create table [dbo].[Doljnost]
(
	[ID_Doljnost] [int] not null identity(1,1),
	[Name_Doljnost] [varchar] (30) not null,
	[Oklad] [decimal] (32,2) not null,
	constraint [PK_ID_Doljnost] primary key clustered ([ID_Doljnost] ASC) on [PRIMARY],
	constraint [CH_Name_Doljnost] check ([Name_Doljnost] like '%[�-�]%' OR [Name_Doljnost] like '%[�-�]%'),
	constraint [CH_Oklad] check (len([Oklad]) > 0)
)
go

--��������� ������ � ������� "���������"
insert into [dbo].[Doljnost] ([Name_Doljnost],[Oklad])
values ('������','1000'),
	   ('������','60000'),
	   ('�������','80000'),
	   ('�����','60000'),
	   ('������','60000'),
	   ('��������','70000'),
	   ('�������','80000'),
	   ('������','90000'),
	   ('�������','10000'),
	   ('����������','20000')
go

--��������� ���������� ������ � ������� "���������"
create procedure [dbo].[Doljnost_Insert]
@Name_Doljnost [varchar] (30), @Oklad [decimal] (32,2)
as
	insert into [dbo].[Doljnost] 
	([Name_Doljnost], [Oklad]) 
	values
	(@Name_Doljnost, @Oklad)
go 

--��������� ��������� ������ � ������� "���������"
create procedure [dbo].[Doljnost_Update]
@ID_Doljnost [int], @Name_Doljnost [varchar] (30), @Oklad [decimal] (32,2)
as
	update [dbo].[Doljnost] set
		[Name_Doljnost] = @Name_Doljnost,
		[Oklad] = @Oklad
	where 
		[ID_Doljnost] = @ID_Doljnost
go

--��������� �������� ������ �� ������� "���������"
create procedure [dbo].[Doljnost_Delete]
@ID_Doljnost [int]
as
	delete from [dbo].[Doljnost]
	where 
		[ID_Doljnost] = @ID_Doljnost
go

--������� "����������"
create table [dbo].[Sotrudnik]
(
	[ID_Sotrudnik] [int] not null identity(1,1),
	[Familiya_Sotrudnik] [varchar] (30) not null,
	[Name_Sotrudnik] [varchar] (30) not null,
	[Otchestvo_Sotrudnik] [varchar] (30) not null,
	[Date_Rojdeniya] [varchar] (10) null,
	[Seriya_Pasporta] [varchar] (4) null,
	[Number_Pasporta] [varchar] (6) null,
	[LoginS] [varchar] (30) not null,
	[PasswordS] [varchar] (30) not null,
	[Doljnost_ID] [int] null DEFAULT (1),
	[Normativnie_Documenti_ID] [int] null DEFAULT (1),
	constraint [PK_ID_Sotrudnik] primary key clustered ([ID_Sotrudnik] ASC) on [PRIMARY],
	constraint [CH_Familiya_Sotrudnik] check ([Familiya_Sotrudnik] like '%[�-�]%' OR [Familiya_Sotrudnik] like '%[�-�]%'),
	constraint [CH_Name_Sotrudnik] check ([Name_Sotrudnik] like '%[�-�]%' OR [Name_Sotrudnik] like '%[�-�]%'),
	constraint [CH_Otchestvo_Sotrudnik] check ([Otchestvo_Sotrudnik] like '%[�-�]%' OR [Otchestvo_Sotrudnik] like '%[�-�]%'),
	constraint [CH_Date_Rojdeniya] check ([Date_Rojdeniya] like '[0-9][0-9].[0-9][0-9].[0-9][0-9][0-9][0-9]'),
	constraint [CH_Seriya_Pasporta] check ([Seriya_Pasporta] like '[0-9][0-9][0-9][0-9]'),
	constraint [CH_Number_Pasporta] check ([Number_Pasporta] like '[0-9][0-9][0-9][0-9][0-9][0-9]'),
	constraint [CH_LoginS] check ([LoginS] like '%[a-z]%' OR [LoginS] like '%[A-Z]%' or [LoginS] like '%[0-9]%'),
	constraint [CH_PasswordS] check ([PasswordS] like '%[a-z]%' OR [PasswordS] like '%[A-Z]%' or [PasswordS] like '%[0-9]%'),
	constraint [FK_Sotrudnik_Doljnost] foreign key ([Doljnost_ID]) references [dbo].[Doljnost] ([ID_Doljnost]),
	constraint [FK_Sotrudnik_ormativnie_Documenti] foreign key ([Normativnie_Documenti_ID]) references [dbo].[Documents] ([ID_Normativnie_Documenti])
)
go

--��������� ������ � ������� "����������"
insert into [dbo].[Sotrudnik] ([Familiya_Sotrudnik],[Name_Sotrudnik],[Otchestvo_Sotrudnik],[Date_Rojdeniya],[Seriya_Pasporta],[Number_Pasporta],[LoginS],[PasswordS],[Doljnost_ID],[Normativnie_Documenti_ID])
values ('������','����','��������','18.03.1993','1234','125602','Geffest','qwerty','1','1'),
	   ('�����','���������','����������','17.05.1998','1234','625591','Techis','qwer4ty','2','2'),
	   ('�������','������','���������','08.01.2000','1234','725353','Miner','qw2erty','3','3'),
	   ('�������','����','����������','02.06.2000','1234','925164','Abaddon','qw9erty','4','4'),
	   ('���������','������','�������������','08.09.1997','1234','825015','Necr','qwe8rty','5','5'),
	   ('��������','����','��������','11.08.1999','1234','225226','Ded','q6werty','6','6'),
	   ('��������','������','��������','13.01.1996','1234','125537','Dmitry','qwer1ty','7','7'),
	   ('�����������','�����','�������������','18.02.1996','1234','325448','4Rake','qwe4rty','8','8'),
	   ('�������','�����','���������','20.05.2003','1234','525359','Vitya','qwer3ty','9','9'),
	   ('������','����','��������','01.04.1999','1234','425860','Gefaer','qwe1rty','10','10')
go

--��������� ���������� ������ � ������� "����������"
create procedure [dbo].[Sotrudnik_Insert]
@Familiya_Sotrudnik [varchar] (30), @Name_Sotrudnik [varchar] (30), @Otchestvo_Sotrudnik [varchar] (30), @Date_Rojdeniya [varchar] (10), @Seriya_Pasporta [varchar] (4), @Number_Pasporta [varchar] (6), @LoginS [varchar] (30), @PasswordS [varchar] (30), @Doljnost_ID [int], @Normativnie_Documenti_ID [int]
as
	insert into [dbo].[Sotrudnik] 
	([Familiya_Sotrudnik], [Name_Sotrudnik], [Otchestvo_Sotrudnik], [Date_Rojdeniya], [Seriya_Pasporta], [Number_Pasporta], [LoginS], [PasswordS], [Doljnost_ID], [Normativnie_Documenti_ID]) 
	values
	(@Familiya_Sotrudnik, @Name_Sotrudnik, @Otchestvo_Sotrudnik, @Date_Rojdeniya, @Seriya_Pasporta, @Number_Pasporta, @LoginS, @PasswordS, @Doljnost_ID, @Normativnie_Documenti_ID)
go 

--��������� �����������
create procedure [dbo].[Regestration]
@Familiya_Sotrudnik [varchar] (30), @Name_Sotrudnik [varchar] (30), @Otchestvo_Sotrudnik [varchar] (30), @LoginS [varchar] (30), @PasswordS [varchar] (30)
as
	insert into [dbo].[Sotrudnik] 
	([Familiya_Sotrudnik], [Name_Sotrudnik], [Otchestvo_Sotrudnik], [LoginS], [PasswordS], [Doljnost_ID], [Normativnie_Documenti_ID]) 
	values
	(@Familiya_Sotrudnik, @Name_Sotrudnik, @Otchestvo_Sotrudnik, @LoginS, @PasswordS, DEFAULT, DEFAULT)
go 

--��������� ��������� ������ � ������� "����������"
create procedure [dbo].[Sotrudnik_Update]
@ID_Sotrudnik [int], @Familiya_Sotrudnik [varchar] (30), @Name_Sotrudnik [varchar] (30), @Otchestvo_Sotrudnik [varchar] (30), @Date_Rojdeniya [varchar] (10), @Seriya_Pasporta [varchar] (4), @Number_Pasporta [varchar] (6), @LoginS [varchar] (30), @PasswordS [varchar] (30), @Doljnost_ID [int], @Normativnie_Documenti_ID [int]
as
	update [dbo].[Sotrudnik] set
		[Familiya_Sotrudnik] = @Familiya_Sotrudnik,
		[Name_Sotrudnik] = @Name_Sotrudnik,
		[Otchestvo_Sotrudnik] = @Otchestvo_Sotrudnik,
		[Date_Rojdeniya] = @Date_Rojdeniya,
		[Seriya_Pasporta] = @Seriya_Pasporta,
		[Number_Pasporta] = @Number_Pasporta,
		[LoginS] = @LoginS,
		[PasswordS] = @PasswordS,
		[Doljnost_ID] = @Doljnost_ID,
		[Normativnie_Documenti_ID] = @Normativnie_Documenti_ID

	where 
		[ID_Sotrudnik] = @ID_Sotrudnik
go

--��������� �������� ������ �� ������� "����������"
create procedure [dbo].[Sotrudnik_Delete]
@ID_Sotrudnik [int]
as
	delete from [dbo].[Sotrudnik]
	where 
		[ID_Sotrudnik] = @ID_Sotrudnik
go

--������� "�����"
create table [dbo].[Tovar]
(
	[ID_Tovar] [int] not null identity(1,1),
	[Name_Tovar] [varchar] (30) not null,
	[Kolichestvo_Tovar] [int] not null,
	[Cena] [decimal] (32,2) not null,
	[Data_Proisvodstva] [varchar] (10) not null,
	[Sirie_ID] [int] not null,
	[Sotrudnik_ID] [int] not null,
	[Type_Tovar_ID] [int] not null,
	constraint [PK_ID_Tovar] primary key clustered ([ID_Tovar] ASC) on [PRIMARY],
	constraint [CH_Name_Tovar] check ([Name_Tovar] like '%[�-�]%' OR [Name_Tovar] like '%[�-�]%'),
	constraint [CH_Kolichestvo_Tovar] check (len([Kolichestvo_Tovar]) > 0),
	constraint [CH_Cena] check (len([Cena]) > 0),
	constraint [CH_Data_Proisvodstva] check ([Data_Proisvodstva] like '[0-9][0-9].[0-9][0-9].[0-9][0-9][0-9][0-9]'),
	constraint [FK_Tovar_Sirie] foreign key ([Sirie_ID]) references [dbo].[Sirie] ([ID_Sirie]),
	constraint [FK_Tovar_Sotrudnik] foreign key ([Sotrudnik_ID]) references [dbo].[Sotrudnik] ([ID_Sotrudnik]),
	constraint [FK_Tovar_Type_Tovar] foreign key ([Type_Tovar_ID]) references [dbo].[Type_Tovar] ([ID_Type_Tovar])
)
go

--��������� ������ � ������� "�����"
insert into [dbo].[Tovar] ([Name_Tovar],[Kolichestvo_Tovar],[Cena],[Data_Proisvodstva],[Sirie_ID],[Sotrudnik_ID],[Type_Tovar_ID])
values ('������� ����','3','300','09.04.2020','1','1','1'),
	   ('����� � �������','7','500','09.04.2020','2','2','2'),
	   ('����� � ������','6','260','09.04.2020','3','3','3'),
	   ('������ �������� ����','4','200','09.04.2020','4','4','4'),
	   ('����� �������� ����','2','100','09.04.2020','5','5','5'),
	   ('����� ����','10','600','09.04.2020','6','6','6'),
	   ('������ � ��������','6','220','09.04.2020','7','7','7'),
	   ('������ � �������','3','120','09.04.2020','8','8','8'),
	   ('����� � �����','5','190','09.04.2020','9','9','9'),
	   ('������ ����','3','160','09.04.2020','10','10','10')
go

--��������� ���������� ������ � ������� "�����"
create procedure [dbo].[Tovar_Insert]
@Name_Tovar [varchar] (30), @Kolichestvo_Tovar [int], @Cena [decimal] (32,2), @Data_Proisvodstva [varchar] (10), @Sirie_ID [int], @Sotrudnik_ID [int], @Type_Tovar_ID [int]
as
	insert into [dbo].[Tovar] 
	([Name_Tovar], [Kolichestvo_Tovar], [Cena], [Data_Proisvodstva], [Sirie_ID], [Sotrudnik_ID], [Type_Tovar_ID]) 
	values
	(@Name_Tovar, @Kolichestvo_Tovar, @Cena, @Data_Proisvodstva, @Sirie_ID, @Sotrudnik_ID, @Type_Tovar_ID)
go 

--��������� ��������� ������ � ������� "�����"
create procedure [dbo].[Tovar_Update]
@ID_Tovar [int], @Name_Tovar [varchar] (30), @Kolichestvo_Tovar [int], @Cena [decimal] (32,2), @Data_Proisvodstva [varchar] (10), @Sirie_ID [int], @Sotrudnik_ID [int], @Type_Tovar_ID [int]
as
	update [dbo].[Tovar] set
		[Name_Tovar] = @Name_Tovar,
		[Kolichestvo_Tovar] = @Kolichestvo_Tovar,
		[Cena] = @Cena ,
		[Data_Proisvodstva] = @Data_Proisvodstva,
		[Sirie_ID] = @Sirie_ID,
		[Sotrudnik_ID] = @Sotrudnik_ID,
		[Type_Tovar_ID] = @Type_Tovar_ID
	where 
		[ID_Tovar] = @ID_Tovar
go

--��������� �������� ������ �� ������� "�����"
create procedure [dbo].[Tovar_Delete]
@ID_Tovar [int]
as
	delete from [dbo].[Tovar]
	where 
		[ID_Tovar] = @ID_Tovar
go

--������� "������ ������"
create table [dbo].[Status_Zakaza]
(
	[ID_Status_Zakaza] [int] not null identity(1,1),
	[Sostiyanie_Zakaza] [varchar] (30) not null,
	constraint [PK_ID_Status_Zakaza] primary key clustered ([ID_Status_Zakaza] ASC) on [PRIMARY],
)
go

--��������� ������ � ������� "������ ������"
insert into [dbo].[Status_Zakaza] ([Sostiyanie_Zakaza])
values ('�����������'),
	   ('����������'),
	   ('��������'),
	   ('�������� � �������'),
	   ('�� �����'),
	   ('� ������'),
	   ('�� ������������'),
	   ('�����'),
	   ('�������� �� �����'),
	   ('�������� �������')
go

--��������� ���������� ������ � ������� "������ ������"
create procedure [dbo].[Status_Zakaza_Insert]
@Sostiyanie_Zakaza [varchar] (30)
as
	insert into [dbo].[Status_Zakaza] 
	([Sostiyanie_Zakaza]) 
	values
	(@Sostiyanie_Zakaza)
go 

--��������� ��������� ������ � ������� "������ ������"
create procedure [dbo].[Status_Zakaza_Update]
@ID_Status_Zakaza [int], @Sostiyanie_Zakaza [varchar] (30)
as
	update [dbo].[Status_Zakaza] set
		[Sostiyanie_Zakaza] = @Sostiyanie_Zakaza
	where 
		[ID_Status_Zakaza] = @ID_Status_Zakaza
go

--��������� �������� ������ �� ������� "������ ������"
create procedure [dbo].[Status_Zakaza_Delete]
@ID_Status_Zakaza [int]
as
	delete from [dbo].[Status_Zakaza]
	where 
		[ID_Status_Zakaza] = @ID_Status_Zakaza
go

--������� "������"
create table [dbo].[Klient]
(
	[ID_Klient] [int] not null identity(1,1),
	[Familiya_Klient] [varchar] (30) not null,
	[Name_Klient] [varchar] (30) not null,
	[Otchestvo_Klient] [varchar] (30) not null,
	constraint [PK_ID_Klient] primary key clustered ([ID_Klient] ASC) on [PRIMARY],
	constraint [CH_Familiya_Klient] check ([Familiya_Klient] like '%[�-�]%' OR [Familiya_Klient] like '%[�-�]%'),
	constraint [CH_Name_Klient] check ([Name_Klient] like '%[�-�]%' OR [Name_Klient] like '%[�-�]%'),
	constraint [CH_Otchestvo_Klient] check ([Otchestvo_Klient] like '%[�-�]%' OR [Otchestvo_Klient] like '%[�-�]%')
)
go

--��������� ������ � ������� "������"
insert into [dbo].[Klient] ([Familiya_Klient],[Name_Klient],[Otchestvo_Klient])
values ('�������','�����','���������'),
	   ('������','����','��������'),
	   ('�������','����','��������'),
	   ('�������','�����','���������'),
	   ('��������','�������','����������'),
	   ('�������','�������','�����������'),
	   ('�������','������','���������'),
	   ('�������','������','���������'),
	   ('������','�����','��������'),
	   ('��������','�������','�������')
go

--��������� ���������� ������ � ������� "������"
create procedure [dbo].[Klient_Insert]
@Familiya_Klient [varchar] (30), @Name_Klient [varchar] (30), @Otchestvo_Klient [varchar] (30)
as
	insert into [dbo].[Klient] 
	([Familiya_Klient], [Name_Klient], [Otchestvo_Klient]) 
	values
	(@Familiya_Klient, @Name_Klient, @Otchestvo_Klient)
go 

--��������� ��������� ������ � ������� "������"
create procedure [dbo].[Klient_Update]
@ID_Klient [int], @Familiya_Klient [varchar] (30), @Name_Klient [varchar] (30), @Otchestvo_Klient [varchar] (30)
as
	update [dbo].[Klient] set
		[Familiya_Klient] = @Familiya_Klient,
		[Name_Klient] = @Name_Klient,
		[Otchestvo_Klient] = @Otchestvo_Klient
	where 
		[ID_Klient] = @ID_Klient
go

--��������� �������� ������ �� ������� "������"
create procedure [dbo].[Klient_Delete]
@ID_Klient [int]
as
	delete from [dbo].[Klient]
	where 
		[ID_Klient] = @ID_Klient
go

--������� "�����"
create table [dbo].[Zakaz]
(
	[ID_Zakaz] [int] not null identity(1,1),
	[Number_Zakaz] [int] not null,
	[Kolichestvo] [int] not null,
	[Summa] [Decimal](32,2) not null,
	[Date_Prodaji] [varchar] (10) not null,
	[Status_Zakaza_ID] [int] not null,
	[Sotrudnik_ID] [int] not null,
	[Klient_ID] [int] not null,
	[Tovar_ID] [int] not null,
	constraint [PK_ID_Zakaz] primary key clustered ([ID_Zakaz] ASC) on [PRIMARY],
	constraint [CH_Number_Zakaz] check ([Number_Zakaz] >0),
	constraint [CH_Kolichestvo] check ([Kolichestvo] >0),
	constraint [CH_Summa] check ([Summa] >0),
	constraint [CH_Date_Prodaji] check ([Date_Prodaji] like '[0-9][0-9].[0-9][0-9].[0-9][0-9][0-9][0-9]'),
	constraint [FK_Status_Zakaza] foreign key ([Status_Zakaza_ID]) references [dbo].[Status_Zakaza] ([ID_Status_Zakaza]),
	constraint [FK_Sotrudnik_Zakaz] foreign key ([Sotrudnik_ID]) references [dbo].[Sotrudnik] ([ID_Sotrudnik]),
	constraint [FK_Klient_Zakaz] foreign key ([Klient_ID]) references [dbo].[Klient] ([ID_Klient]),
	constraint [FK_Tovar_Zakaz] foreign key ([Tovar_ID]) references [dbo].[Tovar] ([ID_Tovar])
)
go

--��������� ������ � ������� "�����"
insert into [dbo].[Zakaz] ([Number_Zakaz],[Kolichestvo],[Summa],[Date_Prodaji],[Status_Zakaza_ID],[Sotrudnik_ID],[Klient_ID],[Tovar_ID])
values ('111','1','200','09.04.2020','1','1','1','1'),
	   ('112','4','110','09.04.2020','2','2','2','2'),
	   ('113','3','130','09.04.2020','3','3','3','3'),
	   ('114','2','120','09.04.2020','4','4','4','4'),
	   ('115','5','500','09.04.2020','5','5','5','5'),
	   ('116','4','150','09.04.2020','6','6','6','6'),
	   ('117','3','340','09.04.2020','7','7','7','7'),
	   ('118','2','260','09.04.2020','8','8','8','8'),
	   ('119','2','250','09.04.2020','9','9','9','9'),
	   ('120','1','300','09.04.2020','10','10','10','10')
go

--��������� ���������� ������ � ������� "�����"
create procedure [dbo].[Zakaz_Insert]
@Number_Zakaz [int], @Kolichestvo [int], @Summa [decimal] (32,2), @Date_Prodaji [varchar] (10), @Status_Zakaza_ID [int], @Sotrudnik_ID [int], @Klient_ID [int], @Tovar_ID [int]
as
	insert into [dbo].[Zakaz] 
	([Number_Zakaz], [Kolichestvo], [Summa], [Date_Prodaji], [Status_Zakaza_ID], [Sotrudnik_ID], [Klient_ID], [Tovar_ID]) 
	values
	(@Number_Zakaz, @Kolichestvo, @Summa, @Date_Prodaji, @Status_Zakaza_ID, @Sotrudnik_ID, @Klient_ID, @Tovar_ID)
go 

--��������� ��������� ������ � ������� "�����"
create procedure [dbo].[Zakaz_Update]
@ID_Zakaz [int], @Number_Zakaz [int], @Kolichestvo [int], @Summa [decimal] (32,2), @Date_Prodaji [varchar] (10), @Status_Zakaza_ID [int], @Sotrudnik_ID [int], @Klient_ID [int], @Tovar_ID [int]
as
	update [dbo].[Zakaz] set
		[Number_Zakaz] = @Number_Zakaz,
		[Kolichestvo] = @Kolichestvo,
		[Summa] = @Summa,
		[Date_Prodaji] = @Date_Prodaji,
		[Status_Zakaza_ID] = @Status_Zakaza_ID,
		[Sotrudnik_ID] = @Sotrudnik_ID,
		[Klient_ID] = @Klient_ID,
		[Tovar_ID] = @Tovar_ID
	where 
		[ID_Zakaz] = @ID_Zakaz
go

--��������� �������� ������ �� ������� "�����"
create procedure [dbo].[Zakaz_Delete]
@ID_Zakaz [int]
as
	delete from [dbo].[Zakaz]
	where 
		[ID_Zakaz] = @ID_Zakaz
go

--������� "��� ������"
create table [dbo].[Type_Zakaz]
(
	[ID_Type_Zakaz] [int] not null identity(1,1),
	[Name_Type_Zakaz] [varchar](30) not null,
	constraint [PK_ID_Type_Zakaz] primary key clustered ([ID_Type_Zakaz] ASC) on [PRIMARY],
	constraint [CH_Name_Type_Zakaz] check ([Name_Type_Zakaz] like '%[�-�]%' OR [Name_Type_Zakaz] like '%[�-�]%')
)
go

--��������� ������ � ������� "��� ������"
insert into [dbo].[Type_Zakaz] ([Name_Type_Zakaz])
values ('��������'),
	   ('�� �����'),
	   ('� �����'),
	   ('��������1'),
	   ('�� �����1'),
	   ('� �����1'),
	   ('�� �����2'),
	   ('�� �����3'),
	   ('��������2'),
	   ('� �����2')
go

--��������� ���������� ������ � ������� "��� ������"
create procedure [dbo].[Type_Zakaz_Insert]
@Name_Type_Zakaz [varchar] (30)
as
	insert into [dbo].[Type_Zakaz] 
	([Name_Type_Zakaz]) 
	values
	(@Name_Type_Zakaz)
go 

--��������� ��������� ������ � ������� "��� ������"
create procedure [dbo].[Type_Zakaz_Update]
@ID_Type_Zakaz [int], @Name_Type_Zakaz [varchar] (30)
as
	update [dbo].[Type_Zakaz] set
		[Name_Type_Zakaz] = @Name_Type_Zakaz
	where 
		[ID_Type_Zakaz] = @ID_Type_Zakaz
go

--��������� �������� ������ �� ������� "��� ������"
create procedure [dbo].[Type_Zakaz_Delete]
@ID_Type_Zakaz [int]
as
	delete from [dbo].[Type_Zakaz]
	where 
		[ID_Type_Zakaz] = @ID_Type_Zakaz
go

--������� "���"
create table [dbo].[Chek]
(
	[ID_Chek] [int] not null identity(1,1),
	[Number_Chek] [int] not null,
	[Date_Pechat] [varchar](10) not null,
	[Sotrudnik_ID] [int] not null,
	[Klient_ID] [int] not null,
	[Tovar_ID] [int] not null,
	[Type_Zakaz_ID] [int] not null,
	constraint [PK_ID_Chek] primary key clustered ([ID_Chek] ASC) on [PRIMARY],
	constraint [CH_Number_Chek] check ([Number_Chek] >0),
	constraint [CH_Date_Pechat] check ([Date_Pechat] like '[0-9][0-9].[0-9][0-9].[0-9][0-9][0-9][0-9]'),
	constraint [FK_Sotrudnik_Chek] foreign key ([Sotrudnik_ID]) references [dbo].[Sotrudnik] ([ID_Sotrudnik]),
	constraint [FK_Klient_Chek] foreign key ([Klient_ID]) references [dbo].[Klient] ([ID_Klient]),
	constraint [FK_Tovar_Chek] foreign key ([Tovar_ID]) references [dbo].[Tovar] ([ID_Tovar]),
	constraint [FK_Type_Zakaz_Chek] foreign key ([Type_Zakaz_ID]) references [dbo].[Type_Zakaz] ([ID_Type_Zakaz])
)
go

--��������� ���������� ������ � ������� "���"
create procedure [dbo].[Chek_Insert]
@Number_Chek [int], @Date_Pechat [varchar] (10), @Sotrudnik_ID [int], @Klient_ID [int], @Tovar_ID [int], @Type_Zakaz_ID [int]
as
	insert into [dbo].[Chek] 
	([Number_Chek], [Date_Pechat], [Sotrudnik_ID], [Klient_ID] , [Tovar_ID], [Type_Zakaz_ID]) 
	values
	(@Number_Chek, @Date_Pechat, @Sotrudnik_ID, @Klient_ID, @Tovar_ID, @Type_Zakaz_ID)
go 

--��������� ��������� ������ � ������� "���"
create procedure [dbo].[Chek_Update]
@ID_Chek [int], @Number_Chek [int], @Date_Pechat [varchar] (10), @Sotrudnik_ID [int], @Klient_ID [int], @Tovar_ID [int], @Type_Zakaz_ID [int]
as
	update [dbo].[Chek] set
		[Number_Chek] = @Number_Chek,
		[Date_Pechat] = @Date_Pechat,
		[Sotrudnik_ID] = @Sotrudnik_ID,
		[Klient_ID] = @Klient_ID,
		[Tovar_ID] = @Tovar_ID,
		[Type_Zakaz_ID] = @Type_Zakaz_ID
	where 
		[ID_Chek] = @ID_Chek
go

--��������� �������� ������ �� ������� "���"
create procedure [dbo].[Chek_Delete]
@ID_Chek [int]
as
	delete from [dbo].[Chek]
	where 
		[ID_Chek] = @ID_Chek
go

--������� ���������� ����������� ���������
create trigger Documents_Insert_Trigger
on [dbo].[Documents]
after insert
as
INSERT INTO [dbo].[History] (ProductId,Operation)
SELECT ID_Normativnie_Documenti, '�������� �������� ����������� ���������� ' + Name_Normativnie_Documenti +' ����  ' + Srok_Deistviya
FROM INSERTED
go

--������� ���������� ����������
CREATE TRIGGER Postavhik_Insert_Trigger
ON [dbo].[Postavhik]
AFTER INSERT
AS
INSERT INTO [dbo].[History] (ProductId,Operation)
SELECT ID_Postavhik, '�������� ��������� ' + Familiya_Postavhik  +' ' + Name_Postavhik + ' ' + Otchestvo_Postavhik + '����������� ��������' + Convert([varchar](max),Normativnie_Documenti_ID)
FROM INSERTED
go

--������� ���������� �����
CREATE TRIGGER Sirie_Insert_Trigger
ON [dbo].[Sirie]
AFTER INSERT
AS
INSERT INTO [dbo].[History] (ProductId,Operation)
SELECT ID_Sirie, '��������� ����� ' +Name_Sirie   +' ���� ��������' + Date_Postavki + ' ��������� ' + Convert([varchar](max),Postavhik_ID)
FROM INSERTED
go

--������� ���������� ��� ������
CREATE TRIGGER Type_Tovar_Insert_Trigger
ON [dbo].[Type_Tovar]
AFTER INSERT
AS
INSERT INTO [dbo].[History] (ProductId,Operation)
SELECT ID_Type_Tovar, '�������� ��� ������ ' + Name_Type_Tovar 
FROM INSERTED
go

--������� ���������� ������ ���������
CREATE TRIGGER Doljnost_Insert_Trigger
ON [dbo].[Doljnost]
AFTER INSERT
AS
INSERT INTO [dbo].[History] (ProductId,Operation)
SELECT ID_Doljnost, '����������� ��������� ' + Name_Doljnost + '�����   ' + Convert([varchar] (max), Oklad)
FROM INSERTED
go

----������� ���������� ����������
--CREATE TRIGGER Sotrudnik_Insert_Trigger
--ON [dbo].[Sotrudnik]
--AFTER INSERT
--AS
--INSERT INTO [dbo].[History] (ProductId,Operation)
--SELECT ID_Sotrudnik, '�������� ��������� ' + Familiya_Sotrudnik + ' ' + Name_Sotrudnik + ' '+ Otchestvo_Sotrudnik
--+ ' ���� �������� ' +Date_Rojdeniya + '  ����� �������� '+ Seriya_Pasporta + ' ����� ��������'
--+ Number_Pasporta + '�����' + LoginS +'������' + PasswordS + '���������'+ Convert([varchar](max),Doljnost_ID) +'����������� ���������'+Convert([varchar](max),Normativnie_Documenti_ID)
--FROM INSERTED 
--go

--������� ���������� ������� ������
CREATE TRIGGER Status_Zakaza_Insert_Trigger
ON [dbo].[Status_Zakaza]
AFTER INSERT
AS
INSERT INTO [dbo].[History] (ProductId,Operation)
SELECT ID_Status_Zakaza, '����������� ������ ' + Sostiyanie_Zakaza 
FROM INSERTED
go

--������� ���������� �������
CREATE TRIGGER Klient_Insert_Trigger
ON [dbo].[Klient]
AFTER INSERT
AS
INSERT INTO [dbo].[History] (ProductId,Operation)
SELECT ID_Klient, '������ ' + Familiya_Klient +' '+Name_Klient+ ' '+Otchestvo_Klient
FROM INSERTED
go

--������� ���������� ��� ������
CREATE TRIGGER Type_Zakaz_Insert_Trigger
ON [dbo].[Type_Zakaz]
AFTER INSERT
AS
INSERT INTO [dbo].[History] (ProductId,Operation)
SELECT ID_Type_Zakaz, '�������� ��� ������ ' + Name_Type_Zakaz
FROM INSERTED
go

--������������� ��� ����������� ��� ���������� ��� ��������� � ��
create view [dbo].[Sotrudnik_Info]
(Familiya_Sotrudnik, Name_Sotrudnik, Otchestvo_Sotrudnik, Name_Doljnost, Oklad)
as
	select [Familiya_Sotrudnik], [Name_Sotrudnik], [Otchestvo_Sotrudnik], [Name_Doljnost], [Oklad]
	from [dbo].[Sotrudnik] inner join [dbo].[Doljnost] on [dbo].[Sotrudnik].[ID_Sotrudnik] = [dbo].[Doljnost].[ID_Doljnost]
go

--������������� ��� ����������� ��� ���������� � �������� � ���
create view [dbo].[Postavhik_Info]
(Familiya_Postavhik, Name_Postavhik, Otchestvo_Postavhik, Name_Normativnie_Documenti, Srok_Deistviya)
as
	select [Familiya_Postavhik], [Name_Postavhik], [Otchestvo_Postavhik], [Name_Normativnie_Documenti], [Srok_Deistviya]
	from [dbo].[Postavhik] inner join [dbo].[Documents] on [dbo].[Postavhik].[ID_Postavhik] = [dbo].[Documents].[ID_Normativnie_Documenti]
go

--������������� ��� ����������� ��� ���������� � �����, ������� �� ����������
create view [dbo].[Postavhik_Info_Sirie]
(Familiya_Postavhik, Name_Postavhik, Otchestvo_Postavhik, Name_Sirie, Date_Postavki)
as
	select [Familiya_Postavhik], [Name_Postavhik], [Otchestvo_Postavhik], [Name_Sirie], [Date_Postavki]
	from [dbo].[Postavhik] inner join [dbo].[Sirie] on [dbo].[Postavhik].[ID_Postavhik] = [dbo].[Sirie].[ID_Sirie]
go

--������������� ��� ����������� ���������� � ������
create view [dbo].[Zakaz_Info]
(Number_Zakaz, Kolichestvo, Summa, Date_Prodaji, Sostiyanie_Zakaza, Familiya_Sotrudnik, Name_Sotrudnik, Otchestvo_Sotrudnik, Familiya_Klient, Name_Klient, Otchestvo_Klient, Name_Tovar)
as
	select [Number_Zakaz], [Kolichestvo], [Summa], [Date_Prodaji], [Sostiyanie_Zakaza], [Familiya_Sotrudnik], [Name_Sotrudnik], [Otchestvo_Sotrudnik], [Familiya_Klient], [Name_Klient], [Otchestvo_Klient], [Name_Tovar]
	from [dbo].[Zakaz] 
	inner join [dbo].[Status_Zakaza] on [dbo].[Zakaz].[ID_Zakaz] = [dbo].[Status_Zakaza].[ID_Status_Zakaza]
	inner join [dbo].[Sotrudnik] on [dbo].[Zakaz].[ID_Zakaz] = [dbo].[Sotrudnik].[ID_Sotrudnik]
	inner join [dbo].[Klient] on [dbo].[Zakaz].[ID_Zakaz] = [dbo].[Klient].[ID_Klient]
	inner join [dbo].[Tovar] on [dbo].[Zakaz].[ID_Zakaz] = [dbo].[Tovar].[ID_Tovar]
go

--��������� ��������� ������ � ������ ��������
create procedure [dbo].[Login_Password_Update]
@ID_Sotrudnik [int], @LoginS [varchar], @PasswordS [varchar]
as
	update [dbo].[Sotrudnik] set
		[LoginS] = @LoginS,
		[PasswordS] = @PasswordS
	where 
		[ID_Sotrudnik] = @ID_Sotrudnik
go 



--������� ���������� ����������� ���������
create trigger Documents_update_Trigger
on [dbo].[Documents]
after update
as
INSERT INTO [dbo].[History] (ProductId,Operation)
SELECT ID_Normativnie_Documenti, '��������� ������: �������� ����������� ���������� ' + Name_Normativnie_Documenti +' ����  ' + Srok_Deistviya
FROM INSERTED
go

--������� ���������� ����������
CREATE TRIGGER Postavhik_update_Trigger
ON [dbo].[Postavhik]
AFTER update
AS
INSERT INTO [dbo].[History] (ProductId,Operation)
SELECT ID_Postavhik, '��������� ������: ��������� ' + Familiya_Postavhik  +' ' + Name_Postavhik + ' ' + Otchestvo_Postavhik + '����������� ��������' + Convert([varchar](max),Normativnie_Documenti_ID)
FROM INSERTED
go

--������� ���������� �����
CREATE TRIGGER Sirie_updatet_Trigger
ON [dbo].[Sirie]
AFTER update
AS
INSERT INTO [dbo].[History] (ProductId,Operation)
SELECT ID_Sirie, '��������� ������: ����� ' +Name_Sirie   +' ���� ��������' + Date_Postavki + ' ��������� ' + Convert([varchar](max),Postavhik_ID)
FROM INSERTED
go

--������� ���������� ��� ������
CREATE TRIGGER Type_Tovar_update_Trigger
ON [dbo].[Type_Tovar]
AFTER update
AS
INSERT INTO [dbo].[History] (ProductId,Operation)
SELECT ID_Type_Tovar, '��������� ������: ��� ������ ' + Name_Type_Tovar 
FROM INSERTED
go

--������� ���������� ���������� ���������
CREATE TRIGGER Doljnost_update_Trigger
ON [dbo].[Doljnost]
AFTER update
AS
INSERT INTO [dbo].[History] (ProductId,Operation)
SELECT ID_Doljnost, '��������� ������: ��������� ' + Name_Doljnost + '�����   ' + Convert([varchar] (max), Oklad)
FROM INSERTED
go

--������� ���������� ����������
CREATE TRIGGER Sotrudnik_update_Trigger
ON [dbo].[Sotrudnik]
AFTER update
AS
INSERT INTO [dbo].[History] (ProductId,Operation)
SELECT ID_Sotrudnik, '��������� ������: ��������� ' + Familiya_Sotrudnik + ' ' + Name_Sotrudnik + ' '+ Otchestvo_Sotrudnik
+ ' ���� �������� ' +Date_Rojdeniya + '  ����� �������� '+ Seriya_Pasporta + ' ����� ��������'
+ Number_Pasporta + '�����' + LoginS +'������' + PasswordS + '���������'+ Convert([varchar](max),Doljnost_ID) +'����������� ���������'+Convert([varchar](max),Normativnie_Documenti_ID)
FROM INSERTED 
go

--������� ���������� ������� ������
CREATE TRIGGER Status_Zakaza_update_Trigger
ON [dbo].[Status_Zakaza]
AFTER update
AS
INSERT INTO [dbo].[History] (ProductId,Operation)
SELECT ID_Status_Zakaza, '��������� ������: ������ ' + Sostiyanie_Zakaza 
FROM INSERTED
go

--������� ���������� �������
CREATE TRIGGER Klient_update_Trigger
ON [dbo].[Klient]
AFTER update
AS
INSERT INTO [dbo].[History] (ProductId,Operation)
SELECT ID_Klient, '��������� ������: ������ ' + Familiya_Klient +' '+Name_Klient+ ' '+Otchestvo_Klient
FROM INSERTED
go

--������� ���������� ��� ������
CREATE TRIGGER Type_Zakaz_update_Trigger
ON [dbo].[Type_Zakaz]
AFTER update
AS
INSERT INTO [dbo].[History] (ProductId,Operation)
SELECT ID_Type_Zakaz, '��������� ������: ��� ������ ' + Name_Type_Zakaz
FROM INSERTED
go

--��������

--������� �������� ����������� ���������
create trigger Documents_delete_Trigger
on [dbo].[Documents]
after delete
as
INSERT INTO [dbo].[History] (ProductId,Operation)
SELECT ID_Normativnie_Documenti, '������� ������: �������� ����������� ���������� ' + Name_Normativnie_Documenti +' ����  ' + Srok_Deistviya
FROM deleted
go

--������� �������� ����������
CREATE TRIGGER Postavhik_delete_Trigger
ON [dbo].[Postavhik]
AFTER delete
AS
INSERT INTO [dbo].[History] (ProductId,Operation)
SELECT ID_Postavhik, '������� ������: ��������� ' + Familiya_Postavhik  +' ' + Name_Postavhik + ' ' + Otchestvo_Postavhik + '����������� ��������' + Convert([varchar](max),Normativnie_Documenti_ID)
FROM deleted
go

--������� �������� �����
CREATE TRIGGER Sirie_delete_Trigger
ON [dbo].[Sirie]
AFTER delete
AS
INSERT INTO [dbo].[History] (ProductId,Operation)
SELECT ID_Sirie, '������� ������: ����� ' +Name_Sirie   +' ���� ��������' + Date_Postavki + ' ��������� ' + Convert([varchar](max),Postavhik_ID)
FROM deleted
go

--������� �������� ��� ������
CREATE TRIGGER Type_Tovar_delete_Trigger
ON [dbo].[Type_Tovar]
AFTER delete
AS
INSERT INTO [dbo].[History] (ProductId,Operation)
SELECT ID_Type_Tovar, '������� ������: ��� ������ ' + Name_Type_Tovar 
FROM deleted
go

--������� �������� ���������� ���������
CREATE TRIGGER Doljnost_delete_Trigger
ON [dbo].[Doljnost]
AFTER delete
AS
INSERT INTO [dbo].[History] (ProductId,Operation)
SELECT ID_Doljnost, '������� ������: ��������� ' + Name_Doljnost + '�����   ' + Convert([varchar] (max), Oklad)
FROM deleted
go

--������� �������� ����������
CREATE TRIGGER Sotrudnik_delete_Trigger
ON [dbo].[Sotrudnik]
AFTER delete
AS
INSERT INTO [dbo].[History] (ProductId,Operation)
SELECT ID_Sotrudnik, '������� ������: ��������� ' + Familiya_Sotrudnik + ' ' + Name_Sotrudnik + ' '+ Otchestvo_Sotrudnik
+ ' ���� �������� ' +Date_Rojdeniya + '  ����� �������� '+ Seriya_Pasporta + ' ����� ��������'
+ Number_Pasporta + '�����' + LoginS +'������' + PasswordS + '���������'+ Convert([varchar](max),Doljnost_ID) +'����������� ���������'+Convert([varchar](max),Normativnie_Documenti_ID)
FROM deleted
go

--������� �������� ������� ������
CREATE TRIGGER Status_Zakaza_delete_Trigger
ON [dbo].[Status_Zakaza]
AFTER delete
AS
INSERT INTO [dbo].[History] (ProductId,Operation)
SELECT ID_Status_Zakaza, '������� ������: ������ ' + Sostiyanie_Zakaza 
FROM deleted
go

--������� �������� �������
create TRIGGER Klient_delete_Trigger
ON [dbo].[Klient]
AFTER delete
AS
INSERT INTO [dbo].[History] (ProductId,Operation)
SELECT ID_Klient, '������� ������: ������ ' + Familiya_Klient +' '+Name_Klient+ ' '+Otchestvo_Klient
FROM deleted
go

--������� �������� ��� ������
CREATE TRIGGER Type_Zakaz_delete_Trigger
ON [dbo].[Type_Zakaz]
AFTER delete
AS
INSERT INTO [dbo].[History] (ProductId,Operation)
SELECT ID_Type_Zakaz, '������� ������: ��� ������ ' + Name_Type_Zakaz
FROM deleted
go

