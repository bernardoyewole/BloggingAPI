using AutoMapper;
using BLL;
using DAL;
using Entities.Context;

namespace BloggingAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddSingleton<IPostService, PostService>();
            builder.Services.AddSingleton<IPostRepository, PostRepository>();
            builder.Services.AddSingleton<IBlogManagementContext, BlogManagementContext>();
            builder.Services.AddScoped<ICommentService, CommentService>();
            builder.Services.AddScoped<ICommentRepository, CommentRepository>();

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MyMappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            builder.Services.AddSingleton(mapper);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
