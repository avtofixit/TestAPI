CREATE TABLE [dbo].[Segment](
	[X] [float] NOT NULL,
	[Y] [float] NOT NULL,
	[X1] [float] NOT NULL,
	[Y1] [float] NOT NULL
) ON [PRIMARY]
GO

CREATE PROCEDURE [dbo].[SearchSegments]
	@x float = 20,
	@y float = 25,
	@x1 float = 20,
	@y1 float = 22
AS
BEGIN

	select * from Segment
	where (X <= @x and @x <= X1 and Y <= @y and @y <= Y1)
		  or 
		  (X <= @x1 and @x1 <= X1 and Y <= @y1 and @y1 <= Y1)

END
GO
-------------------------
--                     --
-- generate some data  --
--                     --
-------------------------
declare @x int, @y int, @x1 int, @y1 int, @t int, @i int = 0
WHILE @i < 200000
BEGIN
    SET @i = @i + 1

	select @x = rand() * 100, @y = rand() * 100, @x1 = rand() * 100, @y1 = rand() * 100

	if (@x > @x1)
	begin
		set @t = @x1;
		set @x1 = @x;
		set @x = @t;
	end

	if (@y > @y1)
	begin
		set @t = @y1;
		set @y1 = @y;
		set @y = @t;
	end

	insert into Segment(X, Y, X1, Y1) values (@x, @y, @x1, @y1);
END

