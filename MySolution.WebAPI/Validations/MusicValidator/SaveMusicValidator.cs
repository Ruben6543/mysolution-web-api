using FluentValidation;
using MySolution.WebAPI.Models.Music;
using System.Text.RegularExpressions;

namespace MySolution.WebAPI.Validations.MusicValidator
{
    public class SaveMusicValidator : AbstractValidator<MusicCreateRequest>
    {
        readonly Regex regEx = new Regex("^[a-zA-Z0-9]*$");

        public SaveMusicValidator() 
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("The Name can not be empty")
                .Length(3, 50).WithMessage("Please insert between 2 to 100 characters");

            RuleFor(x => x.Genre)
                .NotEmpty().WithMessage("The Code can not be empty")
                .Length(2, 10).WithMessage("Please insert between 2 to 10 characters ")
                .Matches(regEx).WithMessage("This Property can not contain especial characters");
        }
    }
}
