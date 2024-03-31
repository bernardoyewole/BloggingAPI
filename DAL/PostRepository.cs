using Entities.Context;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IPostRepository
    {
        Task<List<Post>> GetPosts();
        Task<Post> GetPostById(int id);
        Task<bool> AddPost(Post post);
        Task<bool> UpdatePost(Post post);
        Task<bool> DeletePost(int id);
    }

    public class PostRepository : IPostRepository
    {
        private readonly IBlogManagementContext _blogManagementContext;

        public PostRepository(IBlogManagementContext blogManagementContext)
        {
            _blogManagementContext = blogManagementContext;
        }

        public async Task<List<Post>> GetPosts()
        {
            return await _blogManagementContext.Posts.ToListAsync();
        }

        public async Task<Post> GetPostById(int id)
        {
            Post post = await _blogManagementContext.Posts.FindAsync(id);
            
            if (post != null)
            {
                return post;
            }
            return null;
        }

        public async Task<bool> AddPost(Post post)
        {
            if (post != null)
            {
                _blogManagementContext.Entry(post).State = EntityState.Added;
                await _blogManagementContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> UpdatePost(Post post)
        {
            if (post != null)
            {
                _blogManagementContext.Entry(post).State = EntityState.Modified;
                await _blogManagementContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeletePost(int id)
        {
            Post post = await _blogManagementContext.Posts.FindAsync(id);

            if (post != null)
            {
                _blogManagementContext.Entry(post).State = EntityState.Deleted;
                await _blogManagementContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
