using Azure;
using Azure.Core;
using MySolution.Domain.DataTransferObject;
using MySolution.Domain.Infraestructure;
using MySolution.Infraestructure;
using MySolution.Infraestructure.Entities;
using MySolution.Infraestructure.Infraestructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MySolution.Domain.Services
{
    public class MusicService : IMusicService
    {
        private readonly IRepository<MySolutionDataContext, MusicEntity> _musicRepository;

        public MusicService(IRepository<MySolutionDataContext, MusicEntity> musicRepository)
        {
            _musicRepository = musicRepository;
        }

        public async Task<ServiceResult> List()
        {
            var data = await _musicRepository.GetAllAsync();

            return new ServiceResult(data.Where(h => !h.IsDeleted).Select(h => new Music
            {
                Title = h.Title,
                Genre = h.Genre,
                Id = h.Id,
            }).ToList());
        }

        public async Task<ServiceResult> Save(object data)
        {
            Music newMusic = data as Music;

            var music = new MusicEntity
            {
                Title = newMusic.Title,
                Genre= newMusic.Genre.ToUpper(),
            };

            var musicCreated = await _musicRepository.AddAsync(music);

            var response = new Music() 
            {
                Id = musicCreated.Id,
                Title = musicCreated.Title,
                Genre = musicCreated.Genre,
            };

            return new ServiceResult(response);
        }

        public async Task<ServiceResult> Update(object data)
        {
            Music request = data as Music;

            Music newMusic = new Music()
            {
                Id = request.Id,
                Title = request.Title,
                Genre = request.Genre.ToUpper(),
            };

            var music = await _musicRepository.FindAsync(h => h.Id == newMusic.Id);
            
            if (music == null)
            {
                throw new InvalidOperationException("The music doesnt exists");
            }

            music.Title = request.Title;
            music.Genre = request.Genre;

            var response = await _musicRepository.UpdateAsync(music, music.Id);

            return new ServiceResult(response);

        }

        public async Task<ServiceResult> Delete(int id)
        {
            var musicEntity = await _musicRepository.FindAsync(h => h.Id == id);

            if (musicEntity == null)
            {
                throw new InvalidOperationException("The music doesnt exists");
            }

            var response = await _musicRepository.DeleteAsync(musicEntity);

            return new ServiceResult(response);
        }

        public async Task<ServiceResult> Get(int id)
        {
            var music = await _musicRepository.FindAsync(h => h.Id == id);

            if (music == null)
            {
                throw new Exception("The music doesnt exists");
            }
            else
            {
                return new ServiceResult(new Music()
                {
                    Id = music.Id,
                    Title = music.Title,
                    Genre = music.Genre,
                });
            }
        }
    }
}
