using System;
using System.Collections.Generic;


namespace ProjectManagment
{
    class Program
    {


        static void Main(string[] args)
        {
            Data.TaskManger taskManager = new Data.TaskManger();

            //TaskManager.AddTask("hello", Constants.PriorityEnum.Low, "dennis", "saravanan", DateTime.Now, DateTime.Now);
            int option;

            do
            {
                Console.WriteLine("Enter Your Choice\n1.Create New Task \n2.List All Task \n3.Update Task\n4.Delete Task\n0.Quit");
                option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        Console.WriteLine("Enter Name of the task");
                        string taskName = Console.ReadLine();
                        Console.WriteLine("Assigned To ");
                        string assignedTo = Console.ReadLine();
                        Console.WriteLine("Assigned By");
                        string assignedBy = Console.ReadLine();
                        Console.WriteLine("Priority of the Task(Low//Medium//High)");
                        Constants.PriorityEnum Priority = Enum.Parse<Constants.PriorityEnum>(Console.ReadLine());

                        Console.WriteLine("Due Date(1-31)");
                        int date = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Due Month(1-12)");
                        int month = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Due Date(YYYY)");
                        int year = Convert.ToInt32(Console.ReadLine());
                        DateTime dueDate = new DateTime(year, month, date);

                        taskManager.AddTask(taskName, Priority, assignedTo, assignedBy, DateTime.Now, dueDate);
                        break;

                    case 2:

                        List<Model.Task> allTasks = taskManager.ListAllTasks();

                        Console.WriteLine("List of all Tasks"); 

                        foreach (var task in allTasks)
                        {
                            Console.WriteLine($"Task Name:{ task.TaskString}");
                            Console.WriteLine($"Assigned To:{ task.AssignedTo}");
                            Console.WriteLine($"Assigned By:{ task.AssignedBy}\n");
                        }
                        break;

                    case 3:
                        taskManager.DisplayAllTaskNames();

                        Console.WriteLine("Enter the task Number for updating");
                        int taskNumber = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("1.Update Task\n2.Update Priority\n3.Update Assigned To\n4.Update Assigned By\n5.Update Due date");
                        int updateNo = Convert.ToInt32(Console.ReadLine());

                        if(updateNo == 1 || updateNo == 3 || updateNo == 4)
                        {
                            Console.WriteLine("Enter the new string");
                            string updateString = Console.ReadLine();
                            taskManager.UpdateTask(taskNumber - 1, updateNo, updateString);
                        }
                        else if (updateNo == 5)
                        {
                            Console.WriteLine("Due Date(1-31)");
                            int newDate = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Due Month(1-12)");
                            int newMonth = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Due Date(YYYY)");
                            int newYear = Convert.ToInt32(Console.ReadLine());
                            DateTime newDueDate = new DateTime(newYear, newMonth, newDate);

                            taskManager.UpdateTask(taskNumber - 1, newDueDate);
                        }
                        else 
                        {
                            Console.WriteLine("Enter the New Priority");
                            Constants.PriorityEnum newPriority = Enum.Parse<Constants.PriorityEnum>(Console.ReadLine());
                            taskManager.UpdateTask(taskNumber - 1, newPriority);
                        }

                        break;

                    case 4:
                        taskManager.DisplayAllTaskNames();
                        int deleteNumber = Convert.ToInt32(Console.ReadLine());
                        taskManager.Delete(--deleteNumber);
                        break;
                }
            } while (option != 0); 
        }
    }
}
