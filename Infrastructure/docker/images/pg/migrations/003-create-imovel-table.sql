CREATE TABLE Imovels (
                        idimovel        uuid PRIMARY KEY DEFAULT uuid_generate_v4(),
                        nome            VARCHAR(100) NOT NULL,
                        valorrenda      FLOAT NOT NULL,
                        valorcondo      FLOAT NOT NULL,
                        valoresti       FLOAT NOT NULL,
                        rua             VARCHAR(100) NOT NULL,
                        nporta          VARCHAR(10) NOT NULL,
                        idativofk         uuid NOT NULL,
                        codpostal       VARCHAR(20) NOT NULL,
                        FOREIGN KEY (codpostal) REFERENCES "Codpostals"(codpostal1),
                        FOREIGN KEY (idativofk) REFERENCES "Ativofinanceiro"(idativo)
);
