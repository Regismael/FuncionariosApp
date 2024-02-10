CREATE TABLE FUNCIONARIO(

ID                  UNIQUEIDENTIFIER           PRIMARY KEY,
NOME                VARCHAR(150)               NOT NULL,
MATRICULA           VARCHAR(6)                 NOT NULL,
CPF                 VARCHAR(11)                NOT NULL,
DATAHORACADASTRO    DATETIME                   NOT NULL,
ATIVO               INT                        NOT NULL DEFAULT 1);
GO