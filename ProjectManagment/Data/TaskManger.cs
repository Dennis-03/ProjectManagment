using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManagment.Data
{
    class TaskManger
    {
        List<Model.Task> TaskList = new List<Model.Task>();

        public void AddTask(string taskString, Constants.PriorityEnum priority, string assignedTo, string assignedBy, DateTime assignedDate, DateTime dueDate)
        {
            Model.Task myTask = new Model.Task();
            myTask.TaskString = taskString;
            myTask.AssignedTo = assignedTo;
            myTask.AssignedBy = assignedBy;
            myTask.AssignedDate = assignedDate;
            myTask.DueDate = dueDate;
            myTask.Priority = priority;

            TaskList.Add(myTask);
        }
        public List<Model.Task> ListAllTasks()
        {
            return TaskList;
        }

        public void DisplayAllTaskNames()
        {

            Console.WriteLine("List of all Tasks");
            int i = 1;

            foreach (var task in TaskList)
            {
                Console.WriteLine($"{i}:{ task.TaskString}");
                i++;
            }
        }

        public Model.Task UpdateTask(Model.Task updateTask, int updateNo, string updateString)
        {
            switch (updateNo)
            {
                case 1:
                    updateTask.TaskString = updateString;
                    break;
                case 3:
                    updateTask.AssignedTo = updateString;
                    break;
                case 4:
                    updateTask.AssignedBy = updateString;
                    break;
            }
            return updateTask;
        }
        public Model.Task UpdateTask(Model.Task updateTask, DateTime updateDueDate)
        {
            updateTask.DueDate = updateDueDate;
            return updateTask;
        }
        public Model.Task UpdateTask(Model.Task updateTask,Constants.PriorityEnum updatePriority)
        {
            updateTask.Priority = updatePriority;
            return updateTask;
        }


    }
}
