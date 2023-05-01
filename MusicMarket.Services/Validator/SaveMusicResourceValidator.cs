using FluentValidation;
using MusicMarket.Services.DTO;

namespace MusicMarket.Services.Validator
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
