USE [blog]
GO
/****** Object:  Table [dbo].[category]    Script Date: 06/11/2020 10:24:59 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[category](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[parentId] [bigint] NULL,
	[title] [varchar](75) NULL,
	[metaTilte] [varchar](100) NULL,
	[slug] [varchar](100) NULL,
	[contenido] [text] NULL,
 CONSTRAINT [PK_category] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[post]    Script Date: 06/11/2020 10:24:59 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[post](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[authorId] [bigint] NOT NULL,
	[parentId] [bigint] NULL,
	[title] [varchar](50) NULL,
	[metaTile] [varchar](50) NULL,
	[slug] [varchar](50) NULL,
	[summary] [varchar](50) NULL,
	[published] [tinyint] NULL,
	[createAt] [datetime] NULL,
	[updateAt] [datetime] NULL,
	[publishedAt] [datetime] NULL,
	[contenido] [text] NULL,
 CONSTRAINT [PK_post] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[post_category]    Script Date: 06/11/2020 10:24:59 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[post_category](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[postId] [bigint] NOT NULL,
	[categoryId] [bigint] NOT NULL,
 CONSTRAINT [PK_post_category] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[post_comment]    Script Date: 06/11/2020 10:24:59 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[post_comment](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[postId] [bigint] NOT NULL,
	[parentId] [bigint] NULL,
	[title] [varchar](100) NULL,
	[published] [tinyint] NULL,
	[createdAt] [datetime] NULL,
	[publishedAt] [datetime] NULL,
	[contenido] [text] NULL,
 CONSTRAINT [PK_post_comment] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[post_tag]    Script Date: 06/11/2020 10:24:59 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[post_tag](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[postId] [bigint] NOT NULL,
	[tagId] [bigint] NOT NULL,
 CONSTRAINT [PK_post_tag] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tag]    Script Date: 06/11/2020 10:24:59 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tag](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[title] [varchar](75) NULL,
	[metaTitle] [varchar](100) NULL,
	[slug] [varchar](100) NULL,
	[contenido] [text] NULL,
 CONSTRAINT [PK_tag] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[user]    Script Date: 06/11/2020 10:24:59 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[user](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[firstName] [varchar](50) NULL,
	[middleName] [varchar](50) NULL,
	[lastName] [varchar](50) NULL,
	[mobile] [varchar](50) NULL,
	[email] [varchar](50) NULL,
	[passwordHash] [varchar](50) NULL,
	[registeredAt] [datetime] NULL,
	[lastLogin] [datetime] NULL,
	[intro] [varchar](max) NULL,
	[profile] [varchar](50) NULL,
 CONSTRAINT [PK_user] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[post]  WITH CHECK ADD  CONSTRAINT [FK_post_user] FOREIGN KEY([authorId])
REFERENCES [dbo].[user] ([id])
GO
ALTER TABLE [dbo].[post] CHECK CONSTRAINT [FK_post_user]
GO
ALTER TABLE [dbo].[post_category]  WITH CHECK ADD  CONSTRAINT [FK_post_category_category] FOREIGN KEY([categoryId])
REFERENCES [dbo].[category] ([id])
GO
ALTER TABLE [dbo].[post_category] CHECK CONSTRAINT [FK_post_category_category]
GO
ALTER TABLE [dbo].[post_category]  WITH CHECK ADD  CONSTRAINT [FK_post_category_post] FOREIGN KEY([postId])
REFERENCES [dbo].[post] ([id])
GO
ALTER TABLE [dbo].[post_category] CHECK CONSTRAINT [FK_post_category_post]
GO
ALTER TABLE [dbo].[post_comment]  WITH CHECK ADD  CONSTRAINT [FK_post_comment_post] FOREIGN KEY([postId])
REFERENCES [dbo].[post] ([id])
GO
ALTER TABLE [dbo].[post_comment] CHECK CONSTRAINT [FK_post_comment_post]
GO
ALTER TABLE [dbo].[post_tag]  WITH CHECK ADD  CONSTRAINT [FK_post_tag_post] FOREIGN KEY([postId])
REFERENCES [dbo].[post] ([id])
GO
ALTER TABLE [dbo].[post_tag] CHECK CONSTRAINT [FK_post_tag_post]
GO
ALTER TABLE [dbo].[post_tag]  WITH CHECK ADD  CONSTRAINT [FK_post_tag_tag] FOREIGN KEY([tagId])
REFERENCES [dbo].[tag] ([id])
GO
ALTER TABLE [dbo].[post_tag] CHECK CONSTRAINT [FK_post_tag_tag]
GO
