using System;
using System.Collections.Generic;
using System.Text;
using ProjectManagment.Model;
using ProjectManagment.Data;

namespace ProjectManagment.Data
{
    class CommentManager
    {
        private static readonly CommentManager _instance = new CommentManager();
        private CommentManager()
        {
        }
        public static CommentManager GetCommentManager()
        {
            return _instance;
        }

        TaskManager taskManager  = TaskManager.GetTaskManager();
        public void AddComment(long taskId, string commentString)
        {
            Comment addComment = new Comment
            {
                CommentString = commentString,
                TaskID = taskId,
                commentedDateTime = DateTime.Now
            };
            ZTask zTask= taskManager.GetZTask(taskId);
            zTask.Comment.Add(addComment);
            taskManager.UpdateTask(zTask);
        }

        public void AddReply(long commentId,long taskId, string replyString)
        {
            Comment addReply = new Comment
            {
                CommentString = replyString,
                TaskID = taskId,
                ParentId = commentId,
                commentedDateTime=DateTime.Now
            };
            ZTask zTask = taskManager.GetZTask(taskId);
            zTask.Comment.Add(addReply);
        }

        public Comment GetComment(long commentId,long taskId)
        {
            ZTask task= taskManager.GetZTask(taskId);
            return task.Comment.Find(comment=>comment.Id==commentId); 
        }
    }
}
