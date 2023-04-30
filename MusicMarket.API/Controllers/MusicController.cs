using AutoMapper;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicMarket.API.DTO;
using MusicMarket.Core.Models;
using MusicMarket.Core.Repositories;
using MusicMarket.Core.Services;

namespace MusicMarket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicController : ControllerBase
    {
        private readonly IMusicService _musicService;
        private readonly IMapper _mapper;
        public MusicController(IMusicService musicService,IMapper mapper)
        {
            _musicService = musicService;
            _mapper = mapper;
        }
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Music>>> GetAllMusics()
        //{
        //   var musics = await _musicService.GetAllWithArtist();
        //   return Ok(musics);
        //}
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
            var musicRes = _mapper.Map<Music,MusicDTO>(music);
            return Ok(musicRes);
        }
    }
}
