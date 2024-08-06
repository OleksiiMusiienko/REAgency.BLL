using REAgency.BLL.DTO.Persons;
using REAgency.DAL.Interfaces;
using REAgency.BLL.Infrastructure;
using REAgency.BLL.Interfaces.Persons;
using REAgency.DAL.Entities.Person;
using AutoMapper;
using REAgency.BLL.DTO;

namespace REAgency.BLL.Services.Persons
{
    internal class PostService : IPostService
    {
        IUnitOfWork Database { get; set; }

        public PostService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public async Task<IEnumerable<PostDTO>> GetPosts()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Post, PostDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Post>, IEnumerable<PostDTO>>(await Database.Posts.GetAll());
        }

        public async Task<PostDTO> GetPostById(int id)
        {
            var post = await Database.Posts.Get(id);
            if (post == null)
                throw new ValidationException("Wrong post!", "");
            return new PostDTO
            {
                Id = post.Id,
                Name = post.Name
            };
        }

        public async Task<PostDTO> GetPostByName(string name)
        {
            var post = await Database.Posts.GetByName(name);
            if (post == null)
                throw new ValidationException("Wrong post!", "");
            return new PostDTO
            {
                Id = post.Id,
                Name = post.Name
            };
        }

        public async Task CreatePost(PostDTO postDTO)
        {

        }
        public async Task DeletePost(int id)
        {

        }
    }
}
