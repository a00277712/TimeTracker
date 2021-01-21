

CREATE VIEW [dbo].[vwTime]
AS
     SELECT [Time].Id, 
            [Time].WorkDate, 
            [Time].[Location], 
            [Time].Comment, 
            [Time].[Hours], 
			[Time].UserId,
            Tasks.Title AS TaskTitle, 
            Projects.Title AS ProjectTitle, 
            BillableType.[Text] AS Billable
     FROM [Time]
          INNER JOIN Tasks ON [Time].TaskId = Tasks.Id
          INNER JOIN Projects ON Tasks.ProjectId = Projects.Id
          INNER JOIN BillableType ON [Time].BillableTypeId = BillableType.Id
     WHERE [Time].Deleted = 0
	 AND Tasks.Deleted = 0
	 AND Projects.Deleted = 0