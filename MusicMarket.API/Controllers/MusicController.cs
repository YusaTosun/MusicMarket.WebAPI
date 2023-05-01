using AutoMapper;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicMarket.Services.Validator;
using MusicMarket.Services.DTO;
using MusicMarket.Core.Models;
using MusicMarket.Core.Repositories;
using MusicMarket.Services.Abstract;
using MusicMarket.Common.ResponseObjects;

namespace MusicMarket.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MusicController : ControllerBase
    {
        private readonly IMusicService _musicService;
        public MusicController(IMusicService musicService)
        {
            _musicService = musicService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MusicDTO>>> GetAllMusics()
        {
            var musicsRes = await _musicService.GetAllWithArtist();
            return Ok(musicsRes);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<MusicDTO>> GetMusicById(int id)
        {
            var musicRes = await _musicService.GetMusicById(id);
            return Ok(musicRes);
        }
        [HttpPost]
        public async Task<IResponse<SaveMusicDTO>> CreateMusic(SaveMusicDTO saveMusicRes)
        {
            return await _musicService.CreateMusic(saveMusicRes);
        }
        [HttpDelete("{id}")]
        public async Task<IResponse> DeleteMusic(int id)
        {
            return await _musicService.DeleteMusic(id);
            #region Old Code
            //if (id == 0)
            //{
            //    return BadRequest();
            //}
            //var music = await _musicService.GetMusicById(id);
            //if (music == null)
            //{
            //    return NotFound();
            //}
            //await _musicService.DeleteMusic(music); 
            #endregion
        }
        [HttpPut]
        public async Task<Response> Update(int id, UpdateMusicDTO updateMusicRes)
        {
           return await _musicService.UpdateMusic(updateMusicRes, id);

            #region Old Code
            //var validator = new SaveMusicResourceValidator();
            //var validateResult = await validator.ValidateAsync(saveMusicRes);
            //if (!validateResult.IsValid)
            //{
            //    return BadRequest(validateResult.Errors);
            //}

            //var musicToUpdate = await _musicService.GetMusicById(id);

            //if (musicToUpdate == null)
            //{
            //    return NotFound();
            //}
            //var music = _mapper.Map<SaveMusicDTO, Music>(saveMusicRes);

            //await _musicService.UpdateMusic(musicToUpdate, music);

            //var updatedMusic = await _musicService.GetMusicById(id);
            //var updatedMusicRes = _mapper.Map<Music, MusicDTO>(updatedMusic);

            //return Ok(updatedMusicRes); 
            #endregion
        }
    }
}
