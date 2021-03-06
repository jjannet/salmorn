USE [SalmornDB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 22-Jan-18 1:11:56 AM ******/
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
/****** Object:  Table [dbo].[_Test]    Script Date: 22-Jan-18 1:11:56 AM ******/
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
/****** Object:  Table [dbo].[L_FileUpload]    Script Date: 22-Jan-18 1:11:56 AM ******/
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
/****** Object:  Table [dbo].[M_PostType]    Script Date: 22-Jan-18 1:11:56 AM ******/
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
/****** Object:  Table [dbo].[M_Product]    Script Date: 22-Jan-18 1:11:56 AM ******/
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
	[title] [nvarchar](500) NULL,
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
/****** Object:  Table [dbo].[M_Product_Image]    Script Date: 22-Jan-18 1:11:56 AM ******/
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
/****** Object:  Table [dbo].[S_Role]    Script Date: 22-Jan-18 1:11:56 AM ******/
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
/****** Object:  Table [dbo].[S_RoleMapping]    Script Date: 22-Jan-18 1:11:56 AM ******/
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
/****** Object:  Table [dbo].[S_User]    Script Date: 22-Jan-18 1:11:56 AM ******/
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
/****** Object:  Table [dbo].[T_CustomerOneTime]    Script Date: 22-Jan-18 1:11:56 AM ******/
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
/****** Object:  Table [dbo].[T_Order]    Script Date: 22-Jan-18 1:11:56 AM ******/
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
/****** Object:  Table [dbo].[T_Order_D]    Script Date: 22-Jan-18 1:11:56 AM ******/
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
/****** Object:  Table [dbo].[T_PaymentNotification]    Script Date: 22-Jan-18 1:11:56 AM ******/
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
/****** Object:  Table [dbo].[T_Post]    Script Date: 22-Jan-18 1:11:56 AM ******/
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
/****** Object:  Table [dbo].[T_ProductStocks]    Script Date: 22-Jan-18 1:11:57 AM ******/
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
/****** Object:  Table [dbo].[T_Shipping]    Script Date: 22-Jan-18 1:11:57 AM ******/
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
/****** Object:  Table [dbo].[T_Shipping_D]    Script Date: 22-Jan-18 1:11:57 AM ******/
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
/****** Object:  Table [dbo].[T_Shipping_H]    Script Date: 22-Jan-18 1:11:57 AM ******/
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

INSERT [dbo].[L_FileUpload] ([id], [fileName], [ipAddress], [macAddress], [type], [uploadDate], [userId]) VALUES (10019, N'1UW92RWDYP54DRKKP2J9T0GZE2HXG8.png', N'::1', NULL, N'PROD', CAST(N'2018-01-19T23:24:36.0158973' AS DateTime2), 1)
INSERT [dbo].[L_FileUpload] ([id], [fileName], [ipAddress], [macAddress], [type], [uploadDate], [userId]) VALUES (10020, N'IXSPTNBCSEZOF3W0EDP46QIXOAO75A.png', N'::1', NULL, N'PROD', CAST(N'2018-01-20T00:04:24.1886689' AS DateTime2), 1)
SET IDENTITY_INSERT [dbo].[L_FileUpload] OFF
SET IDENTITY_INSERT [dbo].[M_PostType] ON 

INSERT [dbo].[M_PostType] ([id], [name]) VALUES (1, N'Post')
INSERT [dbo].[M_PostType] ([id], [name]) VALUES (2, N'Activity')
SET IDENTITY_INSERT [dbo].[M_PostType] OFF
SET IDENTITY_INSERT [dbo].[M_Product] ON 

INSERT [dbo].[M_Product] ([id], [code], [cost], [createBy], [createDate], [detail], [isActive], [isPreOrder], [isUseStock], [title], [name], [note], [preEnd], [preStart], [price], [isShipping], [qtyShippingPriceCeiling], [shippintPriceRate], [unitName], [updateBy], [updateDate], [weight], [isDelete], [isManualPickup], [pickupAt], [stockQrty]) VALUES (15, N'SLM20180119001', CAST(0.00 AS Decimal(18, 2)), NULL, CAST(N'2018-01-20T11:37:41.440' AS DateTime), N'<p><img src="https://kadnud.s3-ap-southeast-1.amazonaws.com/bnk48/product_media/od-merry-christmas-2017-photoset/b6c249b2-bae0-436a-8864-c1d63e30a57c.png" style="width: 100%;"></p><p><br></p><p><img src="https://kadnud.s3-ap-southeast-1.amazonaws.com/bnk48/product_media/od-merry-christmas-2017-photoset/1de98b21-38a7-42cb-8d0f-5c3a915f397a.png" style="width: 100%;"></p><h5 style="box-sizing: border-box; font-family: Kanit, Thonburi, sans-serif; margin-right: 0px; margin-bottom: 10px; margin-left: 0px; line-height: 1.3; color: rgb(51, 51, 51); font-size: 1.17647em; text-align: center;"><div style="box-sizing: border-box;"><span style="box-sizing: border-box; color: inherit; font-family: inherit; font-size: 1.25rem;">BNK48 Merry Christmas 2017 Photoset</span></div><div style="box-sizing: border-box;"><span style="box-sizing: border-box; color: inherit; font-family: inherit; font-size: 1.25rem;">( 5 Random Photo Per Set )</span></div></h5><h5 style="box-sizing: border-box; font-family: Kanit, Thonburi, sans-serif; margin-right: 0px; margin-bottom: 10px; margin-left: 0px; line-height: 1.3; color: rgb(51, 51, 51); font-size: 1.17647em; text-align: center;"><div style="box-sizing: border-box;"><span style="box-sizing: border-box; color: inherit; font-family: inherit; font-size: 1.25rem;">รูปของสมาชิกวง BNK 48</span></div><div style="box-sizing: border-box;"><span style="box-sizing: border-box; color: inherit; font-family: inherit; font-size: 1.25rem;">มีทั้งหมด 28 คน</span></div></h5><h5 style="box-sizing: border-box; font-family: Kanit, Thonburi, sans-serif; margin-right: 0px; margin-bottom: 10px; margin-left: 0px; line-height: 1.3; color: rgb(51, 51, 51); font-size: 1.17647em; text-align: center;"><div style="box-sizing: border-box;"><span style="box-sizing: border-box; color: inherit; font-family: inherit; font-size: 1.25rem;">รูปจำนวน 5 ใบต่อการสุ่ม 1 ครั้ง</span></div><div style="box-sizing: border-box;"><span style="box-sizing: border-box; color: inherit; font-family: inherit; font-size: 1.25rem;">(ใน 1 สมาชิกจะมี 3 แบบ รวมทั้งหมดมี 84 แบบ)</span></div><div style="box-sizing: border-box;"><span style="box-sizing: border-box; color: inherit; font-family: inherit; font-size: 1.25rem;"><br></span></div><div style="box-sizing: border-box;"><span style="box-sizing: border-box; color: inherit; font-family: inherit; font-size: 1.25rem;"><br></span></div><div style="box-sizing: border-box;"><span style="box-sizing: border-box; color: inherit; font-family: inherit; font-size: 1.25rem;"><img src="https://kadnud.s3-ap-southeast-1.amazonaws.com/bnk48/product_media/od-merry-christmas-2017-photoset/066371cf-388b-40fb-9433-c6772f3e1f6b.png" style="width: 100%;"></span></div><div style="box-sizing: border-box;"><span style="box-sizing: border-box; color: inherit; font-family: inherit; font-size: 1.25rem;"><br></span></div><div style="box-sizing: border-box;"><span style="box-sizing: border-box; color: inherit; font-family: inherit; font-size: 1.25rem;"><br></span></div><div style="box-sizing: border-box;"><span style="box-sizing: border-box; color: inherit; font-family: inherit; font-size: 1.25rem;"><br></span></div><div style="box-sizing: border-box;"><span style="box-sizing: border-box; color: inherit; font-family: inherit; font-size: 1.25rem;"><br></span></div></h5><p><br></p>', 1, 1, 0, N'Pre-Order BNK48 Merry Christmas 2017 Photoset (5 Random Photo Per Set)', N'Merry Christmas 2017 Photoset', N'<p><span data-v-7e8fd02c="" style="box-sizing: border-box; font-weight: bolder; color: rgb(87, 87, 87); font-family: Kanit, Thonburi, sans-serif; font-size: 15px;">หมายเหตุ</span><span style="color: rgb(87, 87, 87); font-family: Kanit, Thonburi, sans-serif; font-size: 15px; background-color: rgb(255, 237, 237);"></span></p><div data-v-7e8fd02c="" style="box-sizing: border-box; color: rgb(87, 87, 87); font-family: Kanit, Thonburi, sans-serif; font-size: 15px;"><p style="box-sizing: border-box; margin-right: 0px; margin-bottom: 1.3em; margin-left: 0px;">คำนวณค่าจัดส่งแบบ Flat rate โดยการสั่งซื้อทุกๆ 20 ชิ้นจะเสียค่าจัดส่งครั้งละ 70 บาท</p><p style="box-sizing: border-box; margin: 1.3em 0px;"><span style="box-sizing: border-box; font-weight: bolder;">ตัวอย่าง</span><br style="box-sizing: border-box;">สินค้า 1 - 20 ชิ้น ค่าจัดส่ง 70 บาท<br style="box-sizing: border-box;">สินค้า 21 - 40 ชิ้น ค่าจัดส่ง 140 บาท</p><p style="box-sizing: border-box; margin: 1.3em 0px;"><span style="box-sizing: border-box; font-weight: bolder;">วันที่จัดส่งสินค้า</span><br style="box-sizing: border-box;">ระหว่างวันที่ 20 กุมภาพันธ์ พ.ศ. 2561 - วันที่ 23 กุมภาพันธ์ พ.ศ. 2561และคาดว่าจะได้รับสินค้าประมาณวันที่ 21 - 28 กุมภาพันธ์ 2561</p><p style="box-sizing: border-box; margin: 1.3em 0px;"><span style="box-sizing: border-box; font-weight: bolder;">รับสินค้าด้วยตัวเองที่ BNK48 Digital Live Studio<br style="box-sizing: border-box;"></span>ตั้งแต่วันที่ 20 กุมภาพันธ์เป็นต้นไป ไม่มีค่าจัดส่ง&nbsp;<br style="box-sizing: border-box;">(ไม่สามารถให้ผู้อื่นรับแทนได้ ชื่อผู้รับจะต้องตรงกับชื่อที่ใช้ในการสั่งสินค้าเท่านั้น)</p><p style="box-sizing: border-box; margin: 1.3em 0px;"><span style="box-sizing: border-box; font-weight: bolder;">*หมายเหตุ</span>&nbsp;<u style="box-sizing: border-box;">ในกรณีจัดส่ง ไม่สามารถส่งรวมกับสินค้าอื่น ๆ นอกจาก BNK48 Merry Christmas 2017 Photoset ได้และกรุณาตรวจสอบชื่อ ที่อยู่ และเบอร์โทรศัพท์ให้ถูกต้องครบถ้วนก่อนกดยืนยันสั่งสินค้า เมื่อกดยืนยันแล้ว จะไม่สามารถเปลี่ยนแปลงข้อมูลใด ๆ ได้ไม่ว่ากรณีใด ๆ ก็ตาม</u></p></div>', CAST(N'2018-01-22T00:00:00.0000000' AS DateTime2), CAST(N'2018-01-16T00:00:00.0000000' AS DateTime2), CAST(250.00 AS Decimal(18, 2)), 0, 10, CAST(150.00 AS Decimal(18, 2)), N'ชุด', NULL, CAST(N'2018-01-20T11:37:41.440' AS DateTime), CAST(150.00 AS Decimal(18, 2)), 0, 1, N'ตู้ปลา วันเกิดอร', 0)
INSERT [dbo].[M_Product] ([id], [code], [cost], [createBy], [createDate], [detail], [isActive], [isPreOrder], [isUseStock], [title], [name], [note], [preEnd], [preStart], [price], [isShipping], [qtyShippingPriceCeiling], [shippintPriceRate], [unitName], [updateBy], [updateDate], [weight], [isDelete], [isManualPickup], [pickupAt], [stockQrty]) VALUES (16, N'SLM20180120001', CAST(0.00 AS Decimal(18, 2)), NULL, CAST(N'2018-01-20T11:37:33.100' AS DateTime), N'<p><img src="https://kadnud.s3-ap-southeast-1.amazonaws.com/bnk48/product_media/od-KFC-photoset/fbee0c69-e235-4606-a7b2-cd3684ddf096.png"></p><p><br></p><p><br></p><p><img src="https://kadnud.s3-ap-southeast-1.amazonaws.com/bnk48/product_media/od-KFC-photoset/90a71343-8dd5-4035-8925-a548146e4824.png"></p><p><br></p><p><br></p><h4 style="box-sizing: border-box; font-family: Kanit, Thonburi, sans-serif; margin-right: 0px; margin-bottom: 10px; margin-left: 0px; line-height: 1.3; color: rgb(51, 51, 51); font-size: 1.17647em; text-align: center;"><span style="box-sizing: border-box; color: inherit; font-family: inherit; font-size: 1.5rem;">BNK48&nbsp;</span>Koisuru Fortune Cookie Senbatsu<span style="box-sizing: border-box; color: inherit; font-family: inherit; font-size: 1.5rem;">&nbsp;Photoset</span><br style="box-sizing: border-box;"><span style="box-sizing: border-box; color: inherit; font-family: inherit; font-size: 1.5rem;">( 5 Random Photo Per Set )</span><br style="box-sizing: border-box;"></h4><h5 style="box-sizing: border-box; font-family: Kanit, Thonburi, sans-serif; margin-right: 0px; margin-bottom: 10px; margin-left: 0px; line-height: 1.3; color: rgb(51, 51, 51); font-size: 1.17647em; text-align: center;"><div style="box-sizing: border-box;"><span style="box-sizing: border-box; color: inherit; font-family: inherit; font-size: 1.25rem;">รูปของสมาชิกวง BNK 48</span></div><div style="box-sizing: border-box;"><span style="box-sizing: border-box; color: inherit; font-family: inherit; font-size: 1.25rem;">มีทั้งหมด 28 คน</span></div></h5><h5 style="box-sizing: border-box; font-family: Kanit, Thonburi, sans-serif; margin-right: 0px; margin-bottom: 10px; margin-left: 0px; line-height: 1.3; color: rgb(51, 51, 51); font-size: 1.17647em; text-align: center;"><div style="box-sizing: border-box;"><span style="box-sizing: border-box; color: inherit; font-family: inherit; font-size: 1.25rem;">รูปจำนวน 5 ใบต่อการสุ่ม 1 ครั้ง</span></div><div style="box-sizing: border-box;"><span style="box-sizing: border-box; color: inherit; font-family: inherit; font-size: 1.25rem;">(ใน 1 สมาชิกจะมี 3 แบบ รวมทั้งหมดมี 84 แบบ)</span></div><div style="box-sizing: border-box;"><span style="box-sizing: border-box; color: inherit; font-family: inherit; font-size: 1.25rem;"><br></span></div><div style="box-sizing: border-box;"><span style="box-sizing: border-box; color: inherit; font-family: inherit; font-size: 1.25rem;"><br></span></div><div style="box-sizing: border-box;"><span style="box-sizing: border-box; color: inherit; font-family: inherit; font-size: 1.25rem;"><img src="https://kadnud.s3-ap-southeast-1.amazonaws.com/bnk48/product_media/od-KFC-photoset/92e724c4-a344-4f91-b236-12b14fff3831.png"><br></span></div></h5>', 1, 1, 0, N'Pre-Order BNK48 Koisuru Fortune Cookie Senbatsu Photoset (5 Random Photo Per Set)', N'Koisuru Fortune Cookie Senbatsu Photoset', N'<p><span data-v-7e8fd02c="" style="box-sizing: border-box; font-weight: bolder; color: rgb(87, 87, 87); font-family: Kanit, Thonburi, sans-serif; font-size: 15px;">หมายเหตุ</span><span style="color: rgb(87, 87, 87); font-family: Kanit, Thonburi, sans-serif; font-size: 15px; background-color: rgb(255, 237, 237);"></span></p><div data-v-7e8fd02c="" style="box-sizing: border-box; color: rgb(87, 87, 87); font-family: Kanit, Thonburi, sans-serif; font-size: 15px;"><p style="box-sizing: border-box; margin-right: 0px; margin-bottom: 1.3em; margin-left: 0px;">คำนวณค่าจัดส่งแบบ Flat rate โดยการสั่งซื้อทุกๆ 20 ชิ้นจะเสียค่าจัดส่งครั้งละ 70 บาท</p><p style="box-sizing: border-box; margin: 1.3em 0px;"><span style="box-sizing: border-box; font-weight: bolder;">ตัวอย่าง</span><br style="box-sizing: border-box;">สินค้า 1 - 20 ชิ้น ค่าจัดส่ง 70 บาท<br style="box-sizing: border-box;">สินค้า 21 - 40 ชิ้น ค่าจัดส่ง 140 บาท</p><p style="box-sizing: border-box; margin: 1.3em 0px;"><span style="box-sizing: border-box; font-weight: bolder;">วันที่จัดส่งสินค้า</span><br style="box-sizing: border-box;">ระหว่างวันที่ 20 กุมภาพันธ์ พ.ศ. 2561 - วันที่ 23 กุมภาพันธ์ พ.ศ. 2561 และคาดว่าจะได้รับสินค้าประมาณวันที่ 21 - 28 กุมภาพันธ์ 2561<br style="box-sizing: border-box;"></p><p style="box-sizing: border-box; margin: 1.3em 0px;"><span style="box-sizing: border-box; font-weight: bolder;">รับสินค้าด้วยตัวเองที่ BNK48 Digital Live Studio</span><br style="box-sizing: border-box;">ตั้งแต่วันที่ 20 กุมภาพันธ์เป็นต้นไป ไม่มีค่าจัดส่ง&nbsp;<br style="box-sizing: border-box;">(ไม่สามารถให้ผู้อื่นรับแทนได้ ชื่อผู้รับจะต้องตรงกับชื่อที่ใช้ในการสั่งสินค้าเท่านั้น)</p><p style="box-sizing: border-box; margin: 1.3em 0px;"><span style="box-sizing: border-box; font-weight: bolder;">*หมายเหตุ</span>&nbsp;<u style="box-sizing: border-box;">ในกรณีจัดส่ง ไม่สามารถส่งรวมกับสินค้าอื่น ๆ นอกจาก BNK48 2nd Single Koisuru Fortune Cookie Costume Photoset ได้และกรุณาตรวจสอบชื่อ ที่อยู่ และเบอร์โทรศัพท์ให้ถูกต้องครบถ้วนก่อนกดยืนยันสั่งสินค้า เมื่อกดยืนยันแล้ว จะไม่สามารถเปลี่ยนแปลงข้อมูลใด ๆ ได้ไม่ว่ากรณีใด ๆ ก็ตาม</u></p></div>', CAST(N'2561-01-23T00:00:00.0000000' AS DateTime2), CAST(N'2018-01-16T00:00:00.0000000' AS DateTime2), CAST(250.00 AS Decimal(18, 2)), 0, 10, CAST(150.00 AS Decimal(18, 2)), N'ชุด', NULL, CAST(N'2018-01-20T11:37:33.100' AS DateTime), CAST(150.00 AS Decimal(18, 2)), 0, 1, N'ตู้ปลางานวันเกิดอร', 0)
SET IDENTITY_INSERT [dbo].[M_Product] OFF
SET IDENTITY_INSERT [dbo].[M_Product_Image] ON 

INSERT [dbo].[M_Product_Image] ([id], [fileId], [productId]) VALUES (15, 10020, 16)
INSERT [dbo].[M_Product_Image] ([id], [fileId], [productId]) VALUES (16, 10019, 15)
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

INSERT [dbo].[T_Order] ([id], [code], [paymentId], [orderDate], [productId], [qty], [unitPrice], [totalPrice], [totalProductPrice], [isPay], [payDate], [isShipping], [shippingDateStart], [shippingDateEnd], [shippingDate], [shippingPrice], [tel], [email], [firstName], [lastName], [address], [province], [zipCode], [isMeetReceive], [isActive], [isCreateShipping], [isFinish], [createBy], [createDate], [updateBy], [updateDate]) VALUES (3, N'SLM2101201800000', NULL, CAST(N'2018-01-21T22:21:12.0350694' AS DateTime2), 15, 10, CAST(250.00 AS Decimal(18, 2)), CAST(2500.00 AS Decimal(18, 2)), CAST(2500.00 AS Decimal(18, 2)), 0, NULL, 0, NULL, NULL, NULL, CAST(0.00 AS Decimal(18, 2)), N'0925699900', N'jirawat.jannet@gmail.com', N'Jirawat', N'Jannet', N'71/1 Test', N'bankok', N'10920', 0, 1, 0, 0, -1, CAST(N'2018-01-21T22:21:12.033' AS DateTime), -1, CAST(N'2018-01-21T22:21:12.037' AS DateTime))
INSERT [dbo].[T_Order] ([id], [code], [paymentId], [orderDate], [productId], [qty], [unitPrice], [totalPrice], [totalProductPrice], [isPay], [payDate], [isShipping], [shippingDateStart], [shippingDateEnd], [shippingDate], [shippingPrice], [tel], [email], [firstName], [lastName], [address], [province], [zipCode], [isMeetReceive], [isActive], [isCreateShipping], [isFinish], [createBy], [createDate], [updateBy], [updateDate]) VALUES (4, N'SLM2101201800000', NULL, CAST(N'2018-01-21T22:21:12.0532635' AS DateTime2), 16, 12, CAST(250.00 AS Decimal(18, 2)), CAST(3000.00 AS Decimal(18, 2)), CAST(3000.00 AS Decimal(18, 2)), 0, NULL, 0, NULL, NULL, NULL, CAST(0.00 AS Decimal(18, 2)), N'0925699900', N'jirawat.jannet@gmail.com', N'Jirawat', N'Jannet', N'71/1 Test', N'bankok', N'10920', 0, 1, 0, 0, -1, CAST(N'2018-01-21T22:21:12.053' AS DateTime), -1, CAST(N'2018-01-21T22:21:12.053' AS DateTime))
INSERT [dbo].[T_Order] ([id], [code], [paymentId], [orderDate], [productId], [qty], [unitPrice], [totalPrice], [totalProductPrice], [isPay], [payDate], [isShipping], [shippingDateStart], [shippingDateEnd], [shippingDate], [shippingPrice], [tel], [email], [firstName], [lastName], [address], [province], [zipCode], [isMeetReceive], [isActive], [isCreateShipping], [isFinish], [createBy], [createDate], [updateBy], [updateDate]) VALUES (5, N'SLM2101201800003', NULL, CAST(N'2018-01-21T23:56:25.4964330' AS DateTime2), 15, 10, CAST(250.00 AS Decimal(18, 2)), CAST(2500.00 AS Decimal(18, 2)), CAST(2500.00 AS Decimal(18, 2)), 0, NULL, 0, NULL, NULL, NULL, CAST(0.00 AS Decimal(18, 2)), N'0925699900', N'jirawat.jannet@gmail.com', N'Jirawat', N'Jannet', N'71/1 Test', N'bankok', N'10920', 0, 1, 0, 0, -1, CAST(N'2018-01-21T23:56:25.497' AS DateTime), -1, CAST(N'2018-01-21T23:56:25.497' AS DateTime))
INSERT [dbo].[T_Order] ([id], [code], [paymentId], [orderDate], [productId], [qty], [unitPrice], [totalPrice], [totalProductPrice], [isPay], [payDate], [isShipping], [shippingDateStart], [shippingDateEnd], [shippingDate], [shippingPrice], [tel], [email], [firstName], [lastName], [address], [province], [zipCode], [isMeetReceive], [isActive], [isCreateShipping], [isFinish], [createBy], [createDate], [updateBy], [updateDate]) VALUES (6, N'SLM2101201800003', NULL, CAST(N'2018-01-21T23:56:25.5170699' AS DateTime2), 16, 12, CAST(250.00 AS Decimal(18, 2)), CAST(3000.00 AS Decimal(18, 2)), CAST(3000.00 AS Decimal(18, 2)), 0, NULL, 0, NULL, NULL, NULL, CAST(0.00 AS Decimal(18, 2)), N'0925699900', N'jirawat.jannet@gmail.com', N'Jirawat', N'Jannet', N'71/1 Test', N'bankok', N'10920', 0, 1, 0, 0, -1, CAST(N'2018-01-21T23:56:25.517' AS DateTime), -1, CAST(N'2018-01-21T23:56:25.517' AS DateTime))
INSERT [dbo].[T_Order] ([id], [code], [paymentId], [orderDate], [productId], [qty], [unitPrice], [totalPrice], [totalProductPrice], [isPay], [payDate], [isShipping], [shippingDateStart], [shippingDateEnd], [shippingDate], [shippingPrice], [tel], [email], [firstName], [lastName], [address], [province], [zipCode], [isMeetReceive], [isActive], [isCreateShipping], [isFinish], [createBy], [createDate], [updateBy], [updateDate]) VALUES (7, N'SLM2101201800005', NULL, CAST(N'2018-01-21T23:57:04.9923912' AS DateTime2), 15, 4, CAST(250.00 AS Decimal(18, 2)), CAST(1000.00 AS Decimal(18, 2)), CAST(1000.00 AS Decimal(18, 2)), 0, NULL, 0, NULL, NULL, NULL, CAST(0.00 AS Decimal(18, 2)), N'0925699900', N'jirawat.jannet@gmail.com', N'Jirawat', N'Jannet', N'71/1 Test', N'bankok', N'10920', 0, 1, 0, 0, -1, CAST(N'2018-01-21T23:57:04.993' AS DateTime), -1, CAST(N'2018-01-21T23:57:04.993' AS DateTime))
INSERT [dbo].[T_Order] ([id], [code], [paymentId], [orderDate], [productId], [qty], [unitPrice], [totalPrice], [totalProductPrice], [isPay], [payDate], [isShipping], [shippingDateStart], [shippingDateEnd], [shippingDate], [shippingPrice], [tel], [email], [firstName], [lastName], [address], [province], [zipCode], [isMeetReceive], [isActive], [isCreateShipping], [isFinish], [createBy], [createDate], [updateBy], [updateDate]) VALUES (8, N'SLM2101201800005', NULL, CAST(N'2018-01-21T23:57:05.0016767' AS DateTime2), 16, 4, CAST(250.00 AS Decimal(18, 2)), CAST(1000.00 AS Decimal(18, 2)), CAST(1000.00 AS Decimal(18, 2)), 0, NULL, 0, NULL, NULL, NULL, CAST(0.00 AS Decimal(18, 2)), N'0925699900', N'jirawat.jannet@gmail.com', N'Jirawat', N'Jannet', N'71/1 Test', N'bankok', N'10920', 0, 1, 0, 0, -1, CAST(N'2018-01-21T23:57:05.003' AS DateTime), -1, CAST(N'2018-01-21T23:57:05.003' AS DateTime))
INSERT [dbo].[T_Order] ([id], [code], [paymentId], [orderDate], [productId], [qty], [unitPrice], [totalPrice], [totalProductPrice], [isPay], [payDate], [isShipping], [shippingDateStart], [shippingDateEnd], [shippingDate], [shippingPrice], [tel], [email], [firstName], [lastName], [address], [province], [zipCode], [isMeetReceive], [isActive], [isCreateShipping], [isFinish], [createBy], [createDate], [updateBy], [updateDate]) VALUES (9, N'SLM2201201800001', NULL, CAST(N'2018-01-22T00:08:48.2498599' AS DateTime2), 15, 1, CAST(250.00 AS Decimal(18, 2)), CAST(250.00 AS Decimal(18, 2)), CAST(250.00 AS Decimal(18, 2)), 0, NULL, 0, NULL, NULL, NULL, CAST(0.00 AS Decimal(18, 2)), N'0925699900', N'jirawat.jannet@gmail.com', N'Jirawat', N'Jannet', N'71/1 Test', N'bankok', N'10920', 0, 1, 0, 0, -1, CAST(N'2018-01-22T00:08:48.250' AS DateTime), -1, CAST(N'2018-01-22T00:08:48.250' AS DateTime))
INSERT [dbo].[T_Order] ([id], [code], [paymentId], [orderDate], [productId], [qty], [unitPrice], [totalPrice], [totalProductPrice], [isPay], [payDate], [isShipping], [shippingDateStart], [shippingDateEnd], [shippingDate], [shippingPrice], [tel], [email], [firstName], [lastName], [address], [province], [zipCode], [isMeetReceive], [isActive], [isCreateShipping], [isFinish], [createBy], [createDate], [updateBy], [updateDate]) VALUES (10, N'SLM2201201800001', NULL, CAST(N'2018-01-22T00:08:48.2578027' AS DateTime2), 16, 1, CAST(250.00 AS Decimal(18, 2)), CAST(250.00 AS Decimal(18, 2)), CAST(250.00 AS Decimal(18, 2)), 0, NULL, 0, NULL, NULL, NULL, CAST(0.00 AS Decimal(18, 2)), N'0925699900', N'jirawat.jannet@gmail.com', N'Jirawat', N'Jannet', N'71/1 Test', N'bankok', N'10920', 0, 1, 0, 0, -1, CAST(N'2018-01-22T00:08:48.257' AS DateTime), -1, CAST(N'2018-01-22T00:08:48.257' AS DateTime))
INSERT [dbo].[T_Order] ([id], [code], [paymentId], [orderDate], [productId], [qty], [unitPrice], [totalPrice], [totalProductPrice], [isPay], [payDate], [isShipping], [shippingDateStart], [shippingDateEnd], [shippingDate], [shippingPrice], [tel], [email], [firstName], [lastName], [address], [province], [zipCode], [isMeetReceive], [isActive], [isCreateShipping], [isFinish], [createBy], [createDate], [updateBy], [updateDate]) VALUES (11, N'SLM2201201800003', NULL, CAST(N'2018-01-22T00:11:12.1574795' AS DateTime2), 15, 1, CAST(250.00 AS Decimal(18, 2)), CAST(250.00 AS Decimal(18, 2)), CAST(250.00 AS Decimal(18, 2)), 0, NULL, 0, NULL, NULL, NULL, CAST(0.00 AS Decimal(18, 2)), N'0925699900', N'jirawat.jannet@gmail.com', N'Jirawat', N'Jannet', N'71/1 Test', N'bankok', N'10920', 0, 1, 0, 0, -1, CAST(N'2018-01-22T00:11:12.157' AS DateTime), -1, CAST(N'2018-01-22T00:11:12.160' AS DateTime))
INSERT [dbo].[T_Order] ([id], [code], [paymentId], [orderDate], [productId], [qty], [unitPrice], [totalPrice], [totalProductPrice], [isPay], [payDate], [isShipping], [shippingDateStart], [shippingDateEnd], [shippingDate], [shippingPrice], [tel], [email], [firstName], [lastName], [address], [province], [zipCode], [isMeetReceive], [isActive], [isCreateShipping], [isFinish], [createBy], [createDate], [updateBy], [updateDate]) VALUES (12, N'SLM2201201800003', NULL, CAST(N'2018-01-22T00:11:12.1662054' AS DateTime2), 16, 1, CAST(250.00 AS Decimal(18, 2)), CAST(250.00 AS Decimal(18, 2)), CAST(250.00 AS Decimal(18, 2)), 0, NULL, 0, NULL, NULL, NULL, CAST(0.00 AS Decimal(18, 2)), N'0925699900', N'jirawat.jannet@gmail.com', N'Jirawat', N'Jannet', N'71/1 Test', N'bankok', N'10920', 0, 1, 0, 0, -1, CAST(N'2018-01-22T00:11:12.167' AS DateTime), -1, CAST(N'2018-01-22T00:11:12.167' AS DateTime))
INSERT [dbo].[T_Order] ([id], [code], [paymentId], [orderDate], [productId], [qty], [unitPrice], [totalPrice], [totalProductPrice], [isPay], [payDate], [isShipping], [shippingDateStart], [shippingDateEnd], [shippingDate], [shippingPrice], [tel], [email], [firstName], [lastName], [address], [province], [zipCode], [isMeetReceive], [isActive], [isCreateShipping], [isFinish], [createBy], [createDate], [updateBy], [updateDate]) VALUES (13, N'SLM2201201800005', NULL, CAST(N'2018-01-22T00:17:25.8502139' AS DateTime2), 15, 1, CAST(250.00 AS Decimal(18, 2)), CAST(250.00 AS Decimal(18, 2)), CAST(250.00 AS Decimal(18, 2)), 0, NULL, 0, NULL, NULL, NULL, CAST(0.00 AS Decimal(18, 2)), N'0925699900', N'jirawat.jannet@gmail.com', N'Jirawat', N'Jannet', N'71/1 Test', N'bankok', N'10920', 0, 1, 0, 0, -1, CAST(N'2018-01-22T00:17:25.850' AS DateTime), -1, CAST(N'2018-01-22T00:17:25.850' AS DateTime))
INSERT [dbo].[T_Order] ([id], [code], [paymentId], [orderDate], [productId], [qty], [unitPrice], [totalPrice], [totalProductPrice], [isPay], [payDate], [isShipping], [shippingDateStart], [shippingDateEnd], [shippingDate], [shippingPrice], [tel], [email], [firstName], [lastName], [address], [province], [zipCode], [isMeetReceive], [isActive], [isCreateShipping], [isFinish], [createBy], [createDate], [updateBy], [updateDate]) VALUES (14, N'SLM2201201800006', NULL, CAST(N'2018-01-22T00:19:41.2220724' AS DateTime2), 15, 1, CAST(250.00 AS Decimal(18, 2)), CAST(250.00 AS Decimal(18, 2)), CAST(250.00 AS Decimal(18, 2)), 0, NULL, 0, NULL, NULL, NULL, CAST(0.00 AS Decimal(18, 2)), N'0925699900', N'jirawat.jannet@gmail.com', N'Jirawat', N'Jannet', N'71/1 Test', N'bankok', N'10920', 0, 1, 0, 0, -1, CAST(N'2018-01-22T00:19:41.220' AS DateTime), -1, CAST(N'2018-01-22T00:19:41.223' AS DateTime))
INSERT [dbo].[T_Order] ([id], [code], [paymentId], [orderDate], [productId], [qty], [unitPrice], [totalPrice], [totalProductPrice], [isPay], [payDate], [isShipping], [shippingDateStart], [shippingDateEnd], [shippingDate], [shippingPrice], [tel], [email], [firstName], [lastName], [address], [province], [zipCode], [isMeetReceive], [isActive], [isCreateShipping], [isFinish], [createBy], [createDate], [updateBy], [updateDate]) VALUES (15, N'SLM2201201800007', NULL, CAST(N'2018-01-22T00:20:10.8942981' AS DateTime2), 16, 1, CAST(250.00 AS Decimal(18, 2)), CAST(250.00 AS Decimal(18, 2)), CAST(250.00 AS Decimal(18, 2)), 0, NULL, 0, NULL, NULL, NULL, CAST(0.00 AS Decimal(18, 2)), N'0925699900', N'jirawat.jannet@gmail.com', N'Jirawat', N'Jannet', N'71/1 Test', N'bankok', N'10920', 0, 1, 0, 0, -1, CAST(N'2018-01-22T00:20:10.893' AS DateTime), -1, CAST(N'2018-01-22T00:20:21.860' AS DateTime))
INSERT [dbo].[T_Order] ([id], [code], [paymentId], [orderDate], [productId], [qty], [unitPrice], [totalPrice], [totalProductPrice], [isPay], [payDate], [isShipping], [shippingDateStart], [shippingDateEnd], [shippingDate], [shippingPrice], [tel], [email], [firstName], [lastName], [address], [province], [zipCode], [isMeetReceive], [isActive], [isCreateShipping], [isFinish], [createBy], [createDate], [updateBy], [updateDate]) VALUES (16, N'SLM2201201800008', NULL, CAST(N'2018-01-22T00:21:43.4890869' AS DateTime2), 16, 1, CAST(250.00 AS Decimal(18, 2)), CAST(250.00 AS Decimal(18, 2)), CAST(250.00 AS Decimal(18, 2)), 0, NULL, 0, NULL, NULL, NULL, CAST(0.00 AS Decimal(18, 2)), N'0925699900', N'jirawat.jannet@gmail.com', N'Jirawat', N'Jannet', N'71/1 Test', N'bankok', N'10920', 0, 1, 0, 0, -1, CAST(N'2018-01-22T00:21:43.490' AS DateTime), -1, CAST(N'2018-01-22T00:21:54.603' AS DateTime))
INSERT [dbo].[T_Order] ([id], [code], [paymentId], [orderDate], [productId], [qty], [unitPrice], [totalPrice], [totalProductPrice], [isPay], [payDate], [isShipping], [shippingDateStart], [shippingDateEnd], [shippingDate], [shippingPrice], [tel], [email], [firstName], [lastName], [address], [province], [zipCode], [isMeetReceive], [isActive], [isCreateShipping], [isFinish], [createBy], [createDate], [updateBy], [updateDate]) VALUES (17, N'SLM2201201800009', NULL, CAST(N'2018-01-22T00:22:29.4085282' AS DateTime2), 16, 1, CAST(250.00 AS Decimal(18, 2)), CAST(250.00 AS Decimal(18, 2)), CAST(250.00 AS Decimal(18, 2)), 0, NULL, 0, NULL, NULL, NULL, CAST(0.00 AS Decimal(18, 2)), N'0925699900', N'jirawat.jannet@gmail.com', N'Jirawat', N'Jannet', N'71/1 Test', N'bankok', N'10920', 0, 1, 0, 0, -1, CAST(N'2018-01-22T00:22:29.410' AS DateTime), -1, CAST(N'2018-01-22T00:22:51.323' AS DateTime))
INSERT [dbo].[T_Order] ([id], [code], [paymentId], [orderDate], [productId], [qty], [unitPrice], [totalPrice], [totalProductPrice], [isPay], [payDate], [isShipping], [shippingDateStart], [shippingDateEnd], [shippingDate], [shippingPrice], [tel], [email], [firstName], [lastName], [address], [province], [zipCode], [isMeetReceive], [isActive], [isCreateShipping], [isFinish], [createBy], [createDate], [updateBy], [updateDate]) VALUES (18, N'SLM2201201800010', NULL, CAST(N'2018-01-22T00:23:33.7074918' AS DateTime2), 16, 1, CAST(250.00 AS Decimal(18, 2)), CAST(250.00 AS Decimal(18, 2)), CAST(250.00 AS Decimal(18, 2)), 0, NULL, 0, NULL, NULL, NULL, CAST(0.00 AS Decimal(18, 2)), N'0925699900', N'jirawat.jannet@gmail.com', N'Jirawat', N'Jannet', N'71/1 Test', N'bankok', N'10920', 0, 1, 0, 0, -1, CAST(N'2018-01-22T00:23:33.707' AS DateTime), -1, CAST(N'2018-01-22T00:23:35.300' AS DateTime))
INSERT [dbo].[T_Order] ([id], [code], [paymentId], [orderDate], [productId], [qty], [unitPrice], [totalPrice], [totalProductPrice], [isPay], [payDate], [isShipping], [shippingDateStart], [shippingDateEnd], [shippingDate], [shippingPrice], [tel], [email], [firstName], [lastName], [address], [province], [zipCode], [isMeetReceive], [isActive], [isCreateShipping], [isFinish], [createBy], [createDate], [updateBy], [updateDate]) VALUES (19, N'SLM2201201800011', NULL, CAST(N'2018-01-22T00:24:55.4372657' AS DateTime2), 16, 1, CAST(250.00 AS Decimal(18, 2)), CAST(250.00 AS Decimal(18, 2)), CAST(250.00 AS Decimal(18, 2)), 0, NULL, 0, NULL, NULL, NULL, CAST(0.00 AS Decimal(18, 2)), N'0925699900', N'jirawat.jannet@gmail.com', N'Jirawat', N'Jannet', N'71/1 Test', N'bankok', N'10920', 0, 1, 0, 0, -1, CAST(N'2018-01-22T00:24:55.437' AS DateTime), -1, CAST(N'2018-01-22T00:24:55.437' AS DateTime))
INSERT [dbo].[T_Order] ([id], [code], [paymentId], [orderDate], [productId], [qty], [unitPrice], [totalPrice], [totalProductPrice], [isPay], [payDate], [isShipping], [shippingDateStart], [shippingDateEnd], [shippingDate], [shippingPrice], [tel], [email], [firstName], [lastName], [address], [province], [zipCode], [isMeetReceive], [isActive], [isCreateShipping], [isFinish], [createBy], [createDate], [updateBy], [updateDate]) VALUES (20, N'SLM2201201800012', NULL, CAST(N'2018-01-22T00:27:16.2540630' AS DateTime2), 16, 1, CAST(250.00 AS Decimal(18, 2)), CAST(400.00 AS Decimal(18, 2)), CAST(250.00 AS Decimal(18, 2)), 0, NULL, 1, NULL, NULL, NULL, CAST(0.00 AS Decimal(18, 2)), N'0925699900', N'jirawat.jannet@gmail.com', N'Jirawat', N'Jannet', N'71/1 Test', N'bankok', N'10920', 0, 1, 0, 0, -1, CAST(N'2018-01-22T00:27:16.253' AS DateTime), -1, CAST(N'2018-01-22T00:27:16.253' AS DateTime))
INSERT [dbo].[T_Order] ([id], [code], [paymentId], [orderDate], [productId], [qty], [unitPrice], [totalPrice], [totalProductPrice], [isPay], [payDate], [isShipping], [shippingDateStart], [shippingDateEnd], [shippingDate], [shippingPrice], [tel], [email], [firstName], [lastName], [address], [province], [zipCode], [isMeetReceive], [isActive], [isCreateShipping], [isFinish], [createBy], [createDate], [updateBy], [updateDate]) VALUES (21, N'SLM2201201800013', NULL, CAST(N'2018-01-22T00:30:27.8999335' AS DateTime2), 16, 1, CAST(250.00 AS Decimal(18, 2)), CAST(400.00 AS Decimal(18, 2)), CAST(250.00 AS Decimal(18, 2)), 0, NULL, 1, NULL, NULL, NULL, CAST(0.00 AS Decimal(18, 2)), N'0925699900', N'jirawat.jannet@gmail.com', N'Jirawat', N'Jannet', N'71/1 Test', N'bankok', N'10920', 0, 1, 0, 0, -1, CAST(N'2018-01-22T00:30:27.900' AS DateTime), -1, CAST(N'2018-01-22T00:30:27.900' AS DateTime))
INSERT [dbo].[T_Order] ([id], [code], [paymentId], [orderDate], [productId], [qty], [unitPrice], [totalPrice], [totalProductPrice], [isPay], [payDate], [isShipping], [shippingDateStart], [shippingDateEnd], [shippingDate], [shippingPrice], [tel], [email], [firstName], [lastName], [address], [province], [zipCode], [isMeetReceive], [isActive], [isCreateShipping], [isFinish], [createBy], [createDate], [updateBy], [updateDate]) VALUES (22, N'SLM2201201800014', NULL, CAST(N'2018-01-22T00:32:40.5607232' AS DateTime2), 16, 1, CAST(250.00 AS Decimal(18, 2)), CAST(400.00 AS Decimal(18, 2)), CAST(250.00 AS Decimal(18, 2)), 0, NULL, 1, NULL, NULL, NULL, CAST(150.00 AS Decimal(18, 2)), N'0925699900', N'jirawat.jannet@gmail.com', N'Jirawat', N'Jannet', N'71/1 Test', N'bankok', N'10920', 0, 1, 0, 0, -1, CAST(N'2018-01-22T00:32:40.560' AS DateTime), -1, CAST(N'2018-01-22T00:32:40.563' AS DateTime))
INSERT [dbo].[T_Order] ([id], [code], [paymentId], [orderDate], [productId], [qty], [unitPrice], [totalPrice], [totalProductPrice], [isPay], [payDate], [isShipping], [shippingDateStart], [shippingDateEnd], [shippingDate], [shippingPrice], [tel], [email], [firstName], [lastName], [address], [province], [zipCode], [isMeetReceive], [isActive], [isCreateShipping], [isFinish], [createBy], [createDate], [updateBy], [updateDate]) VALUES (23, N'SLM2201201800015', NULL, CAST(N'2018-01-22T00:33:11.1603837' AS DateTime2), 15, 1, CAST(250.00 AS Decimal(18, 2)), CAST(250.00 AS Decimal(18, 2)), CAST(250.00 AS Decimal(18, 2)), 0, NULL, 0, NULL, NULL, NULL, CAST(0.00 AS Decimal(18, 2)), N'0925699900', N'jirawat.jannet@gmail.com', N'Jirawat', N'Jannet', N'71/1 Test', N'bankok', N'10920', 1, 1, 0, 0, -1, CAST(N'2018-01-22T00:33:11.160' AS DateTime), -1, CAST(N'2018-01-22T00:33:11.160' AS DateTime))
INSERT [dbo].[T_Order] ([id], [code], [paymentId], [orderDate], [productId], [qty], [unitPrice], [totalPrice], [totalProductPrice], [isPay], [payDate], [isShipping], [shippingDateStart], [shippingDateEnd], [shippingDate], [shippingPrice], [tel], [email], [firstName], [lastName], [address], [province], [zipCode], [isMeetReceive], [isActive], [isCreateShipping], [isFinish], [createBy], [createDate], [updateBy], [updateDate]) VALUES (24, N'SLM2201201800016', NULL, CAST(N'2018-01-22T01:03:15.4238214' AS DateTime2), 16, 1, CAST(250.00 AS Decimal(18, 2)), CAST(400.00 AS Decimal(18, 2)), CAST(250.00 AS Decimal(18, 2)), 0, NULL, 1, NULL, NULL, NULL, CAST(150.00 AS Decimal(18, 2)), N'0925699900', N'jirawat.jannet@gmail.com', N'Jirawat', N'Jannet', N'71/1 Test', N'bankok', N'10920', 0, 1, 0, 0, -1, CAST(N'2018-01-22T01:03:15.423' AS DateTime), -1, CAST(N'2018-01-22T01:03:15.427' AS DateTime))
SET IDENTITY_INSERT [dbo].[T_Order] OFF
SET IDENTITY_INSERT [dbo].[T_Order_D] ON 

INSERT [dbo].[T_Order_D] ([id], [hId], [productId], [qty], [unitPrice]) VALUES (1, 2, 1, 2, CAST(100.00 AS Decimal(18, 2)))
INSERT [dbo].[T_Order_D] ([id], [hId], [productId], [qty], [unitPrice]) VALUES (2, 2, 2, 2, CAST(100.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[T_Order_D] OFF
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
/****** Object:  StoredProcedure [dbo].[sp_m_product_add]    Script Date: 22-Jan-18 1:11:57 AM ******/
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
/****** Object:  StoredProcedure [dbo].[sp_m_product_edit]    Script Date: 22-Jan-18 1:11:57 AM ******/
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
/****** Object:  StoredProcedure [dbo].[sp_test]    Script Date: 22-Jan-18 1:11:57 AM ******/
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
