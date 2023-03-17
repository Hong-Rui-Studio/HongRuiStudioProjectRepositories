use master
go
create database HongRuiGamesStudioDb
go
use HongRuiGamesStudioDb
go
create table Roles
(
	 Id uniqueidentifier primary key ,
	 Title nvarchar(50) not null,
	 CreateTime datetime ,
	 UpdateTime datetime
)
go
create table Admins
(
	Id uniqueidentifier primary key ,
	Name nvarchar(50) not null,
	BornDate date not null,
	Gender int not null ,
	Email varchar(50) not null,
	Tel	varchar(50) not null,
	Photo varchar(50) not null,
	Images varchar(50) not null,
	Address varchar(50) not null,
	RolesId uniqueidentifier not null,
	CreateTime datetime ,
	UpdateTime datetime
)
go
create table SystemMenus
(
	Id uniqueidentifier primary key ,
	Title nvarchar(50) not null,
	Link varchar(50) not null,
	Icons varchar(50),
	ParentId uniqueidentifier not null,
	CreateTime datetime ,
	UpdateTime datetime
)
go
create table AdminsPermission
(
	Id uniqueidentifier primary key ,
	RolesId uniqueidentifier not null,
	MenusId uniqueidentifier not null,
	CreateTime datetime ,
	UpdateTime datetime
)
go
create table WebMenus
(
	Id uniqueidentifier primary key ,
	Title nvarchar(50) not null,
	Link varchar(50) not null,
	Icons varchar(50),
	ParentId uniqueidentifier not null,
	CreateTime datetime ,
	UpdateTime datetime
)
go
create table Seos
(
	Id uniqueidentifier primary key ,
	Title nvarchar(50) not null,
	Keyword nvarchar(300) not null,
	Description nvarchar(1000) not null,
	WebMenusId uniqueidentifier not null,
	CreateTime datetime ,
	UpdateTime datetime
)
go
create table FriendLinks
(
	Id uniqueidentifier primary key ,
	Title nvarchar(50) not null,
	Link varchar(100) not null,
	IsShow int not null,
	CreateTime datetime ,
	UpdateTime datetime
)
go
create table Copyrights
(
	Id uniqueidentifier primary key ,
	Title nvarchar(50),
	Content nvarchar(2000),
	Email varchar(50),
	Fax varchar(50),
	Phone varchar(50),
	Tel varchar(50),
	Logo varchar(50),
	Images varchar(50),
	Address nvarchar(100),
	QQNum varchar(50),
	QQNum1 varchar(50),
	WeChat varchar(50),
	CreateTime datetime ,
	UpdateTime datetime
)