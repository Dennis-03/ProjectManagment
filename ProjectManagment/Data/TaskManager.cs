using System;
using System.Collections.Generic;
using System.Text;
using ProjectManagment.Model;
using ProjectManagment.Constants;

namespace ProjectManagment.Data
{
    class TaskManager
    {
        List<ZTask> TaskList = new List<ZTask>();
        List<Comment> CommentList = new List<Comment>();
        List<Reply> ReplyList = new List<Reply>();


        public void AddTask(string taskString, PriorityEnum priority, string assignedTo, string assignedBy, DateTime assignedDate, DateTime dueDate)
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



        public void DisplayAllTaskNames()
        {
            Console.WriteLine("List of all Tasks");
            int i = 1;

            foreach (var task in TaskList)
            {
                Console.WriteLine($"{i}:{ task.TaskName}");
                i++;
            }
        }

        public ZTask UpdateTask(int taskNo, int updateNo, string updateString)
        {
            ZTask updateTask = TaskList[taskNo];
            switch (updateNo)
            {
                case 1:
                    updateTask.TaskName = updateString;
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
        public ZTask UpdateTask(int taskNo, DateTime updateDueDate)
        {
            ZTask updateTask = TaskList[taskNo];
            updateTask.DueDate = updateDueDate;
            return updateTask;
        }
        public ZTask UpdateTask(int taskNo,PriorityEnum updatePriority)
        {
            ZTask updateTask = TaskList[taskNo];
            updateTask.Priority = updatePriority;
            return updateTask;
        }


        public void Delete(int deleteNumber)
        {
            TaskList.RemoveAt(deleteNumber);
        }

        public long GetTaskID(int taskNo)
        {
            return TaskList[taskNo].Id;
        }
        public void AddComment(int taskNo,string commentString)
        {
            Comment addComment = new Comment();
            addComment.CommentString = commentString;
            addComment.TaskID = GetTaskID(--taskNo);

            CommentList.Add(addComment);
        }

        public long GetCommentID(int commentNo)
        {
            return CommentList[commentNo].Id;
        }

        public void ListComments(int taskNo)
        {
            int i = 1;
            long taskID = GetTaskID(--taskNo);
            foreach(var comment in CommentList)
            {
                if (comment.TaskID == taskID)
                {
                    Console.WriteLine($"{i}.{comment.CommentString}");
                    i++;
                }
            }
        }
        public void AddReply(int commentNo,string replyString)
        {
            Reply addReply = new Reply();
            addReply.ReplyString = replyString;
            addReply.CommentID = GetCommentID(--commentNo);

            ReplyList.Add(addReply);
        }

        public void DisplayTask(int taskNo)
        {
            taskNo--;
            Console.WriteLine($"Task Name : {TaskList[taskNo].TaskName}");
            Console.WriteLine($"Priority : {TaskList[taskNo].Priority}");
            Console.WriteLine($"Assigned To : {TaskList[taskNo].AssignedTo}");
            Console.WriteLine($"Assigned By : {TaskList[taskNo].AssignedBy}");
            Console.WriteLine($"Due Date : {TaskList[taskNo].DueDate.ToString("dd-MMM-yyyy")}");
            Console.WriteLine($"Assigned Date : {TaskList[taskNo].AssignedDate.ToString("dd-MMM-yyyy")}");

            Console.WriteLine("The comments for the task are");
            long taskID = GetTaskID(taskNo);
            foreach(var comment in CommentList)
            {
                if (comment.TaskID == taskID)
                {
                    Console.WriteLine(comment.CommentString);
                    foreach(var reply in ReplyList)
                    {
                        if (comment.Id == reply.CommentID)
                        {
                            Console.WriteLine($"-{reply.ReplyString}");
                        }
                    }
                }
            }

        }
    }
}
