create database Pessoa;
go
use Pessoa;
go
CREATE TABLE [dbo].[tabUsuario](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nome] [varchar](200) NOT NULL,
	[usuario] [varchar](100) NOT NULL,
	[senha] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE TABLE [dbo].[tabPessoa](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nome] [varchar](300) NOT NULL,
	[dataNascimento] [datetime] NOT NULL,
	[altura] [decimal](3, 2) NOT NULL,
	[peso] [decimal](6, 3) NOT NULL,
	[salario] [decimal](18, 2) NOT NULL,
	[saldo] [decimal](18, 2) NOT NULL,
	[idade] [int] NULL,
	[imc] [decimal](5, 2) NULL,
	[classificacao] [varchar](300) NULL,
	[inss] [decimal](18, 2) NULL,
	[aliquota] [decimal](5, 2) NULL,
	[salarioLiquido] [decimal](18, 2) NULL,
	[saldoDolar] [decimal](18, 2) NULL,
	[idUsuario] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO 
insert into tabUsuario (nome, usuario, senha)
values ('var', 'var', 'var');