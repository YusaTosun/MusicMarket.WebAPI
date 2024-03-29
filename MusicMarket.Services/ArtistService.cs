﻿using AutoMapper;
using MusicMarket.Core;
using MusicMarket.Core.Models;
using MusicMarket.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicMarket.Services
{
    public class ArtistService : IArtistService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ArtistService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Artist> CreateArtist(Artist newArtist)
        {
            await _unitOfWork.Artists.AddAsync(newArtist);
            await _unitOfWork.CommitAsync();
            return newArtist;
        }

        public async Task DeleteArtist(Artist artist)
        {
            _unitOfWork.Artists.Remove(artist);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Artist>> GetAllArtists()
        {
            return await _unitOfWork.Artists.GetAllAsync();

        }

        public async Task<Artist> GetArtistById(int id)
        {
            return await _unitOfWork.Artists.GetByIdAsync(id);
        }

        public async Task UpdateArtist(Artist artistToBeUpdated, Artist artist)
        {
            artistToBeUpdated.Name= artist.Name;  //todo:Buraya daha sonra tekrar kafa yor !!!!!
            await _unitOfWork.CommitAsync();
        }
    }
}
