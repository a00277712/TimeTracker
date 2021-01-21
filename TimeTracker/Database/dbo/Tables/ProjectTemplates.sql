CREATE TABLE [dbo].[ProjectTemplates] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [TaskTitle]   NVARCHAR (50) NOT NULL,
    [TaskNo]      INT           NOT NULL,
    [ProjectType] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_ProjectTemplates] PRIMARY KEY CLUSTERED ([Id] ASC)
);

