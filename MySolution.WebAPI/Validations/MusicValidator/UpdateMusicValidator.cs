using FluentValidation;
using MySolution.WebAPI.Models.Music;

namespace MySolution.WebAPI.Validations.MusicValidator
{
    public class UpdateMusicValidator : AbstractValidator<MusicUpdateRequest>
    {
        public UpdateMusicValidator() 
        {
            Include(new SaveMusicValidator());

            RuleFor(x => x.Id)
                .NotEmpty();
        }
    }
}
