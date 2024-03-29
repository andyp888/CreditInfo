USE [creditInfo]
GO
/****** Object:  User [adminUser]    Script Date: 10/11/2019 18:24:14 ******/
CREATE USER [adminUser] FOR LOGIN [adminUser] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [adminUser]
GO
ALTER ROLE [db_accessadmin] ADD MEMBER [adminUser]
GO
/****** Object:  Table [dbo].[Amount]    Script Date: 10/11/2019 18:24:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Amount](
	[Value] [decimal](19, 4) NOT NULL,
	[Currency] [nvarchar](3) NOT NULL,
	[AmountId] [int] IDENTITY(1,1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[AmountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contract]    Script Date: 10/11/2019 18:24:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contract](
	[ContractCode] [nvarchar](30) NOT NULL,
	[PhaseOfContract] [int] NOT NULL,
	[OriginalAmountId] [int] NULL,
	[InstallmentAmountId] [int] NULL,
	[CurrentBalanceId] [int] NULL,
	[OverdueBalanceId] [int] NULL,
	[DateOfLastPayment] [date] NULL,
	[NextPaymentDate] [date] NULL,
	[DateAccountOpened] [date] NULL,
	[RealEndDate] [date] NULL,
 CONSTRAINT [PK_Contract] PRIMARY KEY CLUSTERED 
(
	[ContractCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Individual]    Script Date: 10/11/2019 18:24:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Individual](
	[CustomerCode] [nvarchar](50) NOT NULL,
	[FirstName] [nchar](64) NULL,
	[LastName] [nchar](128) NULL,
	[Gender] [int] NULL,
	[DateOfBirth] [date] NULL,
	[NationalID] [nchar](32) NULL,
 CONSTRAINT [PK_Individual] PRIMARY KEY CLUSTERED 
(
	[CustomerCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SubjectRole]    Script Date: 10/11/2019 18:24:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubjectRole](
	[CustomerCode] [nchar](50) NOT NULL,
	[RoleOfCustomer] [int] NOT NULL,
	[GuaranteeAmountId] [int] NULL,
 CONSTRAINT [PK_SubjectRole] PRIMARY KEY CLUSTERED 
(
	[CustomerCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Contract]  WITH CHECK ADD  CONSTRAINT [FK_Contract_CurrentBalance] FOREIGN KEY([CurrentBalanceId])
REFERENCES [dbo].[Amount] ([AmountId])
GO
ALTER TABLE [dbo].[Contract] CHECK CONSTRAINT [FK_Contract_CurrentBalance]
GO
ALTER TABLE [dbo].[Contract]  WITH CHECK ADD  CONSTRAINT [FK_Contract_InstallmentAmount] FOREIGN KEY([InstallmentAmountId])
REFERENCES [dbo].[Amount] ([AmountId])
GO
ALTER TABLE [dbo].[Contract] CHECK CONSTRAINT [FK_Contract_InstallmentAmount]
GO
ALTER TABLE [dbo].[Contract]  WITH CHECK ADD  CONSTRAINT [FK_Contract_OverdueBalance] FOREIGN KEY([OverdueBalanceId])
REFERENCES [dbo].[Amount] ([AmountId])
GO
ALTER TABLE [dbo].[Contract] CHECK CONSTRAINT [FK_Contract_OverdueBalance]
GO
ALTER TABLE [dbo].[Contract]  WITH CHECK ADD  CONSTRAINT [FK_OriginalAmount] FOREIGN KEY([OriginalAmountId])
REFERENCES [dbo].[Amount] ([AmountId])
GO
ALTER TABLE [dbo].[Contract] CHECK CONSTRAINT [FK_OriginalAmount]
GO
ALTER TABLE [dbo].[SubjectRole]  WITH CHECK ADD  CONSTRAINT [FK_SubjectRole_GuaranteeAmount] FOREIGN KEY([GuaranteeAmountId])
REFERENCES [dbo].[Amount] ([AmountId])
GO
ALTER TABLE [dbo].[SubjectRole] CHECK CONSTRAINT [FK_SubjectRole_GuaranteeAmount]
GO
