CREATE TABLE Ativofinanceiros (
                                 idativo         uuid PRIMARY KEY DEFAULT uuid_generate_v4(),
                                 datainicio      DATE NOT NULL,
                                 duracao        INT NOT NULL,
                                 taxaimposto     FLOAT NOT NULL,
                                 idcliente       uuid NOT NULL,
                                 FOREIGN KEY (idcliente) REFERENCES "Utilizador"("IdUtilizador")
);
