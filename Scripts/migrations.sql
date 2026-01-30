IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
CREATE TABLE [Administrators] (
    [Id] uniqueidentifier NOT NULL,
    [FirstName] nvarchar(50) NOT NULL,
    [LastName] nvarchar(50) NOT NULL,
    [Email] varchar(100) NOT NULL,
    [Dni] varchar NOT NULL,
    [Age] int NOT NULL,
    [Domicilie_Street] varchar(30) NOT NULL,
    [Domicilie_City] varchar(30) NOT NULL,
    [Domicilie_Number] int NOT NULL,
    CONSTRAINT [PK_Administrators] PRIMARY KEY ([Id])
);

CREATE TABLE [Rules] (
    [Id] uniqueidentifier NOT NULL,
    [TypeRule] int NOT NULL,
    [Value] float NOT NULL,
    CONSTRAINT [PK_Rules] PRIMARY KEY ([Id])
);

CREATE TABLE [Users] (
    [Id] uniqueidentifier NOT NULL,
    [UserName] nvarchar(20) NOT NULL,
    [Password] nvarchar(20) NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
);

CREATE TABLE [Alumns] (
    [Id] uniqueidentifier NOT NULL,
    [UserId] uniqueidentifier NOT NULL,
    [FirstName] nvarchar(50) NOT NULL,
    [LastName] nvarchar(50) NOT NULL,
    [Email] varchar(100) NOT NULL,
    [Dni] varchar NOT NULL,
    [Age] int NOT NULL,
    [Domicilie_Street] varchar(30) NOT NULL,
    [Domicilie_City] varchar(30) NOT NULL,
    [Domicilie_Number] int NOT NULL,
    CONSTRAINT [PK_Alumns] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Alumns_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
);

CREATE TABLE [Teachers] (
    [Id] uniqueidentifier NOT NULL,
    [Phone] varchar(50) NOT NULL,
    [UserId] uniqueidentifier NOT NULL,
    [FirstName] nvarchar(50) NOT NULL,
    [LastName] nvarchar(50) NOT NULL,
    [Email] varchar(100) NOT NULL,
    [Dni] varchar NOT NULL,
    [Age] int NOT NULL,
    [Domicilie_Street] varchar(30) NOT NULL,
    [Domicilie_City] varchar(30) NOT NULL,
    [Domicilie_Number] int NOT NULL,
    CONSTRAINT [PK_Teachers] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Teachers_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
);

CREATE TABLE [Courses] (
    [Id] uniqueidentifier NOT NULL,
    [Name] varchar(30) NOT NULL,
    [Description] varchar(450) NOT NULL,
    [PriceBase] float NOT NULL,
    [PriceEnd] float NOT NULL,
    [RuleId] uniqueidentifier NOT NULL,
    [TeacherId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_Courses] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Courses_Rules_RuleId] FOREIGN KEY ([RuleId]) REFERENCES [Rules] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Courses_Teachers_TeacherId] FOREIGN KEY ([TeacherId]) REFERENCES [Teachers] ([Id]) ON DELETE CASCADE
);

CREATE TABLE [Classes] (
    [Id] uniqueidentifier NOT NULL,
    [Number] int NOT NULL,
    [Description] varchar(450) NOT NULL,
    [CourseId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_Classes] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Classes_Courses_CourseId] FOREIGN KEY ([CourseId]) REFERENCES [Courses] ([Id]) ON DELETE CASCADE
);

CREATE TABLE [Inscriptions] (
    [Id] uniqueidentifier NOT NULL,
    [InscriptionDate] datetime2 NOT NULL,
    [Status] int NOT NULL,
    [AlumnId] uniqueidentifier NOT NULL,
    [AdministratorId] uniqueidentifier NOT NULL,
    [CourseId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_Inscriptions] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Inscriptions_Administrators_AdministratorId] FOREIGN KEY ([AdministratorId]) REFERENCES [Administrators] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Inscriptions_Alumns_AlumnId] FOREIGN KEY ([AlumnId]) REFERENCES [Alumns] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Inscriptions_Courses_CourseId] FOREIGN KEY ([CourseId]) REFERENCES [Courses] ([Id]) ON DELETE CASCADE
);

CREATE TABLE [Contents] (
    [Id] uniqueidentifier NOT NULL,
    [Name] varchar(30) NOT NULL,
    [Description] varchar(450) NOT NULL,
    [ClassId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_Contents] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Contents_Classes_ClassId] FOREIGN KEY ([ClassId]) REFERENCES [Classes] ([Id]) ON DELETE CASCADE
);

CREATE TABLE [Fees] (
    [Id] uniqueidentifier NOT NULL,
    [Number] int NOT NULL,
    [Value] float NOT NULL,
    [InscriptionId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_Fees] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Fees_Inscriptions_InscriptionId] FOREIGN KEY ([InscriptionId]) REFERENCES [Inscriptions] ([Id]) ON DELETE CASCADE
);

CREATE TABLE [Materials] (
    [Id] uniqueidentifier NOT NULL,
    [Name] varchar(30) NOT NULL,
    [Path] varchar(255) NOT NULL,
    [Description] varchar(450) NOT NULL,
    [DateCreated] datetime2 NOT NULL,
    [ContentId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_Materials] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Materials_Contents_ContentId] FOREIGN KEY ([ContentId]) REFERENCES [Contents] ([Id]) ON DELETE CASCADE
);

CREATE TABLE [Pays] (
    [Id] uniqueidentifier NOT NULL,
    [PayDate] datetime2 NOT NULL,
    [Amount] float NOT NULL,
    [TypeMethod] int NOT NULL,
    [FeeId] uniqueidentifier NOT NULL,
    [AdministratorId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_Pays] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Pays_Administrators_AdministratorId] FOREIGN KEY ([AdministratorId]) REFERENCES [Administrators] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Pays_Fees_FeeId] FOREIGN KEY ([FeeId]) REFERENCES [Fees] ([Id]) ON DELETE CASCADE
);

CREATE INDEX [IX_Alumns_UserId] ON [Alumns] ([UserId]);

CREATE INDEX [IX_Classes_CourseId] ON [Classes] ([CourseId]);

CREATE INDEX [IX_Contents_ClassId] ON [Contents] ([ClassId]);

CREATE INDEX [IX_Courses_RuleId] ON [Courses] ([RuleId]);

CREATE INDEX [IX_Courses_TeacherId] ON [Courses] ([TeacherId]);

CREATE UNIQUE INDEX [IX_Fees_InscriptionId] ON [Fees] ([InscriptionId]);

CREATE INDEX [IX_Inscriptions_AdministratorId] ON [Inscriptions] ([AdministratorId]);

CREATE INDEX [IX_Inscriptions_AlumnId] ON [Inscriptions] ([AlumnId]);

CREATE UNIQUE INDEX [IX_Inscriptions_CourseId] ON [Inscriptions] ([CourseId]);

CREATE INDEX [IX_Materials_ContentId] ON [Materials] ([ContentId]);

CREATE INDEX [IX_Pays_AdministratorId] ON [Pays] ([AdministratorId]);

CREATE INDEX [IX_Pays_FeeId] ON [Pays] ([FeeId]);

CREATE INDEX [IX_Teachers_UserId] ON [Teachers] ([UserId]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260123005032_ModelInitial', N'9.0.11');

COMMIT;
GO

