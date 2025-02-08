CREATE OR AlTER PROCEDURE TASK.PROC_DELETETASK
(
@Id int
)
AS
BEGIN
Delete from TAsk.TaskDetails where id=@Id
END;