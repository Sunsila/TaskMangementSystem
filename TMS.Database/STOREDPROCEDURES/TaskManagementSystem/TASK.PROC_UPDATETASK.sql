CREATE OR AlTER PROCEDURE TASK.PROC_UPDATETASK
(
@Id int,
@Title nvarchar(255),
@Description nvarchar(max),
@Status nvarchar(50),
@CreatedAt datetime,
@DueDate datetime,
@Priority nvarchar(50)
)
AS
BEGIN

UPDATE TASK.TaskDetails
        SET 
		Title=@Title,
		Description=@Description,
		Status=@Status,
		CreatedAt=@CreatedAt,
		DueDate=@DueDate,
		Priority=@Priority
        WHERE Id = @Id;

END;


