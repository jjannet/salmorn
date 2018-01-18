USE [SalmornDB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 26/12/2560 16:26:38 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[_Test]    Script Date: 26/12/2560 16:26:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[_Test](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[test] [text] NULL,
 CONSTRAINT [PK__Test] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[L_FileUpload]    Script Date: 26/12/2560 16:26:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[L_FileUpload](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[fileName] [nvarchar](max) NULL,
	[ipAddress] [nvarchar](20) NULL,
	[macAddress] [nvarchar](20) NULL,
	[type] [nvarchar](20) NULL,
	[uploadDate] [datetime2](7) NOT NULL,
	[userId] [int] NULL,
 CONSTRAINT [PK_L_FileUpload] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[M_PostType]    Script Date: 26/12/2560 16:26:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[M_PostType](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_M_PostType] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[M_Product]    Script Date: 26/12/2560 16:26:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[M_Product](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[code] [nvarchar](20) NULL,
	[cost] [decimal](18, 2) NULL,
	[createBy] [int] NULL,
	[createDate] [datetime] NULL,
	[detail] [nvarchar](max) NULL,
	[isActive] [bit] NOT NULL,
	[isPreOrder] [bit] NULL,
	[isUseStock] [bit] NOT NULL,
	[name] [nvarchar](250) NULL,
	[note] [nvarchar](max) NULL,
	[preEnd] [datetime2](7) NULL,
	[preStart] [datetime2](7) NULL,
	[price] [decimal](18, 2) NULL,
	[isShipping] [bit] NOT NULL,
	[qtyShippingPriceCeiling] [int] NOT NULL,
	[shippintPriceRate] [decimal](18, 2) NOT NULL,
	[unitName] [nvarchar](50) NULL,
	[updateBy] [int] NULL,
	[updateDate] [datetime] NULL,
	[weight] [decimal](18, 2) NULL,
	[isDelete] [bit] NOT NULL,
	[isManualPickup] [bit] NOT NULL,
	[pickupAt] [nvarchar](500) NULL,
	[stockQrty] [int] NULL,
 CONSTRAINT [PK_M_Product] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[M_Product_Image]    Script Date: 26/12/2560 16:26:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[M_Product_Image](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[fileId] [bigint] NOT NULL,
	[productId] [int] NOT NULL,
 CONSTRAINT [PK_M_Product_Image] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[S_Role]    Script Date: 26/12/2560 16:26:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[S_Role](
	[role] [nvarchar](5) NOT NULL,
	[roleName] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_S_Role] PRIMARY KEY CLUSTERED 
(
	[role] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[S_RoleMapping]    Script Date: 26/12/2560 16:26:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[S_RoleMapping](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[role] [nvarchar](5) NOT NULL,
	[userId] [int] NOT NULL,
 CONSTRAINT [PK_S_RoleMapping_1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[S_User]    Script Date: 26/12/2560 16:26:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[S_User](
	[userId] [int] IDENTITY(1,1) NOT NULL,
	[createBy] [int] NOT NULL,
	[createDate] [datetime] NOT NULL,
	[displayName] [nvarchar](255) NOT NULL,
	[email] [nvarchar](255) NOT NULL,
	[isActive] [bit] NOT NULL,
	[password] [nvarchar](255) NOT NULL,
	[updateBy] [int] NOT NULL,
	[updateDate] [datetime] NOT NULL,
 CONSTRAINT [PK_S_User] PRIMARY KEY CLUSTERED 
(
	[userId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_CustomerOneTime]    Script Date: 26/12/2560 16:26:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_CustomerOneTime](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[email] [nvarchar](250) NOT NULL,
	[tel] [nvarchar](50) NOT NULL,
	[firstName] [nvarchar](150) NOT NULL,
	[lastName] [nvarchar](150) NOT NULL,
	[address] [nvarchar](max) NOT NULL,
	[province] [nvarchar](250) NOT NULL,
	[zipCode] [nvarchar](5) NOT NULL,
 CONSTRAINT [PK_T_CustomerOneTime] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Order]    Script Date: 26/12/2560 16:26:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Order](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[code] [nvarchar](50) NULL,
	[paymentId] [int] NULL,
	[orderDate] [datetime2](7) NOT NULL,
	[productId] [int] NOT NULL,
	[qty] [int] NOT NULL,
	[unitPrice] [decimal](18, 2) NOT NULL,
	[totalPrice] [decimal](18, 2) NOT NULL,
	[totalProductPrice] [decimal](18, 2) NOT NULL,
	[isPay] [bit] NOT NULL,
	[payDate] [datetime2](7) NULL,
	[isShipping] [bit] NOT NULL,
	[shippingDateStart] [datetime] NULL,
	[shippingDateEnd] [datetime] NULL,
	[shippingDate] [datetime] NULL,
	[shippingPrice] [decimal](18, 2) NOT NULL,
	[tel] [nvarchar](50) NULL,
	[email] [nvarchar](250) NULL,
	[firstName] [nvarchar](150) NULL,
	[lastName] [nvarchar](150) NULL,
	[address] [nvarchar](max) NULL,
	[province] [nvarchar](250) NULL,
	[zipCode] [nvarchar](5) NULL,
	[isMeetReceive] [bit] NOT NULL,
	[isActive] [bit] NOT NULL,
	[isCreateShipping] [bit] NOT NULL,
	[isFinish] [bit] NOT NULL,
	[createBy] [int] NULL,
	[createDate] [datetime] NULL,
	[updateBy] [int] NULL,
	[updateDate] [datetime] NULL,
 CONSTRAINT [PK_T_Order_H] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Order_D]    Script Date: 26/12/2560 16:26:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Order_D](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[hId] [int] NOT NULL,
	[productId] [int] NOT NULL,
	[qty] [int] NOT NULL,
	[unitPrice] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_T_Order_D] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_PaymentNotification]    Script Date: 26/12/2560 16:26:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_PaymentNotification](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[fileId] [bigint] NOT NULL,
	[firstName] [nvarchar](150) NOT NULL,
	[lastName] [nvarchar](150) NOT NULL,
	[orderCode] [nvarchar](50) NOT NULL,
	[paymentDate] [datetime2](7) NOT NULL,
	[paymentType] [nvarchar](50) NOT NULL,
	[isActive] [bit] NOT NULL,
	[isMapping] [bit] NOT NULL,
	[money] [numeric](18, 2) NOT NULL,
 CONSTRAINT [PK_T_PaymentNotification] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Post]    Script Date: 26/12/2560 16:26:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Post](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](500) NOT NULL,
	[detail] [text] NOT NULL,
	[typeId] [int] NOT NULL,
	[isActive] [bit] NOT NULL,
	[author] [nvarchar](500) NOT NULL,
	[authorId] [int] NOT NULL,
	[targetDate] [datetime] NULL,
	[createDate] [datetime] NOT NULL,
	[updateDate] [datetime] NOT NULL,
	[updateBy] [int] NOT NULL,
 CONSTRAINT [PK_T_Post] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_ProductStocks]    Script Date: 26/12/2560 16:26:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_ProductStocks](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[date] [datetime2](7) NOT NULL,
	[productId] [int] NOT NULL,
	[qty] [int] NOT NULL,
 CONSTRAINT [PK_ProductStocks] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Shipping]    Script Date: 26/12/2560 16:26:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Shipping](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[trackingCode] [nvarchar](20) NULL,
	[orderId] [int] NOT NULL,
	[orderCode] [nvarchar](50) NOT NULL,
	[isActive] [bit] NOT NULL,
	[isShipping] [bit] NOT NULL,
	[shippingDate] [datetime] NULL,
	[email] [nvarchar](250) NOT NULL,
	[tel] [nvarchar](50) NOT NULL,
	[firstName] [nvarchar](150) NOT NULL,
	[lastName] [nvarchar](150) NOT NULL,
	[address] [nvarchar](max) NOT NULL,
	[province] [nvarchar](250) NOT NULL,
	[zipCode] [nvarchar](5) NOT NULL,
	[printCoverQty] [int] NULL,
	[createDate] [datetime] NULL,
	[createBy] [int] NULL,
	[updateDate] [datetime] NULL,
	[updateBy] [int] NULL,
 CONSTRAINT [PK_T_Shipping] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Shipping_D]    Script Date: 26/12/2560 16:26:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Shipping_D](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[hId] [int] NOT NULL,
	[orderId] [int] NOT NULL,
	[code] [nvarchar](50) NULL,
 CONSTRAINT [PK_T_Shipping_D] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Shipping_H]    Script Date: 26/12/2560 16:26:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Shipping_H](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[code] [nvarchar](20) NULL,
	[isActive] [bit] NOT NULL,
	[isShipping] [bit] NOT NULL,
	[shippingDate] [datetime] NULL,
	[createDate] [datetime] NULL,
	[createBy] [int] NULL,
	[updateDate] [datetime] NULL,
	[updateBy] [int] NULL,
 CONSTRAINT [PK_T_Shipping_H] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20171201195839_InitialCreate', N'2.0.0-rtm-26452')
SET IDENTITY_INSERT [dbo].[_Test] ON 

INSERT [dbo].[_Test] ([id], [test]) VALUES (1, N'ทดสอบ อิอิ กำ')
SET IDENTITY_INSERT [dbo].[_Test] OFF
SET IDENTITY_INSERT [dbo].[L_FileUpload] ON 

INSERT [dbo].[L_FileUpload] ([id], [fileName], [ipAddress], [macAddress], [type], [uploadDate], [userId]) VALUES (1, N'0K7YDOLKCJBLB1FHQ8D3RD4QQ7H1X8.jpg', N'::1', NULL, N'PDI', CAST(N'2017-12-02T03:46:58.9258825' AS DateTime2), NULL)
INSERT [dbo].[L_FileUpload] ([id], [fileName], [ipAddress], [macAddress], [type], [uploadDate], [userId]) VALUES (2, N'BIVIN3JPOFVPG32N7M9DG9O2YQVDQM.jpg', N'::1', NULL, N'PDI', CAST(N'2017-12-02T18:50:51.6485297' AS DateTime2), NULL)
INSERT [dbo].[L_FileUpload] ([id], [fileName], [ipAddress], [macAddress], [type], [uploadDate], [userId]) VALUES (3, N'6SN6Y5LVP1C2DM28478DMMVDCOKBFL.jpg', N'::1', NULL, N'PDI', CAST(N'2017-12-02T18:54:00.2420811' AS DateTime2), NULL)
INSERT [dbo].[L_FileUpload] ([id], [fileName], [ipAddress], [macAddress], [type], [uploadDate], [userId]) VALUES (4, N'XMGCWFCL166M2V6YJH7SL32EQT6J3J.jpg', N'::1', NULL, N'PDI', CAST(N'2017-12-02T18:57:58.7074746' AS DateTime2), NULL)
INSERT [dbo].[L_FileUpload] ([id], [fileName], [ipAddress], [macAddress], [type], [uploadDate], [userId]) VALUES (5, N'UJPDEZWAZW6SGCG9U9GNFDDWA3UBWD.mp4', N'::1', NULL, N'PDI', CAST(N'2017-12-02T18:58:00.9278072' AS DateTime2), NULL)
INSERT [dbo].[L_FileUpload] ([id], [fileName], [ipAddress], [macAddress], [type], [uploadDate], [userId]) VALUES (6, N'I2RRLW7YRHCISKW3XZ8Q96CPERF2DL.jpg', N'::1', NULL, N'PDI', CAST(N'2017-12-02T18:58:09.6827486' AS DateTime2), NULL)
INSERT [dbo].[L_FileUpload] ([id], [fileName], [ipAddress], [macAddress], [type], [uploadDate], [userId]) VALUES (7, N'0B7AP5SL6N3QJRHW2I4Z8G1OY8B9WR.jpg', N'::1', NULL, N'PDI', CAST(N'2017-12-02T21:30:17.4383847' AS DateTime2), NULL)
INSERT [dbo].[L_FileUpload] ([id], [fileName], [ipAddress], [macAddress], [type], [uploadDate], [userId]) VALUES (8, N'OKOKFFHWVRNC8JKN55ROOZ2NLTJTLQ.jpg', N'::1', NULL, N'PDI', CAST(N'2017-12-02T21:31:24.5690151' AS DateTime2), NULL)
INSERT [dbo].[L_FileUpload] ([id], [fileName], [ipAddress], [macAddress], [type], [uploadDate], [userId]) VALUES (9, N'TEST', N'123', N'ABC', N'PRD', CAST(N'2017-12-10T14:08:54.7822190' AS DateTime2), 1)
INSERT [dbo].[L_FileUpload] ([id], [fileName], [ipAddress], [macAddress], [type], [uploadDate], [userId]) VALUES (10, N'2S9QJS8UKYV98CE3DUIN5LA9LXO5YH.jpg', N'::1', NULL, N'PROD', CAST(N'2017-12-16T18:44:38.3111787' AS DateTime2), 1)
INSERT [dbo].[L_FileUpload] ([id], [fileName], [ipAddress], [macAddress], [type], [uploadDate], [userId]) VALUES (11, N'ZOU68QTDLFI87UZLF4TQCC5Q0ZBXC5.jpg', N'::1', NULL, N'PROD', CAST(N'2017-12-19T12:39:24.7853977' AS DateTime2), 1)
INSERT [dbo].[L_FileUpload] ([id], [fileName], [ipAddress], [macAddress], [type], [uploadDate], [userId]) VALUES (12, N'117B4URBRMGSKU7SJHKBG3FYWXSDFI.jpg', N'::1', NULL, N'PROD', CAST(N'2017-12-19T12:39:56.9739115' AS DateTime2), 1)
INSERT [dbo].[L_FileUpload] ([id], [fileName], [ipAddress], [macAddress], [type], [uploadDate], [userId]) VALUES (13, N'G0XZBBT6U3IEZ2713514TOUP5MKJ85.jpg', N'::1', NULL, N'PROD', CAST(N'2017-12-19T14:58:42.9829193' AS DateTime2), 1)
INSERT [dbo].[L_FileUpload] ([id], [fileName], [ipAddress], [macAddress], [type], [uploadDate], [userId]) VALUES (14, N'Z42P0Y0S3AZL7WMB4HORP1XB11FI4Z.jpg', N'::1', NULL, N'PROD', CAST(N'2017-12-19T14:58:48.5267578' AS DateTime2), 1)
INSERT [dbo].[L_FileUpload] ([id], [fileName], [ipAddress], [macAddress], [type], [uploadDate], [userId]) VALUES (15, N'0K7YDOLKCJBLB1FHQ8D3RD4QQ7H1X8.jpg', N'::1', NULL, N'PROD', CAST(N'2017-12-19T14:59:42.0371424' AS DateTime2), 1)
INSERT [dbo].[L_FileUpload] ([id], [fileName], [ipAddress], [macAddress], [type], [uploadDate], [userId]) VALUES (16, N'SSYEJONIS7ZUFEQE055TKGFAHXPQIF.jpg', N'::1', NULL, N'PROD', CAST(N'2017-12-19T14:59:49.4964639' AS DateTime2), 1)
INSERT [dbo].[L_FileUpload] ([id], [fileName], [ipAddress], [macAddress], [type], [uploadDate], [userId]) VALUES (17, N'HUXE0TW7S04IPFE780ALHL5DXMNX6W.jpg', N'::1', NULL, N'PROD', CAST(N'2017-12-19T15:02:02.7186500' AS DateTime2), 1)
INSERT [dbo].[L_FileUpload] ([id], [fileName], [ipAddress], [macAddress], [type], [uploadDate], [userId]) VALUES (18, N'969M0E6BO7R2MEZC196KYZQ785ZTQO.jpg', N'::1', NULL, N'PROD', CAST(N'2017-12-19T15:02:25.8283521' AS DateTime2), 1)
INSERT [dbo].[L_FileUpload] ([id], [fileName], [ipAddress], [macAddress], [type], [uploadDate], [userId]) VALUES (19, N'G9A617ICO9A7LC3O90NUUN0W7JQCO5.jpg', N'::1', NULL, N'PROD', CAST(N'2017-12-19T15:03:47.4542247' AS DateTime2), 1)
INSERT [dbo].[L_FileUpload] ([id], [fileName], [ipAddress], [macAddress], [type], [uploadDate], [userId]) VALUES (20, N'K32FKEG2MG8QC3ZBNL6SA3HZZ75M9B.jpg', N'::1', NULL, N'PROD', CAST(N'2017-12-19T15:26:53.4699877' AS DateTime2), 1)
INSERT [dbo].[L_FileUpload] ([id], [fileName], [ipAddress], [macAddress], [type], [uploadDate], [userId]) VALUES (21, N'BIVIN3JPOFVPG32N7M9DG9O2YQVDQM.jpg', N'::1', NULL, N'PROD', CAST(N'2017-12-19T15:27:16.9212612' AS DateTime2), 1)
INSERT [dbo].[L_FileUpload] ([id], [fileName], [ipAddress], [macAddress], [type], [uploadDate], [userId]) VALUES (22, N'J43LE043Q518616UXO6MASM54B42U6.jpg', N'::1', NULL, N'PROD', CAST(N'2017-12-19T15:30:39.9230011' AS DateTime2), 1)
INSERT [dbo].[L_FileUpload] ([id], [fileName], [ipAddress], [macAddress], [type], [uploadDate], [userId]) VALUES (23, N'HF8C51V4ZCSD5DLICW5D3HGEM0R7QC.jpg', N'::1', NULL, N'PROD', CAST(N'2017-12-19T15:32:03.2060488' AS DateTime2), 1)
INSERT [dbo].[L_FileUpload] ([id], [fileName], [ipAddress], [macAddress], [type], [uploadDate], [userId]) VALUES (24, N'5CJUYV945F82Z346WITW8H7RC994ZF.jpg', N'::1', NULL, N'PROD', CAST(N'2017-12-19T15:33:03.7787542' AS DateTime2), 1)
INSERT [dbo].[L_FileUpload] ([id], [fileName], [ipAddress], [macAddress], [type], [uploadDate], [userId]) VALUES (25, N'JYOWGQ4LP0II00EASNKQEJO4EYE2RY.jpg', N'::1', NULL, N'PROD', CAST(N'2017-12-19T15:33:47.7600969' AS DateTime2), 1)
INSERT [dbo].[L_FileUpload] ([id], [fileName], [ipAddress], [macAddress], [type], [uploadDate], [userId]) VALUES (26, N'WFF05KODXOCL33N0QGMBRWTJBAKTRS.jpg', N'::1', NULL, N'PROD', CAST(N'2017-12-19T15:35:48.7018422' AS DateTime2), 1)
INSERT [dbo].[L_FileUpload] ([id], [fileName], [ipAddress], [macAddress], [type], [uploadDate], [userId]) VALUES (27, N'LB31DCDA43WPZ6N2QUQNH8PQHAW5Z5.jpg', N'::1', NULL, N'PROD', CAST(N'2017-12-19T15:36:26.4203692' AS DateTime2), 1)
INSERT [dbo].[L_FileUpload] ([id], [fileName], [ipAddress], [macAddress], [type], [uploadDate], [userId]) VALUES (28, N'A4VECASBZLXQMTPB6X5IUZDEKMWNUD.jpg', N'::1', NULL, N'PROD', CAST(N'2017-12-19T15:38:07.2908130' AS DateTime2), 1)
INSERT [dbo].[L_FileUpload] ([id], [fileName], [ipAddress], [macAddress], [type], [uploadDate], [userId]) VALUES (29, N'QHL8214V3NKO5F01V5AFE89QLL0R40.jpg', N'::1', NULL, N'PROD', CAST(N'2017-12-19T15:38:59.4639173' AS DateTime2), 1)
INSERT [dbo].[L_FileUpload] ([id], [fileName], [ipAddress], [macAddress], [type], [uploadDate], [userId]) VALUES (30, N'NERW4PEN0XHK3S7G48NS00MO9RI4XR.jpg', N'::1', NULL, N'PROD', CAST(N'2017-12-19T15:46:17.0636860' AS DateTime2), 1)
INSERT [dbo].[L_FileUpload] ([id], [fileName], [ipAddress], [macAddress], [type], [uploadDate], [userId]) VALUES (31, N'AM1D9F6JKLWIFM73FQTFR2DL9X2CXM.jpg', N'::1', NULL, N'PROD', CAST(N'2017-12-19T15:46:52.9909628' AS DateTime2), 1)
INSERT [dbo].[L_FileUpload] ([id], [fileName], [ipAddress], [macAddress], [type], [uploadDate], [userId]) VALUES (32, N'GK0JW4T0T2KVXC5SVARFM1LSAIJPEM.jpg', N'::1', NULL, N'PROD', CAST(N'2017-12-19T15:48:02.2897366' AS DateTime2), 1)
INSERT [dbo].[L_FileUpload] ([id], [fileName], [ipAddress], [macAddress], [type], [uploadDate], [userId]) VALUES (33, N'N3W7EMS5ZCJP7056EBPQB1VRAP9HJO.jpg', N'::1', NULL, N'PROD', CAST(N'2017-12-19T15:49:48.5248816' AS DateTime2), 1)
INSERT [dbo].[L_FileUpload] ([id], [fileName], [ipAddress], [macAddress], [type], [uploadDate], [userId]) VALUES (34, N'XOQBSF81YP57I5ODO68GSVTM8A31J5.jpg', N'::1', NULL, N'PROD', CAST(N'2017-12-19T16:17:39.4454915' AS DateTime2), 1)
INSERT [dbo].[L_FileUpload] ([id], [fileName], [ipAddress], [macAddress], [type], [uploadDate], [userId]) VALUES (10011, N'KAYGZOOZIZK14JSQ9NNMMGZWMFONNH.jpg', N'::1', NULL, N'PROD', CAST(N'2017-12-20T13:58:57.8889473' AS DateTime2), 1)
INSERT [dbo].[L_FileUpload] ([id], [fileName], [ipAddress], [macAddress], [type], [uploadDate], [userId]) VALUES (10012, N'LIQESSHYI27UH3RS6WY65BYPCKI5F6.png', N'::1', NULL, N'PROD', CAST(N'2017-12-20T14:33:35.5542958' AS DateTime2), 1)
INSERT [dbo].[L_FileUpload] ([id], [fileName], [ipAddress], [macAddress], [type], [uploadDate], [userId]) VALUES (10013, N'4E5CFFDLZN0520YA0LP0K3K22KTBBH.jpg', N'::1', NULL, N'PROD', CAST(N'2017-12-20T14:34:27.4523433' AS DateTime2), 1)
INSERT [dbo].[L_FileUpload] ([id], [fileName], [ipAddress], [macAddress], [type], [uploadDate], [userId]) VALUES (10014, N'KLSL73ZEYMPV6LF9I80CU6QPWB3CK5.jpg', N'::1', NULL, N'PROD', CAST(N'2017-12-20T14:39:27.9365507' AS DateTime2), 1)
INSERT [dbo].[L_FileUpload] ([id], [fileName], [ipAddress], [macAddress], [type], [uploadDate], [userId]) VALUES (10015, N'VBJSCONQ34KWXDKZ68W2BVK8WN4DZ5.jpg', N'::1', NULL, N'PROD', CAST(N'2017-12-20T14:40:53.7835638' AS DateTime2), 1)
INSERT [dbo].[L_FileUpload] ([id], [fileName], [ipAddress], [macAddress], [type], [uploadDate], [userId]) VALUES (10016, N'AW430NLNI1W2E628INE6E4PR491L5Z.jpg', N'::1', NULL, N'PROD', CAST(N'2017-12-20T14:45:37.7629387' AS DateTime2), 1)
INSERT [dbo].[L_FileUpload] ([id], [fileName], [ipAddress], [macAddress], [type], [uploadDate], [userId]) VALUES (10017, N'UK074X24M7OT05GIQOGYER830FGM80.jpg', N'::1', NULL, N'PROD', CAST(N'2017-12-20T15:03:24.9669588' AS DateTime2), 1)
INSERT [dbo].[L_FileUpload] ([id], [fileName], [ipAddress], [macAddress], [type], [uploadDate], [userId]) VALUES (10018, N'W9STGLBHBEGOAHRVEULVSMEGUDL7HY.jpg', N'::1', NULL, N'PROD', CAST(N'2017-12-20T15:06:11.4522287' AS DateTime2), 1)
SET IDENTITY_INSERT [dbo].[L_FileUpload] OFF
SET IDENTITY_INSERT [dbo].[M_PostType] ON 

INSERT [dbo].[M_PostType] ([id], [name]) VALUES (1, N'Post')
INSERT [dbo].[M_PostType] ([id], [name]) VALUES (2, N'Activity')
SET IDENTITY_INSERT [dbo].[M_PostType] OFF
SET IDENTITY_INSERT [dbo].[M_Product] ON 

INSERT [dbo].[M_Product] ([id], [code], [cost], [createBy], [createDate], [detail], [isActive], [isPreOrder], [isUseStock], [name], [note], [preEnd], [preStart], [price], [isShipping], [qtyShippingPriceCeiling], [shippintPriceRate], [unitName], [updateBy], [updateDate], [weight], [isDelete], [isManualPickup], [pickupAt], [stockQrty]) VALUES (1, N'SALMORN1700001', CAST(0.00 AS Decimal(18, 2)), NULL, CAST(N'2017-12-02T03:24:54.807' AS DateTime), N'<p>fewfewf</p>', 1, 0, 0, N'fewfewf', N'<p><br></p>', NULL, NULL, CAST(0.00 AS Decimal(18, 2)), 0, 15, CAST(123.00 AS Decimal(18, 2)), N'ชิ้น', NULL, CAST(N'2017-12-02T03:24:54.807' AS DateTime), CAST(123.00 AS Decimal(18, 2)), 1, 0, NULL, NULL)
INSERT [dbo].[M_Product] ([id], [code], [cost], [createBy], [createDate], [detail], [isActive], [isPreOrder], [isUseStock], [name], [note], [preEnd], [preStart], [price], [isShipping], [qtyShippingPriceCeiling], [shippintPriceRate], [unitName], [updateBy], [updateDate], [weight], [isDelete], [isManualPickup], [pickupAt], [stockQrty]) VALUES (2, N'SALMORN1700002', CAST(0.00 AS Decimal(18, 2)), NULL, CAST(N'2017-12-02T03:26:54.117' AS DateTime), N'<p>fewfew</p>', 0, 0, 0, N'gfrger', N'<p><br></p>', NULL, NULL, CAST(0.00 AS Decimal(18, 2)), 0, 0, CAST(231.00 AS Decimal(18, 2)), N'ชิ้น', NULL, CAST(N'2017-12-02T03:26:54.117' AS DateTime), CAST(213.00 AS Decimal(18, 2)), 1, 0, NULL, NULL)
INSERT [dbo].[M_Product] ([id], [code], [cost], [createBy], [createDate], [detail], [isActive], [isPreOrder], [isUseStock], [name], [note], [preEnd], [preStart], [price], [isShipping], [qtyShippingPriceCeiling], [shippintPriceRate], [unitName], [updateBy], [updateDate], [weight], [isDelete], [isManualPickup], [pickupAt], [stockQrty]) VALUES (3, N'SALMORN1700003', CAST(0.00 AS Decimal(18, 2)), NULL, CAST(N'2017-12-02T03:28:52.257' AS DateTime), N'<p>fewf</p>', 1, 0, 0, N'fewfewf', N'<p><br></p>', NULL, NULL, CAST(0.00 AS Decimal(18, 2)), 0, 123, CAST(123.00 AS Decimal(18, 2)), N'ชิ้น', NULL, CAST(N'2017-12-02T03:28:52.257' AS DateTime), CAST(123.00 AS Decimal(18, 2)), 0, 0, NULL, NULL)
INSERT [dbo].[M_Product] ([id], [code], [cost], [createBy], [createDate], [detail], [isActive], [isPreOrder], [isUseStock], [name], [note], [preEnd], [preStart], [price], [isShipping], [qtyShippingPriceCeiling], [shippintPriceRate], [unitName], [updateBy], [updateDate], [weight], [isDelete], [isManualPickup], [pickupAt], [stockQrty]) VALUES (4, N'SALMORN1700004', CAST(0.00 AS Decimal(18, 2)), NULL, CAST(N'2017-12-02T03:29:56.027' AS DateTime), N'<p>gregre</p>', 0, 0, 0, N'gregre', N'<p><br></p>', NULL, NULL, CAST(0.00 AS Decimal(18, 2)), 0, 0, CAST(0.00 AS Decimal(18, 2)), N'ชิ้น', NULL, CAST(N'2017-12-02T03:29:56.027' AS DateTime), CAST(23.00 AS Decimal(18, 2)), 1, 0, NULL, NULL)
INSERT [dbo].[M_Product] ([id], [code], [cost], [createBy], [createDate], [detail], [isActive], [isPreOrder], [isUseStock], [name], [note], [preEnd], [preStart], [price], [isShipping], [qtyShippingPriceCeiling], [shippintPriceRate], [unitName], [updateBy], [updateDate], [weight], [isDelete], [isManualPickup], [pickupAt], [stockQrty]) VALUES (5, N'SALMORN1700005', CAST(0.00 AS Decimal(18, 2)), NULL, CAST(N'2017-12-02T03:31:22.943' AS DateTime), N'<p><b>gfewgre</b></p>', 1, 1, 1, N'fewfew', N'<p><br></p>', CAST(N'2017-12-27T20:00:00.0000000' AS DateTime2), CAST(N'2017-12-05T20:00:00.0000000' AS DateTime2), CAST(123456.00 AS Decimal(18, 2)), 0, 10, CAST(100.00 AS Decimal(18, 2)), N'ชิ้น', NULL, CAST(N'2017-12-02T03:31:22.943' AS DateTime), CAST(123.00 AS Decimal(18, 2)), 0, 0, NULL, NULL)
INSERT [dbo].[M_Product] ([id], [code], [cost], [createBy], [createDate], [detail], [isActive], [isPreOrder], [isUseStock], [name], [note], [preEnd], [preStart], [price], [isShipping], [qtyShippingPriceCeiling], [shippintPriceRate], [unitName], [updateBy], [updateDate], [weight], [isDelete], [isManualPickup], [pickupAt], [stockQrty]) VALUES (6, N'SL<25601220001', CAST(123.00 AS Decimal(18, 2)), NULL, CAST(N'2017-12-20T14:41:18.653' AS DateTime), N'<p>fewgwg</p>', 1, 1, 0, N'gregreg', N'<p><br></p>', NULL, CAST(N'2017-12-21T00:00:00.0000000' AS DateTime2), CAST(0.00 AS Decimal(18, 2)), 0, 0, CAST(0.00 AS Decimal(18, 2)), N'ชิ้น', NULL, CAST(N'2017-12-20T14:41:18.653' AS DateTime), CAST(100.00 AS Decimal(18, 2)), 1, 1, N'frerg', NULL)
INSERT [dbo].[M_Product] ([id], [code], [cost], [createBy], [createDate], [detail], [isActive], [isPreOrder], [isUseStock], [name], [note], [preEnd], [preStart], [price], [isShipping], [qtyShippingPriceCeiling], [shippintPriceRate], [unitName], [updateBy], [updateDate], [weight], [isDelete], [isManualPickup], [pickupAt], [stockQrty]) VALUES (7, N'SL<25601220002', CAST(123.00 AS Decimal(18, 2)), NULL, CAST(N'2017-12-21T14:50:55.273' AS DateTime), N'<p>fewgwg</p>', 1, 1, 0, N'gregreg', N'<p><br></p>', CAST(N'2017-12-23T00:00:00.0000000' AS DateTime2), CAST(N'2017-12-21T00:00:00.0000000' AS DateTime2), CAST(0.00 AS Decimal(18, 2)), 0, 0, CAST(0.00 AS Decimal(18, 2)), N'ชิ้น', NULL, CAST(N'2017-12-21T14:50:55.273' AS DateTime), CAST(100.00 AS Decimal(18, 2)), 0, 1, N'frerg', NULL)
INSERT [dbo].[M_Product] ([id], [code], [cost], [createBy], [createDate], [detail], [isActive], [isPreOrder], [isUseStock], [name], [note], [preEnd], [preStart], [price], [isShipping], [qtyShippingPriceCeiling], [shippintPriceRate], [unitName], [updateBy], [updateDate], [weight], [isDelete], [isManualPickup], [pickupAt], [stockQrty]) VALUES (8, N'SL<25601220003', CAST(0.00 AS Decimal(18, 2)), NULL, CAST(N'2017-12-20T14:45:50.587' AS DateTime), N'<p>3213213</p>', 1, 1, 0, N'fewfewf', N'<p><br></p>', NULL, CAST(N'2017-12-06T00:00:00.0000000' AS DateTime2), CAST(0.00 AS Decimal(18, 2)), 0, 0, CAST(0.00 AS Decimal(18, 2)), N'ชิ้น', NULL, CAST(N'2017-12-20T14:45:50.587' AS DateTime), CAST(123.00 AS Decimal(18, 2)), 0, 1, N'213', NULL)
INSERT [dbo].[M_Product] ([id], [code], [cost], [createBy], [createDate], [detail], [isActive], [isPreOrder], [isUseStock], [name], [note], [preEnd], [preStart], [price], [isShipping], [qtyShippingPriceCeiling], [shippintPriceRate], [unitName], [updateBy], [updateDate], [weight], [isDelete], [isManualPickup], [pickupAt], [stockQrty]) VALUES (9, N'SL<25601220003', CAST(0.00 AS Decimal(18, 2)), NULL, CAST(N'2017-12-20T14:45:50.590' AS DateTime), N'<p>3213213</p>', 1, 1, 0, N'fewfewf', N'<p><br></p>', NULL, CAST(N'2017-12-06T00:00:00.0000000' AS DateTime2), CAST(0.00 AS Decimal(18, 2)), 0, 0, CAST(0.00 AS Decimal(18, 2)), N'ชิ้น', NULL, CAST(N'2017-12-20T14:45:50.590' AS DateTime), CAST(123.00 AS Decimal(18, 2)), 1, 1, N'213', NULL)
INSERT [dbo].[M_Product] ([id], [code], [cost], [createBy], [createDate], [detail], [isActive], [isPreOrder], [isUseStock], [name], [note], [preEnd], [preStart], [price], [isShipping], [qtyShippingPriceCeiling], [shippintPriceRate], [unitName], [updateBy], [updateDate], [weight], [isDelete], [isManualPickup], [pickupAt], [stockQrty]) VALUES (10, N'SL<25601220005', CAST(0.00 AS Decimal(18, 2)), NULL, CAST(N'2017-12-20T15:03:36.573' AS DateTime), N'<p>gregre</p>', 1, 1, 0, N'ghtrh', N'<p><br></p>', NULL, CAST(N'2017-12-21T00:00:00.0000000' AS DateTime2), CAST(0.00 AS Decimal(18, 2)), 0, 0, CAST(0.00 AS Decimal(18, 2)), N'ชิ้น', NULL, CAST(N'2017-12-20T15:03:36.573' AS DateTime), CAST(156.00 AS Decimal(18, 2)), 0, 1, N'gregre', NULL)
INSERT [dbo].[M_Product] ([id], [code], [cost], [createBy], [createDate], [detail], [isActive], [isPreOrder], [isUseStock], [name], [note], [preEnd], [preStart], [price], [isShipping], [qtyShippingPriceCeiling], [shippintPriceRate], [unitName], [updateBy], [updateDate], [weight], [isDelete], [isManualPickup], [pickupAt], [stockQrty]) VALUES (11, N'SL<25601220005', CAST(0.00 AS Decimal(18, 2)), NULL, CAST(N'2017-12-20T16:29:54.140' AS DateTime), N'<p>gregre</p>', 1, 1, 0, N'ghtrh', N'<p><br></p>', CAST(N'2017-12-22T00:00:00.0000000' AS DateTime2), CAST(N'2017-12-15T00:00:00.0000000' AS DateTime2), CAST(0.00 AS Decimal(18, 2)), 0, 0, CAST(0.00 AS Decimal(18, 2)), N'ชิ้น', NULL, CAST(N'2017-12-20T16:29:54.140' AS DateTime), CAST(156.00 AS Decimal(18, 2)), 0, 1, N'gregre', NULL)
INSERT [dbo].[M_Product] ([id], [code], [cost], [createBy], [createDate], [detail], [isActive], [isPreOrder], [isUseStock], [name], [note], [preEnd], [preStart], [price], [isShipping], [qtyShippingPriceCeiling], [shippintPriceRate], [unitName], [updateBy], [updateDate], [weight], [isDelete], [isManualPickup], [pickupAt], [stockQrty]) VALUES (12, N'SL<25601220007', CAST(0.00 AS Decimal(18, 2)), NULL, CAST(N'2017-12-20T15:05:56.730' AS DateTime), N'<p>gregre</p>', 1, 1, 0, N'ghtrh', N'<p><br></p>', NULL, CAST(N'2017-12-21T00:00:00.0000000' AS DateTime2), CAST(0.00 AS Decimal(18, 2)), 0, 0, CAST(0.00 AS Decimal(18, 2)), N'ชิ้น', NULL, CAST(N'2017-12-20T15:05:56.730' AS DateTime), CAST(156.00 AS Decimal(18, 2)), 0, 1, N'gregre', NULL)
INSERT [dbo].[M_Product] ([id], [code], [cost], [createBy], [createDate], [detail], [isActive], [isPreOrder], [isUseStock], [name], [note], [preEnd], [preStart], [price], [isShipping], [qtyShippingPriceCeiling], [shippintPriceRate], [unitName], [updateBy], [updateDate], [weight], [isDelete], [isManualPickup], [pickupAt], [stockQrty]) VALUES (13, N'SL<25601220007', CAST(0.00 AS Decimal(18, 2)), NULL, CAST(N'2017-12-20T15:05:56.730' AS DateTime), N'<p>gregre</p>', 1, 1, 0, N'ghtrh', N'<p><br></p>', NULL, CAST(N'2017-12-21T00:00:00.0000000' AS DateTime2), CAST(0.00 AS Decimal(18, 2)), 0, 0, CAST(0.00 AS Decimal(18, 2)), N'ชิ้น', NULL, CAST(N'2017-12-20T15:05:56.730' AS DateTime), CAST(156.00 AS Decimal(18, 2)), 0, 1, N'gregre', NULL)
INSERT [dbo].[M_Product] ([id], [code], [cost], [createBy], [createDate], [detail], [isActive], [isPreOrder], [isUseStock], [name], [note], [preEnd], [preStart], [price], [isShipping], [qtyShippingPriceCeiling], [shippintPriceRate], [unitName], [updateBy], [updateDate], [weight], [isDelete], [isManualPickup], [pickupAt], [stockQrty]) VALUES (14, N'SL<25601220009', CAST(0.00 AS Decimal(18, 2)), NULL, CAST(N'2017-12-20T15:06:19.983' AS DateTime), N'<p>gregreg</p>', 1, 1, 0, N'bfngm', N'<p><br></p>', NULL, CAST(N'2017-12-29T00:00:00.0000000' AS DateTime2), CAST(0.00 AS Decimal(18, 2)), 0, 0, CAST(0.00 AS Decimal(18, 2)), N'ชิ้น', NULL, CAST(N'2017-12-20T15:06:19.983' AS DateTime), CAST(100.00 AS Decimal(18, 2)), 1, 1, N'Trset', NULL)
SET IDENTITY_INSERT [dbo].[M_Product] OFF
SET IDENTITY_INSERT [dbo].[M_Product_Image] ON 

INSERT [dbo].[M_Product_Image] ([id], [fileId], [productId]) VALUES (1, 10015, 6)
INSERT [dbo].[M_Product_Image] ([id], [fileId], [productId]) VALUES (2, 10015, 7)
INSERT [dbo].[M_Product_Image] ([id], [fileId], [productId]) VALUES (3, 10016, 8)
INSERT [dbo].[M_Product_Image] ([id], [fileId], [productId]) VALUES (4, 10016, 9)
INSERT [dbo].[M_Product_Image] ([id], [fileId], [productId]) VALUES (5, 10017, 10)
INSERT [dbo].[M_Product_Image] ([id], [fileId], [productId]) VALUES (6, 10017, 11)
INSERT [dbo].[M_Product_Image] ([id], [fileId], [productId]) VALUES (7, 10017, 13)
INSERT [dbo].[M_Product_Image] ([id], [fileId], [productId]) VALUES (8, 10017, 12)
INSERT [dbo].[M_Product_Image] ([id], [fileId], [productId]) VALUES (9, 10018, 14)
SET IDENTITY_INSERT [dbo].[M_Product_Image] OFF
INSERT [dbo].[S_Role] ([role], [roleName]) VALUES (N'ADMIN', N'Administrator')
INSERT [dbo].[S_Role] ([role], [roleName]) VALUES (N'SLM', N'Salmorn')
SET IDENTITY_INSERT [dbo].[S_RoleMapping] ON 

INSERT [dbo].[S_RoleMapping] ([id], [role], [userId]) VALUES (1, N'ADMIN', 1)
INSERT [dbo].[S_RoleMapping] ([id], [role], [userId]) VALUES (2, N'SLM', 1)
SET IDENTITY_INSERT [dbo].[S_RoleMapping] OFF
SET IDENTITY_INSERT [dbo].[S_User] ON 

INSERT [dbo].[S_User] ([userId], [createBy], [createDate], [displayName], [email], [isActive], [password], [updateBy], [updateDate]) VALUES (1, 1, CAST(N'2560-12-10T00:00:00.000' AS DateTime), N'JJannet', N'jirawat.jannet@gmail.com', 1, N'72ab994fa2eb426c051ef59cad617750bfe06d7cf6311285ff79c19c32afd236', 1, CAST(N'2560-12-10T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[S_User] OFF
SET IDENTITY_INSERT [dbo].[T_Order] ON 

INSERT [dbo].[T_Order] ([id], [code], [paymentId], [orderDate], [productId], [qty], [unitPrice], [totalPrice], [totalProductPrice], [isPay], [payDate], [isShipping], [shippingDateStart], [shippingDateEnd], [shippingDate], [shippingPrice], [tel], [email], [firstName], [lastName], [address], [province], [zipCode], [isMeetReceive], [isActive], [isCreateShipping], [isFinish], [createBy], [createDate], [updateBy], [updateDate]) VALUES (1, N'SALMORN201708120001', NULL, CAST(N'2560-08-12T00:00:00.0000000' AS DateTime2), 1, 5, CAST(200.00 AS Decimal(18, 2)), CAST(1000.00 AS Decimal(18, 2)), CAST(1000.00 AS Decimal(18, 2)), 1, CAST(N'2017-12-24T14:25:00.0000000' AS DateTime2), 1, NULL, NULL, NULL, CAST(100.00 AS Decimal(18, 2)), N'092-5699900', N'jirawat.jannet@gmail.com', N'Jirawat', N'Jannet', N'71/1 ถ.โนนตาล ต.ในเมือง อ.เมือง จ.ยโสธร 35000', N'ยโสธร', N'35000', 1, 1, 0, 1, 0, CAST(N'2560-08-12T00:00:00.000' AS DateTime), 0, CAST(N'2560-08-12T00:00:00.000' AS DateTime))
INSERT [dbo].[T_Order] ([id], [code], [paymentId], [orderDate], [productId], [qty], [unitPrice], [totalPrice], [totalProductPrice], [isPay], [payDate], [isShipping], [shippingDateStart], [shippingDateEnd], [shippingDate], [shippingPrice], [tel], [email], [firstName], [lastName], [address], [province], [zipCode], [isMeetReceive], [isActive], [isCreateShipping], [isFinish], [createBy], [createDate], [updateBy], [updateDate]) VALUES (2, N'O20171210001', NULL, CAST(N'2017-12-10T14:13:02.4694816' AS DateTime2), 2, 10, CAST(350.00 AS Decimal(18, 2)), CAST(35000.00 AS Decimal(18, 2)), CAST(900.00 AS Decimal(18, 2)), 1, CAST(N'2017-12-20T00:00:00.0000000' AS DateTime2), 1, NULL, NULL, NULL, CAST(100.00 AS Decimal(18, 2)), N'0925699900', N'jj@gmail', N'jirawat', N'jannet', N'AAA', N'Yasothon', N'35000', 1, 1, 0, 1, 1, CAST(N'2017-12-10T14:13:11.087' AS DateTime), 1, CAST(N'2017-12-10T14:13:11.087' AS DateTime))
SET IDENTITY_INSERT [dbo].[T_Order] OFF
SET IDENTITY_INSERT [dbo].[T_Order_D] ON 

INSERT [dbo].[T_Order_D] ([id], [hId], [productId], [qty], [unitPrice]) VALUES (1, 2, 1, 2, CAST(100.00 AS Decimal(18, 2)))
INSERT [dbo].[T_Order_D] ([id], [hId], [productId], [qty], [unitPrice]) VALUES (2, 2, 2, 2, CAST(100.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[T_Order_D] OFF
SET IDENTITY_INSERT [dbo].[T_PaymentNotification] ON 

INSERT [dbo].[T_PaymentNotification] ([id], [fileId], [firstName], [lastName], [orderCode], [paymentDate], [paymentType], [isActive], [isMapping], [money]) VALUES (2, 1, N'Jirawat', N'Jannet', N'SALMORN201708120001', CAST(N'2017-12-24T14:25:00.0000000' AS DateTime2), N'Transfer', 1, 0, CAST(1000.00 AS Numeric(18, 2)))
INSERT [dbo].[T_PaymentNotification] ([id], [fileId], [firstName], [lastName], [orderCode], [paymentDate], [paymentType], [isActive], [isMapping], [money]) VALUES (3, 2, N'Jirawat', N'Jannet', N'O20171210001', CAST(N'2017-12-20T00:00:00.0000000' AS DateTime2), N'Transfer', 1, 0, CAST(2000.00 AS Numeric(18, 2)))
SET IDENTITY_INSERT [dbo].[T_PaymentNotification] OFF
SET IDENTITY_INSERT [dbo].[T_Post] ON 

INSERT [dbo].[T_Post] ([id], [title], [detail], [typeId], [isActive], [author], [authorId], [targetDate], [createDate], [updateDate], [updateBy]) VALUES (2, N'ควันหลงงานวันออดิชั่น รายการท่องเที่ยวญี่ปุ่น ครั้งที่ 2', N'เกริ่นนำ ก่อนถึงงานวันออดิชั่น ครั้งที่ 2...
โปรเจคงานออดิชั่นเพื่อไปทำหน้าที่ MC และ ขับร้อง ผ่านรายการท่องเที่ยว ที่ประเทศญี่ปุ่น เป็นโปรเจคเซอร์ไพรส์ที่จ๊อบซังประกาศขึ้นกลางงาน JAPAN EXPO IN THAILAND 2017 ในวันอาทิตย์ที่ 3 กันยายน 2560 (ช่วงเย็นๆ) ถือเป็นการเซอร์ไพรส์ทั้งแฟนคลับ และสมาชิกทั้ง 30 คน
รูปแบบรายการ จะมีเค้าโครงคล้ายกับรายการ “คิวชู เดอะ ซีรส์” ที่มี “SANQ BAND” (เอ๊ะ ละอองฟอง และ แดน วรเวช) เคยทำมาก่อน
คณะกรรมการต้องการจะคัดเลือกคนที่มีความสามารถในด้าน MC และ ร้องเพลง ให้ทำหน้าที่เป็นหลัก และต้องการคนที่มีความตั้งใจจริง จึงเปิดโอกาสให้สมาชิกที่อยากจะเข้าร่วม สมัครเข้าร่วมได้ผ่านการออดิชั่น (จะร่วมหรือไม่ก็ได้)
รูปแบบรายการจะใช้เวลาถ่ายทำหลายสิบวัน
และจะมีกำหนดการออดิชั่น ในวันจันทร์ที่ 4 กันยายน 2560 เวลา 17.00 น. !
พลันที่จ๊อบซังประกาศกำหนดการออดิชั่นเช่นนี้ ก็มีเสียงฮือฮาทั้งจากแฟนๆ และสมาชิก BN 48 เอง เนื่องด้วยระยะเวลาที่ระบุมาเช่นนี้ นั่นหมายความว่า ทุกคนจะมีเวลาเตรียมตัวไม่ถึง 10 ชม. เท่านั้น (ไม่นับเวลานอน) ทั้งยังเป็นโปรเจคที่เหล่าสมาชิกเพิ่งจะผ่านการแสดง และจับมือกลุ่มจากงาน JAPAN EXPO มาหยกๆ มันจึงเป็นการออดิชั่นที่ท้าทายความสามารถมากๆ
คืนนั้นเอง ทางเพจ OFFICIAL ได้ประกาศรายชื่อสมาชิกที่สมัครเข้าร่วมโปรเจคออกมาทั้งหมด 19 คน ซึ่งต่อมาได้สละสิทธิ์ไป 4 คน จึงเหลือสมาชิกที่จะเข้าร่วมออดิชั่นทั้งหมด 15 คน ได้แก่ น้ำหอม ตาหวาน เจนนิษฐ์ แจน เคท นิ้ง น้ำหนึ่ง แก้ว แคนแคน อร น้ำใส โมบายล์ ปัญ ซัทจัง ไข่มุก
และเป็นอย่างที่ทุกคนทราบ...
หลังผ่านงานออดิชั่นที่สมาชิกทั้ง 15 คน ออกมาร้องเพลง “เพื่อนร่วมทาง” สั้นๆ แค่ประมาณ 3-4 ประโยค (15-20 วินาที) กับพูดแนะนำประเทศญี่ปุ่นกับเพื่อนสมาชิกอีกคนหนึ่งประมาณ 1 นาที', 1, 1, N'JJannet', 1, NULL, CAST(N'2017-12-21T00:00:00.000' AS DateTime), CAST(N'2017-12-21T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[T_Post] ([id], [title], [detail], [typeId], [isActive], [author], [authorId], [targetDate], [createDate], [updateDate], [updateBy]) VALUES (3, N'44848fefe', N'<p>fewfe</p>', 2, 1, N'JJannet', 1, NULL, CAST(N'2017-12-23T23:38:24.550' AS DateTime), CAST(N'2017-12-23T23:45:17.850' AS DateTime), 1)
INSERT [dbo].[T_Post] ([id], [title], [detail], [typeId], [isActive], [author], [authorId], [targetDate], [createDate], [updateDate], [updateBy]) VALUES (4, N'gregre', N'<p>gregreg</p>', 1, 1, N'JJannet', 1, NULL, CAST(N'2017-12-23T23:39:28.153' AS DateTime), CAST(N'2017-12-23T23:39:28.153' AS DateTime), 1)
INSERT [dbo].[T_Post] ([id], [title], [detail], [typeId], [isActive], [author], [authorId], [targetDate], [createDate], [updateDate], [updateBy]) VALUES (5, N'fewfew', N'<p>fewfewf</p>', 1, 1, N'JJannet', 1, NULL, CAST(N'2017-12-23T23:39:47.323' AS DateTime), CAST(N'2017-12-23T23:39:47.323' AS DateTime), 1)
INSERT [dbo].[T_Post] ([id], [title], [detail], [typeId], [isActive], [author], [authorId], [targetDate], [createDate], [updateDate], [updateBy]) VALUES (6, N'fewfwe', N'<p>fewfewff</p>', 1, 1, N'JJannet', 1, NULL, CAST(N'2017-12-23T23:40:01.710' AS DateTime), CAST(N'2017-12-23T23:40:01.710' AS DateTime), 1)
INSERT [dbo].[T_Post] ([id], [title], [detail], [typeId], [isActive], [author], [authorId], [targetDate], [createDate], [updateDate], [updateBy]) VALUES (7, N'Test post 23', N'<p style="text-align: center;"><b>Test post</b></p><p style="text-align: center;"><b><br></b></p><p style="text-align: left;"><b>ทดสอบการ Post</b></p><p style="text-align: left;"><b><br></b></p><p style="text-align: left;">อิอิ กำ</p>', 1, 1, N'JJannet', 1, NULL, CAST(N'2017-12-23T23:40:37.143' AS DateTime), CAST(N'2017-12-26T00:33:31.690' AS DateTime), 1)
INSERT [dbo].[T_Post] ([id], [title], [detail], [typeId], [isActive], [author], [authorId], [targetDate], [createDate], [updateDate], [updateBy]) VALUES (8, N'Tes', N'<p>Test</p>', 1, 1, N'JJannet', 1, NULL, CAST(N'2017-12-23T23:41:40.073' AS DateTime), CAST(N'2017-12-23T23:41:40.073' AS DateTime), 1)
INSERT [dbo].[T_Post] ([id], [title], [detail], [typeId], [isActive], [author], [authorId], [targetDate], [createDate], [updateDate], [updateBy]) VALUES (9, N'fewfewf', N'<p>ewfewfewf</p>', 1, 1, N'JJannet', 1, NULL, CAST(N'2017-12-23T23:42:00.210' AS DateTime), CAST(N'2017-12-23T23:42:00.210' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[T_Post] OFF
SET IDENTITY_INSERT [dbo].[T_ProductStocks] ON 

INSERT [dbo].[T_ProductStocks] ([id], [date], [productId], [qty]) VALUES (1, CAST(N'2017-12-02T03:44:10.2959617' AS DateTime2), 5, 123)
SET IDENTITY_INSERT [dbo].[T_ProductStocks] OFF
SET IDENTITY_INSERT [dbo].[T_Shipping] ON 

INSERT [dbo].[T_Shipping] ([id], [trackingCode], [orderId], [orderCode], [isActive], [isShipping], [shippingDate], [email], [tel], [firstName], [lastName], [address], [province], [zipCode], [printCoverQty], [createDate], [createBy], [updateDate], [updateBy]) VALUES (1, NULL, 1, N'SALMORN201708120001', 1, 0, NULL, N'jirawat.jannet@gmal.com', N'0925699900', N'Jirawat', N'Jannet', N'71/1 ถ.โนนตาล ต.ในเมือง อ.เมือง', N'ยโสธร', N'35000', 0, NULL, 1, NULL, 1)
INSERT [dbo].[T_Shipping] ([id], [trackingCode], [orderId], [orderCode], [isActive], [isShipping], [shippingDate], [email], [tel], [firstName], [lastName], [address], [province], [zipCode], [printCoverQty], [createDate], [createBy], [updateDate], [updateBy]) VALUES (2, NULL, 2, N'O20171210001', 1, 0, NULL, N'jirawat.jannet@gmal.com', N'0925699900', N'Jirawat', N'Jannet', N'71/1 ถ.โนนตาล ต.ในเมือง อ.เมือง', N'อุบลราชธานี', N'15000', 0, NULL, 1, NULL, 1)
SET IDENTITY_INSERT [dbo].[T_Shipping] OFF
SET IDENTITY_INSERT [dbo].[T_Shipping_D] ON 

INSERT [dbo].[T_Shipping_D] ([id], [hId], [orderId], [code]) VALUES (1, 1, 1, NULL)
SET IDENTITY_INSERT [dbo].[T_Shipping_D] OFF
SET IDENTITY_INSERT [dbo].[T_Shipping_H] ON 

INSERT [dbo].[T_Shipping_H] ([id], [code], [isActive], [isShipping], [shippingDate], [createDate], [createBy], [updateDate], [updateBy]) VALUES (1, N'TEST0001', 1, 0, NULL, NULL, 1, NULL, 1)
SET IDENTITY_INSERT [dbo].[T_Shipping_H] OFF
ALTER TABLE [dbo].[M_Product] ADD  CONSTRAINT [DF_M_Product_isShipping]  DEFAULT ((0)) FOR [isShipping]
GO
ALTER TABLE [dbo].[M_Product] ADD  CONSTRAINT [DF_M_Product_isManualPickup]  DEFAULT ((0)) FOR [isManualPickup]
GO
ALTER TABLE [dbo].[M_Product_Image]  WITH CHECK ADD  CONSTRAINT [FK_M_Product_Image_L_FileUpload] FOREIGN KEY([fileId])
REFERENCES [dbo].[L_FileUpload] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[M_Product_Image] CHECK CONSTRAINT [FK_M_Product_Image_L_FileUpload]
GO
ALTER TABLE [dbo].[M_Product_Image]  WITH CHECK ADD  CONSTRAINT [FK_M_Product_Image_M_Product] FOREIGN KEY([productId])
REFERENCES [dbo].[M_Product] ([id])
GO
ALTER TABLE [dbo].[M_Product_Image] CHECK CONSTRAINT [FK_M_Product_Image_M_Product]
GO
ALTER TABLE [dbo].[S_RoleMapping]  WITH CHECK ADD  CONSTRAINT [FK_S_RoleMapping_S_RoleMapping] FOREIGN KEY([role])
REFERENCES [dbo].[S_Role] ([role])
GO
ALTER TABLE [dbo].[S_RoleMapping] CHECK CONSTRAINT [FK_S_RoleMapping_S_RoleMapping]
GO
ALTER TABLE [dbo].[S_RoleMapping]  WITH CHECK ADD  CONSTRAINT [FK_S_RoleMapping_S_User] FOREIGN KEY([userId])
REFERENCES [dbo].[S_User] ([userId])
GO
ALTER TABLE [dbo].[S_RoleMapping] CHECK CONSTRAINT [FK_S_RoleMapping_S_User]
GO
ALTER TABLE [dbo].[T_Order]  WITH CHECK ADD  CONSTRAINT [FK_T_Order_M_Product] FOREIGN KEY([productId])
REFERENCES [dbo].[M_Product] ([id])
GO
ALTER TABLE [dbo].[T_Order] CHECK CONSTRAINT [FK_T_Order_M_Product]
GO
ALTER TABLE [dbo].[T_Order_D]  WITH CHECK ADD  CONSTRAINT [FK_T_Order_D_M_Product] FOREIGN KEY([productId])
REFERENCES [dbo].[M_Product] ([id])
GO
ALTER TABLE [dbo].[T_Order_D] CHECK CONSTRAINT [FK_T_Order_D_M_Product]
GO
ALTER TABLE [dbo].[T_PaymentNotification]  WITH CHECK ADD  CONSTRAINT [FK_T_PaymentNotification_L_FileUpload] FOREIGN KEY([fileId])
REFERENCES [dbo].[L_FileUpload] ([id])
GO
ALTER TABLE [dbo].[T_PaymentNotification] CHECK CONSTRAINT [FK_T_PaymentNotification_L_FileUpload]
GO
ALTER TABLE [dbo].[T_Post]  WITH CHECK ADD  CONSTRAINT [FK_T_Post_M_PostType] FOREIGN KEY([typeId])
REFERENCES [dbo].[M_PostType] ([id])
GO
ALTER TABLE [dbo].[T_Post] CHECK CONSTRAINT [FK_T_Post_M_PostType]
GO
ALTER TABLE [dbo].[T_ProductStocks]  WITH CHECK ADD  CONSTRAINT [FK_T_ProductStocks_M_Product] FOREIGN KEY([productId])
REFERENCES [dbo].[M_Product] ([id])
GO
ALTER TABLE [dbo].[T_ProductStocks] CHECK CONSTRAINT [FK_T_ProductStocks_M_Product]
GO
ALTER TABLE [dbo].[T_Shipping]  WITH CHECK ADD  CONSTRAINT [FK_T_Shipping_T_Order] FOREIGN KEY([orderId])
REFERENCES [dbo].[T_Order] ([id])
GO
ALTER TABLE [dbo].[T_Shipping] CHECK CONSTRAINT [FK_T_Shipping_T_Order]
GO
ALTER TABLE [dbo].[T_Shipping_D]  WITH CHECK ADD  CONSTRAINT [FK_T_Shipping_D_T_Shipping_H] FOREIGN KEY([hId])
REFERENCES [dbo].[T_Shipping_H] ([id])
GO
ALTER TABLE [dbo].[T_Shipping_D] CHECK CONSTRAINT [FK_T_Shipping_D_T_Shipping_H]
GO
/****** Object:  StoredProcedure [dbo].[sp_m_product_add]    Script Date: 26/12/2560 16:26:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jirawat Jannet
-- Create date: 02-12-2017
-- =============================================

 CREATE PROCEDURE [dbo].[sp_m_product_add]  
	@id int 
	,@code nvarchar(10) 
	,@cost decimal(18,2) 
	,@detail nvarchar(max) 
	,@isActive bit 
	,@isPreOrder bit 
	,@isUseStock bit 
	,@name nvarchar(250) 
	,@note nvarchar(max) 
	,@preEnd datetime2(7) 
	,@preStart datetime2(7) 
	,@price decimal(18,2) 
	,@qtyShippingPriceCeiling int 
	,@shippintPriceRate decimal(18,2) 
	,@unitName nvarchar(50) 
	,@weight decimal(18,2) 
	,@createBy int 

 AS  
 BEGIN  

 	INSERT INTO M_Product (  
 		code
 		, cost
 		, createBy
 		, createDate
 		, detail
 		, isActive
 		, isPreOrder
 		, isUseStock
 		, name
 		, note
 		, preEnd
 		, preStart
 		, price
 		, qtyShippingPriceCeiling
 		, shippintPriceRate
 		, unitName
 		, updateBy
 		, updateDate
 		, weight
 	) VALUES (  
 		@code
 		, @cost
 		, @createBy
 		, getdate()
 		, @detail
 		, @isActive
 		, @isPreOrder
 		, @isUseStock
 		, @name
 		, @note
 		, @preEnd
 		, @preStart
 		, @price
 		, @qtyShippingPriceCeiling
 		, @shippintPriceRate
 		, @unitName
 		, @createBy
 		, getdate()
 		, @weight
 	)   

 END  
GO
/****** Object:  StoredProcedure [dbo].[sp_m_product_edit]    Script Date: 26/12/2560 16:26:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jirawat Jannet
-- Create date: 02-12-2017
-- =============================================

 CREATE PROCEDURE [dbo].[sp_m_product_edit]
 	@id int 
	,@cost decimal(18,2) 
	,@detail nvarchar(max) 
	,@isActive bit 
	,@isPreOrder bit 
	,@isUseStock bit 
	,@name nvarchar(250) 
	,@note nvarchar(max) 
	,@preEnd datetime2(7) 
	,@preStart datetime2(7) 
	,@price decimal(18,2) 
	,@qtyShippingPriceCeiling int 
	,@shippintPriceRate decimal(18,2) 
	,@unitName nvarchar(50) 
	,@weight decimal(18,2) 
	,@updateBy int
 AS  
 BEGIN  

 	UPDATE M_Product   
 	SET 
 		cost=@cost
 		, detail=@detail
 		, isActive=@isActive
 		, isPreOrder=@isPreOrder
 		, isUseStock=@isUseStock
 		, name=@name
 		, note=@note
 		, preEnd=@preEnd
 		, preStart=@preStart
 		, price=@price
 		, qtyShippingPriceCeiling=@qtyShippingPriceCeiling
 		, shippintPriceRate=@shippintPriceRate
 		, unitName=@unitName
 		, updateBy=@updateBy
 		, updateDate=getdate()
 		, weight=@weight
 	WHERE id=@id  

 END  
GO
/****** Object:  StoredProcedure [dbo].[sp_test]    Script Date: 26/12/2560 16:26:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_test]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	select * from M_Product

END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'นัดรับสินค้าด้วยตัวเอง' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'M_Product', @level2type=N'COLUMN',@level2name=N'isManualPickup'
GO
