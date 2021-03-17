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

        public Model.Task UpdateTask(int taskNo, int updateNo, string updateString)
        {
            Model.Task updateTask = TaskList[taskNo];
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
        public Model.Task UpdateTask(int taskNo, DateTime updateDueDate)
        {
            Model.Task updateTask = TaskList[taskNo];
            updateTask.DueDate = updateDueDate;
            return updateTask;
        }
        public Model.Task UpdateTask(int taskNo,Constants.PriorityEnum updatePriority)
        {
            Model.Task updateTask = TaskList[taskNo];
            updateTask.Priority = updatePriority;
            return updateTask;
        }


        public void Delete(int deleteNumber)
        {
            TaskList.RemoveAt(deleteNumber);
        }


    }
}
