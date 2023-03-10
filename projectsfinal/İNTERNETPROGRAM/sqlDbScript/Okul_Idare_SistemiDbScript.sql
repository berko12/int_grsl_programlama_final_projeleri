USE [OkulIdareSistemi]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 12/4/2022 10:16:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Dersler]    Script Date: 12/4/2022 10:16:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dersler](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Ad] [nvarchar](max) NOT NULL,
	[Kredisi] [nvarchar](max) NOT NULL,
	[OkulYonetimId] [int] NOT NULL,
 CONSTRAINT [PK_Dersler] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OgrenciDersler]    Script Date: 12/4/2022 10:16:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OgrenciDersler](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DersId] [int] NOT NULL,
	[OgrenciId] [int] NOT NULL,
 CONSTRAINT [PK_OgrenciDersler] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ogrenciler]    Script Date: 12/4/2022 10:16:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ogrenciler](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AdSoyad] [nvarchar](max) NOT NULL,
	[KayitTarih] [datetime2](7) NOT NULL,
	[OgrenciNo] [nvarchar](max) NOT NULL,
	[DTarih] [datetime2](7) NOT NULL,
	[Bolum] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Ogrenciler] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OkulYonetimler]    Script Date: 12/4/2022 10:16:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OkulYonetimler](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AdSoyad] [nvarchar](max) NOT NULL,
	[Gorevi] [nvarchar](max) NOT NULL,
	[YonetimTip] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_OkulYonetimler] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Dersler]  WITH CHECK ADD  CONSTRAINT [FK_Dersler_OkulYonetimler_OkulYonetimId] FOREIGN KEY([OkulYonetimId])
REFERENCES [dbo].[OkulYonetimler] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Dersler] CHECK CONSTRAINT [FK_Dersler_OkulYonetimler_OkulYonetimId]
GO
ALTER TABLE [dbo].[OgrenciDersler]  WITH CHECK ADD  CONSTRAINT [FK_OgrenciDersler_Dersler_DersId] FOREIGN KEY([DersId])
REFERENCES [dbo].[Dersler] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OgrenciDersler] CHECK CONSTRAINT [FK_OgrenciDersler_Dersler_DersId]
GO
ALTER TABLE [dbo].[OgrenciDersler]  WITH CHECK ADD  CONSTRAINT [FK_OgrenciDersler_Ogrenciler_OgrenciId] FOREIGN KEY([OgrenciId])
REFERENCES [dbo].[Ogrenciler] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OgrenciDersler] CHECK CONSTRAINT [FK_OgrenciDersler_Ogrenciler_OgrenciId]
GO
