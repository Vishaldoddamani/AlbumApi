using AlbumApi.Models;
using FluentValidation;

namespace AlbumApi.Validators
{
    public class AlbumValidator : AbstractValidator<Album>
    {
        public AlbumValidator()
        {
            RuleFor(album => album.UserId).NotNull();
        }
    }
}