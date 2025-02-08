-- Create the Tasks table
CREATE TABLE Task.TaskDetails (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Title NVARCHAR(255) NOT NULL,
    Description NVARCHAR(MAX) NULL,
    Status NVARCHAR(50) CHECK (Status IN ('Pending', 'In Progress', 'Completed')) NOT NULL,
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),
    DueDate DATETIME NULL
);




