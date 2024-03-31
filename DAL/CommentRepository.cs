using Entities.Context;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DAL
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetComments();
        Task<Comment> GetCommentById(int id);
        Task<List<Comment>> GetCommentsByPostId(int id);
        Task<bool> AddComment(Comment comment);
        Task<bool> UpdateComment(Comment comment);
        Task<bool> DeleteComment(int id);
        Task<bool> DeleteCommentsByPost(int id);
    }

    public class CommentRepository : ICommentRepository
    {
        private readonly IBlogManagementContext _blogManagementContext;

        public CommentRepository(IBlogManagementContext blogManagementContext)
        {
            _blogManagementContext = blogManagementContext;
        }

        public async Task<List<Comment>> GetComments()
        {
            return await _blogManagementContext.Comments.ToListAsync();
        }

        public async Task<Comment> GetCommentById(int id)
        {
            Comment comment = await _blogManagementContext.Comments.FindAsync(id);

            if (comment != null)
            {
                return comment;
            }
            return null;
        }

        public async Task<List<Comment>> GetCommentsByPostId(int id)
        {
            List<Comment> commentsByPost= await _blogManagementContext.Comments.Where(x => x.PostId == id).ToListAsync();
            return commentsByPost;
        }

        public async Task<bool> AddComment(Comment comment)
        {
            if (comment != null)
            {
                _blogManagementContext.Entry(comment).State = EntityState.Added;
                await _blogManagementContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> UpdateComment(Comment comment)
        {
            if (comment != null)
            {
                _blogManagementContext.Entry(comment).State = EntityState.Modified;
                await _blogManagementContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteComment(int id)
        {
            Comment comment = await _blogManagementContext.Comments.FindAsync(id);

            if (comment != null)
            {
                _blogManagementContext.Entry(comment).State = EntityState.Deleted;
                await _blogManagementContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteCommentsByPost(int id)
        {
            List<Comment> commentsByPost = await _blogManagementContext.Comments.Where(x => x.PostId == id).ToListAsync();

            foreach (Comment comment in commentsByPost)
            {
                if (comment != null)
                {
                    _blogManagementContext.Entry(comment).State = EntityState.Deleted;
                    await _blogManagementContext.SaveChangesAsync();
                }
            }

            List<Comment> deletedComments = await _blogManagementContext.Comments.Where(x => x.PostId == id).ToListAsync();

            if (deletedComments.Count > 0)
            {
                return false;
            }
            return true;
        }
    }
}
