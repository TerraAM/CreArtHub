using CreArtHub.Domain.Entity;
using CreArtHub.Shared.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreArtHub.App.Mappers
{
    public static class FileMapper
    {
        public static FileDto ToDto(this File File)
        {
            if (File == null)
            {
                return null;
            }

            FileDto FileDto = new FileDto()
            {
                Id = File.Id,
                FileName = File.FileName,
                FilePath = File.FilePath,
                PostId = File.PostId,
                Post = File.Post.ToDto(),
            };

            return FileDto;
        }
        public static File ToEntity(this FileDto FileDto)
        {
            if (FileDto == null)
            {
                return null;
            }

            File File = new File()
            {
                Id = FileDto.Id,
                FileName = FileDto.FileName,
                FilePath = FileDto.FilePath,
                PostId = FileDto.PostId,
                Post = FileDto.Post.ToEntity(),
            };

            return File;
        }
    }
}
