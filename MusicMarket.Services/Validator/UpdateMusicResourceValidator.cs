using FluentValidation;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MusicMarket.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicMarket.Services.Validator
{
    public class UpdateMusicResourceValidator:AbstractValidator<UpdateMusicDTO>
    {
        public UpdateMusicResourceValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(50);

            RuleFor(x => x.ArtistId).NotEmpty().WithMessage("Artist Id must not be 0 or empty");
        }
    }
}
