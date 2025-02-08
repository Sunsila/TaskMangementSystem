CREATE OR ALTER PROCEDURE Task.PROC_TaskStatusReport 
AS
BEGIN
   WITH CTE_TaskDetails AS (
        SELECT 
            COUNT(*) AS TotalNoOfTasks,
            SUM(CASE WHEN Status = 'Pending' THEN 1 ELSE 0 END) AS PendingTasks,
            SUM(CASE WHEN Status = 'In Progress' THEN 1 ELSE 0 END) AS InProgressTasks,
            SUM(CASE WHEN Status = 'Completed' THEN 1 ELSE 0 END) AS CompletedTasks
        FROM Task.TaskDetails
    )
    SELECT
        TotalNoOfTasks,
        PendingTasks,
        InProgressTasks,
        CompletedTasks,
        CASE
            WHEN TotalNoOfTasks = 0 THEN 0
            ELSE (CAST(CompletedTasks AS FLOAT) / TotalNoOfTasks) * 100
        END AS CompletedTaskByPercentage
    FROM CTE_TaskDetails;
END;


 