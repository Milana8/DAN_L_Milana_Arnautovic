CREATE DATABASE DAN_L
 IF DB_ID('DAN_XLII') IS NULL
CREATE DATABASE DAN_L;
GO
USE DAN_L;
--we provided drop tables
if exists (SELECT name FROM sys.sysobjects WHERE name = 'tblUsers')
drop table tblUsers;

if exists (SELECT name FROM sys.sysobjects WHERE name = 'tblSong')
drop table tblSong ;

if exists (SELECT name FROM sys.sysobjects WHERE name = 'vwSong')
drop view vwSong ;


CREATE TABLE tblUsers(
 UserID int IDENTITY(1,1) Primary key not null, --Primary key
 Username nvarchar (50) not null unique,
 Pasword nvarchar (50) not null,
 

 )

create table tblSongs(
SongID int identity(1,1) Primary key, --Primary key
SongName nvarchar(50) not null,
Author nvarchar (50) not null,
Duration nvarchar(50) not null,
UserID int,
)




ALTER TABLE tblSongs
ADD FOREIGN KEY (UserID) REFERENCES tblUsers(UserID);

GO

create view vwSongs as
select s.* , u.Username, u.Pasword
from tblSongs s
INNER JOIN tblUsers u
ON u.UserID = s.UserID;
GO
