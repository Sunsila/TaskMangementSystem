CREATE OR AlTER PROCEDURE TASK.PROC_ADDTASK
(
@Title nvarchar(255),
@Description nvarchar(max),
@Status nvarchar(50),
@CreatedAt datetime,
@DueDate datetime,
@Priority nvarchar(50)
)
AS
BEGIN
INSERT INTO Task.TaskDetails (Title, Description, Status, CreatedAt, DueDate,Priority)
VALUES 
(@Title, @Description, @Status, @CreatedAt, @DueDate,@Priority)
END;