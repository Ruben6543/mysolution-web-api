using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MySolution.Domain.DataTransferObject;
using MySolution.Domain.Infraestructure;
using MySolution.WebAPI.Models.Music;
using MySolution.WebAPI.Validations.MusicValidator;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MySolution.WebAPI.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class MusicsController : ControllerBase
    {
        private readonly IMusicService _musicService;
        private readonly IMapper _mapper;
        public MusicsController(IMusicService musicService, IMapper mapper)
        {
            _musicService = musicService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MusicResponse>>> GetAllMusics()
        {
            var musics = await _musicService.List();
            var result = musics.GetResult<ICollection<Music>>();
            var musicResponses = _mapper.Map<ICollection<Music>, ICollection<MusicResponse>>(result);


            return Ok(musicResponses);
        }

        [HttpPost]
        public async Task<ActionResult<MusicCreateRequest>> SaveMusic([FromBody] MusicCreateRequest saveMusicResource)
        {
            var validation = new SaveMusicValidator();

            var validationResult = await validation.ValidateAsync(saveMusicResource);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            Music request = new Music() 
            {
                Title = saveMusicResource.Title,
                Genre = saveMusicResource.Genre,
            };

            var newMusic = await _musicService.Save(request);
            var result = newMusic.GetResult<Music>();
            var MusicResponse = _mapper.Map<Music, MusicResponse>(result);

            return Ok(MusicResponse);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<MusicCreateRequest>> UpdateArtist(int id, [FromBody] MusicUpdateRequest updateMusicResource)
        {
            if (id != updateMusicResource.Id)
            {
                Unauthorized("Security Error");
            }

            var validation = new UpdateMusicValidator();
            var validationResult = await validation.ValidateAsync(updateMusicResource);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var music = await _musicService.Get(id);
            var musicResponse = music.GetResult<Music>();

            if (music == null)
            {
                return NotFound();
            }

            Music musicToUpdate = new Music()
            {
                Id = musicResponse.Id,
                Title = updateMusicResource.Title,
                Genre = updateMusicResource.Genre,
            };

            await _musicService.Update(musicToUpdate);

            var musicUpdated = await _musicService.Get(id);

            var musicResource = _mapper.Map<Music, MusicResponse>(musicUpdated.GetResult<Music>());
            
            return Ok(musicResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArtist(int id)
        {
            var music = await _musicService.Get(id);
            var response = music.GetResult<Music>();

            if (music == null)
            {
                return NotFound();
            }
            await _musicService.Delete(response.Id);

            return Ok(response);
        }

    }
}
