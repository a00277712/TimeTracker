CREATE TABLE [dbo].[Projects] (
    [Id]                  INT            IDENTITY (1, 1) NOT NULL,
    [Code]                NVARCHAR (50)  NOT NULL,
    [Title]               NVARCHAR (50)  NULL,
    [Description]         NVARCHAR (MAX) NULL,
    [Client]              NVARCHAR (50)  NULL,
    [ClientContact]       NVARCHAR (MAX) NULL,
    [Notes]               NVARCHAR (MAX) NULL,
    [StartDate]           DATE           NULL,
    [EndDate]             DATE           NULL,
    [CommercialCover]     NVARCHAR (MAX) NULL,
    [ProjectDeliverables] NVARCHAR (MAX) NULL,
    [DataProcessing]      BIT            NULL,
    [BudgetDays]          INT            NULL,
    [ProjectManagerId]    NVARCHAR (450) NULL,
    [ContactEmail]        NVARCHAR (MAX) NULL,
    [ReferenceProcesses]  INT            NULL,
    [CreatedById]         NVARCHAR (450) NOT NULL,
    [DateCreated]         DATETIME       NOT NULL,
    [LastModifiedById]    NVARCHAR (450) NULL,
    [DateLastModified]    DATETIME       NULL,
    [Deleted]             BIT            CONSTRAINT [DF_Projects_Deleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Projects] PRIMARY KEY CLUSTERED ([Id] ASC)
);





