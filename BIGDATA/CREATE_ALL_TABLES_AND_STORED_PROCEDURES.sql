SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[RowVer] [timestamp] NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Phone] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](50) NULL,
	[RowVer] [timestamp] NOT NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Phone] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[RowVer] [timestamp] NOT NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderLine](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[OrderId] [int] NOT NULL,
	[RowVer] [timestamp] NOT NULL,
 CONSTRAINT [PK_Orderline] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Price] [money] NOT NULL,
	[Time] [datetime2](7) NOT NULL,
	[CustomerId] [int] NULL,
	[EmployeeId] [int] NOT NULL,
	[Comment] [nvarchar](3750) NULL,
	[RowVer] [timestamp] NOT NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](500) NOT NULL,
	[Price] [money] NOT NULL,
	[CategoryId] [int] NOT NULL,
	[RowVer] [timestamp] NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reservation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Time] [datetime2](7) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[RowVer] [timestamp] NOT NULL,
 CONSTRAINT [PK_Reservation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReservedTable](
	[ReservationId] [int] NOT NULL,
	[TableId] [int] NOT NULL,
 CONSTRAINT [PK_ReservedTable_1] PRIMARY KEY CLUSTERED 
(
	[ReservationId] ASC,
	[TableId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Table](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Seats] [int] NULL,
	[RowVer] [timestamp] NOT NULL,
 CONSTRAINT [PK_Table] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TablesOrders](
	[OrderId] [int] NOT NULL,
	[TableId] [int] NOT NULL,
 CONSTRAINT [PK_OrdersTables] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC,
	[TableId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Orders] ADD  CONSTRAINT [DF_Order_Time]  DEFAULT (getdate()) FOR [Time]
GO
ALTER TABLE [dbo].[Reservation] ADD  CONSTRAINT [DF_Reservation_Time]  DEFAULT (getdate()) FOR [Time]
GO
ALTER TABLE [dbo].[OrderLine]  WITH CHECK ADD  CONSTRAINT [FK_OrderLine_Orders] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([Id])
GO
ALTER TABLE [dbo].[OrderLine] CHECK CONSTRAINT [FK_OrderLine_Orders]
GO
ALTER TABLE [dbo].[OrderLine]  WITH CHECK ADD  CONSTRAINT [FK_OrderLine_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[OrderLine] CHECK CONSTRAINT [FK_OrderLine_Product]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Order_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([Id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Order_Customer]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Order_Employee] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Order_Employee]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Category]
GO
ALTER TABLE [dbo].[Reservation]  WITH CHECK ADD  CONSTRAINT [FK_Reservation_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([Id])
GO
ALTER TABLE [dbo].[Reservation] CHECK CONSTRAINT [FK_Reservation_Customer]
GO
ALTER TABLE [dbo].[Reservation]  WITH CHECK ADD  CONSTRAINT [FK_Reservation_Employee] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[Reservation] CHECK CONSTRAINT [FK_Reservation_Employee]
GO
ALTER TABLE [dbo].[ReservedTable]  WITH CHECK ADD  CONSTRAINT [FK_ReservedTable_Reservation] FOREIGN KEY([ReservationId])
REFERENCES [dbo].[Reservation] ([Id])
GO
ALTER TABLE [dbo].[ReservedTable] CHECK CONSTRAINT [FK_ReservedTable_Reservation]
GO
ALTER TABLE [dbo].[ReservedTable]  WITH CHECK ADD  CONSTRAINT [FK_ReservedTable_Table] FOREIGN KEY([TableId])
REFERENCES [dbo].[Table] ([Id])
GO
ALTER TABLE [dbo].[ReservedTable] CHECK CONSTRAINT [FK_ReservedTable_Table]
GO
ALTER TABLE [dbo].[TablesOrders]  WITH CHECK ADD  CONSTRAINT [FK_OrdersTables_Orders] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([Id])
GO
ALTER TABLE [dbo].[TablesOrders] CHECK CONSTRAINT [FK_OrdersTables_Orders]
GO
ALTER TABLE [dbo].[TablesOrders]  WITH CHECK ADD  CONSTRAINT [FK_OrdersTables_Table] FOREIGN KEY([TableId])
REFERENCES [dbo].[Table] ([Id])
GO
ALTER TABLE [dbo].[TablesOrders] CHECK CONSTRAINT [FK_OrdersTables_Table]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spCategory_GetById] 
	@Id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * 
	FROM Category 
	WHERE @Id = Id;
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spCategory_Update]
	-- Add the parameters for the stored procedure here
	@Id int,
	@Name varchar(50),
	@RowVer timestamp
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE 
		Category
	SET
		Name = @Name
	OUTPUT 
		inserted.RowVer
	WHERE
		Id = @Id AND RowVer = @RowVer;
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spCustomer_GetById]
	-- Add the parameters for the stored procedure here
	@Id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT *
	FROM Customer
	WHERE Id = @Id;
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spCustomer_GetByName]
	-- Add the parameters for the stored procedure here
	@Name nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT *
	FROM Customer
	WHERE Name = @Name;
END


GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spCustomer_Insert]
	-- Add the parameters for the stored procedure here
	@Name nvarchar(50),
	@Phone nvarchar(50),
	@Email nvarchar(50),
	@Address nvarchar(50),
	@Id int = 0 output
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO dbo.Customer(Name, Phone, Email, Address)
	VALUES (@Name, @Phone, @Email, @Address);

	select @Id = SCOPE_IDENTITY();
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spCustomer_Update]
	-- Add the parameters for the stored procedure here
	@Id int,
	@Name varchar(50),
	@Phone varchar(50),
	@Email varchar(50),
	@Address varchar(50),
	@RowVer timestamp
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE
		Customer
	SET
		Name = @Name,
		Phone = @Phone,
		Email = @Email,
		Address = @Address
	OUTPUT
		inserted.RowVer
	WHERE
		Id = @Id AND RowVer = @RowVer;
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spEmployee_GetById] 
	-- Add the parameters for the stored procedure here
	@Id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT *
	FROM Employee
	WHERE Id = @Id;
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spEmployee_Insert] 
	-- Add the parameters for the stored procedure here
	@Name nvarchar(50),
	@Phone nvarchar(50),
	@Email nvarchar(50),
	@Id int = 0 out
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO dbo.Employee (Name, Phone, Email)
	VALUES (@Name, @Phone, @Email);

	SELECT @Id = SCOPE_IDENTITY();
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spEmployee_Update]
	-- Add the parameters for the stored procedure here
	@Id int,
	@Name varchar(50),
	@Phone varchar(50),
	@Email varchar(50),
	@RowVer timestamp
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE 
		Employee
	SET
		Name = @Name,
		Phone = @Phone,
		Email = @Email
	OUTPUT
		inserted.RowVer
	WHERE
		Id = @Id AND RowVer = @RowVer;
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spOrderLine_Delete]
@OrderId int

AS

DELETE FROM [dbo].[OrderLine]
WHERE OrderId = @OrderId

GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spOrderLine_GetByOrder] 
	-- Add the parameters for the stored procedure here
	@Id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT *
	FROM OrderLine
	WHERE OrderId = @Id;
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spOrderLine_Insert] 
	-- Add the parameters for the stored procedure here
	@ProductId int,
	@Quantity int,
	@OrderId int,
	@Id int = 0 out
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO dbo.OrderLine (ProductId, Quantity, OrderId)
	VALUES (@ProductId, @Quantity, @OrderId);

	SELECT @Id = SCOPE_IDENTITY();
END
GO
/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spOrderLine_Update] 
	
	@Id INT,
	@ProductId INT,
	@Quantity INT,
	@RowVer timestamp
AS
BEGIN
	
	SET NOCOUNT ON;

	UPDATE 
		OrderLine
	SET
		ProductId = @ProductId,
		Quantity = @Quantity
	OUTPUT
		inserted.RowVer
	WHERE
		Id = @Id AND RowVer = @RowVer;
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spOrders_Delete] 
	@Id int

AS

BEGIN TRY 

BEGIN TRANSACTION

DELETE FROM OrderLine
WHERE OrderId = @Id

DELETE FROM TablesOrders
WHERE OrderId = @Id

DELETE FROM Orders
WHERE Id = @Id



COMMIT TRANSACTION
END TRY

BEGIN CATCH
        ROLLBACK TRANSACTION
        RETURN ERROR_MESSAGE()
END CATCH
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spOrders_GetByDateTime]
@date datetime2
as
SELECT [Orders].[Id]
      ,[Price]
      ,[Time]
      ,[CustomerId]
      ,[EmployeeId]
  FROM [dbo].[Orders]
  INNER JOIN [dbo].[Employee]
  ON [Orders].[EmployeeId] = [Employee].[Id]
  INNER JOIN [dbo].[Customer]
  ON [Orders].[CustomerId] = [Customer].[Id]
  WHERE datediff(day, Orders.Time,  CONVERT(DATETIME, @date,103) ) = 0
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spOrders_GetById] 
	-- Add the parameters for the stored procedure here
	@Id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * 
	FROM Orders
	WHERE Id = @Id;
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spOrders_Insert]
	-- Add the parameters for the stored procedure here
	@Price money,
	@CustomerId int,
	@EmployeeId int,
	@Comment nvarchar(3750),
	@Id int = 0 output
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO dbo.Orders (Price, CustomerId, EmployeeId, Comment)
	VALUES (@Price, @CustomerId, @EmployeeId, @Comment);

	select @Id = SCOPE_IDENTITY();
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE  [dbo].[spOrders_Update]
	-- Add the parameters for the stored procedure here
	@Id INT ,
	@Price MONEY,
	@Time DATETIME2,
	@CustomerId INT,
	@EmployeeId INT,
	@Comment nvarchar(3750),
	@RowVer timestamp

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON

    -- Insert statements for procedure here
	UPDATE
		Orders
	SET
		Price = @Price,
		Time=@Time, 
		CustomerId=@CustomerId, 
		EmployeeId=@EmployeeId, 
		Comment =@Comment
	OUTPUT
		inserted.RowVer
	WHERE
		Id = @Id AND RowVer = @RowVer;
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spProduct_GetById] 
	-- Add the parameters for the stored procedure here
	@Id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT *
	FROM Product
	Where Id = @Id;
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spProduct_GetByName] 
	-- Add the parameters for the stored procedure here
	@Name nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT *
	FROM Product
	Where Name = @Name;
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spProduct_Insert]
	-- Add the parameters for the stored procedure here
	@Name nvarchar(50),
	@Description nvarchar(50),
	@Price money,
	@CategoryId int,
	@Id int = 0 out
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO Product (Name, Description, Price, CategoryId)
	VALUES (@Name, @Description, @Price, @CategoryId);

	SELECT @Id = SCOPE_IDENTITY();
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spProduct_Update] 
	-- Add the parameters for the stored procedure here
	@Id int,
	@Name varchar(50),
	@Description varchar(500),
	@Price money,
	@CategoryId int,
	@RowVer timestamp
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE
		Product
	SET
		Name = @Name,
		Description = @Description,
		Price = @Price,
		CategoryId = @CategoryId
	OUTPUT
		inserted.RowVer
	WHERE
		Id = @Id AND RowVer = @RowVer;
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spReservation_Delete] 
	@Id int
	

AS

BEGIN TRY 

BEGIN TRANSACTION

DELETE FROM	ReservedTable
WHERE ReservationId = @Id

DELETE FROM Reservation
WHERE Id = @Id







COMMIT TRANSACTION
END TRY

BEGIN CATCH
        ROLLBACK TRANSACTION
        RETURN ERROR_MESSAGE()
END CATCH
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spReservation_Insert] 
	-- Add the parameters for the stored procedure here
	@CustomerId int,
	@EmployeeId int,
	@Time datetime2(7),
	@Id int = 0 out
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO dbo.Reservation(Time, CustomerId, EmployeeId)
	VALUES (@Time, @CustomerId, @EmployeeId);

	SELECT @Id = SCOPE_IDENTITY();
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spReservation_Update] 
	
	@Id INT,
	@Time datetime2(7),
	@RowVer timestamp
		
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE 
		Reservation
	SET
		[dmab0918_1074178].[dbo].[Reservation].[Time] = @Time
	OUTPUT
		inserted.RowVer
	WHERE
		Id = @Id AND RowVer = @RowVer;
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spReservedTable_Insert]
	-- Add the parameters for the stored procedure here
	@TableId int,
	@ReservationId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO ReservedTable (TableId, ReservationId)
	VALUES (@TableId, @ReservationId);
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[spTable_Available]
	-- Add the parameters for the stored procedure here

	@Time datetime2(7)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT t.* FROM
		[dmab0918_1074178].[dbo].[Table] t
	LEFT JOIN
		(SELECT TableId FROM
			ReservedTable rt
	INNER JOIN
		Reservation res
	ON rt.ReservationId = res.Id
	WHERE 
	dateadd(HOUR, 2, res.Time) > @Time)
	ReservationAtThisTime
ON t.Id = ReservationAtThisTime.TableId
WHERE ReservationAtThisTime.TableId IS NULL;

END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spTable_GetByOrder]
	-- Add the parameters for the stored procedure here
	@Id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT 
		[dmab0918_1074178].[dbo].[Table].[Id], 
		[dmab0918_1074178].[dbo].[Table].[Name],
		[dmab0918_1074178].[dbo].[Table].[Seats]
	
	FROM 
		TablesOrders, 
		[dmab0918_1074178].[dbo].[Table]
	WHERE 
		TablesOrders.OrderId = @Id
	AND 
		[dmab0918_1074178].[dbo].[Table].[Id] = TablesOrders.TableId;

END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spTable_Insert]
	-- Add the parameters for the stored procedure here
	@Name nvarchar(50),
	@Id int = 0 out,
	@Seats int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [dmab0918_1074178].[dbo].[Table] (Name, Seats)
	VALUES (@Name, @Seats);

	SELECT @Id = SCOPE_IDENTITY();
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spTable_NumberOfSeats] 
	-- Add the parameters for the stored procedure here
	@Seats int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT *
	FROM [dbo].[Table]
	Where Seats <= @Seats;
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spTable_Update] 
	-- Add the parameters for the stored procedure here
	@Id int,
	@Name varchar(50),
	@Seats int,
	@RowVer timestamp
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE
		[dmab0918_1074178].[dbo].[Table]
	SET
		Name = @Name,
		Seats = @Seats
	OUTPUT
		inserted.RowVer
	WHERE
		Id = @Id AND RowVer = @RowVer;
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spTablesOrders_Insert]
	-- Add the parameters for the stored procedure here
	@OrderId int,
	@TableId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO TablesOrders (OrderId, TableId)
	VALUES (@OrderId, @TableId)
END
GO
USE [master]
GO
ALTER DATABASE [dmab0918_1074178] SET  READ_WRITE 
GO
