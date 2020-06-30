
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/25/2020 13:12:56
-- Generated from EDMX file: C:\Users\Andrej\Desktop\BP2Projekat\RentACar\Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [RentACarDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_GradFilijala]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Filijale] DROP CONSTRAINT [FK_GradFilijala];
GO
IF OBJECT_ID(N'[dbo].[FK_FilijalaVozilo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Vozila] DROP CONSTRAINT [FK_FilijalaVozilo];
GO
IF OBJECT_ID(N'[dbo].[FK_VoziloOcena]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Ocene] DROP CONSTRAINT [FK_VoziloOcena];
GO
IF OBJECT_ID(N'[dbo].[FK_VoziloServis]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Servisi] DROP CONSTRAINT [FK_VoziloServis];
GO
IF OBJECT_ID(N'[dbo].[FK_VoziloRezervacija]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Rezervacije] DROP CONSTRAINT [FK_VoziloRezervacija];
GO
IF OBJECT_ID(N'[dbo].[FK_AgentRezervacija]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Rezervacije] DROP CONSTRAINT [FK_AgentRezervacija];
GO
IF OBJECT_ID(N'[dbo].[FK_KlijentOcena]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Ocene] DROP CONSTRAINT [FK_KlijentOcena];
GO
IF OBJECT_ID(N'[dbo].[FK_KlijentRezervacija]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Rezervacije] DROP CONSTRAINT [FK_KlijentRezervacija];
GO
IF OBJECT_ID(N'[dbo].[FK_FilijalaZaposleni]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Zaposleni] DROP CONSTRAINT [FK_FilijalaZaposleni];
GO
IF OBJECT_ID(N'[dbo].[FK_ServisServiser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Servisi] DROP CONSTRAINT [FK_ServisServiser];
GO
IF OBJECT_ID(N'[dbo].[FK_OsiguranjeRezervacija]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Rezervacije] DROP CONSTRAINT [FK_OsiguranjeRezervacija];
GO
IF OBJECT_ID(N'[dbo].[FK_Agent_inherits_Zaposleni]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Zaposleni_Agent] DROP CONSTRAINT [FK_Agent_inherits_Zaposleni];
GO
IF OBJECT_ID(N'[dbo].[FK_Serviser_inherits_Zaposleni]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Zaposleni_Serviser] DROP CONSTRAINT [FK_Serviser_inherits_Zaposleni];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Gradovi]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Gradovi];
GO
IF OBJECT_ID(N'[dbo].[Filijale]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Filijale];
GO
IF OBJECT_ID(N'[dbo].[Vozila]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Vozila];
GO
IF OBJECT_ID(N'[dbo].[Ocene]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Ocene];
GO
IF OBJECT_ID(N'[dbo].[Servisi]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Servisi];
GO
IF OBJECT_ID(N'[dbo].[Klijenti]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Klijenti];
GO
IF OBJECT_ID(N'[dbo].[Rezervacije]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Rezervacije];
GO
IF OBJECT_ID(N'[dbo].[Osiguranja]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Osiguranja];
GO
IF OBJECT_ID(N'[dbo].[Zaposleni]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Zaposleni];
GO
IF OBJECT_ID(N'[dbo].[Zaposleni_Agent]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Zaposleni_Agent];
GO
IF OBJECT_ID(N'[dbo].[Zaposleni_Serviser]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Zaposleni_Serviser];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Gradovi'
CREATE TABLE [dbo].[Gradovi] (
    [PostanskiBroj] int  NOT NULL,
    [Drzava] nvarchar(50)  NOT NULL,
    [Naziv] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Filijale'
CREATE TABLE [dbo].[Filijale] (
    [Id] int  NOT NULL,
    [Naziv] nvarchar(max)  NOT NULL,
    [BrojTelefona] nvarchar(max)  NOT NULL,
    [Adresa] nvarchar(max)  NOT NULL,
    [GradPostanskiBroj] int  NOT NULL
);
GO

-- Creating table 'Vozila'
CREATE TABLE [dbo].[Vozila] (
    [Id] int  NOT NULL,
    [Model] nvarchar(max)  NOT NULL,
    [Marka] nvarchar(max)  NOT NULL,
    [FilijalaId] int  NOT NULL,
    [Tip_vozila] int  NOT NULL
);
GO

-- Creating table 'Ocene'
CREATE TABLE [dbo].[Ocene] (
    [Id] int  NOT NULL,
    [VoziloId] int  NOT NULL,
    [Vrednost] int  NOT NULL,
    [KlijentJmbg] nvarchar(20)  NOT NULL
);
GO

-- Creating table 'Servisi'
CREATE TABLE [dbo].[Servisi] (
    [Id] int  NOT NULL,
    [Cena] int  NOT NULL,
    [Komentar] nvarchar(max)  NOT NULL,
    [Datum] datetime  NOT NULL,
    [VoziloId] int  NOT NULL,
    [ServiserJmbg] nvarchar(20)  NOT NULL
);
GO

-- Creating table 'Klijenti'
CREATE TABLE [dbo].[Klijenti] (
    [Jmbg] nvarchar(20)  NOT NULL,
    [Ime] nvarchar(max)  NOT NULL,
    [Prezime] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Rezervacije'
CREATE TABLE [dbo].[Rezervacije] (
    [Id] int  NOT NULL,
    [Datum_rezervacije] datetime  NOT NULL,
    [Datum_preuzimanja] datetime  NOT NULL,
    [Datum_vracanja] datetime  NOT NULL,
    [VoziloId] int  NOT NULL,
    [KlijentJmbg] nvarchar(20)  NOT NULL,
    [OsiguranjeId] int  NOT NULL,
    [AgentJmbg] nvarchar(20)  NOT NULL
);
GO

-- Creating table 'Osiguranja'
CREATE TABLE [dbo].[Osiguranja] (
    [Id] int  NOT NULL,
    [Broj_polise] nvarchar(max)  NOT NULL,
    [Tip_osiguranja] int  NOT NULL
);
GO

-- Creating table 'Zaposleni'
CREATE TABLE [dbo].[Zaposleni] (
    [Ime] nvarchar(max)  NOT NULL,
    [Prezime] nvarchar(max)  NOT NULL,
    [Broj_ugovora] nvarchar(max)  NOT NULL,
    [Jmbg] nvarchar(20)  NOT NULL,
    [FilijalaId] int  NOT NULL
);
GO

-- Creating table 'Zaposleni_Serviser'
CREATE TABLE [dbo].[Zaposleni_Serviser] (
    [Broj_licence] nvarchar(max)  NOT NULL,
    [Tip_Struke] int  NOT NULL,
    [Jmbg] nvarchar(20)  NOT NULL
);
GO

-- Creating table 'Zaposleni_Agent'
CREATE TABLE [dbo].[Zaposleni_Agent] (
    [Broj_sertifikata] nvarchar(max)  NOT NULL,
    [Jmbg] nvarchar(20)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [PostanskiBroj] in table 'Gradovi'
ALTER TABLE [dbo].[Gradovi]
ADD CONSTRAINT [PK_Gradovi]
    PRIMARY KEY CLUSTERED ([PostanskiBroj] ASC);
GO

-- Creating primary key on [Id] in table 'Filijale'
ALTER TABLE [dbo].[Filijale]
ADD CONSTRAINT [PK_Filijale]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Vozila'
ALTER TABLE [dbo].[Vozila]
ADD CONSTRAINT [PK_Vozila]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Ocene'
ALTER TABLE [dbo].[Ocene]
ADD CONSTRAINT [PK_Ocene]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Servisi'
ALTER TABLE [dbo].[Servisi]
ADD CONSTRAINT [PK_Servisi]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Jmbg] in table 'Klijenti'
ALTER TABLE [dbo].[Klijenti]
ADD CONSTRAINT [PK_Klijenti]
    PRIMARY KEY CLUSTERED ([Jmbg] ASC);
GO

-- Creating primary key on [Id] in table 'Rezervacije'
ALTER TABLE [dbo].[Rezervacije]
ADD CONSTRAINT [PK_Rezervacije]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Osiguranja'
ALTER TABLE [dbo].[Osiguranja]
ADD CONSTRAINT [PK_Osiguranja]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Jmbg] in table 'Zaposleni'
ALTER TABLE [dbo].[Zaposleni]
ADD CONSTRAINT [PK_Zaposleni]
    PRIMARY KEY CLUSTERED ([Jmbg] ASC);
GO

-- Creating primary key on [Jmbg] in table 'Zaposleni_Serviser'
ALTER TABLE [dbo].[Zaposleni_Serviser]
ADD CONSTRAINT [PK_Zaposleni_Serviser]
    PRIMARY KEY CLUSTERED ([Jmbg] ASC);
GO

-- Creating primary key on [Jmbg] in table 'Zaposleni_Agent'
ALTER TABLE [dbo].[Zaposleni_Agent]
ADD CONSTRAINT [PK_Zaposleni_Agent]
    PRIMARY KEY CLUSTERED ([Jmbg] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [GradPostanskiBroj] in table 'Filijale'
ALTER TABLE [dbo].[Filijale]
ADD CONSTRAINT [FK_GradFilijala]
    FOREIGN KEY ([GradPostanskiBroj])
    REFERENCES [dbo].[Gradovi]
        ([PostanskiBroj])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_GradFilijala'
CREATE INDEX [IX_FK_GradFilijala]
ON [dbo].[Filijale]
    ([GradPostanskiBroj]);
GO

-- Creating foreign key on [FilijalaId] in table 'Vozila'
ALTER TABLE [dbo].[Vozila]
ADD CONSTRAINT [FK_FilijalaVozilo]
    FOREIGN KEY ([FilijalaId])
    REFERENCES [dbo].[Filijale]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FilijalaVozilo'
CREATE INDEX [IX_FK_FilijalaVozilo]
ON [dbo].[Vozila]
    ([FilijalaId]);
GO

-- Creating foreign key on [VoziloId] in table 'Ocene'
ALTER TABLE [dbo].[Ocene]
ADD CONSTRAINT [FK_VoziloOcena]
    FOREIGN KEY ([VoziloId])
    REFERENCES [dbo].[Vozila]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VoziloOcena'
CREATE INDEX [IX_FK_VoziloOcena]
ON [dbo].[Ocene]
    ([VoziloId]);
GO

-- Creating foreign key on [VoziloId] in table 'Servisi'
ALTER TABLE [dbo].[Servisi]
ADD CONSTRAINT [FK_VoziloServis]
    FOREIGN KEY ([VoziloId])
    REFERENCES [dbo].[Vozila]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VoziloServis'
CREATE INDEX [IX_FK_VoziloServis]
ON [dbo].[Servisi]
    ([VoziloId]);
GO

-- Creating foreign key on [VoziloId] in table 'Rezervacije'
ALTER TABLE [dbo].[Rezervacije]
ADD CONSTRAINT [FK_VoziloRezervacija]
    FOREIGN KEY ([VoziloId])
    REFERENCES [dbo].[Vozila]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VoziloRezervacija'
CREATE INDEX [IX_FK_VoziloRezervacija]
ON [dbo].[Rezervacije]
    ([VoziloId]);
GO

-- Creating foreign key on [KlijentJmbg] in table 'Ocene'
ALTER TABLE [dbo].[Ocene]
ADD CONSTRAINT [FK_KlijentOcena]
    FOREIGN KEY ([KlijentJmbg])
    REFERENCES [dbo].[Klijenti]
        ([Jmbg])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_KlijentOcena'
CREATE INDEX [IX_FK_KlijentOcena]
ON [dbo].[Ocene]
    ([KlijentJmbg]);
GO

-- Creating foreign key on [KlijentJmbg] in table 'Rezervacije'
ALTER TABLE [dbo].[Rezervacije]
ADD CONSTRAINT [FK_KlijentRezervacija]
    FOREIGN KEY ([KlijentJmbg])
    REFERENCES [dbo].[Klijenti]
        ([Jmbg])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_KlijentRezervacija'
CREATE INDEX [IX_FK_KlijentRezervacija]
ON [dbo].[Rezervacije]
    ([KlijentJmbg]);
GO

-- Creating foreign key on [FilijalaId] in table 'Zaposleni'
ALTER TABLE [dbo].[Zaposleni]
ADD CONSTRAINT [FK_FilijalaZaposleni]
    FOREIGN KEY ([FilijalaId])
    REFERENCES [dbo].[Filijale]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FilijalaZaposleni'
CREATE INDEX [IX_FK_FilijalaZaposleni]
ON [dbo].[Zaposleni]
    ([FilijalaId]);
GO

-- Creating foreign key on [ServiserJmbg] in table 'Servisi'
ALTER TABLE [dbo].[Servisi]
ADD CONSTRAINT [FK_ServisServiser]
    FOREIGN KEY ([ServiserJmbg])
    REFERENCES [dbo].[Zaposleni_Serviser]
        ([Jmbg])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ServisServiser'
CREATE INDEX [IX_FK_ServisServiser]
ON [dbo].[Servisi]
    ([ServiserJmbg]);
GO

-- Creating foreign key on [OsiguranjeId] in table 'Rezervacije'
ALTER TABLE [dbo].[Rezervacije]
ADD CONSTRAINT [FK_OsiguranjeRezervacija]
    FOREIGN KEY ([OsiguranjeId])
    REFERENCES [dbo].[Osiguranja]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OsiguranjeRezervacija'
CREATE INDEX [IX_FK_OsiguranjeRezervacija]
ON [dbo].[Rezervacije]
    ([OsiguranjeId]);
GO

-- Creating foreign key on [AgentJmbg] in table 'Rezervacije'
ALTER TABLE [dbo].[Rezervacije]
ADD CONSTRAINT [FK_AgentRezervacija]
    FOREIGN KEY ([AgentJmbg])
    REFERENCES [dbo].[Zaposleni_Agent]
        ([Jmbg])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AgentRezervacija'
CREATE INDEX [IX_FK_AgentRezervacija]
ON [dbo].[Rezervacije]
    ([AgentJmbg]);
GO

-- Creating foreign key on [Jmbg] in table 'Zaposleni_Serviser'
ALTER TABLE [dbo].[Zaposleni_Serviser]
ADD CONSTRAINT [FK_Serviser_inherits_Zaposleni]
    FOREIGN KEY ([Jmbg])
    REFERENCES [dbo].[Zaposleni]
        ([Jmbg])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Jmbg] in table 'Zaposleni_Agent'
ALTER TABLE [dbo].[Zaposleni_Agent]
ADD CONSTRAINT [FK_Agent_inherits_Zaposleni]
    FOREIGN KEY ([Jmbg])
    REFERENCES [dbo].[Zaposleni]
        ([Jmbg])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------