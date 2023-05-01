using AutoMapper;
using FluentValidation;
using MusicMarket.Common.ResponseObjects;
using MusicMarket.Core;
using MusicMarket.Core.Models;
using MusicMarket.Core.Repositories;
using MusicMarket.Services.Abstract;
using MusicMarket.Services.DTO;
using MusicMarket.Services.Extensions;
using MusicMarket.Services.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicMarket.Services
{
    public class MusicService : IMusicService // todo:Concrete klasörü
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public MusicService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IResponse<SaveMusicDTO>> CreateMusic(SaveMusicDTO newMusicDTO)
        {
            #region Old code
            //await _unitOfWork.Musics.AddAsync(newMusic);
            //await _unitOfWork.CommitAsync();
            //return newMusic; 
            #endregion

            var validator = new SaveMusicResourceValidator();
            var validateResult = validator.Validate(newMusicDTO);
            if (validateResult.IsValid)
            {
                var newMusic = _mapper.Map<SaveMusicDTO,Music>(newMusicDTO);
                await _unitOfWork.Musics.AddAsync(newMusic);
                await _unitOfWork.CommitAsync();
                return new Response<SaveMusicDTO>(ResponseType.Success, newMusicDTO);
            }
            else
            {
                return new Response<SaveMusicDTO>(ResponseType.ValidationError,newMusicDTO,validateResult.ConvertToCustomValidationError());
            }
        }

        public async Task<IResponse> DeleteMusic(int id)
        {
            var music = await _unitOfWork.Musics.GetByIdAsync(id);
            if (music == null)
            {
                return new Response(ResponseType.NotFound,"Bulanamadı");
            }
            _unitOfWork.Musics.Remove(music);
            await _unitOfWork.CommitAsync();
            return new Response<Music>(ResponseType.Success,music);
        }

        public async Task<IResponse<IEnumerable<MusicDTO>>> GetAllWithArtist()
        {
            var music = await _unitOfWork.Musics.GetAllWithArtistAsync();
            var data = _mapper.Map<IEnumerable<Music>, IEnumerable<MusicDTO>>(music); // todo:Buranın null olma durumlarını daha sonra incele
            if (music == null)
            {
                return new Response<IEnumerable<MusicDTO>>(ResponseType.NotFound, "Musics Not Founded");  // todo: data tekrar incele
            }
            var musicDTO = _mapper.Map<IEnumerable<Music>, IEnumerable<MusicDTO>>(music);
            return new Response<IEnumerable<MusicDTO>>(ResponseType.NotFound, data);  // todo: data tekrar incele

        }

        public async Task<IResponse<MusicDTO>> GetMusicById(int Id)
        {
            var music = await _unitOfWork.Musics.GetByIdAsync(Id);
            if (music == null)
            {
                return new Response<MusicDTO>(ResponseType.NotFound,"Music Not Found");
            }
            var musicDTO = _mapper.Map<Music, MusicDTO>(music);
            return new Response<MusicDTO>(ResponseType.Success,musicDTO);
        }

        public async Task<IResponse<IEnumerable<Music>>> GetMusicsByArtistId(int artistId)
        {
            var musics = await _unitOfWork.Musics.GetAllWithArtistByArtistIdAsync(artistId);
            if (musics == null)
            {
                return new Response<IEnumerable<Music>>(ResponseType.NotFound,"Music Not Founded");
            }
            return new Response<IEnumerable<Music>>(ResponseType.Success,musics);

        }

        public async Task<Response> UpdateMusic(UpdateMusicDTO musicToBeUpdatedDTO, int id) //todo:Dönüş daha sonra tipini ayarla 
        {
            
            var validator = new UpdateMusicResourceValidator();
            var validateResult = validator.Validate(musicToBeUpdatedDTO);
            if (validateResult.IsValid)
            {
                var oldMusic = await _unitOfWork.Musics.GetByIdAsync(id);
                if (oldMusic==null)
                {
                    return new Response(ResponseType.NotFound, "Music Not Founded");
                }
                var musicToBeUpdated = _mapper.Map<UpdateMusicDTO,Music>(musicToBeUpdatedDTO);
                oldMusic.Name = musicToBeUpdated.Name;
                oldMusic.ArtistId = musicToBeUpdated.ArtistId;
                await _unitOfWork.CommitAsync();
                return new Response(ResponseType.Success);
            }
            else
            {
                    return new Response<UpdateMusicDTO>(ResponseType.ValidationError, musicToBeUpdatedDTO, validateResult.ConvertToCustomValidationError());
            }
        }
    }
}
