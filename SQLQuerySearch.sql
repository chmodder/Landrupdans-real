SELECT TeamName, StyleName, Description, FirstName, LastName, Info, Level, StudentAge  FROM Teams
INNER JOIN Styles ON Styles.Id = Teams.FkStyleId
INNER JOIN Instructors ON Instructors.Id = Teams.FKInstructorId
INNER JOIN Age ON Age.Id = Teams.FkAgeId
INNER JOIN Levels ON Levels.Id = Teams.FkLevelId
WHERE Instructors.FirstName LIKE '%ørg%' OR Instructors.LastName LIKE '%ørg%'