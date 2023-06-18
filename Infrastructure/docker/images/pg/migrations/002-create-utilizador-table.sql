CREATE TABLE Utilizadors (
     IdUtilizador             uuid PRIMARY KEY DEFAULT uuid_generate_v4(),
     Nome           VARCHAR(100) NOT NULL,
     nif            VARCHAR(10) NOT NULL,
     ncc            VARCHAR(10) NOT NULL,
     rua            VARCHAR(100) NOT NULL,
     n_porta        INT NOT NULL,
     username       VARCHAR(100) NOT NULL,
     pass           VARCHAR(100) NOT NULL,
     codpostal      VARCHAR(9) NOT NULL,
     tipoutilizador INT NOT NULL 
);