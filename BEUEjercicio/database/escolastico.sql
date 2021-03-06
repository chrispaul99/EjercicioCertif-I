USE [DBESCOLASTICO]
GO
/****** Object:  Table [dbo].[Alumno]    Script Date: 03/08/2020 21:35:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Alumno](
	[idalumno] [int] IDENTITY(1,1) NOT NULL,
	[nombres] [varchar](50) NULL,
	[apellidos] [varchar](50) NULL,
	[cedula] [varchar](13) NULL,
	[fecha_nacimiento] [date] NULL,
	[lugar_nacimiento] [varchar](50) NULL,
	[sexo] [nchar](1) NULL,
 CONSTRAINT [PK_Alumno] PRIMARY KEY CLUSTERED 
(
	[idalumno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Area]    Script Date: 03/08/2020 21:35:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Area](
	[idarea] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[coordinador] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Area] PRIMARY KEY CLUSTERED 
(
	[idarea] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Calificacion]    Script Date: 03/08/2020 21:35:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Calificacion](
	[idcalificacion] [int] IDENTITY(1,1) NOT NULL,
	[valor] [decimal](4, 2) NOT NULL,
	[fecha] [datetime] NOT NULL,
	[unidad] [nchar](1) NOT NULL,
	[idmatricula] [int] NOT NULL,
 CONSTRAINT [PK_Calificacion] PRIMARY KEY CLUSTERED 
(
	[idcalificacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Carrera]    Script Date: 03/08/2020 21:35:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Carrera](
	[idCarrera] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NOT NULL,
	[fecha_creacion] [date] NOT NULL,
	[director] [varchar](max) NOT NULL,
	[creditos_totales] [int] NOT NULL,
	[tipo] [varchar](100) NOT NULL,
	[descripcion] [varchar](max) NOT NULL,
	[mision] [varchar](max) NOT NULL,
	[vision] [varchar](max) NOT NULL,
	[modalidad] [nchar](1) NOT NULL,
	[estatus] [nchar](1) NOT NULL,
	[duracion] [int] NOT NULL,
	[resolucion_ces] [varchar](max) NOT NULL,
	[semanas_periodo] [int] NOT NULL,
	[requisitos] [varchar](max) NOT NULL,
	[escenarios_labo] [varchar](max) NOT NULL,
	[objeto_estudio] [varchar](max) NOT NULL,
 CONSTRAINT [PK_Carrera] PRIMARY KEY CLUSTERED 
(
	[idCarrera] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Materia]    Script Date: 03/08/2020 21:35:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Materia](
	[idmateria] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](75) NOT NULL,
	[nrc] [nchar](5) NOT NULL,
	[creditos] [smallint] NOT NULL,
	[idarea] [int] NOT NULL,
 CONSTRAINT [PK_Materia] PRIMARY KEY CLUSTERED 
(
	[idmateria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Matricula]    Script Date: 03/08/2020 21:35:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Matricula](
	[idmatricula] [int] IDENTITY(1,1) NOT NULL,
	[fecha] [datetime] NOT NULL,
	[costo] [decimal](18, 2) NOT NULL,
	[estado] [nchar](1) NOT NULL,
	[tipo] [nchar](1) NOT NULL,
	[idalumno] [int] NOT NULL,
	[idmateria] [int] NOT NULL,
 CONSTRAINT [PK_Matricula] PRIMARY KEY CLUSTERED 
(
	[idmatricula] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Alumno] ON 

INSERT [dbo].[Alumno] ([idalumno], [nombres], [apellidos], [cedula], [fecha_nacimiento], [lugar_nacimiento], [sexo]) VALUES (1011, N'Christian', N'Guanopatin', N'1234567890', CAST(N'1999-08-16' AS Date), N'Ambato', N'H')
INSERT [dbo].[Alumno] ([idalumno], [nombres], [apellidos], [cedula], [fecha_nacimiento], [lugar_nacimiento], [sexo]) VALUES (2003, N'Christian', N'Castro', N'1804582813', CAST(N'2020-07-14' AS Date), N'Ambato', N'H')
INSERT [dbo].[Alumno] ([idalumno], [nombres], [apellidos], [cedula], [fecha_nacimiento], [lugar_nacimiento], [sexo]) VALUES (2004, N'dsdsa', N'sdasd', N'1234567896', CAST(N'2020-08-18' AS Date), N'dsada', N'M')
SET IDENTITY_INSERT [dbo].[Alumno] OFF
SET IDENTITY_INSERT [dbo].[Area] ON 

INSERT [dbo].[Area] ([idarea], [nombre], [coordinador]) VALUES (12, N'Programacion', N'Javier Montaluisa')
SET IDENTITY_INSERT [dbo].[Area] OFF
SET IDENTITY_INSERT [dbo].[Carrera] ON 

INSERT [dbo].[Carrera] ([idCarrera], [nombre], [fecha_creacion], [director], [creditos_totales], [tipo], [descripcion], [mision], [vision], [modalidad], [estatus], [duracion], [resolucion_ces], [semanas_periodo], [requisitos], [escenarios_labo], [objeto_estudio]) VALUES (6, N'Software', CAST(N'2020-08-20' AS Date), N'Ing. Lucas Garces', 280, N'Postgrado', N'Es una disciplina formada por un conjunto de métodos, herramientas y técnicas que se utilizan en el desarrollo de los programas informáticos (software). Esta disciplina trasciende la actividad de programación, que es el pilar fundamental a la hora de crear una aplicación.', N'Formar Ingenieros de software competitivos, fomentando la investigación y desarrollo de tecnología de la información y comunicación para crear e innovar soluciones que contribuyan al desarrollo de la región y del país.', N'será un referente regional y nacional en la formación de ingenieros/a en software.', N'E', N'V', 10, N'RPC-SO-27-No.524-2008', 16, N'1. Poseer título de bachiller o su equivalente
2. Haber cumplido los requisitos normados por el sistema nacional de nivelación y admisión
3. El proceso de inscripción, evaluación y selección de aspirantes a las diferentes carreras de tercer nivel, será regentada en el estamento que corresponda.', N'• Industria de Software
• Empresas de investigación, innovación y desarrollo
• Empresas con unidades de desarrollo
• Empresas de auditoría y consultoría
• Área Académica', N'La formación profesional del Ingeniero de Software estudia las fases del proceso de desarrollo de software (análisis, diseño, implementación, pruebas, implantación, retiro y gestión), con un enfoque sistémico y cuantificable, que integre los componentes teórico, metodológico y buenas prácticas del desarrollo software; mediante la aplicación de: lenguajes de programación, métodos, técnicas, herramientas, normas y estándares; con el propósito de construir software de calidad que proporcione soluciones a las necesidades de los contextos de los diferentes sectores socio-económicos, productivos y
tecnológicos.')
INSERT [dbo].[Carrera] ([idCarrera], [nombre], [fecha_creacion], [director], [creditos_totales], [tipo], [descripcion], [mision], [vision], [modalidad], [estatus], [duracion], [resolucion_ces], [semanas_periodo], [requisitos], [escenarios_labo], [objeto_estudio]) VALUES (7, N' Electrónica y Instrumentacion', CAST(N'2015-06-19' AS Date), N'Pedro Olmedo', 300, N'Ingenieria', N'La carrera de Ingeniería Electrónica y Automatización se enfoca en el estudio de los métodos y tecnologías que permiten la automatización de sistemas, la comunicación de voz, datos e imágenes; así como la optimización de dispositivos que forman equipos más complejos.', N'Formar académicos, profesionales e investigadores de excelencia especializados en Electrónica y Automatización, creativos, humanistas, con capacidad de liderazgo, pensamiento crítico y alta conciencia ciudadana; para generar, aplicar y difundir el conocimiento. Con habilidad para trabajar en equipo, gestionar proyectos altamente productivos, fundamentados en la innovación, el mejoramiento continuo y, proporcionar e implementar alternativas de solución a los problemas del país, acordes con el Plan Nacional de Desarrollo.', N'Ser líder en la gestión del conocimiento y de la tecnología, en el ámbito de la Electrónica y Automatización, en el Sistema Nacional de Educación Superior, con prestigio Internacional y referente de práctica de valores éticos, cívicos y de servicio a la sociedad.', N'A', N'N', 10, N'RPC-SO-24-No-476-2015', 16, N'Generar Acta de Matrícula.
Fotocopia autenticada del diploma de bachiller o presentar original y copia.
Fotocopia autenticada del Acta de grado de bachiller o presentar original y copia.
Una fotografía tamaño 3x4.
Certificado de presentación del examen de estado ICFES.', N'Empresas nacionales e internacionales del sector industrial y de manufactura.

Empresas de servicios relacionados con la ingeniería en electrónica.

Empresas de servicios relacionados con la ingeniería en automatización.

Instituciones académicas y de investigación.

Instituciones públicas y privadas cuyo ámbito de acción esté relacionado con el fomento de la competitividad industrial.

Empresas de emprendimiento con base tecnológica, entre otras.', N'La Ingeniería Electrónica tiene como objeto de estudio el análisis de tecnologías, que abarca desde el diseño hasta la aplicación de los múltiples componentes electrónicos existentes.')
SET IDENTITY_INSERT [dbo].[Carrera] OFF
SET IDENTITY_INSERT [dbo].[Materia] ON 

INSERT [dbo].[Materia] ([idmateria], [nombre], [nrc], [creditos], [idarea]) VALUES (7, N'Fundamentos de programacion', N'1234 ', 10, 12)
INSERT [dbo].[Materia] ([idmateria], [nombre], [nrc], [creditos], [idarea]) VALUES (8, N'Certificación I', N'7898 ', 10, 12)
SET IDENTITY_INSERT [dbo].[Materia] OFF
ALTER TABLE [dbo].[Calificacion]  WITH CHECK ADD  CONSTRAINT [FK_Calificacion_Matricula] FOREIGN KEY([idmatricula])
REFERENCES [dbo].[Matricula] ([idmatricula])
GO
ALTER TABLE [dbo].[Calificacion] CHECK CONSTRAINT [FK_Calificacion_Matricula]
GO
ALTER TABLE [dbo].[Materia]  WITH CHECK ADD  CONSTRAINT [FK_Materia_Area] FOREIGN KEY([idarea])
REFERENCES [dbo].[Area] ([idarea])
GO
ALTER TABLE [dbo].[Materia] CHECK CONSTRAINT [FK_Materia_Area]
GO
ALTER TABLE [dbo].[Matricula]  WITH CHECK ADD  CONSTRAINT [FK_Matricula_Alumno] FOREIGN KEY([idalumno])
REFERENCES [dbo].[Alumno] ([idalumno])
GO
ALTER TABLE [dbo].[Matricula] CHECK CONSTRAINT [FK_Matricula_Alumno]
GO
ALTER TABLE [dbo].[Matricula]  WITH CHECK ADD  CONSTRAINT [FK_Matricula_Materia] FOREIGN KEY([idmateria])
REFERENCES [dbo].[Materia] ([idmateria])
GO
ALTER TABLE [dbo].[Matricula] CHECK CONSTRAINT [FK_Matricula_Materia]
GO
