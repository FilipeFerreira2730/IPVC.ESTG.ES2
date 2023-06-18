CREATE TABLE Fundos (
                       idfundo         uuid PRIMARY KEY DEFAULT uuid_generate_v4(),
                       nome            VARCHAR(100) NOT NULL,
                       montante        FLOAT NOT NULL,
                       taxajuro        FLOAT NOT NULL,
                       idativofk         uuid NOT NULL,
                       FOREIGN KEY (idativofk) REFERENCES "Ativofinanceiro"(idativo)
);
