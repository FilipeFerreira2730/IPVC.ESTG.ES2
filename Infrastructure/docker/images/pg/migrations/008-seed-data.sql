-- Insert initial data into the utilizadors table                                                                                                       
INSERT INTO "Utilizador" ("Nome", nif, ncc, rua, n_porta, username, pass, codpostal, tipoutilizador)
VALUES
    ('João Silva', '123456789', '987654321', 'Rua A', 123, 'joao', 'senha123', '12345', 1),
    ('Maria Santos', '987654321', '123456789', 'Rua B', 456, 'maria', 'senha456', '54321', 2);


-- Insert initial data into the imovels table                                                                                                         
INSERT INTO "Imovels" (nome, valorrenda, valorcondo, valoresti, rua, nporta, codpostal, idativofk)
VALUES
    ('Casa Azul', 1000.00, 200.00, 500.00, 'Rua X', '123', '12345-678', (SELECT idativo FROM "Ativofinanceiro" LIMIT 1 OFFSET 0)),
    ('Apartamento Vermelho', 800.00, 150.00, 400.00, 'Rua Y', '456', '98765-432', (SELECT idativo FROM "Ativofinanceiro" LIMIT 1 OFFSET 1));


-- Insert initial data into the fundos table  
INSERT INTO "Fundos" (nome, montante, taxajuro, idativofk)
VALUES
    ('Fundo A', 10000.00, 0.05, (SELECT idativo FROM "Ativofinanceiro" LIMIT 1 OFFSET 0)),
    ('Fundo B', 20000.00, 0.06, (SELECT idativo FROM "Ativofinanceiro" LIMIT 1 OFFSET 1));


-- Insert initial data into the depositos table
INSERT INTO "Depositos" (banco, titulares, valor, taxajuro, nconta, idativofk)
VALUES
    ('Banco X', 'João Silva', 5000.00, 0.03, '123456789', (SELECT idativo FROM "Ativofinanceiro" LIMIT 1 OFFSET 0)),
    ('Banco Y', 'Maria Santos', 8000.00, 0.04, '987654321', (SELECT idativo FROM "Ativofinanceiro" LIMIT 1 OFFSET 1));


-- Insert initial data into the codpostals table
INSERT INTO "Codpostals" (codpostal1, localidade)
VALUES
    ('12345-678', 'Localidade A'),
    ('98765-432', 'Localidade B');


-- Insert initial data into the ativofinanceiro table
INSERT INTO "Ativofinanceiro" (datainicio, duracao, taxaimposto, idcliente)
VALUES
    ('2023-01-01', 10, 0.2, (SELECT "IdUtilizador" FROM "Utilizador" LIMIT 1 OFFSET 0)),
    ('2023-02-01', 5, 0.15, (SELECT "IdUtilizador" FROM "Utilizador" LIMIT 1 OFFSET 0));


                                             