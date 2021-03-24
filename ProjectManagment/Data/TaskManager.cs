using System;
using System.Collections.Generic;
using System.Text;
using ProjectManagment.Model;
using ProjectManagment.Constants;

namespace ProjectManagment.Data
{
    class TaskManager
    {
        private static readonly TaskManager instance = new TaskManager();
        private TaskManager()
        {
        }
        public static TaskManager GetTaskManager()
        {
            return instance;
        }

        private List<ZTask> TaskList = new List<ZTask>();

        public void AddTask(string taskString, PriorityEnum priority, uint assignedTo, uint assignedBy, DateTime assignedDate, DateTime dueDate)
        {
            ZTask addTask = new ZTask
            {
                TaskName = taskString,
                AssignedTo = assignedTo,
                AssignedBy = assignedBy,
                AssignedDate = assignedDate,
                DueDate = dueDate,
                Priority = priority
            };

            TaskList.Add(addTask);
        }
        public List<ZTask> ListAllTasks()
        {
            return TaskList;
        }


        public ZTask GetZTask(long Id)
        {
            foreach(var task in TaskList)
            {
                if (task.Id == Id)
                {
                    return task;
                }
            }
            return null;
        }

        public void UpdateTask(ZTask updateTask)
        {
            foreach(var task in TaskList)
            {
                if (task.Id == updateTask.Id)
                {
                    task.Priority = updateTask.Priority;
                    task.AssignedTo = updateTask.AssignedTo;
                    task.AssignedDate = updateTask.AssignedDate;
                    task.TaskName = updateTask.TaskName;
                    task.DueDate = updateTask.DueDate;
                }
            }
        }

        public void DeleteTask(long taskId)
        {
            int i = 0;
            foreach(var task in TaskList)
            {
                i++;
                if (task.Id == taskId)
                {
                    TaskList.RemoveAt(i);
                }
            }
        }
    }
}
