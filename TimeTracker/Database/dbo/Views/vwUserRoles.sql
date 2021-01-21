
CREATE VIEW [dbo].[vwUserRoles]
AS
     SELECT u.id UserId,
            r.id RoleId, 
            r.Name RoleName, 
            CAST(CASE
                     WHEN ur.userid IS NULL
                     THEN 0
                     ELSE 1
                 END AS BIT) Assigned
     FROM AspNetUsers u
          CROSS JOIN AspNetRoles r
          LEFT OUTER JOIN AspNetUserRoles ur ON ur.UserId = u.id
                                                AND ur.RoleId = r.Id;