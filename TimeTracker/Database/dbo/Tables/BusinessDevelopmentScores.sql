CREATE TABLE [dbo].[BusinessDevelopmentScores] (
    [Id]    INT           IDENTITY (1, 1) NOT NULL,
    [Text]  NVARCHAR (50) NOT NULL,
    [Value] INT           NOT NULL,
    CONSTRAINT [PK_BusinessDevelopmentScores] PRIMARY KEY CLUSTERED ([Id] ASC)
);

