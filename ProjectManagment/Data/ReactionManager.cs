using System;
using System.Collections.Generic;
using System.Text;
using ProjectManagment.Data;
using ProjectManagment.Model;

namespace ProjectManagment.Data
{
    class ReactionManager
    {
        TaskManager taskManager = TaskManager.GetTaskManager();
        CommentManager commentManager = CommentManager.GetCommentManager();
        public bool AddReactionToTask(long  reactedById,long taskId)
        {
            ZTask task = new ZTask();
            task = taskManager.GetZTask(taskId);
            foreach(var reaction in task.Reaction)
            {
                if (reaction.ReactedById == reactedById)
                {
                    return false;
                }
            }
            Reaction newReaction = new Reaction
            {
                ReactedById = reactedById,
                ReactedToId = taskId
            };
            task.Reaction.Add(newReaction);
            return true;
        }

        public bool AddReactionToComment(long reactedById, long commentId,long taskId)
        {
            Comment myComment = new Comment();
            myComment = commentManager.GetComment(commentId, taskId);
            foreach (var reaction in myComment.Reaction)
            {
                if (reaction.ReactedById == reactedById)
                {
                    return false;
                }
            }
            Reaction newReaction = new Reaction
            {
                ReactedById = reactedById,
                ReactedToId = taskId
            };
            myComment.Reaction.Add(newReaction);
            return true;
        }
    }
}
