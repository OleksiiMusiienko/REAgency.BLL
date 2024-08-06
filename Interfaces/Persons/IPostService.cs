using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using REAgency.BLL.DTO.Persons;

namespace REAgency.BLL.Interfaces.Persons
{
    public interface IPostService
    {
        Task<IEnumerable<PostDTO>> GetPosts();

        Task<PostDTO> GetPostById(int id);

        Task<PostDTO> GetPostByName(string name);

        Task CreatePost(PostDTO postDTO);
        Task DeletePost(int id);
    }
}
