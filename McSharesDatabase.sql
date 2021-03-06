USE [McShares]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 30/12/2021 16:50:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[Customer](
	[CustomerId] [bigint] IDENTITY(1,1) NOT NULL,
	[CustomerNo] [varchar](100) NULL,
	[CustomerType] [varchar](100) NULL,
	[DateOfBirth] [datetime] NULL,
	[DateInCorporate] [datetime] NULL,
	[RegistrationNo] [varchar](100) NULL,
	[DtStamp] [datetime] NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CustomerContactDetails]    Script Date: 30/12/2021 16:50:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[CustomerContactDetails](
	[CustomerContactDetailId] [bigint] IDENTITY(1,1) NOT NULL,
	[CustomerId] [bigint] NOT NULL,
	[ContactName] [varchar](100) NULL,
	[ContactNumber] [varchar](100) NULL,
	[DtStamp] [datetime] NULL,
 CONSTRAINT [PK_CustomerContactDetails] PRIMARY KEY CLUSTERED 
(
	[CustomerContactDetailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CustomerMailAddress]    Script Date: 30/12/2021 16:50:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CustomerMailAddress](
	[CustomerMailAddressId] [bigint] IDENTITY(1,1) NOT NULL,
	[CustomerId] [bigint] NOT NULL,
	[AddressLine1] [varchar](200) NULL,
	[AddressLine2] [varchar](200) NULL,
	[TownCity] [varchar](100) NULL,
	[Country] [varchar](100) NULL,
	[DtStamp] [datetime] NULL,
 CONSTRAINT [PK_CustomerMailAddress] PRIMARY KEY CLUSTERED 
(
	[CustomerMailAddressId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CustomerShareDetails]    Script Date: 30/12/2021 16:50:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerShareDetails](
	[CustomerShareDetailId] [bigint] IDENTITY(1,1) NOT NULL,
	[CustomerId] [bigint] NOT NULL,
	[Shares] [int] NULL,
	[SharePrice] [decimal](18, 2) NULL,
	[Balance] [decimal](18, 2) NULL,
	[DtStamp] [datetime] NULL,
 CONSTRAINT [PK_CustomerShareDetails] PRIMARY KEY CLUSTERED 
(
	[CustomerShareDetailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Document]    Script Date: 30/12/2021 16:50:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Document](
	[DocumentId] [bigint] IDENTITY(1,1) NOT NULL,
	[DocReferenceNo] [varchar](100) NULL,
	[DocXML] [xml] NULL,
	[DocDate] [datetime] NULL,
	[DtStamp] [datetime] NULL,
 CONSTRAINT [PK_Document] PRIMARY KEY CLUSTERED 
(
	[DocumentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DocumentCustomerSharesStaging]    Script Date: 30/12/2021 16:50:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DocumentCustomerSharesStaging](
	[DocumentCustomerSharesStagingId] [int] IDENTITY(1,1) NOT NULL,
	[DocumentId] [bigint] NULL,
	[CustomerNo] [varchar](100) NULL,
	[CustomerType] [varchar](100) NULL,
	[DateOfBirth] [datetime] NULL,
	[DateInCorporate] [datetime] NULL,
	[RegistrationNo] [varchar](100) NULL,
	[AddressLine1] [varchar](200) NULL,
	[AddressLine2] [varchar](200) NULL,
	[TownCity] [varchar](100) NULL,
	[Country] [varchar](100) NULL,
	[ContactName] [varchar](100) NULL,
	[ContactNumber] [varchar](100) NULL,
	[Shares] [varchar](100) NULL,
	[SharePrice] [varchar](100) NULL,
	[IsError] [bit] NULL,
	[ValidationSummary] [varchar](1000) NULL,
	[DtStamp] [datetime] NULL,
 CONSTRAINT [PK_DocumentCustomerSharesStaging] PRIMARY KEY CLUSTERED 
(
	[DocumentCustomerSharesStagingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ErrorLog]    Script Date: 30/12/2021 16:50:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ErrorLog](
	[ErrorLogId] [bigint] IDENTITY(1,1) NOT NULL,
	[ErrorDescription] [varchar](max) NULL,
	[Source] [varchar](500) NULL,
	[DtStamp] [datetime] NULL,
 CONSTRAINT [PK_ErrorLog] PRIMARY KEY CLUSTERED 
(
	[ErrorLogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[CustomerContactDetails]  WITH CHECK ADD  CONSTRAINT [FK_CustomerContactDetails_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([CustomerId])
GO
ALTER TABLE [dbo].[CustomerContactDetails] CHECK CONSTRAINT [FK_CustomerContactDetails_Customer]
GO
ALTER TABLE [dbo].[CustomerMailAddress]  WITH CHECK ADD  CONSTRAINT [FK_CustomerMailAddress_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([CustomerId])
GO
ALTER TABLE [dbo].[CustomerMailAddress] CHECK CONSTRAINT [FK_CustomerMailAddress_Customer]
GO
ALTER TABLE [dbo].[CustomerShareDetails]  WITH CHECK ADD  CONSTRAINT [FK_CustomerShareDetails_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([CustomerId])
GO
ALTER TABLE [dbo].[CustomerShareDetails] CHECK CONSTRAINT [FK_CustomerShareDetails_Customer]
GO
/****** Object:  StoredProcedure [dbo].[GetCustomerList]    Script Date: 30/12/2021 16:50:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetCustomerList] 
@ContactName VARCHAR(100) = NULL 
AS
BEGIN

SELECT C.CustomerId,C.CustomerNo ,CCD.ContactName AS CustomerName, C.DateOfBirth,C.DateInCorporate,C.CustomerType,C.RegistrationNo,CSD.Shares,CSD.SharePrice As Price,CSD.Balance
FROM Customer C
INNER JOIN CustomerContactDetails CCD ON CCD.CustomerId = C.CustomerId
INNER JOIN CustomerMailAddress CMA ON CMA.CustomerId = C.CustomerId
INNER JOIN CustomerShareDetails CSD ON CSD.CustomerId = C.CustomerId
WHERE (@ContactName IS NULL OR CCD.ContactName  LIKE '%' + @ContactName + '%')

END

GO
/****** Object:  StoredProcedure [dbo].[InsertShareDetailsFromXML]    Script Date: 30/12/2021 16:50:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[InsertShareDetailsFromXML]
       @xmlData XML	  
AS
BEGIN

BEGIN TRY      
        SET NOCOUNT ON;

	    DECLARE @DocumentId INT,@Errormsg VARCHAR(MAX)

		Create Table #TempCustomerDetails([DocumentId] BIGINT,CustomerNo VARCHAR(100),CustomerType VARCHAR(100),
		DateOfBirth DATETIME,DateInCorporate DATETIME,RegistrationNo  VARCHAR(100),AddressLine1 VARCHAR(200),AddressLine2 VARCHAR(200),
		TownCity VARCHAR(100),Country VARCHAR(100),ContactName VARCHAR(100),ContactNumber VARCHAR(100),Shares VARCHAR(100),SharePrice VARCHAR(100))  

		INSERT INTO Document(DocReferenceNo,DocXML,DocDate,DtStamp)
		SELECT  Doc.detail.value('(Doc_Ref/text())[1]','VARCHAR(100)'),
				@xmlData,				
				CONVERT(datetime, Doc.detail.value('(Doc_Date/text())[1]','VARCHAR(100)'),104) ,
				GETDATE()
		FROM  @xmlData.nodes('/RequestDoc') AS Doc(detail) 

		SET  @DocumentId =SCOPE_IDENTITY()
   		
		Insert into #TempCustomerDetails 
		SELECT @DocumentId, 
			Doc.detail.value('(customer_id/text())[1]','VARCHAR(100)'),
			Doc.detail.value('(Customer_Type/text())[1]','VARCHAR(100)'),
			CONVERT(datetime,Doc.detail.value('(Date_Of_Birth/text())[1]','VARCHAR(100)'),104),
			CONVERT(datetime,Doc.detail.value('(Date_Incorp/text())[1]','VARCHAR(100)'),104),
			Doc.detail.value('(REGISTRATION_NO/text())[1]','VARCHAR(100)'),
			Doc.detail.value('(Mailing_Address/Address_Line1/text())[1]','VARCHAR(100)'),
			Doc.detail.value('(Mailing_Address/Address_Line2/text())[1]','VARCHAR(100)'),
			Doc.detail.value('(Mailing_Address/Town_City/text())[1]','VARCHAR(100)'),
			Doc.detail.value('(Mailing_Address/Country/text())[1]','VARCHAR(100)')y,
			Doc.detail.value('(Contact_Details/Contact_Name/text())[1]','VARCHAR(100)'),
			Doc.detail.value('(Contact_Details/Contact_Number/text())[1]','VARCHAR(100)'),
			Doc.detail.value('(Shares_Details/Num_Shares/text())[1]','VARCHAR(100)'),
			Doc.detail.value('(Shares_Details/Share_Price/text())[1]','VARCHAR(100)')
		FROM  
		@xmlData.nodes('/RequestDoc/Doc_Data/DataItem_Customer')AS Doc(detail)

		Insert into DocumentCustomerSharesStaging
		SELECT DocumentId,CustomerNo,CustomerType,DateOfBirth,DateInCorporate,RegistrationNo,AddressLine1,AddressLine2,TownCity,
				Country,ContactName,ContactNumber,Shares,SharePrice,0,NULL,GETDATE()
			FROM #TempCustomerDetails

		--Validation for allrows of document

		EXEC ValidateCustomerShareDetails @DocumentId

		--Insert valid rows to related tables

		INSERT INTO Customer 
		SELECT CustomerNo,CustomerType, DateOfBirth,DateInCorporate,RegistrationNo,GETDATE()
			FROM DocumentCustomerSharesStaging 
			WHERE DocumentId = @DocumentId AND ISNULL(IsError,0) = 0

		INSERT INTO CustomerMailAddress 
		SELECT CUST.CustomerId,DOC.AddressLine1,DOC.AddressLine2,DOC.TownCity,DOC.Country,GETDATE()
			FROM DocumentCustomerSharesStaging DOC
		INNER JOIN Customer CUST ON CUST.CustomerNo = DOC.CustomerNo
			WHERE DOC.DocumentId = @DocumentId AND ISNULL(DOC.IsError,0) = 0

		INSERT INTO CustomerContactDetails 
		SELECT CUST.CustomerId,DOC.ContactName,DOC.ContactNumber,GETDATE()
			FROM DocumentCustomerSharesStaging DOC
		INNER JOIN Customer CUST ON CUST.CustomerNo = DOC.CustomerNo
			WHERE DOC.DocumentId = @DocumentId AND ISNULL(DOC.IsError,0) = 0

		INSERT INTO CustomerShareDetails 
		SELECT CUST.CustomerId,DOC.Shares,DOC.SharePrice,(CAST(DOC.Shares AS INT)*CAST(DOC.SharePrice AS DECIMAL(18,2))),GETDATE()
			FROM DocumentCustomerSharesStaging DOC
		INNER JOIN Customer CUST ON CUST.CustomerNo = DOC.CustomerNo
			WHERE DOC.DocumentId = @DocumentId AND ISNULL(DOC.IsError,0) = 0

		SELECT DocumentCustomerSharesStagingId,CustomerNo,IsError,
		ValidationSummary FROM DocumentCustomerSharesStaging WHERE DocumentId= @DocumentId

END TRY
BEGIN CATCH

		SET @Errormsg= 'Error While Validate : ' + CAST(ERROR_MESSAGE() AS NVARCHAR(250)) + ', ' + CAST(ERROR_NUMBER() AS NVARCHAR(250)) + ' ' + 'Source '+ ERROR_PROCEDURE() + ''
		INSERT INTO ErrorLog(ErrorDescription,Source,DtStamp)
		SELECT @Errormsg,ERROR_PROCEDURE(),GETDATE()

END CATCH 
END




GO
/****** Object:  StoredProcedure [dbo].[UpdateShareDetails]    Script Date: 30/12/2021 16:50:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[UpdateShareDetails]
	-- Add the parameters for the stored procedure here
	@CustomerNo	varchar(100),	
	@RegistrationNo	varchar(100),	
	@ContactName varchar(100),
	@ContactNumber varchar(100),
	@AddressLine1 varchar(200),
	@AdressLine2 varchar(200),
	@TownCity varchar(100),
	@Country varchar(100),
	@Shares int = 0,
	@SharePrice decimal(18,2) = 0.00,
	@message AS varchar(500) ='' OUTPUT

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	BEGIN TRY
		
	    DECLARE @CustomerID int= 0,@CustomerType varchar(100),@DateOfBirth DATETIME,@IsError BIT=0

		SET @message = 'UPDATE SUCCESSFULL'
		SET @CustomerID = (SELECT customerid FROM Customer WHERE CustomerNo = @CustomerNo)
		SELECT @CustomerType=CustomerType FROM Customer WHERE CustomerId = @CustomerID
		SELECT @DateOfBirth=DateOfBirth FROM Customer WHERE CustomerId = @CustomerID

		if(ISNULL(@CustomerID,0)=0)
		BEGIN
			SET @message = 'Customer could not found.'
			RETURN
		END

		IF (ISNULL(DATEDIFF(YY,@DateOfBirth,GETDATE()),0) < 18 AND LOWER(@CustomerType)='individual')
		BEGIN
			SET @message = 'Customer age must be 18.'
			RETURN
		END

		IF (ISNUMERIC(@Shares) = 0)
		BEGIN
			SET @message =  'Number of shares must be an integer and greater than 0.' 
			RETURN
		END

		IF ((ISNUMERIC(@Shares) = 0 AND @Shares NOT LIKE '%[^0-9]%' ) AND @Shares <= 0  )
		BEGIN
			SET @message = 'Number of shares must be an integer and greater than 0.'
			RETURN
		END

		IF (ISNUMERIC(@SharePrice) = 0 OR @SharePrice LIKE '%[^0-9.]%' OR ISNULL(NULLIF(CHARINDEX('.',REVERSE(CONVERT(VARCHAR(50), @SharePrice, 128))),0) - 1,0) > 2)
		BEGIN
			SET @message = 'Share Price is invalid.' 
			RETURN
		END

		IF(LOWER(@CustomerType) = 'corporate' AND @Shares > 0 ) 
		BEGIN
			SET @message = 'Cannot update Corporate share.'
			RETURN
		END	 

	


		UPDATE Customer
		SET CustomerNo	= @CustomerNo,DateOfBirth	= @DateOfBirth,RegistrationNo = @RegistrationNo
		WHERE CustomerId = @CustomerID
	   
		UPDATE CustomerContactDetails 
		SET ContactName = @ContactName, ContactNumber = @ContactNumber
		FROM Customer C 
		INNER JOIN CustomerContactDetails CCD ON C.CustomerId = CCD.CustomerId
		WHERE C.CustomerId = @CustomerID

		
		UPDATE CustomerMailAddress 
		SET AddressLine1 = @AddressLine1, AddressLine2 = @AdressLine2,TownCity = @TownCity,Country =@Country
		FROM Customer C 
		INNER JOIN CustomerMailAddress CMD ON C.CustomerId = CMD.CustomerId
		WHERE C.CustomerId = @CustomerID
		
		UPDATE CustomerShareDetails 
		SET Shares = @Shares, SharePrice = @SharePrice,Balance = (CAST(@Shares AS INT)*CAST(@SharePrice AS DECIMAL(18,2)))
		FROM Customer C 
		INNER JOIN CustomerShareDetails CSD ON C.CustomerId = CSD.CustomerId
		WHERE C.CustomerId = @CustomerID

	END TRY
	BEGIN CATCH
		-- if error, then log into error table
		DECLARE @Errormsg VARCHAR(100)
        SET @Errormsg= 'Error While Validate in ValidateCustomerShareDetails : ' + CAST(ERROR_MESSAGE() AS NVARCHAR(250)) + ', ' + CAST(ERROR_NUMBER() AS NVARCHAR(250)) + ' ' + 'Source '+ ERROR_PROCEDURE() + ''
		
		INSERT INTO ErrorLog(ErrorDescription,Source,DtStamp)
		SELECT @Errormsg,ERROR_PROCEDURE(),GETDATE()

    END CATCH
END





GO
/****** Object:  StoredProcedure [dbo].[ValidateCustomerShareDetails]    Script Date: 30/12/2021 16:50:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ValidateCustomerShareDetails]
       @DocumentId INT
AS
BEGIN

BEGIN TRY
        SET NOCOUNT ON;
		DECLARE @DocumentCustomerSharesStagingId INT,@CustomerNo VARCHAR(100), @CustomerType VARCHAR(100),@DateOfBirth DATETIME, @Shares VARCHAR(100), @SharePrice VARCHAR(100) ,@Errormsg VARCHAR(MAX)

		DECLARE CUST_CURSOR CURSOR  FOR  
		SELECT DocumentCustomerSharesStagingId,CustomerNo,CustomerType,DateOfBirth,Shares,SharePrice FROM DocumentCustomerSharesStaging WHERE DocumentId= @DocumentId
		OPEN CUST_CURSOR  FETCH NEXT FROM CUST_CURSOR INTO @DocumentCustomerSharesStagingId,@CustomerNo, @CustomerType ,@DateOfBirth,@Shares,@SharePrice  
		WHILE @@FETCH_STATUS = 0  
		BEGIN  
			
			DECLARE @IsError BIT=0,@Error VARCHAR(MAX)=''

			IF (ISNULL(DATEDIFF(YY,@DateOfBirth,GETDATE()),0) < 18 AND LOWER(@CustomerType)='individual')
			BEGIN
				SET @IsError = 1
				SET @Error = @Error + 'Customer age must be 18.'+ ', '
			END

			IF (ISNUMERIC(@Shares) = 0)
			BEGIN
				SET @IsError = 1
				SET @Error = @Error + 'Number of shares must be an integer and greater than 0.' + ', '
			END

			IF ((ISNUMERIC(@Shares) = 0 AND @Shares NOT LIKE '%[^0-9]%' ) AND @Shares <= 0  )
			BEGIN
				SET @IsError = 1
				SET @Error =@Error + 'Number of shares must be an integer and greater than 0.' + ', '
			END

			IF (ISNUMERIC(@SharePrice) = 0 OR @SharePrice LIKE '%[^0-9.]%' OR ISNULL(NULLIF(CHARINDEX('.',REVERSE(CONVERT(VARCHAR(50), @SharePrice, 128))),0) - 1,0) > 2)
			BEGIN
				SET @IsError = 1
				SET @Error = @Error + 'Share Price is invalid.' + ', '
			END

			IF EXISTS(SELECT TOP 1 CustomerId FROM Customer WHERE CustomerNo = @CustomerNo)
			BEGIN
				SET @IsError = 1
				SET @Error =@Error + 'Customer record already exists.' + ', '
			END
			
			IF (@IsError = 1)
			BEGIN
			    SET @Error = LEFT(@Error,DATALENGTH(@Error)-2)

				UPDATE DocumentCustomerSharesStaging SET IsError=@IsError,ValidationSummary=@Error
				WHERE DocumentCustomerSharesStagingId = @DocumentCustomerSharesStagingId
			END
			
			FETCH NEXT FROM CUST_CURSOR INTO  @DocumentCustomerSharesStagingId ,@CustomerNo, @CustomerType ,@DateOfBirth,@Shares,@SharePrice  
		END  
		CLOSE CUST_CURSOR  
		DEALLOCATE CUST_CURSOR  
END TRY
BEGIN CATCH

		SET @Errormsg= 'Error While Validate in ValidateCustomerShareDetails : ' + CAST(ERROR_MESSAGE() AS NVARCHAR(250)) + ', ' + CAST(ERROR_NUMBER() AS NVARCHAR(250)) + ' ' + 'Source '+ ERROR_PROCEDURE() + ''
		INSERT INTO ErrorLog(ErrorDescription,Source,DtStamp)
		SELECT @Errormsg,ERROR_PROCEDURE(),GETDATE()

END CATCH 

END


GO
