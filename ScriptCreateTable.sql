-- Création de la base de données
CREATE DATABASE PasswordManager;
GO

USE PasswordManager;
GO

-- Création de la table Applications
CREATE TABLE Applications (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Type INT NOT NULL, -- 1 = Public, 2 = Professional
    CreatedAt DATETIME2 NOT NULL
);
GO

-- Création de la table Passwords
CREATE TABLE Passwords (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(100) NOT NULL,
    EncryptedPassword NVARCHAR(500) NOT NULL,
    Notes NVARCHAR(MAX) NULL,
    CreatedAt DATETIME2 NOT NULL,
    LastModified DATETIME2 NULL,
    ApplicationId INT NOT NULL FOREIGN KEY REFERENCES Applications(Id) ON DELETE CASCADE
);
GO

-- Création d'un index sur la relation
CREATE INDEX IX_Passwords_ApplicationId ON Passwords(ApplicationId);
GO

-- Insertion de données de test
INSERT INTO Applications (Name, Type, CreatedAt)
VALUES 
('Application Grand Public 1', 1, GETDATE()),
('Application Grand Public 2', 1, GETDATE()),
('Application Professionnelle 1', 2, GETDATE()),
('Application Professionnelle 2', 2, GETDATE());
GO

-- Remarque: Nous n'insérons pas de mots de passe pré-chiffrés ici
-- car ils doivent être chiffrés par l'application avec les algorithmes appropriés