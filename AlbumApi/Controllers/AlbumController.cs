using AlbumApi.Services;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace AlbumApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlbumController(ILogger<AlbumController> logger,
        IAlbumService aLbumService,
        IMapper mapper) : ControllerBase

    {

        #region "GetAlbumDetails"

        /// <summary>
        /// https://localhost:44369/api/Album/GetAlbumDetails?UserId=1 or swagger documentation.
        ///  Get Album details by UserId.
        /// </summary>
        /// <param name="UserId">UserId</param>
        /// <returns>List of albums for a particular UserId.</returns>

        [HttpGet("{UserId}", Name = "GetAlbumDetails")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get([FromQuery] int? UserNumber)
        {
            try
            {
                if (UserId == null)
                {
                    logger.LogError("User ID is null");

                    return BadRequest();
                }
                else
                {
                    var userAlbums = await aLbumService.GetAlbumsAsync(UserId);

                    var mappedAlbum = mapper.Map<List<AlbumDetailsDTO>>(userAlbums);

                    if (userAlbums == null)
                    {
                        return NotFound();
                    }

                    return Ok(userAlbums);
                }
            }
            catch (Exception ex)
            {
                logger.LogError("Exception occurred in Method Get");
                throw ex;
            }
        }

        #endregion "GetAlbumDetails"
    }
}