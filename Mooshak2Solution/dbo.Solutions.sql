CREATE TABLE [dbo].[Solutions] (
    [ID]          INT            IDENTITY (1, 1) NOT NULL,
    [userID]      NVARCHAR(MAX)            NOT NULL,
    [milestoneID] INT            NOT NULL,
    [code]        NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.Solutions] PRIMARY KEY CLUSTERED ([ID] ASC)
);

