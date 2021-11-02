
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/14/2021 00:43:57
-- Generated from EDMX file: D:\workspace\asp\elearning-iscae-pfe-asp-mvc-cs\ISCAE.Data\ISCAEModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'iscaeDB')
    BEGIN
        CREATE DATABASE iscaeDB
    END
GO
USE [iscaeDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Annonces_AdministrateurId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Annonces] DROP CONSTRAINT [FK_Annonces_AdministrateurId];
GO
IF OBJECT_ID(N'[dbo].[FK_DocumentNonOfficiels_EtudiantId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DocumentNonOfficiels] DROP CONSTRAINT [FK_DocumentNonOfficiels_EtudiantId];
GO
IF OBJECT_ID(N'[dbo].[FK_DocumentNonOfficiels_ModuleId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DocumentNonOfficiels] DROP CONSTRAINT [FK_DocumentNonOfficiels_ModuleId];
GO
IF OBJECT_ID(N'[dbo].[FK_DocumentOfficiels_ModuleId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DocumentOfficiels] DROP CONSTRAINT [FK_DocumentOfficiels_ModuleId];
GO
IF OBJECT_ID(N'[dbo].[FK_DocumentOfficiels_ProfesseurId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DocumentOfficiels] DROP CONSTRAINT [FK_DocumentOfficiels_ProfesseurId];
GO
IF OBJECT_ID(N'[dbo].[FK_Etudiants_SpecialiteId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Etudiants] DROP CONSTRAINT [FK_Etudiants_SpecialiteId];
GO
IF OBJECT_ID(N'[dbo].[FK_Messages_ProfesseurId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Messages] DROP CONSTRAINT [FK_Messages_ProfesseurId];
GO
IF OBJECT_ID(N'[dbo].[FK_Messages_SpecialiteId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Messages] DROP CONSTRAINT [FK_Messages_SpecialiteId];
GO
IF OBJECT_ID(N'[dbo].[FK_ProfesseurModules_ModuleId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProfesseurModules] DROP CONSTRAINT [FK_ProfesseurModules_ModuleId];
GO
IF OBJECT_ID(N'[dbo].[FK_ProfesseurModules_ProfesseurId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProfesseurModules] DROP CONSTRAINT [FK_ProfesseurModules_ProfesseurId];
GO
IF OBJECT_ID(N'[dbo].[FK_ProfesseurSpecialites_ProfesseurId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProfesseurSpecialites] DROP CONSTRAINT [FK_ProfesseurSpecialites_ProfesseurId];
GO
IF OBJECT_ID(N'[dbo].[FK_ProfesseurSpecialites_SpecialiteId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProfesseurSpecialites] DROP CONSTRAINT [FK_ProfesseurSpecialites_SpecialiteId];
GO
IF OBJECT_ID(N'[dbo].[FK_Questions_EtudiantId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Questions] DROP CONSTRAINT [FK_Questions_EtudiantId];
GO
IF OBJECT_ID(N'[dbo].[FK_Reponses_EtudiantId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Reponses] DROP CONSTRAINT [FK_Reponses_EtudiantId];
GO
IF OBJECT_ID(N'[dbo].[FK_Reponses_QuestionId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Reponses] DROP CONSTRAINT [FK_Reponses_QuestionId];
GO
IF OBJECT_ID(N'[dbo].[FK_Resultats_AdministrateurId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Resultats] DROP CONSTRAINT [FK_Resultats_AdministrateurId];
GO
IF OBJECT_ID(N'[dbo].[FK_Resultats_SpecialiteId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Resultats] DROP CONSTRAINT [FK_Resultats_SpecialiteId];
GO
IF OBJECT_ID(N'[dbo].[FK_SpecialiteModules_ModuleId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SpecialiteModules] DROP CONSTRAINT [FK_SpecialiteModules_ModuleId];
GO
IF OBJECT_ID(N'[dbo].[FK_SpecialiteModules_SpecialiteId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SpecialiteModules] DROP CONSTRAINT [FK_SpecialiteModules_SpecialiteId];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Administrateurs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Administrateurs];
GO
IF OBJECT_ID(N'[dbo].[Annonces]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Annonces];
GO
IF OBJECT_ID(N'[dbo].[DocumentNonOfficiels]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DocumentNonOfficiels];
GO
IF OBJECT_ID(N'[dbo].[DocumentOfficiels]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DocumentOfficiels];
GO
IF OBJECT_ID(N'[dbo].[Etudiants]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Etudiants];
GO
IF OBJECT_ID(N'[dbo].[Messages]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Messages];
GO
IF OBJECT_ID(N'[dbo].[Modules]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Modules];
GO
IF OBJECT_ID(N'[dbo].[Notifications]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Notifications];
GO
IF OBJECT_ID(N'[dbo].[ProfesseurModules]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProfesseurModules];
GO
IF OBJECT_ID(N'[dbo].[Professeurs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Professeurs];
GO
IF OBJECT_ID(N'[dbo].[ProfesseurSpecialites]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProfesseurSpecialites];
GO
IF OBJECT_ID(N'[dbo].[Questions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Questions];
GO
IF OBJECT_ID(N'[dbo].[Recoveries]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Recoveries];
GO
IF OBJECT_ID(N'[dbo].[Reponses]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Reponses];
GO
IF OBJECT_ID(N'[dbo].[Resultats]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Resultats];
GO
IF OBJECT_ID(N'[dbo].[SpecialiteModules]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SpecialiteModules];
GO
IF OBJECT_ID(N'[dbo].[Specialites]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Specialites];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Administrateurs'
CREATE TABLE [dbo].[Administrateurs] (
    [AdministrateurId] int IDENTITY(1,1) NOT NULL,
    [Nom] varchar(100)  NOT NULL,
    [Login] varchar(50)  NOT NULL,
    [Password] varchar(255)  NOT NULL,
    [Telephone] varchar(25)  NOT NULL,
    [Email] varchar(200)  NOT NULL,
    [isActive] tinyint  NOT NULL,
    [ProfilePath] varchar(255)  NOT NULL,
    [Groupe] varchar(25)  NOT NULL
);
GO

-- Creating table 'Annonces'
CREATE TABLE [dbo].[Annonces] (
    [AnnonceId] int IDENTITY(1,1) NOT NULL,
    [Titre] varchar(250)  NOT NULL,
    [Contenu] varchar(max)  NOT NULL,
    [DateAjout] datetime  NOT NULL,
    [AdministrateurId] int  NOT NULL
);
GO

-- Creating table 'DocumentNonOfficiels'
CREATE TABLE [dbo].[DocumentNonOfficiels] (
    [DocumentNonOfficielId] int IDENTITY(1,1) NOT NULL,
    [Titre] varchar(25)  NOT NULL,
    [Emplacement] varchar(255)  NOT NULL,
    [Type] varchar(25)  NULL,
    [ModuleId] int  NOT NULL,
    [DateAjoutNonOfficiel] datetime  NOT NULL,
    [EtudiantId] int  NOT NULL
);
GO

-- Creating table 'DocumentOfficiels'
CREATE TABLE [dbo].[DocumentOfficiels] (
    [DocumentOfficielId] int IDENTITY(1,1) NOT NULL,
    [Titre] varchar(25)  NOT NULL,
    [Emplacement] varchar(255)  NOT NULL,
    [Type] varchar(25)  NULL,
    [DateAjoutOfficiel] datetime  NOT NULL,
    [ProfesseurId] int  NOT NULL,
    [ModuleId] int  NOT NULL
);
GO

-- Creating table 'Etudiants'
CREATE TABLE [dbo].[Etudiants] (
    [EtudiantId] int IDENTITY(1,1) NOT NULL,
    [Nom] varchar(100)  NOT NULL,
    [Matricule] varchar(100)  NOT NULL,
    [Login] varchar(50)  NOT NULL,
    [Password] varchar(255)  NOT NULL,
    [Telephone] varchar(25)  NOT NULL,
    [Email] varchar(200)  NOT NULL,
    [isActive] tinyint  NOT NULL,
    [NNI] varchar(25)  NOT NULL,
    [ProfilePath] varchar(255)  NOT NULL,
    [Niveau] tinyint  NOT NULL,
    [SpecialiteId] int  NOT NULL
);
GO

-- Creating table 'Messages'
CREATE TABLE [dbo].[Messages] (
    [MessageId] int IDENTITY(1,1) NOT NULL,
    [Titre] varchar(200)  NOT NULL,
    [Contenu] varchar(max)  NOT NULL,
    [DateEnvoiMessage] datetime  NOT NULL,
    [ProfesseurId] int  NOT NULL,
    [Niveau] tinyint  NOT NULL,
    [SpecialiteId] int  NOT NULL
);
GO

-- Creating table 'Modules'
CREATE TABLE [dbo].[Modules] (
    [ModuleId] int IDENTITY(1,1) NOT NULL,
    [Designation] varchar(25)  NOT NULL
);
GO

-- Creating table 'Notifications'
CREATE TABLE [dbo].[Notifications] (
    [NotificationId] int IDENTITY(1,1) NOT NULL,
    [ActorId] int  NOT NULL,
    [TargetId] int  NOT NULL,
    [Message] varchar(max)  NOT NULL,
    [NotificationStatus] tinyint  NOT NULL,
    [TableName] varchar(25)  NOT NULL,
    [RecordId] int  NOT NULL,
    [DateNotification] datetime  NOT NULL
);
GO

-- Creating table 'ProfesseurModules'
CREATE TABLE [dbo].[ProfesseurModules] (
    [ProfesseurModuleId] int IDENTITY(1,1) NOT NULL,
    [ProfesseurId] int  NOT NULL,
    [ModuleId] int  NOT NULL
);
GO

-- Creating table 'Professeurs'
CREATE TABLE [dbo].[Professeurs] (
    [ProfesseurId] int IDENTITY(1,1) NOT NULL,
    [Nom] varchar(100)  NOT NULL,
    [Login] varchar(50)  NOT NULL,
    [Password] varchar(255)  NOT NULL,
    [Telephone] varchar(25)  NOT NULL,
    [Email] varchar(200)  NOT NULL,
    [isActive] tinyint  NOT NULL,
    [ProfilePath] varchar(255)  NOT NULL
);
GO

-- Creating table 'ProfesseurSpecialites'
CREATE TABLE [dbo].[ProfesseurSpecialites] (
    [ProfesseurSpecialiteId] int IDENTITY(1,1) NOT NULL,
    [ProfesseurId] int  NOT NULL,
    [SpecialiteId] int  NOT NULL
);
GO

-- Creating table 'Questions'
CREATE TABLE [dbo].[Questions] (
    [QuestionId] int IDENTITY(1,1) NOT NULL,
    [Contenu] varchar(max)  NOT NULL,
    [Titre] varchar(25)  NOT NULL,
    [DateQuestion] datetime  NOT NULL,
    [Attachment] varchar(255)  NULL,
    [EtudiantId] int  NOT NULL
);
GO

-- Creating table 'Recoveries'
CREATE TABLE [dbo].[Recoveries] (
    [RecoveryId] int IDENTITY(1,1) NOT NULL,
    [Matricule] varchar(25)  NOT NULL,
    [Email] varchar(100)  NOT NULL,
    [Code] varchar(100)  NOT NULL
);
GO

-- Creating table 'Reponses'
CREATE TABLE [dbo].[Reponses] (
    [ReponseId] int IDENTITY(1,1) NOT NULL,
    [Contenu] varchar(max)  NOT NULL,
    [DateReponse] datetime  NOT NULL,
    [QuestionId] int  NOT NULL,
    [EtudiantId] int  NOT NULL
);
GO

-- Creating table 'Resultats'
CREATE TABLE [dbo].[Resultats] (
    [ResultatId] int IDENTITY(1,1) NOT NULL,
    [Path] varchar(255)  NOT NULL,
    [Semestre] tinyint  NOT NULL,
    [Annee] varchar(25)  NOT NULL,
    [AdministrateurId] int  NOT NULL,
    [SpecialiteId] int  NOT NULL
);
GO

-- Creating table 'SpecialiteModules'
CREATE TABLE [dbo].[SpecialiteModules] (
    [Niveau] tinyint  NOT NULL,
    [SpecialiteId] int  NOT NULL,
    [ModuleId] int  NOT NULL
);
GO

-- Creating table 'Specialites'
CREATE TABLE [dbo].[Specialites] (
    [SpecialiteId] int IDENTITY(1,1) NOT NULL,
    [Abreviation] varchar(25)  NOT NULL,
    [Designation] varchar(50)  NOT NULL,
    [Description] varchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [AdministrateurId] in table 'Administrateurs'
ALTER TABLE [dbo].[Administrateurs]
ADD CONSTRAINT [PK_Administrateurs]
    PRIMARY KEY CLUSTERED ([AdministrateurId] ASC);
GO

-- Creating primary key on [AnnonceId] in table 'Annonces'
ALTER TABLE [dbo].[Annonces]
ADD CONSTRAINT [PK_Annonces]
    PRIMARY KEY CLUSTERED ([AnnonceId] ASC);
GO

-- Creating primary key on [DocumentNonOfficielId] in table 'DocumentNonOfficiels'
ALTER TABLE [dbo].[DocumentNonOfficiels]
ADD CONSTRAINT [PK_DocumentNonOfficiels]
    PRIMARY KEY CLUSTERED ([DocumentNonOfficielId] ASC);
GO

-- Creating primary key on [DocumentOfficielId] in table 'DocumentOfficiels'
ALTER TABLE [dbo].[DocumentOfficiels]
ADD CONSTRAINT [PK_DocumentOfficiels]
    PRIMARY KEY CLUSTERED ([DocumentOfficielId] ASC);
GO

-- Creating primary key on [EtudiantId] in table 'Etudiants'
ALTER TABLE [dbo].[Etudiants]
ADD CONSTRAINT [PK_Etudiants]
    PRIMARY KEY CLUSTERED ([EtudiantId] ASC);
GO

-- Creating primary key on [MessageId] in table 'Messages'
ALTER TABLE [dbo].[Messages]
ADD CONSTRAINT [PK_Messages]
    PRIMARY KEY CLUSTERED ([MessageId] ASC);
GO

-- Creating primary key on [ModuleId] in table 'Modules'
ALTER TABLE [dbo].[Modules]
ADD CONSTRAINT [PK_Modules]
    PRIMARY KEY CLUSTERED ([ModuleId] ASC);
GO

-- Creating primary key on [NotificationId] in table 'Notifications'
ALTER TABLE [dbo].[Notifications]
ADD CONSTRAINT [PK_Notifications]
    PRIMARY KEY CLUSTERED ([NotificationId] ASC);
GO

-- Creating primary key on [ProfesseurModuleId], [ProfesseurId], [ModuleId] in table 'ProfesseurModules'
ALTER TABLE [dbo].[ProfesseurModules]
ADD CONSTRAINT [PK_ProfesseurModules]
    PRIMARY KEY CLUSTERED ([ProfesseurModuleId], [ProfesseurId], [ModuleId] ASC);
GO

-- Creating primary key on [ProfesseurId] in table 'Professeurs'
ALTER TABLE [dbo].[Professeurs]
ADD CONSTRAINT [PK_Professeurs]
    PRIMARY KEY CLUSTERED ([ProfesseurId] ASC);
GO

-- Creating primary key on [ProfesseurSpecialiteId], [ProfesseurId], [SpecialiteId] in table 'ProfesseurSpecialites'
ALTER TABLE [dbo].[ProfesseurSpecialites]
ADD CONSTRAINT [PK_ProfesseurSpecialites]
    PRIMARY KEY CLUSTERED ([ProfesseurSpecialiteId], [ProfesseurId], [SpecialiteId] ASC);
GO

-- Creating primary key on [QuestionId] in table 'Questions'
ALTER TABLE [dbo].[Questions]
ADD CONSTRAINT [PK_Questions]
    PRIMARY KEY CLUSTERED ([QuestionId] ASC);
GO

-- Creating primary key on [RecoveryId] in table 'Recoveries'
ALTER TABLE [dbo].[Recoveries]
ADD CONSTRAINT [PK_Recoveries]
    PRIMARY KEY CLUSTERED ([RecoveryId] ASC);
GO

-- Creating primary key on [ReponseId] in table 'Reponses'
ALTER TABLE [dbo].[Reponses]
ADD CONSTRAINT [PK_Reponses]
    PRIMARY KEY CLUSTERED ([ReponseId] ASC);
GO

-- Creating primary key on [ResultatId] in table 'Resultats'
ALTER TABLE [dbo].[Resultats]
ADD CONSTRAINT [PK_Resultats]
    PRIMARY KEY CLUSTERED ([ResultatId] ASC);
GO

-- Creating primary key on [SpecialiteId], [ModuleId] in table 'SpecialiteModules'
ALTER TABLE [dbo].[SpecialiteModules]
ADD CONSTRAINT [PK_SpecialiteModules]
    PRIMARY KEY CLUSTERED ([SpecialiteId], [ModuleId] ASC);
GO

-- Creating primary key on [SpecialiteId] in table 'Specialites'
ALTER TABLE [dbo].[Specialites]
ADD CONSTRAINT [PK_Specialites]
    PRIMARY KEY CLUSTERED ([SpecialiteId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [AdministrateurId] in table 'Annonces'
ALTER TABLE [dbo].[Annonces]
ADD CONSTRAINT [FK_Annonces_AdministrateurId]
    FOREIGN KEY ([AdministrateurId])
    REFERENCES [dbo].[Administrateurs]
        ([AdministrateurId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Annonces_AdministrateurId'
CREATE INDEX [IX_FK_Annonces_AdministrateurId]
ON [dbo].[Annonces]
    ([AdministrateurId]);
GO

-- Creating foreign key on [AdministrateurId] in table 'Resultats'
ALTER TABLE [dbo].[Resultats]
ADD CONSTRAINT [FK_Resultats_AdministrateurId]
    FOREIGN KEY ([AdministrateurId])
    REFERENCES [dbo].[Administrateurs]
        ([AdministrateurId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Resultats_AdministrateurId'
CREATE INDEX [IX_FK_Resultats_AdministrateurId]
ON [dbo].[Resultats]
    ([AdministrateurId]);
GO

-- Creating foreign key on [EtudiantId] in table 'DocumentNonOfficiels'
ALTER TABLE [dbo].[DocumentNonOfficiels]
ADD CONSTRAINT [FK_DocumentNonOfficiels_EtudiantId]
    FOREIGN KEY ([EtudiantId])
    REFERENCES [dbo].[Etudiants]
        ([EtudiantId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DocumentNonOfficiels_EtudiantId'
CREATE INDEX [IX_FK_DocumentNonOfficiels_EtudiantId]
ON [dbo].[DocumentNonOfficiels]
    ([EtudiantId]);
GO

-- Creating foreign key on [ModuleId] in table 'DocumentNonOfficiels'
ALTER TABLE [dbo].[DocumentNonOfficiels]
ADD CONSTRAINT [FK_DocumentNonOfficiels_ModuleId]
    FOREIGN KEY ([ModuleId])
    REFERENCES [dbo].[Modules]
        ([ModuleId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DocumentNonOfficiels_ModuleId'
CREATE INDEX [IX_FK_DocumentNonOfficiels_ModuleId]
ON [dbo].[DocumentNonOfficiels]
    ([ModuleId]);
GO

-- Creating foreign key on [ModuleId] in table 'DocumentOfficiels'
ALTER TABLE [dbo].[DocumentOfficiels]
ADD CONSTRAINT [FK_DocumentOfficiels_ModuleId]
    FOREIGN KEY ([ModuleId])
    REFERENCES [dbo].[Modules]
        ([ModuleId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DocumentOfficiels_ModuleId'
CREATE INDEX [IX_FK_DocumentOfficiels_ModuleId]
ON [dbo].[DocumentOfficiels]
    ([ModuleId]);
GO

-- Creating foreign key on [ProfesseurId] in table 'DocumentOfficiels'
ALTER TABLE [dbo].[DocumentOfficiels]
ADD CONSTRAINT [FK_DocumentOfficiels_ProfesseurId]
    FOREIGN KEY ([ProfesseurId])
    REFERENCES [dbo].[Professeurs]
        ([ProfesseurId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DocumentOfficiels_ProfesseurId'
CREATE INDEX [IX_FK_DocumentOfficiels_ProfesseurId]
ON [dbo].[DocumentOfficiels]
    ([ProfesseurId]);
GO

-- Creating foreign key on [SpecialiteId] in table 'Etudiants'
ALTER TABLE [dbo].[Etudiants]
ADD CONSTRAINT [FK_Etudiants_SpecialiteId]
    FOREIGN KEY ([SpecialiteId])
    REFERENCES [dbo].[Specialites]
        ([SpecialiteId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Etudiants_SpecialiteId'
CREATE INDEX [IX_FK_Etudiants_SpecialiteId]
ON [dbo].[Etudiants]
    ([SpecialiteId]);
GO

-- Creating foreign key on [EtudiantId] in table 'Questions'
ALTER TABLE [dbo].[Questions]
ADD CONSTRAINT [FK_Questions_EtudiantId]
    FOREIGN KEY ([EtudiantId])
    REFERENCES [dbo].[Etudiants]
        ([EtudiantId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Questions_EtudiantId'
CREATE INDEX [IX_FK_Questions_EtudiantId]
ON [dbo].[Questions]
    ([EtudiantId]);
GO

-- Creating foreign key on [EtudiantId] in table 'Reponses'
ALTER TABLE [dbo].[Reponses]
ADD CONSTRAINT [FK_Reponses_EtudiantId]
    FOREIGN KEY ([EtudiantId])
    REFERENCES [dbo].[Etudiants]
        ([EtudiantId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Reponses_EtudiantId'
CREATE INDEX [IX_FK_Reponses_EtudiantId]
ON [dbo].[Reponses]
    ([EtudiantId]);
GO

-- Creating foreign key on [ProfesseurId] in table 'Messages'
ALTER TABLE [dbo].[Messages]
ADD CONSTRAINT [FK_Messages_ProfesseurId]
    FOREIGN KEY ([ProfesseurId])
    REFERENCES [dbo].[Professeurs]
        ([ProfesseurId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Messages_ProfesseurId'
CREATE INDEX [IX_FK_Messages_ProfesseurId]
ON [dbo].[Messages]
    ([ProfesseurId]);
GO

-- Creating foreign key on [SpecialiteId] in table 'Messages'
ALTER TABLE [dbo].[Messages]
ADD CONSTRAINT [FK_Messages_SpecialiteId]
    FOREIGN KEY ([SpecialiteId])
    REFERENCES [dbo].[Specialites]
        ([SpecialiteId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Messages_SpecialiteId'
CREATE INDEX [IX_FK_Messages_SpecialiteId]
ON [dbo].[Messages]
    ([SpecialiteId]);
GO

-- Creating foreign key on [ModuleId] in table 'ProfesseurModules'
ALTER TABLE [dbo].[ProfesseurModules]
ADD CONSTRAINT [FK_ProfesseurModules_ModuleId]
    FOREIGN KEY ([ModuleId])
    REFERENCES [dbo].[Modules]
        ([ModuleId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProfesseurModules_ModuleId'
CREATE INDEX [IX_FK_ProfesseurModules_ModuleId]
ON [dbo].[ProfesseurModules]
    ([ModuleId]);
GO

-- Creating foreign key on [ModuleId] in table 'SpecialiteModules'
ALTER TABLE [dbo].[SpecialiteModules]
ADD CONSTRAINT [FK_SpecialiteModules_ModuleId]
    FOREIGN KEY ([ModuleId])
    REFERENCES [dbo].[Modules]
        ([ModuleId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SpecialiteModules_ModuleId'
CREATE INDEX [IX_FK_SpecialiteModules_ModuleId]
ON [dbo].[SpecialiteModules]
    ([ModuleId]);
GO

-- Creating foreign key on [ProfesseurId] in table 'ProfesseurModules'
ALTER TABLE [dbo].[ProfesseurModules]
ADD CONSTRAINT [FK_ProfesseurModules_ProfesseurId]
    FOREIGN KEY ([ProfesseurId])
    REFERENCES [dbo].[Professeurs]
        ([ProfesseurId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProfesseurModules_ProfesseurId'
CREATE INDEX [IX_FK_ProfesseurModules_ProfesseurId]
ON [dbo].[ProfesseurModules]
    ([ProfesseurId]);
GO

-- Creating foreign key on [ProfesseurId] in table 'ProfesseurSpecialites'
ALTER TABLE [dbo].[ProfesseurSpecialites]
ADD CONSTRAINT [FK_ProfesseurSpecialites_ProfesseurId]
    FOREIGN KEY ([ProfesseurId])
    REFERENCES [dbo].[Professeurs]
        ([ProfesseurId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProfesseurSpecialites_ProfesseurId'
CREATE INDEX [IX_FK_ProfesseurSpecialites_ProfesseurId]
ON [dbo].[ProfesseurSpecialites]
    ([ProfesseurId]);
GO

-- Creating foreign key on [SpecialiteId] in table 'ProfesseurSpecialites'
ALTER TABLE [dbo].[ProfesseurSpecialites]
ADD CONSTRAINT [FK_ProfesseurSpecialites_SpecialiteId]
    FOREIGN KEY ([SpecialiteId])
    REFERENCES [dbo].[Specialites]
        ([SpecialiteId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProfesseurSpecialites_SpecialiteId'
CREATE INDEX [IX_FK_ProfesseurSpecialites_SpecialiteId]
ON [dbo].[ProfesseurSpecialites]
    ([SpecialiteId]);
GO

-- Creating foreign key on [QuestionId] in table 'Reponses'
ALTER TABLE [dbo].[Reponses]
ADD CONSTRAINT [FK_Reponses_QuestionId]
    FOREIGN KEY ([QuestionId])
    REFERENCES [dbo].[Questions]
        ([QuestionId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Reponses_QuestionId'
CREATE INDEX [IX_FK_Reponses_QuestionId]
ON [dbo].[Reponses]
    ([QuestionId]);
GO

-- Creating foreign key on [SpecialiteId] in table 'Resultats'
ALTER TABLE [dbo].[Resultats]
ADD CONSTRAINT [FK_Resultats_SpecialiteId]
    FOREIGN KEY ([SpecialiteId])
    REFERENCES [dbo].[Specialites]
        ([SpecialiteId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Resultats_SpecialiteId'
CREATE INDEX [IX_FK_Resultats_SpecialiteId]
ON [dbo].[Resultats]
    ([SpecialiteId]);
GO

-- Creating foreign key on [SpecialiteId] in table 'SpecialiteModules'
ALTER TABLE [dbo].[SpecialiteModules]
ADD CONSTRAINT [FK_SpecialiteModules_SpecialiteId]
    FOREIGN KEY ([SpecialiteId])
    REFERENCES [dbo].[Specialites]
        ([SpecialiteId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

INSERT INTO iscaeDB.dbo.Administrateurs
(Nom, Login, Password, Telephone, Email, isActive, ProfilePath, Groupe)
VALUES('Admin', 'admin', 'd9a91cce94abefc2fb9fbce48bfd5306394b1a25', '36200304', 'admin@admin.com', 1, '~/Resources/Profiles/avatar.png', '');

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------