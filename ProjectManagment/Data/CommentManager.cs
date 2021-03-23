using System;
using System.Collections.Generic;
using System.Text;
using ProjectManagment.Model;

namespace ProjectManagment.Data
{
    class CommentManager
    {
        List<Comment> CommentList = new List<Comment>();
        public void AddComment(long taskId, string commentString)
        {
            Comment addComment = new Comment
            {
                CommentString = commentString,
                TaskID = taskId
            };

            CommentList.Add(addComment);
        }

        public void AddReply(long commentId,long taskId, string replyString)
        {
            Comment addReply = new Comment
            {
                CommentString = replyString,
                TaskID = taskId,
                ParentId = commentId
            };

            CommentList.Add(addReply);
        }

        public List<Comment> ListComments(long taskId)
        {
            List<Comment> returnComment = new List<Comment>();
            foreach(var comment in CommentList)
            {
                if (comment.TaskID == taskId)
                {
                    returnComment.Add(comment);
                }
            }
            return returnComment;
        }
    }
}
