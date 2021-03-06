CREATE DATABASE SINCOABR
GO 
USE SINCOABR
GO
CREATE TABLE MATERIA(
ID_MATERIA INT IDENTITY(1,1) PRIMARY KEY NOT NULL, 
NOMBRE VARCHAR(50) NOT NULL, 
DESCRIPCION VARCHAR(50)
)
GO
CREATE TABLE PROFESOR(
ID_PROFESOR VARCHAR(15) PRIMARY KEY NOT NULL,
NOMBRE VARCHAR(30) NOT NULL,
APELLIDO VARCHAR(30) NOT NULL, 
TELEFONO VARCHAR(15) NOT NULL,
)
GO
CREATE TABLE ALUMNO(
ID_ALUMNO VARCHAR(15) PRIMARY KEY NOT NULL,
NOMBRE VARCHAR(30) NOT NULL, 
APELLIDO VARCHAR(30) NOT NULL,
TELEFONO VARCHAR(30) NOT NULL
)
GO
CREATE TABLE CURSO(
ID_CURSO INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
ID_MATERIA INT NOT NULL, 
ID_PROFESOR VARCHAR(15) NOT NULL,
FOREIGN KEY (ID_MATERIA) REFERENCES MATERIA(ID_MATERIA),
FOREIGN KEY (ID_PROFESOR) REFERENCES PROFESOR(ID_PROFESOR)
)
GO
CREATE TABLE INCRIPCION(
ID_INCRIPCION INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
ID_CURSO INT NOT NULL,
ID_ALUMNO VARCHAR(15) NOT NULL,
NOTA1 SMALLINT DEFAULT 0,
NOTA2 SMALLINT DEFAULT 0,
FOREIGN KEY (ID_CURSO) REFERENCES CURSO(ID_CURSO),
FOREIGN KEY (ID_ALUMNO) REFERENCES ALUMNO(ID_ALUMNO)
)