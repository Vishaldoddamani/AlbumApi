using AlbumApi.Controllers;
using AlbumApi.Entities;
using AlbumApi.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace MyAlbumXunitProject
{
    public class AlbumUnitTest
    {
        [Fact]
        public async System.Threading.Tasks.Task TestUserIdIsNull()
        {
            var mockService = new Mock<IAlbumService>();
            var mockLogger = new Mock<ILogger<AlbumController>>();
            var mockMapper = new Mock<IMapper>();

            int? UserId = null;

            var controller = new AlbumController(mockLogger.Object, mockService.Object, mockMapper.Object);

            IActionResult actionResult = await controller.Get(UserId);

            Assert.NotNull(actionResult);
            Assert.Equal(actionResult.GetType(), typeof(BadRequestResult));
        }

        [Fact]
        public async System.Threading.Tasks.Task TestUserIdNotFound()
        {
            var mockService = new Mock<IAlbumService>();
            var mockLogger = new Mock<ILogger<AlbumController>>();
            var mockMapper = new Mock<IMapper>();
            int UserId = 0;

            var controller = new AlbumController(mockLogger.Object, mockService.Object, mockMapper.Object);

            IActionResult actionResult = await controller.Get(UserId);

            Assert.NotNull(actionResult);
            Assert.Equal(actionResult.GetType(), typeof(NotFoundResult));
        }

        [Fact]
        public async System.Threading.Tasks.Task TestUserIdSuccess()
        {
            var mockService = new Mock<IAlbumService>();
            var mockLogger = new Mock<ILogger<AlbumController>>();
            var mockMapper = new Mock<IMapper>();
            int UserId = 1;

            List<AlbumDetails> albumDetails = new();
            albumDetails.Add(new AlbumDetails
            {
                AlbumTitle = "quidem molestiae enim",
                PhotoThumbNailUrl = "https://via.placeholder.com/150/92c952",
                PhotoTitle = "accusamus beatae ad facilis cum similique qui sunt",
                PhotoUrl = "https://via.placeholder.com/600/92c952",
                UserId = 1
            });

            var controller = new AlbumController(mockLogger.Object, mockService.Object, mockMapper.Object);

            _ = mockService.Setup(x => x.GetAlbumsAsync(UserId))
                .ReturnsAsync(albumDetails);

            IActionResult actionResult = controller.Get(UserId).Result;

            var result = ((Microsoft.AspNetCore.Mvc.ObjectResult)actionResult).Value;

            Assert.NotNull(actionResult);
            Assert.Equal(actionResult.GetType(), typeof(OkObjectResult));

            Assert.Equal(albumDetails[0].AlbumTitle, ((List<AlbumDetails>)result)[0].AlbumTitle);
            Assert.Equal(albumDetails[0].PhotoThumbNailUrl, ((List<AlbumDetails>)result)[0].PhotoThumbNailUrl);
            Assert.Equal(albumDetails[0].PhotoTitle, ((List<AlbumDetails>)result)[0].PhotoTitle);
            Assert.Equal(albumDetails[0].PhotoUrl, ((List<AlbumDetails>)result)[0].PhotoUrl);
            Assert.Equal(albumDetails[0].UserId, ((List<AlbumDetails>)result)[0].UserId);
        }
    }
}