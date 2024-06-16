using CreArtHub.Shared.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreArtHub.Shared.Model
{
    public class HomeModel
    {
        public List <PostDto> PostDtos = new List<PostDto>();
        public List <FileDto> FileDtos = new List<FileDto>();
    }
}
