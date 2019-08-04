using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PhotoAlbumApi.Service;

namespace PhotoAlbumApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoAlbumController : ControllerBase
    {
        private readonly IPhotoAlbumService _photoAlbumService;

        public PhotoAlbumController(IPhotoAlbumService photoAlbumService)
        {
            _photoAlbumService = photoAlbumService;
        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var photoAlbums = await _photoAlbumService.GetDetails();
            return Ok(photoAlbums);
        }

        // GET api/values/5
        [HttpGet("{userId}")]
        public async Task<IActionResult> Get(int userId)
        {
            var photoAlbums = await _photoAlbumService.GetDetailsByUserId(userId);
            return Ok(photoAlbums);
        }
    }
}
