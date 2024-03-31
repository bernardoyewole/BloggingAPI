﻿using AutoMapper;
using BLL;
using Entities.DTO;
using Entities.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BloggingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _commentService;
        private readonly IMapper _mapper;

        public CommentsController(ICommentService commentService, IMapper mapper)
        {
            _commentService = commentService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetComments()
        {
            var listComments = await _commentService.GetComments();
            List<CommentDTO> comments = _mapper.Map<List<CommentDTO>>(listComments);

            return Ok(comments);
        }

        [HttpGet]
        [Route("{Id}")]
        public async Task<IActionResult> GetCommentsById(int Id)
        {
            Comment comment = await _commentService.GetCommentById(Id);
            CommentDTO commentDTO = _mapper.Map<CommentDTO>(comment);

            if (commentDTO == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(commentDTO);
            }
        }

        [HttpGet]
        [Route("Post/{PostId}")]
        public async Task<IActionResult> GetCommentsByPostId(int PostId)
        {
            List<Comment> commentsByPost = await _commentService.GetCommentsByPostId(PostId);
            List<CommentDTO> commentsByPostDTO = _mapper.Map<List<CommentDTO>>(commentsByPost);

            if (commentsByPostDTO.Count() == 0)
            {
                return Ok("No comments for this post");
            } else
            {
                return Ok(commentsByPostDTO);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddComments(Comment comment)
        {
            await _commentService.AddComment(comment);
            return Ok("Comment Added Successfully");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateComments(Comment comment)
        {
            await _commentService.UpdateComment(comment);
            return Ok("Comment updated successfully");
        }

        [HttpDelete]
        [Route("{Id}")]
        public async Task<IActionResult> DeleteComments(int Id)
        {
            if (await _commentService.DeleteComment(Id))
            {
                return Ok("Comment deleted successfully");
            }
            return BadRequest();
        }

        [HttpDelete]
        [Route("Post/{PostId}")]
        public async Task<IActionResult> DeleteCommentsByPostId(int PostId)
        {
            if (await _commentService.DeleteCommentsByPost(PostId))
            {
                return Ok("Comments deleted successfully");
            }
            return BadRequest();
        }
    }
}
