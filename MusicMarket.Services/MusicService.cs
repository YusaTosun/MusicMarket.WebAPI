using AutoMapper;
using FluentValidation;
using MusicMarket.Core;
using MusicMarket.Core.Models;
using MusicMarket.Core.Repositories;
using MusicMarket.Services.Abstract;
using MusicMarket.Services.DTO;
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
        public async Task<int> CreateMusic(SaveMusicDTO newMusicDTO)
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
                return await _unitOfWork.CommitAsync();
            }
            return 0;
        }

        public async Task DeleteMusic(int id)
        {
            var music = await _unitOfWork.Musics.GetByIdAsync(id);
            _unitOfWork.Musics.Remove(music);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<MusicDTO>> GetAllWithArtist()
        {
            var music = await _unitOfWork.Musics.GetAllWithArtistAsync();
            return _mapper.Map<IEnumerable<Music>, IEnumerable<MusicDTO>>(music);
        }

        public async Task<MusicDTO> GetMusicById(int Id)
        {
            var music = await _unitOfWork.Musics.GetByIdAsync(Id);
            return _mapper.Map<Music, MusicDTO>(music);
        }

        public async Task<IEnumerable<Music>> GetMusicsByArtistId(int artistId)
        {
            return await _unitOfWork.Musics.GetAllWithArtistByArtistIdAsync(artistId);
        }

        public async Task UpdateMusic(UpdateMusicDTO musicToBeUpdatedDTO, int id) //todo:Dönüş daha sonra tipini ayarla 
        {
            
            var validator = new UpdateMusicResourceValidator();
            var validateResult = validator.Validate(musicToBeUpdatedDTO);
            if (validateResult.IsValid)
            {
                var oldMusic = await _unitOfWork.Musics.GetByIdAsync(id);
                var musicToBeUpdated = _mapper.Map<UpdateMusicDTO,Music>(musicToBeUpdatedDTO);
                oldMusic.Name = musicToBeUpdated.Name;
                oldMusic.ArtistId = musicToBeUpdated.ArtistId;
                await _unitOfWork.CommitAsync();
            }
        }
    }
}
