using FluentValidation;
using MusicMarket.API.DTO;
using MusicMarket.Core.Models;

namespace MusicMarket.API.Validator
{
    public class SaveArtistResourceValidator:AbstractValidator<SaveArtistDTO>
    {
        public SaveArtistResourceValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(50);
        }
    }
}
