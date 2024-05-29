using CreArtHub.Shared.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreArtHub.Shared.Model
{
    public class PostModel
    {
        public PostDto Post { get; set; }
        public List<CommentDto> Comments { get; set; } = new List<CommentDto>();
        public List<FileDto> Files  { get; set; } = new List<FileDto>();
    }
}
