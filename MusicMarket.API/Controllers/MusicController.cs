using AutoMapper;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicMarket.API.DTO;
using MusicMarket.API.Validator;
using MusicMarket.Core.Models;
using MusicMarket.Core.Repositories;
using MusicMarket.Core.Services;

namespace MusicMarket.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MusicController : ControllerBase
    {
        private readonly IMusicService _musicService;
        private readonly IMapper _mapper;
        public MusicController(IMusicService musicService, IMapper mapper)
        {
            _musicService = musicService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MusicDTO>>> GetAllMusics()
        {
            var musics = await _musicService.GetAllWithArtist();
            var musicResources = _mapper.Map<IEnumerable<Music>, IEnumerable<MusicDTO>>(musics);
            return Ok(musicResources);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<MusicDTO>> GetMusicById(int id)
        {
            var music = await _musicService.GetMusicById(id);
            var musicRes = _mapper.Map<Music, MusicDTO>(music);
            return Ok(musicRes);
        }
        [HttpPost]
        public async Task<ActionResult<MusicDTO>> CreateMusic(SaveMusicDTO saveMusicRes)
        {
            var validator = new SaveMusicResourceValidator();
            var validationResult = await validator.ValidateAsync(saveMusicRes);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var musicToCreate = _mapper.Map<SaveMusicDTO, Music>(saveMusicRes);
            var newMusic = await _musicService.CreateMusic(musicToCreate);
            var music = await _musicService.GetMusicById(newMusic.Id);
            var musicRes = _mapper.Map<Music, MusicDTO>(music);
            return Ok(musicRes);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMusic(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var music = await _musicService.GetMusicById(id);
            if (music == null)
            {
                return NotFound();
            }
            await _musicService.DeleteMusic(music);
            return NoContent();
        }
        [HttpPut]
        public async Task<ActionResult<MusicDTO>> Update(int id,SaveMusicDTO saveMusicRes)
        {
            var validator = new SaveMusicResourceValidator();
            var validateResult = await validator.ValidateAsync(saveMusicRes);
            if (!validateResult.IsValid)
            {
             return BadRequest(validateResult.Errors);
            }

            var musicToUpdate = await _musicService.GetMusicById(id);

            if (musicToUpdate==null)
            {
                return NotFound();
            }
            var music = _mapper.Map<SaveMusicDTO,Music>(saveMusicRes);

            await _musicService.UpdateMusic(musicToUpdate,music);

            var updatedMusic = await _musicService.GetMusicById(id);
            var updatedMusicRes = _mapper.Map<Music,MusicDTO>(updatedMusic);

            return Ok(updatedMusicRes);
        }
    }
}
