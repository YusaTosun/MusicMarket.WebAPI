using FluentValidation;
using MusicMarket.API.DTO;

namespace MusicMarket.API.Validator
{
    public class SaveMusicResourceValidator:AbstractValidator<SaveMusicDTO>
    {
        public SaveMusicResourceValidator()
        {
            RuleFor(x=>x.Name).NotEmpty().MaximumLength(50);

            RuleFor(x => x.ArtistId).NotEmpty().WithMessage("Artist Id must not be 0 or empty");
        }
    }
}
