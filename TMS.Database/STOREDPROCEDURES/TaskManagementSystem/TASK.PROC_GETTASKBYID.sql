CREATE OR AlTER PROCEDURE TASK.PROC_GETTASKBYID
(
@Id int
)
AS
BEGIN
Select * from TAsk.TaskDetails where id=@Id
END;