CREATE DATABASE FindMyPetDB;

USE FindMyPetDB;

CREATE TABLE Gender
(
	Code int NOT NULL IDENTITY (0,1),
	Gender nvarchar(25) NOT NULL,

	CONSTRAINT PK_Gender PRIMARY KEY (Code)
);
GO
INSERT INTO Gender (Gender) 
VALUES ('Unspecified/Unknown'),
('Male'),
('Female');

CREATE TABLE AggressionCode
(
	Code int NOT NULL IDENTITY(0,1),
	Descriptor nvarchar(50) NOT NULL,

	CONSTRAINT PK_AGGRESSION PRIMARY KEY (Code ASC)
);
GO
INSERT INTO AggressionCode (Descriptor) VALUES
('Unknown'),
('Friendly'),
('Not Dangerous/Not Approachable'),
('Dangerous');


CREATE TABLE Customer
(
	CustomerID int NOT NULL IDENTITY(0, 1),
	FirstName nvarchar(50) NOT NULL,
	LastName nvarchar(50) NOT NULL,
	UserName nvarchar(50) NOT NULL UNIQUE,
	Password nvarchar(50) NOT NULL,
	Email nvarchar(150) NOT NULL,
	HomeLocationLatitude float,
	HomeLocationLongitude float,
	WanderingRadius float,
	Phone int,
	ZipCode int,
	AccountCreationDate DATETIME NOT NULL DEFAULT GETDATE(),

	CONSTRAINT PK_CustomerID PRIMARY KEY (CustomerID ASC)
);
GO
INSERT INTO Customer (FirstName, LastName, UserName, Password, Email, AccountCreationDate)
VALUES ('Guest', 'User', 'guest', 'password', 'not@available', GETDATE());
SELECT * FROM Customer;

CREATE TABLE Category
(
	CategoryID int NOT NULL IDENTITY(0,1),
	Type nvarchar(50) NOT NULL,

	CONSTRAINT PK_CATEGORY PRIMARY KEY (CategoryID ASC)
);
GO
INSERT INTO Category (Type)
Values ('Unspecificed'),('Dog'), ('Cat'), ('Bird'), ('Reptile');
SELECT * FROM Category;

CREATE TABLE Breed
(
	BreedID int NOT NULL IDENTITY(1,1),
	CategoryID int NOT NULL,
	Breed nvarchar(50) NOT NULL,

	CONSTRAINT PK_BREEDID PRIMARY KEY (BreedID ASC),
	CONSTRAINT FK_CATEGORYID FOREIGN KEY (CategoryID) REFERENCES Category(CategoryID)
);
GO
INSERT INTO Breed (CategoryID, Breed)
VALUES (1, 'German Shepard'),
	(1, 'Corgi'),
	(2, 'Maine Coon'),
	(2, 'Siamese'),
	(3, 'Parakeet'),
	(3, 'Lovebird');
SELECT * FROM Breed;

CREATE TABLE Pet
(
	PetID int NOT NULL IDENTITY(0,1),
	OwnerID int NOT NULL,
	AggressionCode int NOT NULL,
	Name nvarchar(100) NOT NULL,
	Category int NOT NULL,
	Gender int NOT NULL DEFAULT 0,
	Age int,

	CONSTRAINT PK_PETID PRIMARY KEY (PetID ASC),
	CONSTRAINT FK_OWNER FOREIGN KEY (OwnerID) REFERENCES Customer(CustomerID),
	CONSTRAINT FK_AGGRESSION FOREIGN KEY (AggressionCode) REFERENCES AggressionCode(Code),
	CONSTRAINT FK_CATEGORY FOREIGN KEY (Category) REFERENCES Category(CategoryID),
	CONSTRAINT FK_GENDER FOREIGN KEY (Gender) REFERENCES Gender(Code)
);
GO
INSERT INTO Pet(OwnerID, AggressionCode, Name, Category, Gender)
VALUES ('0','0','Unclaimed Pet', '0', '0');

CREATE TABLE Forum 
(
	ForumID int NOT NULL IDENTITY (1,1),
	IsClaimed BIT NOT NULL DEFAULT 0,
	PetID int NOT NULL,

	CONSTRAINT PK_FORUMID PRIMARY KEY (ForumID ASC),
	CONSTRAINT FK_PETID FOREIGN KEY (PetID) REFERENCES Pet(PetID)

);
GO

CREATE TABLE ForumImg
(
	ImgID int NOT NULL IDENTITY(1,1),
	ForumID int NOT NULL,
	ImgPath varchar(500) NOT NULL,

	CONSTRAINT PK_FORUM_IMG PRIMARY KEY (ImgID ASC),
	CONSTRAINT FK_FORUM FOREIGN KEY (ForumID) REFERENCES Forum(ForumID)
);
GO

CREATE TABLE Post
(
	PostID int NOT NULL IDENTITY(1,1),
	PosterID int NOT NULL,
	ReplyID int NOT NULL,
	ForumID int NOT NULL,
	LocationLatitude float NOT NULL,
	LocationLongitude float NOT NULL,
	TextBody nvarchar(1000),
	PostTime DATETIME NOT NULL,

	CONSTRAINT PK_POSTID PRIMARY KEY (PostID ASC),
	CONSTRAINT FK_POSTERID FOREIGN KEY (PosterID) REFERENCES Customer(CustomerID),
	CONSTRAINT FK_REPLYID FOREIGN KEY (ReplyID) REFERENCES Post(PostID),
	CONSTRAINT FK_FORUMID FOREIGN KEY (ForumID) REFERENCES Forum(ForumID)

);
GO

CREATE TABLE PostImage
(
	ImgID int NOT NULL IDENTITY(1,1),
	PostID int NOT NULL,
	ImgPath nvarchar(255) NOT NULL,

	CONSTRAINT PK_POST_IMG PRIMARY KEY (ImgID ASC),
	CONSTRAINT FK_POSTID FOREIGN KEY (PostID) REFERENCES Post(PostID)	
);
GO

CREATE TABLE Coloration
(
	ColorationID int NOT NULL IDENTITY(1,1),
	Color1 nvarchar(20) NOT NULL,
	Color2 nvarchar(20),
	Pattern nvarchar(100),

	CONSTRAINT ColorationID PRIMARY KEY (ColorationID ASC)	
);
GO

CREATE TABLE PetDescriptors
(
	PetID int NOT NULL,
	ColorationID int NOT NULL,
	BreedID int,

	CONSTRAINT FK_PET FOREIGN KEY (PetID) REFERENCES Pet(PetID),
	CONSTRAINT FK_Coloration FOREIGN KEY (ColorationID) REFERENCES Coloration(ColorationID),
	CONSTRAINT FK_Breed FOREIGN	KEY (BreedID) REFERENCES Breed(BreedID)
);
GO

/*
SELECT * FROM PetDescriptors;
SELECT * FROM Coloration;
SELECT * FROM PostImage;
SELECT * FROM Post;
SELECT * FROM ForumImg;
SELECT * FROM Forum;
SELECT * FROM Pet;
SELECT * FROM Breed;
SELECT * FROM Category;
SELECT * FROM Customer;
SELECT * FROM AggressionCode;
SELECT * FROM Gender;


DROP TABLE PetDescriptors;
DROP TABLE Coloration;
DROP TABLE PostImage;
DROP TABLE Post;
DROP TABLE ForumImg;
DROP TABLE Forum;
DROP TABLE Pet;
DROP TABLE Breed;
DROP TABLE Category;
DROP TABLE Customer;
DROP TABLE AggressionCode;
DROP TABLE Gender;
*/

