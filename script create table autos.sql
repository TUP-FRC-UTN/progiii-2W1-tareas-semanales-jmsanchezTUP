USE [Programacion3]
GO

/****** Object:  Table [dbo].[Autos]    Script Date: 19-Jun-20 09:13:08 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Autos](
	[IdAuto] [int] IDENTITY(1,1) NOT NULL,
	[Patente] [varchar](20) NOT NULL,
	[IdMarca] [int] NOT NULL,
	[Km] [int] NOT NULL,
	[Promocion] [bit] NOT NULL,
	[Precio] [float] NOT NULL,
 CONSTRAINT [PK_Autos] PRIMARY KEY CLUSTERED 
(
	[IdAuto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


