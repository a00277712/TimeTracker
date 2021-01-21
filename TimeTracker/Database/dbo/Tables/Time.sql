CREATE TABLE [dbo].[Time] (
    [Id]               INT             IDENTITY (1, 1) NOT NULL,
    [UserId]           NVARCHAR (450)  NOT NULL,
    [TaskId]           INT             NOT NULL,
    [WorkDate]         DATE            NOT NULL,
    [Hours]            NUMERIC (18, 2) NOT NULL,
    [Comment]          NVARCHAR (MAX)  NULL,
    [Location]         NVARCHAR (50)   NULL,
    [BillableTypeId]   INT             NOT NULL,
    [CreatedById]      NVARCHAR (450)  NOT NULL,
    [DateCreated]      DATETIME        NOT NULL,
    [LastModifiedById] NVARCHAR (450)  NULL,
    [DateLastModified] DATETIME        NULL,
    [Deleted]          BIT             CONSTRAINT [DF_Time_Deleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Time] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Time_AspNetUsers] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]),
    CONSTRAINT [FK_Time_BillableType] FOREIGN KEY ([BillableTypeId]) REFERENCES [dbo].[BillableType] ([Id]),
    CONSTRAINT [FK_Time_Tasks] FOREIGN KEY ([TaskId]) REFERENCES [dbo].[Tasks] ([Id])
);





