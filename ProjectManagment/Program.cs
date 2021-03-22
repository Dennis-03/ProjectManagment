using System;
using System.Collections.Generic;
using ProjectManagment.Data;
using ProjectManagment.Constants;
using ProjectManagment.Model;



namespace ProjectManagment
{
    class Program
    {
        static void Main(string[] args)
        {
            TaskManager taskManager = new TaskManager();
            UserManager userManger = new UserManager();

            userManger.AddUser("dennis", "123");
            userManger.AddUser("saravana", "123");

            Console.WriteLine("Enter your User Name");
            string username= Console.ReadLine();
            Console.WriteLine("Enter your Password");
            string password = Console.ReadLine();

            if (userManger.VerifyUser(username, password))
            {
                int option;

                do
                {
                    Console.WriteLine("Enter Your Choice\n1.Create New Task \n2.List All Task \n3.Update Task\n4.Delete Task\n5.Comment on a Task\n6.Reply to a Comment\n7.View a Specific Task\n0.Quit");
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
                            Console.WriteLine("Priority of the Task(Low/Medium/High)");
                            PriorityEnum Priority = Enum.Parse<PriorityEnum>(Console.ReadLine());

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

                            List<ZTask> allTasks = taskManager.ListAllTasks();

                            Console.WriteLine("List of all Tasks");

                            foreach (var task in allTasks)
                            {
                                Console.WriteLine($"Task Name:{ task.Id}");
                                Console.WriteLine($"Task Name:{ task.TaskName}");
                                Console.WriteLine($"Assigned To:{ task.AssignedTo}");
                                Console.WriteLine($"Assigned By:{ task.AssignedBy}\n");
                            }
                            break;

                        case 3:

                            Console.WriteLine("Enter the task Id for updating");
                            int taskNumber = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("1.Update Task\n2.Update Priority\n3.Update Assigned To\n4.Update Assigned By\n5.Update Due date");
                            int updateNo = Convert.ToInt32(Console.ReadLine());

                            if (updateNo == 1 || updateNo == 3 || updateNo == 4)
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
                            int deleteNumber = Convert.ToInt32(Console.ReadLine());
                            taskManager.Delete(--deleteNumber);
                            break;

                        case 5:
                            int commentTask = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Enter the Comment String");
                            string commentString = Console.ReadLine();

                            taskManager.AddComment(commentTask, commentString);

                            break;

                        case 6:
                            Console.WriteLine("Enter the task");
                            int replyTask = Convert.ToInt32(Console.ReadLine());

                            taskManager.ListComments(replyTask);

                            int replyComment = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter the Reply String");
                            string replyString = Console.ReadLine();

                            taskManager.AddReply(replyComment, replyString);

                            break;

                        case 7:
                            Console.WriteLine("Enter the Specific task Number");
                            int taskNo = Convert.ToInt32(Console.ReadLine());
                            taskManager.DisplayTask(taskNo);

                            break;
                    }
                } while (option != 0);

            }
            else
            {
                Console.WriteLine("Password or Username Incorrect");
            }

             
        }
    }
}
