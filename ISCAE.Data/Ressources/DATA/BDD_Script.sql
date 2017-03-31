/*------------------------------------------------------------
*        Script SQLSERVER 
------------------------------------------------------------*/


/*------------------------------------------------------------
-- Table: Administrateurs
------------------------------------------------------------*/
CREATE TABLE Administrateurs(
	AdministrateurId INT IDENTITY (1,1) NOT NULL ,
	Nom              VARCHAR (100) NOT NULL ,
	Login            VARCHAR (50) NOT NULL UNIQUE,
	Password         VARCHAR (255) NOT NULL ,
	Telephone        VARCHAR (25) NOT NULL UNIQUE,
	Email            VARCHAR (200) NOT NULL UNIQUE,
	isActive         TINYINT  NOT NULL ,
	CONSTRAINT prk_constraint_Administrateurs PRIMARY KEY NONCLUSTERED (AdministrateurId)
);


/*------------------------------------------------------------
-- Table: Professeurs
------------------------------------------------------------*/
CREATE TABLE Professeurs(
	ProfesseurId INT IDENTITY (1,1) NOT NULL ,
	Nom          VARCHAR (100) NOT NULL ,
	Login        VARCHAR (50) NOT NULL UNIQUE,
	Password     VARCHAR (255) NOT NULL ,
	Telephone    VARCHAR (25) NOT NULL UNIQUE,
	Email        VARCHAR (200) NOT NULL UNIQUE,
	isActive     TINYINT  NOT NULL ,
	CONSTRAINT prk_constraint_Professeurs PRIMARY KEY NONCLUSTERED (ProfesseurId)
);


/*------------------------------------------------------------
-- Table: Specialites
------------------------------------------------------------*/
CREATE TABLE Specialites(
	SpecialiteId INT IDENTITY (1,1) NOT NULL ,
	Designation  VARCHAR (25) NOT NULL UNIQUE,
	CONSTRAINT prk_constraint_Specialites PRIMARY KEY NONCLUSTERED (SpecialiteId)
);


/*------------------------------------------------------------
-- Table: Etudiants
------------------------------------------------------------*/
CREATE TABLE Etudiants(
	EtudiantId   INT IDENTITY (1,1) NOT NULL ,
	Nom          VARCHAR (100) NOT NULL ,
	Matricule    VARCHAR (100) NOT NULL ,
	Login        VARCHAR (50) NOT NULL UNIQUE,
	Password     VARCHAR (255) NOT NULL ,
	Telephone    VARCHAR (25) NOT NULL UNIQUE,
	Email        VARCHAR (200) NOT NULL UNIQUE,
	isActive     TINYINT  NOT NULL ,
	Niveau       TINYINT  NOT NULL ,
	SpecialiteId INT  NOT NULL ,
	CONSTRAINT prk_constraint_Etudiants PRIMARY KEY NONCLUSTERED (EtudiantId)
);


/*------------------------------------------------------------
-- Table: Modules
------------------------------------------------------------*/
CREATE TABLE Modules(
	ModuleId    INT IDENTITY (1,1) NOT NULL ,
	Designation VARCHAR (25) NOT NULL UNIQUE,
	CONSTRAINT prk_constraint_Modules PRIMARY KEY NONCLUSTERED (ModuleId)
);


/*------------------------------------------------------------
-- Table: DocumentNonOfficiels
------------------------------------------------------------*/
CREATE TABLE DocumentNonOfficiels(
	DocumentNonOfficielId INT IDENTITY (1,1) NOT NULL ,
	Titre                 VARCHAR (25) NOT NULL ,
	Emplacement           VARCHAR (255) NOT NULL UNIQUE,
	Type                  VARCHAR (25)  ,
	isValid               TINYINT  NOT NULL ,
	ModuleId              INT  NOT NULL ,
	DateAjoutNonOfficiel  DATETIME  NOT NULL ,
	EtudiantId            INT  NOT NULL ,
	CONSTRAINT prk_constraint_DocumentNonOfficiels PRIMARY KEY NONCLUSTERED (DocumentNonOfficielId)
);


/*------------------------------------------------------------
-- Table: DocumentOfficiels
------------------------------------------------------------*/
CREATE TABLE DocumentOfficiels(
	DocumentOfficielId INT IDENTITY (1,1) NOT NULL ,
	Titre              VARCHAR (25) NOT NULL ,
	Emplacement        VARCHAR (255) NOT NULL UNIQUE,
	Type               VARCHAR (25)  ,
	DateAjoutOfficiel  DATETIME  NOT NULL ,
	ProfesseurId       INT  NOT NULL ,
	ModuleId           INT  NOT NULL ,
	CONSTRAINT prk_constraint_DocumentOfficiels PRIMARY KEY NONCLUSTERED (DocumentOfficielId)
);


/*------------------------------------------------------------
-- Table: Messages
------------------------------------------------------------*/
CREATE TABLE Messages(
	MessageId        INT IDENTITY (1,1) NOT NULL ,
	Titre            VARCHAR (200) NOT NULL ,
	Contenu          TEXT  NOT NULL ,
	DateEnvoiMessage DATETIME  NOT NULL ,
	ProfesseurId     INT  NOT NULL ,
	Niveau           TINYINT  NOT NULL ,
	SpecialiteId     INT  NOT NULL ,
	CONSTRAINT prk_constraint_Messages PRIMARY KEY NONCLUSTERED (MessageId)
);


/*------------------------------------------------------------
-- Table: Questions
------------------------------------------------------------*/
CREATE TABLE Questions(
	QuestionId   INT IDENTITY (1,1) NOT NULL ,
	Contenu      TEXT  NOT NULL ,
	Titre        VARCHAR (25) NOT NULL ,
	DateQuestion DATETIME  NOT NULL ,
	EtudiantId   INT  NOT NULL ,
	CONSTRAINT prk_constraint_Questions PRIMARY KEY NONCLUSTERED (QuestionId)
);


/*------------------------------------------------------------
-- Table: Reponses
------------------------------------------------------------*/
CREATE TABLE Reponses(
	ReponseId   INT IDENTITY (1,1) NOT NULL ,
	Contenu     TEXT  NOT NULL ,
	DateReponse DATETIME  NOT NULL ,
	QuestionId  INT  NOT NULL ,
	EtudiantId  INT  NOT NULL ,
	CONSTRAINT prk_constraint_Reponses PRIMARY KEY NONCLUSTERED (ReponseId)
);


/*------------------------------------------------------------
-- Table: Annonces
------------------------------------------------------------*/
CREATE TABLE Annonces(
	AnnonceId        INT IDENTITY (1,1) NOT NULL ,
	Titre            VARCHAR (250) NOT NULL ,
	Contenu          TEXT  NOT NULL ,
	DateAjout        DATETIME  NOT NULL ,
	AdministrateurId INT  NOT NULL ,
	CONSTRAINT prk_constraint_Annonces PRIMARY KEY NONCLUSTERED (AnnonceId)
);


/*------------------------------------------------------------
-- Table: ProfesseurModules
------------------------------------------------------------*/
CREATE TABLE ProfesseurModules(
	ProfesseurId INT  NOT NULL ,
	ModuleId     INT  NOT NULL ,
	CONSTRAINT prk_constraint_ProfesseurModules PRIMARY KEY NONCLUSTERED (ProfesseurId,ModuleId)
);


/*------------------------------------------------------------
-- Table: ProfesseurSpecialites
------------------------------------------------------------*/
CREATE TABLE ProfesseurSpecialites(
	ProfesseurId INT  NOT NULL ,
	SpecialiteId INT  NOT NULL ,
	CONSTRAINT prk_constraint_ProfesseurSpecialites PRIMARY KEY NONCLUSTERED (ProfesseurId,SpecialiteId)
);


/*------------------------------------------------------------
-- Table: SpecialiteModules
------------------------------------------------------------*/
CREATE TABLE SpecialiteModules(
	Niveau       TINYINT  NOT NULL ,
	SpecialiteId INT  NOT NULL ,
	ModuleId     INT  NOT NULL ,
	CONSTRAINT prk_constraint_SpecialiteModules PRIMARY KEY NONCLUSTERED (SpecialiteId,ModuleId)
);



ALTER TABLE Etudiants ADD CONSTRAINT FK_Etudiants_SpecialiteId FOREIGN KEY (SpecialiteId) REFERENCES Specialites(SpecialiteId);
ALTER TABLE DocumentNonOfficiels ADD CONSTRAINT FK_DocumentNonOfficiels_ModuleId FOREIGN KEY (ModuleId) REFERENCES Modules(ModuleId);
ALTER TABLE DocumentNonOfficiels ADD CONSTRAINT FK_DocumentNonOfficiels_EtudiantId FOREIGN KEY (EtudiantId) REFERENCES Etudiants(EtudiantId);
ALTER TABLE DocumentOfficiels ADD CONSTRAINT FK_DocumentOfficiels_ProfesseurId FOREIGN KEY (ProfesseurId) REFERENCES Professeurs(ProfesseurId);
ALTER TABLE DocumentOfficiels ADD CONSTRAINT FK_DocumentOfficiels_ModuleId FOREIGN KEY (ModuleId) REFERENCES Modules(ModuleId);
ALTER TABLE Messages ADD CONSTRAINT FK_Messages_ProfesseurId FOREIGN KEY (ProfesseurId) REFERENCES Professeurs(ProfesseurId);
ALTER TABLE Messages ADD CONSTRAINT FK_Messages_SpecialiteId FOREIGN KEY (SpecialiteId) REFERENCES Specialites(SpecialiteId);
ALTER TABLE Questions ADD CONSTRAINT FK_Questions_EtudiantId FOREIGN KEY (EtudiantId) REFERENCES Etudiants(EtudiantId);
ALTER TABLE Reponses ADD CONSTRAINT FK_Reponses_QuestionId FOREIGN KEY (QuestionId) REFERENCES Questions(QuestionId);
ALTER TABLE Reponses ADD CONSTRAINT FK_Reponses_EtudiantId FOREIGN KEY (EtudiantId) REFERENCES Etudiants(EtudiantId);
ALTER TABLE Annonces ADD CONSTRAINT FK_Annonces_AdministrateurId FOREIGN KEY (AdministrateurId) REFERENCES Administrateurs(AdministrateurId);
ALTER TABLE ProfesseurModules ADD CONSTRAINT FK_ProfesseurModules_ProfesseurId FOREIGN KEY (ProfesseurId) REFERENCES Professeurs(ProfesseurId);
ALTER TABLE ProfesseurModules ADD CONSTRAINT FK_ProfesseurModules_ModuleId FOREIGN KEY (ModuleId) REFERENCES Modules(ModuleId);
ALTER TABLE ProfesseurSpecialites ADD CONSTRAINT FK_ProfesseurSpecialites_ProfesseurId FOREIGN KEY (ProfesseurId) REFERENCES Professeurs(ProfesseurId);
ALTER TABLE ProfesseurSpecialites ADD CONSTRAINT FK_ProfesseurSpecialites_SpecialiteId FOREIGN KEY (SpecialiteId) REFERENCES Specialites(SpecialiteId);
ALTER TABLE SpecialiteModules ADD CONSTRAINT FK_SpecialiteModules_SpecialiteId FOREIGN KEY (SpecialiteId) REFERENCES Specialites(SpecialiteId);
ALTER TABLE SpecialiteModules ADD CONSTRAINT FK_SpecialiteModules_ModuleId FOREIGN KEY (ModuleId) REFERENCES Modules(ModuleId);
