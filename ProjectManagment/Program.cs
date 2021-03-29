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
            TaskManager taskManager = TaskManager.GetTaskManager();
            UserManager userManager = UserManager.GetUserManager();
            CommentManager commentManager = CommentManager.GetCommentManager();
            ReactionManager reactionManager = ReactionManager.GetReactionManager();

            userManager.AddUser("dennis", "dennis");
            userManager.AddUser("saravana", "saravana");

            User newUser;

            do
            {
                Console.WriteLine("Enter your User Name");
                string username = Console.ReadLine();
                Console.WriteLine("Enter your Password");
                string password = Console.ReadLine();
                newUser = userManager.VerifyUser(username,password);

            } while (newUser == null);

            int option;

            do
            {
                Console.WriteLine("\nEnter Your Choice\n1.Create New Task \n2.List All Task \n3.Update Task\n4.Delete Task\n5.Comment on a Task\n6.Reply to a Comment\n7.View a Specific Task\n8.Like a Task\n9.Like a Comment\n0.Quit");
                option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        Console.WriteLine("Enter Name of the task");
                        string taskName = Console.ReadLine();
                        Console.WriteLine("Assigned To (User Id)");
                        uint assignedTo = Convert.ToUInt32( Console.ReadLine());
                        Console.WriteLine("Priority of the Task(Low/Medium/High)");
                        PriorityEnum Priority = Enum.Parse<PriorityEnum>(Console.ReadLine());

                        Console.WriteLine("Due Date(1-31)");
                        int date = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Due Month(1-12)");
                        int month = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Due Date(YYYY)");
                        int year = Convert.ToInt32(Console.ReadLine());
                        DateTime dueDate = new DateTime(year, month, date);

                        taskManager.AddTask(taskName, Priority, assignedTo, newUser.Id, DateTime.Now, dueDate);

                        break;

                    case 2:

                        List<ZTask> allTasks = taskManager.ListAllTasks();

                        Console.WriteLine("List of all Tasks");

                        foreach (var ztask in allTasks)
                        {
                            Console.WriteLine($"Task Id: { ztask.Id}");
                            Console.WriteLine($"Task Name:{ ztask.TaskName}");
                            Console.WriteLine($"Priority:{ ztask.Priority}");
                            Console.WriteLine($"Assigned To:{ ztask.AssignedTo}");
                            Console.WriteLine($"Assigned By:{ ztask.AssignedBy}");
                            Console.WriteLine($"Assigned Date:{ ztask.AssignedDate}");
                            Console.WriteLine($"Due Date:{ ztask.DueDate}\n");
                        }
                        break;

                    case 3:

                        Console.WriteLine("Enter the task Id for updating");
                        long taskId = Convert.ToInt64(Console.ReadLine());
                        Console.WriteLine("1.Update Task\n2.Update Priority\n3.Update Assigned To\n4.Update Due date");
                        int updateNo = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter the new data");
                        string newData = Console.ReadLine();

                        ZTask updateTask= taskManager.GetZTask(taskId);
                        switch (updateNo)
                        {
                            case 1:
                                updateTask.TaskName = newData;
                                break;
                            case 2:
                                updateTask.Priority = Enum.Parse<PriorityEnum>(newData);
                                break;
                            case 3:
                                updateTask.AssignedTo = Convert.ToUInt32(newData);
                                break;
                            case 4:
                                updateTask.DueDate = Convert.ToDateTime(newData);
                                break;
                        }

                        taskManager.UpdateTask(updateTask);

                        break;

                    case 4:
                        Console.WriteLine("Enter the task ID:");
                        long deleteTaskId = Convert.ToInt64(Console.ReadLine());
                        taskManager.DeleteTask(deleteTaskId);
                        break;

                    case 5:
                        Console.WriteLine("Enter the task ID:");
                        long commentTaskId = Convert.ToInt64(Console.ReadLine());

                        Console.WriteLine("Enter the Comment String");
                        string commentString = Console.ReadLine();

                        commentManager.AddComment(commentTaskId,commentString);

                        break;

                    case 6:
                        Console.WriteLine("Enter the task ID:");
                        long replyTaskId = Convert.ToInt64(Console.ReadLine());
                        Console.WriteLine("Enter the Comment ID:");
                        long replyCommentId = Convert.ToInt64(Console.ReadLine());
                        Console.WriteLine("Enter the Reply String");
                        string replyString = Console.ReadLine();

                        commentManager.AddReply(replyCommentId, replyTaskId, replyString);

                        break;

                    case 7:
                        Console.WriteLine("Enter the Specific task Number");
                        long specTaskId= Convert.ToInt64(Console.ReadLine());
                        ZTask task = taskManager.GetZTask(specTaskId);

                        Console.WriteLine($"Task Id: { task.Id}");
                        Console.WriteLine($"Task Name:{ task.TaskName}");
                        Console.WriteLine($"Priority:{ task.Priority}");
                        Console.WriteLine($"Assigned To:{ task.AssignedTo}");
                        Console.WriteLine($"Assigned By:{ task.AssignedBy}");
                        Console.WriteLine($"Assigned Date:{ task.AssignedDate}");
                        Console.WriteLine($"Due Date:{ task.DueDate}");
                        Console.WriteLine($"No of Likes: {task.Reaction.Count}");

                        if (task.Comment != null)
                        {
                            foreach (var comment in task.Comment)
                            {
                                Console.WriteLine($"Comment Id: {comment.Id}");
                                Console.WriteLine($"Comment : { comment.CommentString}");
                                Console.WriteLine($"Comment Parent Id : {comment.ParentId}");
                                Console.WriteLine($"Commented Time {comment.commentedDateTime}");
                                Console.WriteLine($"No of likes {comment.Reaction.Count}\n");
                            }
                        }

                        break;
                    case 8:
                        Console.WriteLine("Enter the task ID:");
                        long likeTaskId = Convert.ToInt64(Console.ReadLine());
                        reactionManager.AddReactionToTask(newUser.Id, likeTaskId);

                        break;
                    case 9:
                        Console.WriteLine("Enter the task ID:");
                        long likeCommentTaskId = Convert.ToInt64(Console.ReadLine());
                        Console.WriteLine("Enter the Comment ID:");
                        long likeCommentId = Convert.ToInt64(Console.ReadLine());
                        reactionManager.AddReactionToComment(newUser.Id,likeCommentId,likeCommentTaskId);

                        break;
                }
            } while (option != 0);

        }
    }
}

