using Dapper.Data.Models.Domain;
using Dapper.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Task_Management_System.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskRepository _taskRepo;

        public TaskController(ITaskRepository taskRepo)
        {
            _taskRepo = taskRepo;
        }

        public async Task<IActionResult> AddTaskDetails()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddTaskDetails(TaskDetailRequestModel taskreq)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(taskreq);
                bool Result = await _taskRepo.AddTaskAsync(taskreq);
                if (Result)
                    TempData["msg"] = "Successfully added the task";
                else
                    TempData["msg"] = "Could not added the task";
            }
            catch (Exception ex)
            {
                TempData["msg"] = "Could not added the task";
            }
            return RedirectToAction(nameof(AddTaskDetails));
        }

        public async Task<IActionResult> UpdateTask(int id)
        {
            var res = await _taskRepo.GetTaskByIdAsync(id);
            return View(res);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTask(TaskDetailRequestModel taskreq)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(taskreq);
                var updateResult = await _taskRepo.UpdateTaskAsync(taskreq);
                if (updateResult)
                    TempData["msg"] = "Updated the task succesfully";
                else
                    TempData["msg"] = "Could not updated the task";

            }
            catch (Exception ex)
            {
                TempData["msg"] = "Could not updated the task";
            }
            return View(taskreq);
        }

        public async Task<IActionResult> DisplayAllTasks()
        {
            var taskdetails = await _taskRepo.GetAllTaskAsync();
            return View(taskdetails);
        }
        public async Task<IActionResult> DeleteTask(int id)
        {
            var deletetask = await _taskRepo.DeleteTaskAsync(id);
            return RedirectToAction(nameof(DisplayAllTasks));
        }


    
    }
}
