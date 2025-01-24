 

/****** Object:  Table [dbo].[UserCredentials]    Script Date: 24-01-2025 03:55:23 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[UserCredentials](
	[Id] [uniqueidentifier] NOT NULL,
	[DateCreated] [datetimeoffset](7) NOT NULL,
	[DateUpdated] [datetimeoffset](7) NULL,
	[DateDeleted] [datetimeoffset](7) NULL,
	[IsDeleted] [bit] NOT NULL,
	[Salt] [nvarchar](50) NULL,
	[Password] [nvarchar](200) NOT NULL
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Users]    Script Date: 24-01-2025 03:55:23 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Users](
	[Id] [uniqueidentifier] NOT NULL,
	[DateCreated] [datetimeoffset](7) NOT NULL,
	[DateUpdated] [datetimeoffset](7) NULL,
	[DateDeleted] [datetimeoffset](7) NULL,
	[IsDeleted] [bit] NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[PhoneNumber] [nvarchar](20) NULL,
	[LinkedInUrl] [nvarchar](200) NULL,
	[Role] [tinyint] NOT NULL,
	[Status] [tinyint] NULL,
	[AliasName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[UserCredentials]  WITH CHECK ADD  CONSTRAINT [FK_UserCredentials_Users] FOREIGN KEY([Id])
REFERENCES [dbo].[Users] ([Id])
GO

ALTER TABLE [dbo].[UserCredentials] CHECK CONSTRAINT [FK_UserCredentials_Users]
GO


