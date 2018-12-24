using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.IService;

namespace DatingApplicationV2.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/ImageLike")]
    [ApiController]
    public class APIImageLikeController : ControllerBase
    {
        private readonly IImageLikeService _imageLikeService;

        public APIImageLikeController(IImageLikeService imageLikeService)
        {
            _imageLikeService = imageLikeService;
        }

        // GET: api/APIImageLike
        [HttpGet("GetImageLikes/{id}")]
        public async Task<JsonResult> GetImageLikes(Guid id)
        {
            return  new JsonResult( await _imageLikeService.CountImageLikesAsync(id));
        }

        //// GET: api/APIImageLike/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/APIImageLike
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT: api/APIImageLike/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
