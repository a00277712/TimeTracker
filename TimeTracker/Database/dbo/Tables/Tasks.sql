CREATE TABLE [dbo].[Tasks] (
    [Id]               INT            IDENTITY (1, 1) NOT NULL,
    [ProjectId]        INT            NOT NULL,
    [TaskNo]           BIGINT         NULL,
    [Title]            NVARCHAR (50)  NOT NULL,
    [CreatedById]      NVARCHAR (450) NOT NULL,
    [DateCreated]      DATETIME       NOT NULL,
    [LastModifiedById] NVARCHAR (450) NULL,
    [DateLastModified] DATETIME       NULL,
    [Deleted]          BIT            CONSTRAINT [DF_Tasks_Deleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Tasks] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Tasks_Projects] FOREIGN KEY ([ProjectId]) REFERENCES [dbo].[Projects] ([Id])
);



