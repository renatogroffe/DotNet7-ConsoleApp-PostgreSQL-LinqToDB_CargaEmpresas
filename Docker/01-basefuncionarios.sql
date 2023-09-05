CREATE DATABASE basefuncionarios;

\c basefuncionarios;

CREATE TABLE "Funcionarios" (
    "Id" SERIAL NOT NULL,
    "Nome" VARCHAR(100) NOT NULL,
    "Email" VARCHAR(120) NOT NULL,
    "Cidade" VARCHAR(100) NOT NULL,
    "Pais" VARCHAR(50) NOT NULL,
    CONSTRAINT "PK_Funcionarios" PRIMARY KEY ("Id")
);