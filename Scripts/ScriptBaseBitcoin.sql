CREATE DATABASE BaseBitcoin
GO

USE BaseBitcoin
GO

CREATE TABLE dbo.CotacaoBitcoin(
	UltimaAtualizacao DATETIME NOT NULL,
	VlCotacaoDolar NUMERIC (18,4) NOT NULL,
	CONSTRAINT PK_Indicadores PRIMARY KEY (UltimaAtualizacao)
)
GO
