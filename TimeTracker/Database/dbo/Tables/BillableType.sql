CREATE TABLE [dbo].[BillableType] (
    [Id]               INT            IDENTITY (1, 1) NOT NULL,
    [Text]             NVARCHAR (50)  NULL,
    [CreatedById]      NVARCHAR (450) NOT NULL,
    [DateCreated]      DATETIME       NOT NULL,
    [LastModifiedById] NVARCHAR (450) NULL,
    [DateLastModified] DATETIME       NULL,
    [Deleted]          BIT            CONSTRAINT [DF_BillableType_Deleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_BillableType] PRIMARY KEY CLUSTERED ([Id] ASC)
);



