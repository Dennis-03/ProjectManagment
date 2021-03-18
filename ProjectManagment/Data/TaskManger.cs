using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManagment.Data
{
    class TaskManger
    {
        List<Model.Task> TaskList = new List<Model.Task>();
        List<Model.Comment> CommentList = new List<Model.Comment>();
        List<Model.Reply> ReplyList = new List<Model.Reply>();


        public void AddTask(string taskString, Constants.PriorityEnum priority, string assignedTo, string assignedBy, DateTime assignedDate, DateTime dueDate)
        {
            Model.Task addTask = new Model.Task();
            addTask.TaskString = taskString;
            addTask.AssignedTo = assignedTo;
            addTask.AssignedBy = assignedBy;
            addTask.AssignedDate = assignedDate;
            addTask.DueDate = dueDate;
            addTask.Priority = priority;

            TaskList.Add(addTask);
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

        public long GetTaskID(int taskNo)
        {
            return TaskList[taskNo].ID;
        }
        public void AddComment(int taskNo,string commentString)
        {
            Model.Comment addComment = new Model.Comment();
            addComment.CommentString = commentString;
            addComment.TaskID = GetTaskID(--taskNo);

            CommentList.Add(addComment);
        }

        public long GetCommentID(int commentNo)
        {
            return CommentList[commentNo].ID;
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
            Model.Reply addReply = new Model.Reply();
            addReply.ReplyString = replyString;
            addReply.CommentID = GetCommentID(--commentNo);

            ReplyList.Add(addReply);
        }

        public void DisplayTask(int taskNo)
        {
            taskNo--;
            Console.WriteLine($"Task Name : {TaskList[taskNo].TaskString}");
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
                        if (comment.ID == reply.CommentID)
                        {
                            Console.WriteLine($"-{reply.ReplyString}");
                        }
                    }
                }
            }

        }
    }
}
