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
    public class AlbumController : ControllerBase

    {
        private readonly ILogger<AlbumController> _logger;
        private readonly IAlbumService _albumService;
        private readonly IMapper _mapper;

        public AlbumController(ILogger<AlbumController> logger, IAlbumService aLbumService, IMapper mapper)
        {
            _logger = logger;
            _albumService = aLbumService;
            _mapper = mapper;
        }

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
        public async Task<IActionResult> Get([FromQuery] int? UserId)
        {
            try
            {
                if (UserId == null)
                {
                    _logger.LogError("User ID is null");

                    return BadRequest();
                }
                else
                {
                    var userAlbums = await _albumService.GetAlbumsAsync(UserId);

                    var mappedAlbum = _mapper.Map<List<AlbumDetailsDTO>>(userAlbums);

                    if (userAlbums == null)
                    {
                        return NotFound();
                    }

                    return Ok(userAlbums);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception occurred in Method Get");
                throw ex;
            }
        }

        #endregion "GetAlbumDetails"
    }
}