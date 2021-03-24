using System;
using System.Collections.Generic;
using System.Text;
using ProjectManagment.Model;
using ProjectManagment.Data;

namespace ProjectManagment.Data
{
    class CommentManager
    {
        private static readonly CommentManager instance = new CommentManager();
        private CommentManager()
        {
        }
        public static CommentManager GetCommentManager()
        {
            return instance;
        }

        //List<Comment> CommentList = new List<Comment>();
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
            zTask.comment.Add(addComment);
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
            zTask.comment.Add(addReply);
        }
    }
}
