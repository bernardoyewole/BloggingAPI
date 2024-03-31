using DAL;
using Entities.Entities;

namespace BLL
{
    public interface IPostService
    {
        Task<List<Post>> GetPosts();
        Task<Post> GetPostById(int id);
        Task<bool> AddPost(Post post);
        Task<bool> UpdatePost(Post post);
        Task<bool> DeletePost(int id);
    }
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;

        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<List<Post>> GetPosts()
        {
            return await _postRepository.GetPosts();
        }

        public async Task<Post> GetPostById(int id)
        {
            return await _postRepository.GetPostById(id);
        }

        public async Task<bool> AddPost(Post post)
        {
            return await _postRepository.AddPost(post);
        }

        public async Task<bool> UpdatePost(Post post)
        {
            return await _postRepository.UpdatePost(post);
        }

        public async Task<bool> DeletePost(int id)
        {
            return await _postRepository.DeletePost(id);
        }
    }
}
