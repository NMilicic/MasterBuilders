USE [MasterBuilders]
GO
/****** Object:  Table [dbo].[kategorija]    Script Date: 29.1.2017. 14:08:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[kategorija](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ime] [varchar](400) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[kategorija] ON 

INSERT [dbo].[kategorija] ([id], [ime]) VALUES (1, N'Technic Connectors')
INSERT [dbo].[kategorija] ([id], [ime]) VALUES (2, N'Minifigs')
INSERT [dbo].[kategorija] ([id], [ime]) VALUES (3, N'Bricks Curved')
INSERT [dbo].[kategorija] ([id], [ime]) VALUES (4, N'Bricks Round and Cones')
INSERT [dbo].[kategorija] ([id], [ime]) VALUES (5, N'Tiles Printed')
INSERT [dbo].[kategorija] ([id], [ime]) VALUES (6, N'Tiles')
INSERT [dbo].[kategorija] ([id], [ime]) VALUES (7, N'Bricks')
INSERT [dbo].[kategorija] ([id], [ime]) VALUES (8, N'Bricks Sloped')
INSERT [dbo].[kategorija] ([id], [ime]) VALUES (9, N'Other')
INSERT [dbo].[kategorija] ([id], [ime]) VALUES (10, N'Non-LEGO')
INSERT [dbo].[kategorija] ([id], [ime]) VALUES (11, N'Plates')
INSERT [dbo].[kategorija] ([id], [ime]) VALUES (12, N'Technic Beams')
INSERT [dbo].[kategorija] ([id], [ime]) VALUES (13, N'Tiles Special')
INSERT [dbo].[kategorija] ([id], [ime]) VALUES (14, N'Plates Special')
INSERT [dbo].[kategorija] ([id], [ime]) VALUES (15, N'Plates Round and Dishes')
INSERT [dbo].[kategorija] ([id], [ime]) VALUES (16, N'Power Functions, Mindstorms and Electric')
INSERT [dbo].[kategorija] ([id], [ime]) VALUES (17, N'Bricks Printed')
INSERT [dbo].[kategorija] ([id], [ime]) VALUES (18, N'Bricks Wedged')
INSERT [dbo].[kategorija] ([id], [ime]) VALUES (19, N'Duplo, Quatro and Primo')
INSERT [dbo].[kategorija] ([id], [ime]) VALUES (20, N'Plates Angled')
INSERT [dbo].[kategorija] ([id], [ime]) VALUES (21, N'Bars, Ladders and Fences')
INSERT [dbo].[kategorija] ([id], [ime]) VALUES (22, N'Minifig Accessories')
INSERT [dbo].[kategorija] ([id], [ime]) VALUES (23, N'Technic Bricks')
INSERT [dbo].[kategorija] ([id], [ime]) VALUES (24, N'Hinges, Arms and Turntables')
INSERT [dbo].[kategorija] ([id], [ime]) VALUES (25, N'Plants and Animals')
INSERT [dbo].[kategorija] ([id], [ime]) VALUES (26, N'Bricks Special')
INSERT [dbo].[kategorija] ([id], [ime]) VALUES (27, N'Containers')
INSERT [dbo].[kategorija] ([id], [ime]) VALUES (28, N'Flags, Signs, Plastics and Cloth')
INSERT [dbo].[kategorija] ([id], [ime]) VALUES (29, N'Clikits')
INSERT [dbo].[kategorija] ([id], [ime]) VALUES (30, N'Bionicle, Hero Factory and Constraction')
INSERT [dbo].[kategorija] ([id], [ime]) VALUES (31, N'Windscreens and Fuselage')
INSERT [dbo].[kategorija] ([id], [ime]) VALUES (32, N'Windows and Doors')
INSERT [dbo].[kategorija] ([id], [ime]) VALUES (33, N'Technic Bushes')
INSERT [dbo].[kategorija] ([id], [ime]) VALUES (34, N'Transportation - Land')
INSERT [dbo].[kategorija] ([id], [ime]) VALUES (35, N'Technic Panels')
INSERT [dbo].[kategorija] ([id], [ime]) VALUES (36, N'Transportation - Sea and Air')
INSERT [dbo].[kategorija] ([id], [ime]) VALUES (37, N'Wheels and Tyres')
INSERT [dbo].[kategorija] ([id], [ime]) VALUES (38, N'Rock')
INSERT [dbo].[kategorija] ([id], [ime]) VALUES (39, N'Belville, Scala and Fabuland')
INSERT [dbo].[kategorija] ([id], [ime]) VALUES (40, N'Panels')
INSERT [dbo].[kategorija] ([id], [ime]) VALUES (41, N'Technic Special')
INSERT [dbo].[kategorija] ([id], [ime]) VALUES (42, N'Tubes and Hoses')
INSERT [dbo].[kategorija] ([id], [ime]) VALUES (43, N'Technic Gears')
INSERT [dbo].[kategorija] ([id], [ime]) VALUES (44, N'Baseplates')
INSERT [dbo].[kategorija] ([id], [ime]) VALUES (45, N'Pneumatics')
INSERT [dbo].[kategorija] ([id], [ime]) VALUES (46, N'Technic Pins')
INSERT [dbo].[kategorija] ([id], [ime]) VALUES (47, N'Znap')
INSERT [dbo].[kategorija] ([id], [ime]) VALUES (48, N'Mechanical')
INSERT [dbo].[kategorija] ([id], [ime]) VALUES (49, N'HO Scale')
INSERT [dbo].[kategorija] ([id], [ime]) VALUES (50, N'String, Bands and Reels')
INSERT [dbo].[kategorija] ([id], [ime]) VALUES (51, N'Supports, Girders and Cranes')
INSERT [dbo].[kategorija] ([id], [ime]) VALUES (52, N'Technic Steering, Suspension and Engine')
INSERT [dbo].[kategorija] ([id], [ime]) VALUES (53, N'Magnets and Holders')
INSERT [dbo].[kategorija] ([id], [ime]) VALUES (54, N'Tools')
INSERT [dbo].[kategorija] ([id], [ime]) VALUES (55, N'Technic Axles')
INSERT [dbo].[kategorija] ([id], [ime]) VALUES (56, N'Technic Beams Special')
SET IDENTITY_INSERT [dbo].[kategorija] OFF

BEGIN
UPDATE [MasterBuilders].[dbo].[kockica]
SET [MasterBuilders].[dbo].[kockica].[kategorija] = [MasterBuilders].[dbo].[kategorija].[id]
FROM [MasterBuilders].[dbo].[kockica] JOIN [MasterBuilders].[dbo].[kategorija]
ON [MasterBuilders].[dbo].[kockica].[kategorija] = [MasterBuilders].[dbo].[kategorija].[ime]
END;

BEGIN
EXEC sp_RENAME 'kockica.kategorija', 'pomocno', 'COLUMN'
END;

BEGIN
ALTER TABLE [MasterBuilders].[dbo].[kockica]
add kategorija INT
END;

BEGIN
UPDATE [MasterBuilders].[dbo].[kockica]
SET kategorija = pomocno
END;

BEGIN
ALTER TABLE kockica
ADD FOREIGN KEY (kategorija)
REFERENCES kategorija(id)
END;