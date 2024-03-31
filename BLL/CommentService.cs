using DAL;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface ICommentService
    {
        Task<List<Comment>> GetComments();
        Task<Comment> GetCommentById(int id);
        Task<List<Comment>> GetCommentsByPostId(int id);
        Task<bool> AddComment(Comment comment);
        Task<bool> UpdateComment(Comment comment);
        Task<bool> DeleteComment(int id);
        Task<bool> DeleteCommentsByPost(int id);
    }

    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;

        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<List<Comment>> GetComments()
        {
            return await _commentRepository.GetComments();
        }

        public async Task<Comment> GetCommentById(int id)
        {
            return await _commentRepository.GetCommentById(id);
        }

        public async Task<List<Comment>> GetCommentsByPostId(int id)
        {
            return await _commentRepository.GetCommentsByPostId(id);
        }

        public async Task<bool> AddComment(Comment comment)
        {
            return await _commentRepository.AddComment(comment);
        }

        public async Task<bool> UpdateComment(Comment comment)
        {
            return await _commentRepository.UpdateComment(comment);
        }

        public async Task<bool> DeleteComment(int id)
        {
            return await _commentRepository.DeleteComment(id);
        }

        public async Task<bool> DeleteCommentsByPost(int id)
        {
            return await _commentRepository.DeleteCommentsByPost(id);
        }
    }
}
