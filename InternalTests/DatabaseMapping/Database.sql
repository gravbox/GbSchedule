if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[A_TABLE]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[A_TABLE]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[C_TABLE]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[C_TABLE]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[P_TABLE]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[P_TABLE]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[R_TABLE]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[R_TABLE]
GO

CREATE TABLE [dbo].[A_TABLE] (
	[the_key] [char] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[s_time] [datetime] NOT NULL ,
	[duration] [int] NOT NULL ,
	[mytext] [char] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[C_TABLE] (
	[the_key] [char] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[mytext] [char] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[mycolor] [int] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[P_TABLE] (
	[the_key] [char] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[mytext] [char] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[mycolor] [int] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[R_TABLE] (
	[the_key] [char] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[mytext] [char] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL 
) ON [PRIMARY]
GO

