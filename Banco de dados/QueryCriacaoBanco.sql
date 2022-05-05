USE master
GO

CREATE DATABASE LocacaoVeiculo
GO

USE LocacaoVeiculo
GO

CREATE TABLE Endereco 
(
	ID INT NOT NULL,
	CEP VARCHAR (MAX) NOT NULL,
	Rua VARCHAR(MAX) NOT NULL,
	Bairro VARCHAR(MAX) NOT NULL,
	Numero INT NOT NULL,
	Complemento VARCHAR(MAX)	
)
GO

CREATE TABLE Cliente
(
	ID INT NOT NULL,
	CPF VARCHAR(MAX) NOT NULL,
	Nome VARCHAR(MAX) NOT NULL,
	Email VARCHAR(MAX),
	Telefone VARCHAR(MAX) NOT NULL,
	DataCadastro DATE NOT NULL,
	ID_Endereco INT NOT NULL
)
GO

CREATE TABLE Locacao
(
	ID INT NOT NULL,
	DataLocacao DATE NOT NULL,
	StatusLocacao VARCHAR(MAX) NOT NULL,
	Valor MONEY NOT NULL,
	QtdVeiculos INT NOT NULL,
	ID_Cliente INT NOT NULL
)
GO

CREATE TABLE Devolucao
(
	ID INT NOT NULL,
	DataDevolucao DATETIME NOT NULL,
	ValorDevolucao MONEY NOT NULL,
	MetodoPagamento VARCHAR(MAX) NOT NULL,
	Observacoes VARCHAR(MAX),
	ID_Locacao INT NOT NULL
)
GO

CREATE TABLE LocacaoVeiculo
(	
	ID INT NOT NULL, 
	ID_Veiculo INT NOT NULL
)
GO

CREATE TABLE Veiculo
(
	ID INT NOT NULL,
	UltimaRevisao DATE NOT NULL,
	Quilometragem INT NOT NULL,
	Cor VARCHAR(MAX) NOT NULL,
	Placa VARCHAR(MAX) NOT NULL,
	ID_Categoria INT NOT NULL
)
GO

CREATE TABLE Categoria
(
	ID INT NOT NULL,
	Descricao VARCHAR(MAX) NOT NULL,
	Finalidade VARCHAR(MAX) NOT NULL,
	Tamanho VARCHAR(MAX) NOT NULL
)
GO

ALTER TABLE Endereco
ADD CONSTRAINT PK_Endereco
PRIMARY KEY (ID)
GO

ALTER TABLE Cliente
ADD CONSTRAINT PK_Cliente
PRIMARY KEY (ID)
GO

ALTER TABLE Locacao
ADD CONSTRAINT PK_Locacao
PRIMARY KEY (ID)
GO

ALTER TABLE Veiculo
ADD CONSTRAINT PK_Veiculo
PRIMARY KEY (ID)
GO

ALTER TABLE Categoria
ADD CONSTRAINT PK_Categoria
PRIMARY KEY (ID)
GO

ALTER TABLE Devolucao
ADD CONSTRAINT PK_Devolucao
PRIMARY KEY (ID)
GO

ALTER TABLE Cliente
ADD CONSTRAINT FK_Endereco
FOREIGN KEY (ID_Endereco)
REFERENCES Endereco (ID)
GO

ALTER TABLE Locacao
ADD CONSTRAINT FK_Cliente
FOREIGN KEY (ID_Cliente)
REFERENCES Cliente (ID)
GO

ALTER TABLE Devolucao
ADD CONSTRAINT FK_LocacaoDevolucao
FOREIGN KEY (ID_Locacao)
REFERENCES Locacao (ID)
GO

ALTER TABLE LocacaoVeiculo
ADD CONSTRAINT FK_Veiculo
FOREIGN KEY (ID_Veiculo)
REFERENCES Veiculo (ID) ON DELETE CASCADE
GO

ALTER TABLE LocacaoVeiculo
ADD CONSTRAINT FK_Locacao
FOREIGN KEY (ID)
REFERENCES Locacao (ID) 
GO

ALTER TABLE Veiculo
ADD CONSTRAINT FK_Categoria
FOREIGN KEY (ID_Categoria)
REFERENCES Categoria (ID)
GO

-- Seção de Stored Procedures ESPECÍFICAS PARA CADA CRUD--------------------------------------------------------------------------------------------------------------------------------------------------

--CRUD Veículo------------------------------------------------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE spIncluiVeiculo 
(
	@id int,		
	@ultimaRevisao date,
	@quilometragem int,
	@cor varchar(max),
	@placa varchar(max),
	@id_Categoria int
)
AS 
BEGIN
	INSERT INTO 
	Veiculo(ID, UltimaRevisao, Quilometragem, Cor, Placa, ID_Categoria)
	VALUES
	(@id, @ultimaRevisao, @quilometragem, @cor, @placa, @id_Categoria)
END

GO



CREATE PROCEDURE spAlteraVeiculo
(
	@id int,	
	@ultimaRevisao date,
	@quilometragem int,
	@cor varchar(max),
	@placa varchar(max),
	@id_Categoria int	
)
AS
BEGIN
	UPDATE Veiculo set		   
		   UltimaRevisao = @ultimaRevisao,
		   Quilometragem = @quilometragem,
		   Cor = @cor,
		   Placa = @placa,
		   ID_Categoria = @id_Categoria
		   where ID = @id
END

GO



CREATE PROCEDURE spExcluiVeiculo
(
	@id int
)
AS
BEGIN
	DELETE Veiculo where ID = @id
END

GO



CREATE PROCEDURE spConsultaVeiculo
(
	@id int
)
AS
BEGIN
	SELECT * FROM Veiculo where ID = @id
END

GO



CREATE PROCEDURE spListaVeiculos
AS
BEGIN
	SELECT * FROM Veiculo 
END

GO



---CRUD CATEGORIAS

CREATE PROCEDURE spIncluiCategoria
(
	@id INT,
	@descricao VARCHAR(MAX),
	@finalidade VARCHAR(MAX),
	@tamanho VARCHAR(MAX) 
)
AS 
BEGIN
	INSERT INTO Categoria(ID, Descricao, Finalidade, Tamanho)
	VALUES(@id, @descricao, @finalidade, @tamanho)	
END
	
GO



CREATE PROCEDURE spAlteraCategoria
(
	@id INT,
	@descricao VARCHAR(MAX),
	@finalidade VARCHAR(MAX),
	@tamanho VARCHAR(MAX) 
)
AS
BEGIN
	UPDATE Categoria set	      
		   Descricao = @descricao,
		   Finalidade = @finalidade,
		   Tamanho = @tamanho
		   where ID = @id
END

GO

CREATE PROCEDURE spExcluiCategoria
(
	@id int
)
AS
BEGIN
	DELETE Categoria where ID = @id
END

GO



CREATE PROCEDURE spConsultaCategoria( @id int )
AS
BEGIN
	SELECT * FROM Categoria where ID = @id
END

GO



CREATE PROCEDURE spListaCategorias
AS 
BEGIN
	SELECT * FROM Categoria
END


GO


--CRUD CLIENTE-------------------------------------------------------------------

CREATE PROCEDURE spIncluiCliente
(
	@id INT,
	@cpf VARCHAR(MAX),
	@nome VARCHAR(MAX),
	@email VARCHAR(MAX),
	@telefone VARCHAR(MAX),
	@dataCadastro DATE,
	@id_Endereco INT
)
AS
BEGIN
	INSERT INTO Cliente(ID, CPF, Nome, Email, Telefone, DataCadastro, ID_Endereco)
	VALUES(@id, @cpf, @nome, @email, @telefone, @dataCadastro, @id_Endereco)
END

GO



CREATE PROCEDURE spAlteraCliente
(
	@id INT,
	@cpf VARCHAR(MAX),
	@nome VARCHAR(MAX),
	@email VARCHAR(MAX),
	@telefone VARCHAR(MAX),
	@dataCadastro DATE,
	@id_Endereco INT
)
AS
BEGIN
	UPDATE Cliente set
		   CPF = @cpf,
		   Nome = @nome,
		   Email = @email,
		   Telefone = @telefone,
		   DataCadastro = @dataCadastro,
		   ID_Endereco = @id_Endereco
		   where ID = @id
END 

GO


CREATE PROCEDURE spExcluiCliente
( @id INT )
AS
BEGIN
	DELETE Cliente where ID = @id
END

GO


CREATE PROCEDURE spConsultaCliente
( @id INT )
AS
BEGIN
	SELECT * FROM Cliente where ID = @id
END

GO


CREATE PROCEDURE spListaClientes
AS
BEGIN
	SELECT * FROM Cliente
END

GO


--------------------- CRUD ENDEREÇOS --------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE spIncluiEndereco
(
	@id int,
	@cep VARCHAR(MAX),
	@rua VARCHAR(MAX),
	@bairro VARCHAR(MAX),
	@numero INT,
	@complemento VARCHAR(MAX)
)
AS
BEGIN
	INSERT INTO Endereco(ID, CEP, Rua, Bairro, Numero, Complemento)
	VALUES(@id, @cep, @rua, @bairro, @numero, @complemento)
END

GO




CREATE PROCEDURE spAlteraEndereco
(
	@id int,
	@cep VARCHAR(MAX),
	@rua VARCHAR(MAX),
	@bairro VARCHAR(MAX),
	@numero INT,
	@complemento VARCHAR(MAX)
)
AS
BEGIN
	UPDATE Endereco set
	CEP = @cep,
	Rua = @rua,
	Bairro = @bairro,
	Numero = @numero,
	Complemento = @complemento
	where ID = @id
END

GO

CREATE PROCEDURE spExcluiEndereco( @id int )
AS
BEGIN	
	DELETE Endereco where ID = @id
END

GO





CREATE PROCEDURE spConsultaEndereco( @id int )
AS 
BEGIN
	SELECT * FROM Endereco where ID = @id
END


GO



CREATE PROCEDURE spListaEnderecos
AS 
BEGIN
	SELECT * FROM Endereco
END


GO



--------------------------- CRUD LOCAÇÃO --------------------------------------------------------------------------------------------------

CREATE PROCEDURE spIncluiLocacao
(
	@id INT,
	@dataLocacao DATE,
	@statusLocacao VARCHAR(MAX),
	@valor MONEY,
	@qtdVeiculos INT,
	@id_Cliente INT
)
AS
BEGIN	
		INSERT INTO Locacao(ID, DataLocacao, StatusLocacao, Valor, QtdVeiculos, ID_Cliente)
		VALUES(@id, @dataLocacao, @statusLocacao, @valor, @qtdVeiculos, @id_Cliente)
END

GO



CREATE PROCEDURE spAlteraLocacao
(
	@id INT,
	@dataLocacao DATE,
	@statusLocacao VARCHAR(MAX),
	@valor MONEY,
	@qtdVeiculos INT,
	@id_Cliente INT
)
AS
BEGIN
	UPDATE Locacao set
	DataLocacao = @dataLocacao,
	StatusLocacao = @statusLocacao,
	Valor = @valor,
	QtdVeiculos = @qtdVeiculos,
	ID_Cliente = @id_Cliente
	where ID = @id
END

GO

--Exclui a locação e também exclui os registros dessa locação na tabela LocacaoVeiculo (Controle de Transação). [MAS TEM AS SPS GENÉRICAS PRA ISSO].
--CREATE PROCEDURE spExcluiLocacao( @id int )
--AS
--BEGIN
--	BEGIN TRANSACTION
--	DELETE Locacao where ID = @id	
--	DELETE LocacaoVeiculo WHERE ID = @id

--	COMMIT TRANSACTION	
--END

--GO



CREATE PROCEDURE spConsultaLocacao( @id int )
AS
BEGIN
	SELECT * FROM Locacao where ID = @id
END

GO



CREATE PROCEDURE spListaLocacao
AS
BEGIN
	SELECT * FROM Locacao
END

GO

--------------------------- CRUD TABELA INTERMEDIÁRIA LOCACAO_VEICULO ---------------------------------------------------------------------------------------

--CONTROLE DE TRANSAÇÃO (COMMIT).
CREATE PROCEDURE spIncluiLocacaoVeiculo
(
	@id INT, -- ID é o mesmo que ID_Locacao.
	@id_Veiculo INT
)
AS
BEGIN
 
	DECLARE @cont INT --Variável para contar a quantidade de veículos em uma locação
	SET @cont = (SELECT COUNT(*) FROM LocacaoVeiculo WHERE ID = @id) --Vai fazer um subselect para contar os veículos na locação
		

	BEGIN TRANSACTION
		INSERT INTO LocacaoVeiculo(ID, ID_Veiculo) --Inserindo mais um veículo na locação
		VALUES(@id, @id_Veiculo)

		SET @cont = @cont + 1 --Aumenta a quantidade de veículos na locação

		UPDATE Locacao SET --Altera a tabela Locacao
		QtdVeiculos = @cont --Atualiza a quantidade de veículos
		WHERE ID = @id

		COMMIT TRANSACTION
END

GO





CREATE PROCEDURE spAlteraLocacaoVeiculo
(
	@ID INT,
	@id_Veiculo INT
)
AS
BEGIN
	UPDATE LocacaoVeiculo set
			ID_Veiculo = @id_Veiculo
			where ID = @ID
END

GO


--Na verdade, a spExcluiLocacao já exclui os registros na tabela LocacaoVeiculo também.
CREATE PROCEDURE spExcluiLocacaoVeiculo
( @id int )
AS
BEGIN
	DELETE LocacaoVeiculo where ID = @id      
END

GO





--caso seja necessário... :

CREATE PROCEDURE spConsultaLocacaoVeiculo( @id int )
AS 
BEGIN
	SELECT * FROM LocacaoVeiculo where ID = @id  
END

GO


CREATE PROCEDURE spListaLocacaoVeiculo
AS
BEGIN
	SELECT * FROM LocacaoVeiculo
END

GO


-------------------------------------- CRUD DEVOLUÇÃO ------------------------------------------------------------------------------------------

CREATE PROCEDURE spIncluiDevolucao
(
	@id INT,
	@dataDevolucao DATETIME,
	@valorDevolucao MONEY,
	@metodoPagamento VARCHAR(MAX),
	@observacoes VARCHAR(MAX),
	@id_Locacao INT
)
AS
BEGIN
	INSERT INTO Devolucao(ID, DataDevolucao, ValorDevolucao, MetodoPagamento, Observacoes, ID_Locacao)
	VALUES(@id, @dataDevolucao, @valorDevolucao, @metodoPagamento, @observacoes, @id_Locacao)
END

GO



CREATE PROCEDURE spAlteraDevolucao
(
	@id INT,
	@dataDevolucao DATETIME,
	@valorDevolucao MONEY,
	@metodoPagamento VARCHAR(MAX),
	@observacoes VARCHAR(MAX),
	@id_Locacao INT
)
AS
BEGIN
	UPDATE Devolucao set
	DataDevolucao = @dataDevolucao,
	ValorDevolucao = @valorDevolucao,
	MetodoPagamento = @metodoPagamento,
	Observacoes = @observacoes,
	ID_Locacao = @id_Locacao
	where ID = @id
END

GO



CREATE PROCEDURE spExcluiDevolucao( @id int )
AS 
BEGIN
	DELETE Devolucao where ID = @id
END

GO



CREATE PROCEDURE spConsultaDevolucao( @id int )
AS
BEGIN
	SELECT * FROM Devolucao where ID = @id
END

GO



CREATE PROCEDURE spListaDevolucoes
AS
BEGIN
	SELECT * FROM Devolucao
END

GO

----------------------------- FIM DA SEÇÃO DE STORED PROCEDURES ESPECÍFICAS --------------------------------------------------------------------------------------------
--OBS: As stored procedures foram implementadas imaginando que cada cadastro (cada CRUD) é uma tela diferentE (uma CRUD por tabela).


------------------------------------SEÇÃO DE STORED PROCEDURES GENÉRICAS--------------------------------------------------------------------------------------

create procedure spDelete 
(   @id int  ,   
	@tabela varchar(max) 
) 
as 
begin    
	declare @sql varchar(max);    
	set @sql = ' delete ' + @tabela + ' where id = ' + cast(@id as varchar(max))    
	exec(@sql) 
end  
GO   



create procedure spConsulta 
(   @id int  ,   
	@tabela varchar(max) 
) 
as 
begin    
	declare @sql varchar(max);    
	set @sql = 'select * from  ' + @tabela + ' where id = ' + cast(@id as varchar(max))    
	exec(@sql) 
end 
GO  



create procedure spListagem 
(    
	@tabela varchar(max),    
	@ordem varchar(max)
) 
as 
begin    
	exec('select * from ' + @tabela + ' order by ' + @ordem) 
end 
GO   


CREATE PROCEDURE spProximoId
(@tabela VARCHAR(max))
AS
BEGIN
	EXEC('select isnull(max(id) +1, 1) as MAIOR from ' +@tabela) -- A tabela é definida na aplicação c# (no método de cada DAO).
END

GO


-------------------------------------------- FIM DA SEÇÃO DE SPs GENÉRICAS -----------------------------------------------------------------------------------------------------
--

--drop database LocacaoVeiculo

--use Vendas

--use LocacaoVeiculo

--select * from Categoria

--select * from Cliente

--select * from Endereco

--select * from Locacao

--select * from Veiculo

--select * from LocacaoVeiculo

---------------------------------------------------------- IMAGENS --------------------------------------------------------------------------------------------------------------

ALTER TABLE Veiculo ADD Imagem VARBINARY(max);
GO

ALTER PROCEDURE spAlteraVeiculo
(
	@id int,	
	@ultimaRevisao date,
	@quilometragem int,
	@cor varchar(max),
	@placa varchar(max),
	@id_Categoria int,
	@imagem varbinary(max)
)
AS
BEGIN
	UPDATE Veiculo set		   
		   UltimaRevisao = @ultimaRevisao,
		   Quilometragem = @quilometragem,
		   Cor = @cor,
		   Placa = @placa,
		   ID_Categoria = @id_Categoria,
		   Imagem = @imagem
		   where ID = @id
END

GO


ALTER PROCEDURE spIncluiVeiculo 
(
	@id int,		
	@ultimaRevisao date,
	@quilometragem int,
	@cor varchar(max),
	@placa varchar(max),
	@id_Categoria int,
	@imagem varbinary(max)
)
AS 
BEGIN
	INSERT INTO 
	Veiculo(ID, UltimaRevisao, Quilometragem, Cor, Placa, ID_Categoria, Imagem)
	VALUES
	(@id, @ultimaRevisao, @quilometragem, @cor, @placa, @id_Categoria, @imagem)
END

GO

----------------------------------------------------FUNCTIONS PARA FILTRO LOCACAO-----------------------------------------------------------------------------------------------

CREATE FUNCTION ConsultaLocacaoComFiltroValorIgual
(	
	@valor MONEY
	--@tabela varchar(max)
)
RETURNS TABLE
AS
RETURN
(
	SELECT * FROM Locacao WHERE Valor = @valor
)

GO
	

CREATE FUNCTION ConsultaLocacaoComFiltroValorMaior
(	
	@valor MONEY
	--@tabela varchar(max)
)
RETURNS TABLE
AS
RETURN
(
	SELECT * FROM Locacao WHERE Valor > @valor
)

GO

CREATE FUNCTION ConsultaLocacaoComFiltroValorMenor
(	
	@valor MONEY
	--@tabela varchar(max)
)
RETURNS TABLE
AS
RETURN
(
	SELECT * FROM Locacao WHERE Valor < @valor
)

GO


CREATE FUNCTION ConsultaLocacaoComFiltroDataIgual
(	
	@data DATE
	--@tabela varchar(max)
)
RETURNS TABLE
AS
RETURN
(
	SELECT * FROM Locacao WHERE DataLocacao = @data
)

GO



CREATE FUNCTION ConsultaLocacaoComFiltroDataMaior
(	
	@data DATE
	--@tabela varchar(max)
)
RETURNS TABLE
AS
RETURN
(
	SELECT * FROM Locacao WHERE DataLocacao > @data
)

GO



CREATE FUNCTION ConsultaLocacaoComFiltroDataMenor
(	
	@data DATE
	--@tabela varchar(max)
)
RETURNS TABLE
AS
RETURN
(
	SELECT * FROM Locacao WHERE DataLocacao < @data
)

GO





----------------------------------------------------------------------------INSERÇÕES---------------------------------------------------------------------------


USE LocacaoVeiculo
INSERT INTO Endereco(ID, CEP, Rua, Bairro, Numero, Complemento) values (1, '09321432', 'Rua Havai', 'Cerâmica', 821, 'Apartamento 654')
INSERT INTO Cliente(ID, CPF, Nome, Email, Telefone, DataCadastro, ID_Endereco) values (2, '3214312321', 'Fabiana', 'fabiana@gmail.com', '32134432', '2021-01-09', 1)
INSERT INTO Categoria(ID, Descricao, Finalidade, Tamanho) values (1, 'Hatch', 'Urbano', 'Pequeno')
INSERT INTO Locacao(ID, DataLocacao, StatusLocacao, Valor, QtdVeiculos, ID_Cliente) values (2, '2021-02-25', 'Ativo', 3214, 0, 2)

GO

--use Vendas
--drop database LocacaoVeiculo
--select * from Endereco
--select * from Cliente
--select * from LocacaoVeiculo
-- use LocacaoVeiculo

-----------------------------------------------------------------------TRIGGERS-------------------------------------------------------------------------------

-- A data de locação não pode ser anterior à data de devolução. 
-- Eu não posso alugar um carro no dia 05/06/2021 para devolver no dia 01/06/2021.
-- O Objetivo dessa trigger é evitar isso.
CREATE TRIGGER trg_VerificaDatas ON Devolucao
FOR INSERT AS
BEGIN
	DECLARE @IDLocacao INT
	DECLARE @dataLocacao DATE
	DECLARE @dataDevolucao DATE

	SET @dataDevolucao = CAST((SELECT DataDevolucao FROM inserted) AS DATE)
	SET @IDLocacao = (SELECT ID_Locacao FROM inserted)
	SET @dataLocacao = (SELECT DataLocacao FROM Locacao WHERE ID = @IDLocacao)

	IF DATEDIFF(DAY, @dataLocacao, @dataDevolucao) < 0
	BEGIN
		PRINT 'A data de devolução não pode ser anterior à data de locação!!!'

		ROLLBACK TRAN
		RETURN
	END
END

GO


-- Quando uma locação é deletada, eu preciso deletar todos os registros dessa locação na tabela LocacaoVeiculo.
-- O objetivo dessa trigger é atualizar a tabela LocacaoVeiculo depois que uma locação foi deletada na tabela Locação.
CREATE TRIGGER trg_Atualiza_LocacaoVeiculo on Locacao
FOR DELETE AS
BEGIN
	DECLARE @idLocacao INT
	SET @idLocacao = (SELECT ID FROM deleted)

	EXEC spDelete @idLocacao, 'LocacaoVeiculo'
END

GO



-- Menor email válido: xy@aa.com
--
CREATE TRIGGER trg_ValidaEmail on Cliente 
FOR INSERT AS 
BEGIN
	DECLARE @email VARCHAR(MAX)
	SET @email = (SELECT Email FROM inserted)

	IF CHARINDEX('@', @email) = 0
	BEGIN
		PRINT 'E-mail inválido'
		ROLLBACK TRAN
		RETURN
	END

	IF CHARINDEX('.', @email) < 6
	BEGIN
		PRINT 'E-mail inválido'
		ROLLBACK TRAN
		RETURN
	END

	IF CHARINDEX('.', @email) - CHARINDEX('@', @email) < 3
	BEGIN
		PRINT 'E-mail inválido'
		ROLLBACK TRAN
		RETURN
	END

	IF CHARINDEX('@', @email) < 3
	BEGIN
		PRINT 'E-mail inválido'
		ROLLBACK TRAN
		RETURN
	END
END
	
----------------------------------------------------------------------------ÍNDICES-----------------------------------------------------------------------------------------------------

-- Index para uma tabela muito consultada.
--CREATE CLUSTERED INDEX idx_LocacaoVeiculo_ID ON dbo.LocacaoVeiculo(ID)
--DROP INDEX idx_Locacao_ID ON dbo.LocacaoVeiculo





	