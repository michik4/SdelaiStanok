CREATE DATABASE Gallery; 
USE Gallery;
GO

CREATE TABLE Descriptions (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Text NVARCHAR(MAX)
);

CREATE TABLE Tags (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(255)
);

CREATE TABLE GalleryItems (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Title NVARCHAR(255),
    MainImagePath NVARCHAR(MAX), 
    DescriptionId INT,
    FOREIGN KEY (DescriptionId) REFERENCES Descriptions(Id)
);

CREATE TABLE GalleryImages ( 
    Id INT PRIMARY KEY IDENTITY(1,1),
    ImagePath NVARCHAR(MAX), 
    GalleryItemId INT,
    FOREIGN KEY (GalleryItemId) REFERENCES GalleryItems(Id)
);


CREATE TABLE GalleryItemTags (
    GalleryItemId INT,
    TagId INT,
    PRIMARY KEY (GalleryItemId, TagId),
    FOREIGN KEY (GalleryItemId) REFERENCES GalleryItems(Id),
    FOREIGN KEY (TagId) REFERENCES Tags(Id)
);
GO