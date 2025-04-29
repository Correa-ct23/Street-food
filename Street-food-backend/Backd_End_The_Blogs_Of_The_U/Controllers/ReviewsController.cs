using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using The_Blogs_Of_The_U.Domain.Entities;
using The_Blogs_Of_The_U.Domain.Services;

namespace Backd_End_The_Blogs_Of_The_U.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("[controller]")]
    public class ReviewsController: ControllerBase
    {
        private readonly ReviewsService _reviewsService;

        public ReviewsController(ReviewsService reviewsService)
        {
            _reviewsService= reviewsService;
        }


        [HttpGet("get-all-reviews")]
        public async Task<IActionResult> GetAllReviews()
        {
            List<Reviews> reviews = await _reviewsService.GetAllReviews();
            return Ok(reviews);
        }

    }
}
