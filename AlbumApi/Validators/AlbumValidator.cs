using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
