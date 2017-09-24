/*  
	The following drop statement might not work in sql server version prior to 2016.
    If this script is executed in a version prior to 2016, remove the drop statements below 
	and make sure the script is run only once.  
*/

drop table if exists dbo.GameMaster
go

drop table if exists dbo.GameRating
go

drop procedure if exists dbo.Proc_GetAllGames
go

drop procedure if exists dbo.Proc_UpdateDesciption
go

drop procedure if exists dbo.Proc_AddRating
go

drop procedure if exists  dbo.Proc_GetById
go

create table GameMaster
(
	GameID int primary key identity(1,1),
	GameName varchar(256),
	GameDescription nvarchar(1024)
)
go

create table GameRating
(
	RatingID int primary key identity(1,1),
	GameID int,
	Rating tinyint
)
go

insert GameMaster
select dr.GameName, dr.GameDescription from
(
	select 'World of Warcraft' as GameName, 
			'Vivamus purus eros, aliquet malesuada gravida at, fringilla vel elit. Mauris vestibulum, erat at volutpat semper, metus enim faucibus nunc, in ultrices magna enim in justo' as GameDescription
union
	select 'League of Legends' as GameName,
			'Integer magna magna, iaculis euismod tincidunt a, cursus ac dolor. Aenean quis egestas diam. Pellentesque purus ipsum' as GameDescription
union
	select 'Final Fantasy' as GameName,
			'Lorem ipsum dolor sit amet, consectetur adipiscing elit' as GameDescription
)dr

go
/*
	Depending on the size of the game database, the query used to calculate and select avg rating will change.
	This is a simple implementation for now.
	exec Proc_GetAllGames
as
*/
create procedure Proc_GetAllGames
as

	select 
		gm.GameID,
		gm.GameName,
		gm.GameDescription,
		(case when dr.Rating is not null then dr.Rating else 0 end) as GameRating
	from
		dbo.GameMaster gm
	left join
	(
		select 
			GameID,
			avg(Rating) as Rating
		from
			dbo.GameRating
		group by 
			GameID
	)dr on dr.GameID = gm.GameID
	order by dr.Rating desc
go

/*
Get a game item record  with avg rating
exec Proc_GetById 2

*/
create procedure Proc_GetById
(
	@GameID int
)
as

	select 
		gm.GameID,
		gm.GameName,
		gm.GameDescription,
		(case when dr.Rating is not null then dr.Rating else 0 end) as GameRating
	from
		dbo.GameMaster gm
	left join
	(
		select 
			GameID,
			avg(Rating) as Rating
		from
			dbo.GameRating
		where GameID = @GameID
		group by 
			GameID
	)dr on dr.GameID = gm.GameID 
	where gm.GameID = @GameID
	order by dr.Rating desc
go


/*
	I understand that we are changing description of the game. 
	The database does not  containt who updated the information yet. Can expand database to accommodate audit informations.
*/
create procedure Proc_UpdateDesciption
(
	@GameID int,
	@GameDescription nvarchar(1024)
)
as
	update 
		dbo.GameMaster 
	set 
		GameDescription = @GameDescription 
	where GameId = @GameID

go

/*
	Audit information is missing and not implemented because of time contraint. 
	The user information is also not saved due to time contraint.
	exec Proc_AddRating 1,2
	exec Proc_AddRating 1,3
*/
create procedure Proc_AddRating
(
	@GameID int,
	@Rating int
)
as
	
	insert into GameRating(GameID, Rating) values (@GameID, @Rating)
go

exec Proc_AddRating 1, 3
go
exec Proc_AddRating 1, 5
go
exec Proc_AddRating 1, 1
go

exec Proc_AddRating 2, 5
go

exec Proc_AddRating 2, 4
go

exec Proc_AddRating 3, 2
go

exec Proc_AddRating 3, 3
go