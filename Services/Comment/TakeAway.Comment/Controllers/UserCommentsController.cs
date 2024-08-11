using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TakeAway.Comment.Dtos;
using TakeAway.Comment.Services;

namespace TakeAway.Comment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserCommentsController : ControllerBase
    {
        private readonly IUserCommentService _userCommentService;

        public UserCommentsController ( IUserCommentService userCommentService )
        {
            _userCommentService = userCommentService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllUserCommentsAsync ()
        {
            var result = await _userCommentService.GetAllUserCommentsAsync();
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult > CreateUserCommentAsync(CreateUserCommentDto createUserCommentDto)

        {
            await _userCommentService.CreateUserCommentAsync(createUserCommentDto);
            return Ok("Comment Created Successfully.");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteComment ( int id )
        {
            await _userCommentService.DeleteUserCommentAsync(id);
            return Ok("Comment Deleted Successfully.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateComment ( UpdateUserCommentDto dto )
        {
            await _userCommentService.UpdateUserCommentAsync(dto);
            return Ok("Comment Updated Successfully.");
        }
        [HttpGet("GetComment/{id}")]
        public async Task<IActionResult> GetComment ( int id )
        {
            var values = await _userCommentService.GetUserCommentByIdAsync(id);
            return Ok(values);
        }
        [HttpGet("GetCommentsByUserId/{id}")]
        public async Task<IActionResult> GetCommentsByUserId ( string id )
        {
            var values = await _userCommentService.GetCommentsByProduct(id);
            return Ok(values);
        }
    }
}
