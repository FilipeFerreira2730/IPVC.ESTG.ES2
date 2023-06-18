CREATE TABLE Depositos (
                          iddeposito      uuid PRIMARY KEY DEFAULT uuid_generate_v4(),
                          banco           VARCHAR(100) NOT NULL,
                          titulares       VARCHAR(255) NOT NULL,
                          valor           FLOAT NOT NULL,
                          taxajuro        FLOAT NOT NULL,
                          nconta          VARCHAR(100) NOT NULL,
                          idativofk         uuid NOT NULL,
                          FOREIGN KEY (idativofk) REFERENCES "Ativofinanceiro"(idativo)
);
