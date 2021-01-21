CREATE TABLE [dbo].[OperationalScores] (
    [Id]    INT           IDENTITY (1, 1) NOT NULL,
    [Text]  NVARCHAR (50) NOT NULL,
    [Value] INT           NOT NULL,
    CONSTRAINT [PK_OperationalScores] PRIMARY KEY CLUSTERED ([Id] ASC)
);

