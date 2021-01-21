CREATE TABLE [dbo].[ClosoutReasons] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Text] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_ClosoutReasons] PRIMARY KEY CLUSTERED ([Id] ASC)
);

