using FluentValidation;
using MusicMarket.Services.DTO;
using MusicMarket.Core.Models;

namespace MusicMarket.Services.Validator
{
    public class SaveArtistResourceValidator:AbstractValidator<SaveArtistDTO>
    {
        public SaveArtistResourceValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(50);
        }
    }
}
