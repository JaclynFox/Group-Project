CREATE TABLE [dbo].[Class](
	[ClassKey] [int] IDENTITY(1,1) NOT NULL,
	[ClassName] [varchar](15) NOT NULL,
	[UserKey] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ClassKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Education]    Script Date: 12/5/2019 4:48:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Education](
	[EducationKey] [int] IDENTITY(1,1) NOT NULL,
	[EducationLevel] [varchar](15) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[EducationKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Files]    Script Date: 12/5/2019 4:48:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Files](
	[FilesKey] [int] IDENTITY(1,1) NOT NULL,
	[File] [varchar](300) NOT NULL,
	[UserKey] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[FilesKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[State]    Script Date: 12/5/2019 4:48:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[State](
	[StateKey] [int] IDENTITY(1,1) NOT NULL,
	[Abbr] [varchar](2) NOT NULL,
	[FullName] [varchar](15) NULL,
PRIMARY KEY CLUSTERED 
(
	[StateKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Status]    Script Date: 12/5/2019 4:48:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Status](
	[StatusKey] [int] IDENTITY(1,1) NOT NULL,
	[StatusName] [varchar](15) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[StatusKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentClass]    Script Date: 12/5/2019 4:48:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentClass](
	[StudentClassKey] [int] IDENTITY(1,1) NOT NULL,
	[ClassKey] [int] NULL,
	[UserKey] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[StudentClassKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 12/5/2019 22:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserKey] [int] IDENTITY(1,1),
	[UserName] [binary](128) NOT NULL,
	[Password] [binary](128) NOT NULL,
	[FirstName] [varchar](20) NOT NULL,
	[LastName] [varchar](30) NOT NULL,
	[street] [varchar](30) NOT NULL,
	[city] [varchar](20) NOT NULL,
	[zip] [int] NOT NULL,
	[email] [varchar](20) NOT NULL,
	[phone] [varchar](30) NOT NULL,
	[YOE] [int] DEFAULT 0,
	[EducationKey] [int] DEFAULT 6,
	[StateKey] [int] NULL,
	[StatusKey] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[UserKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Education] ON 

INSERT [dbo].[Education] ([EducationKey], [EducationLevel]) VALUES (1, N'High School')
INSERT [dbo].[Education] ([EducationKey], [EducationLevel]) VALUES (2, N'Associate')
INSERT [dbo].[Education] ([EducationKey], [EducationLevel]) VALUES (3, N'Bachelor''s')
INSERT [dbo].[Education] ([EducationKey], [EducationLevel]) VALUES (4, N'Master''s')
INSERT [dbo].[Education] ([EducationKey], [EducationLevel]) VALUES (5, N'Doctoral')
INSERT [dbo].[Education] ([EducationKey], [EducationLevel]) VALUES (6, N'none')
SET IDENTITY_INSERT [dbo].[Education] OFF
SET IDENTITY_INSERT [dbo].[State] ON 

INSERT [dbo].[State] ([StateKey], [Abbr], [FullName]) VALUES (51, N'AL', N'Alabama')
INSERT [dbo].[State] ([StateKey], [Abbr], [FullName]) VALUES (52, N'AK', N'Alaska')
INSERT [dbo].[State] ([StateKey], [Abbr], [FullName]) VALUES (53, N'AZ', N'Arizona')
INSERT [dbo].[State] ([StateKey], [Abbr], [FullName]) VALUES (54, N'AR', N'Arkansas')
INSERT [dbo].[State] ([StateKey], [Abbr], [FullName]) VALUES (55, N'CA', N'California')
INSERT [dbo].[State] ([StateKey], [Abbr], [FullName]) VALUES (56, N'CO', N'Colorado')
INSERT [dbo].[State] ([StateKey], [Abbr], [FullName]) VALUES (57, N'CT', N'Connecticut')
INSERT [dbo].[State] ([StateKey], [Abbr], [FullName]) VALUES (58, N'DE', N'Delaware')
INSERT [dbo].[State] ([StateKey], [Abbr], [FullName]) VALUES (59, N'FL', N'Florida')
INSERT [dbo].[State] ([StateKey], [Abbr], [FullName]) VALUES (60, N'GA', N'Georgia')
INSERT [dbo].[State] ([StateKey], [Abbr], [FullName]) VALUES (61, N'HI', N'Hawaii')
INSERT [dbo].[State] ([StateKey], [Abbr], [FullName]) VALUES (62, N'ID', N'Idaho')
INSERT [dbo].[State] ([StateKey], [Abbr], [FullName]) VALUES (63, N'IL', N'Illinois')
INSERT [dbo].[State] ([StateKey], [Abbr], [FullName]) VALUES (64, N'IN', N'Indiana')
INSERT [dbo].[State] ([StateKey], [Abbr], [FullName]) VALUES (65, N'IA', N'Iowa')
INSERT [dbo].[State] ([StateKey], [Abbr], [FullName]) VALUES (66, N'KS', N'Kansas')
INSERT [dbo].[State] ([StateKey], [Abbr], [FullName]) VALUES (67, N'KY', N'Kentucky')
INSERT [dbo].[State] ([StateKey], [Abbr], [FullName]) VALUES (68, N'LA', N'Louisiana')
INSERT [dbo].[State] ([StateKey], [Abbr], [FullName]) VALUES (69, N'ME', N'Maine')
INSERT [dbo].[State] ([StateKey], [Abbr], [FullName]) VALUES (70, N'MD', N'Maryland')
INSERT [dbo].[State] ([StateKey], [Abbr], [FullName]) VALUES (71, N'MA', N'Massachusetts')
INSERT [dbo].[State] ([StateKey], [Abbr], [FullName]) VALUES (72, N'MI', N'Michigan')
INSERT [dbo].[State] ([StateKey], [Abbr], [FullName]) VALUES (73, N'MN', N'Minnesota')
INSERT [dbo].[State] ([StateKey], [Abbr], [FullName]) VALUES (74, N'MS', N'Mississippi')
INSERT [dbo].[State] ([StateKey], [Abbr], [FullName]) VALUES (75, N'MO', N'Missouri')
INSERT [dbo].[State] ([StateKey], [Abbr], [FullName]) VALUES (76, N'MT', N'Montana')
INSERT [dbo].[State] ([StateKey], [Abbr], [FullName]) VALUES (77, N'NE', N'Nebraska')
INSERT [dbo].[State] ([StateKey], [Abbr], [FullName]) VALUES (78, N'NV', N'Nevada')
INSERT [dbo].[State] ([StateKey], [Abbr], [FullName]) VALUES (79, N'NH', N'New Hampshire')
INSERT [dbo].[State] ([StateKey], [Abbr], [FullName]) VALUES (80, N'NJ', N'New Jersey')
INSERT [dbo].[State] ([StateKey], [Abbr], [FullName]) VALUES (81, N'NM', N'New Mexico ')
INSERT [dbo].[State] ([StateKey], [Abbr], [FullName]) VALUES (82, N'NY', N'New York ')
INSERT [dbo].[State] ([StateKey], [Abbr], [FullName]) VALUES (83, N'NC', N'North Carolina')
INSERT [dbo].[State] ([StateKey], [Abbr], [FullName]) VALUES (84, N'ND', N'North Dakota ')
INSERT [dbo].[State] ([StateKey], [Abbr], [FullName]) VALUES (85, N'OH', N'Ohio')
INSERT [dbo].[State] ([StateKey], [Abbr], [FullName]) VALUES (86, N'OK', N'Oklahoma')
INSERT [dbo].[State] ([StateKey], [Abbr], [FullName]) VALUES (87, N'OR', N'Oregon')
INSERT [dbo].[State] ([StateKey], [Abbr], [FullName]) VALUES (88, N'PA', N'Pennsylvania ')
INSERT [dbo].[State] ([StateKey], [Abbr], [FullName]) VALUES (89, N'RI', N'Rhode Island')
INSERT [dbo].[State] ([StateKey], [Abbr], [FullName]) VALUES (90, N'SC', N'South Carolina')
INSERT [dbo].[State] ([StateKey], [Abbr], [FullName]) VALUES (91, N'SD', N'South Dakota')
INSERT [dbo].[State] ([StateKey], [Abbr], [FullName]) VALUES (92, N'TN', N'Tennessee ')
INSERT [dbo].[State] ([StateKey], [Abbr], [FullName]) VALUES (93, N'TX', N'Texas')
INSERT [dbo].[State] ([StateKey], [Abbr], [FullName]) VALUES (94, N'UT', N'Utah')
INSERT [dbo].[State] ([StateKey], [Abbr], [FullName]) VALUES (95, N'VT', N'Vermont')
INSERT [dbo].[State] ([StateKey], [Abbr], [FullName]) VALUES (96, N'VA', N'Virginia ')
INSERT [dbo].[State] ([StateKey], [Abbr], [FullName]) VALUES (97, N'WA', N'Washington')
INSERT [dbo].[State] ([StateKey], [Abbr], [FullName]) VALUES (98, N'WV', N'West Virginia')
INSERT [dbo].[State] ([StateKey], [Abbr], [FullName]) VALUES (99, N'WI', N'Wisconsin')
INSERT [dbo].[State] ([StateKey], [Abbr], [FullName]) VALUES (100, N'WY', N'Wyoming')
SET IDENTITY_INSERT [dbo].[State] OFF
SET IDENTITY_INSERT [dbo].[Status] ON 

INSERT [dbo].[Status] ([StatusKey], [StatusName]) VALUES (1, N'Student')
INSERT [dbo].[Status] ([StatusKey], [StatusName]) VALUES (2, N'Admin')
INSERT [dbo].[Status] ([StatusKey], [StatusName]) VALUES (3, N'Professor')
SET IDENTITY_INSERT [dbo].[Status] OFF
ALTER TABLE [dbo].[Class]  WITH CHECK ADD FOREIGN KEY([UserKey])
REFERENCES [dbo].[Users] ([UserKey])
GO
ALTER TABLE [dbo].[Files]  WITH CHECK ADD FOREIGN KEY([UserKey])
REFERENCES [dbo].[Users] ([UserKey])
GO
ALTER TABLE [dbo].[StudentClass]  WITH CHECK ADD FOREIGN KEY([ClassKey])
REFERENCES [dbo].[Class] ([ClassKey])
GO
ALTER TABLE [dbo].[StudentClass]  WITH CHECK ADD FOREIGN KEY([UserKey])
REFERENCES [dbo].[Users] ([UserKey])
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD FOREIGN KEY([EducationKey])
REFERENCES [dbo].[Education] ([EducationKey])
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD FOREIGN KEY([StateKey])
REFERENCES [dbo].[State] ([StateKey])
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD FOREIGN KEY([StatusKey])
REFERENCES [dbo].[Status] ([StatusKey])
GO

