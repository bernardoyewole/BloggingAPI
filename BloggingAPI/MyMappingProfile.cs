using AutoMapper;
using Entities.DTO;
using Entities.Entities;

namespace BloggingAPI
{
    public class MyMappingProfile : Profile
    {
        public MyMappingProfile()
        {
            CreateMap<Post, PostDTO>();
            CreateMap<Comment, CommentDTO>();
        }
    }
}
