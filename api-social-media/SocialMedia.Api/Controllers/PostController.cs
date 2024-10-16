﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Api.Responses;
using SocialMedia.Core.DTOs;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialMedia.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        public readonly IMapper _mapper;
        private readonly IPostService _postService;

        public PostController(IMapper mapper, IPostService postService)
        {
            _mapper = mapper;
            _postService = postService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var posts = await _postService.Get();
            var postsDto = _mapper.Map<IEnumerable<PostDTO>>(posts);

            var response = new ApiResponse<IEnumerable<PostDTO>>(postsDto);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var post = await _postService.GetById(id);
            var postDto = _mapper.Map<PostDTO>(post);

            var response = new ApiResponse<PostDTO>(postDto);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Add(PostDTO postDto)
        {
            var post = _mapper.Map<Post>(postDto);
            await _postService.Add(post);
            var postDtoResult = _mapper.Map<PostDTO>(post);

            var response = new ApiResponse<PostDTO>(postDtoResult);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(PostDTO postDto)
        {
            var post = _mapper.Map<Post>(postDto);
            var isUpdated = await _postService.Update(post);
            
            var response = new ApiResponse<bool>(isUpdated);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var isDeleted = await _postService.Delete(id);

            var response = new ApiResponse<bool>(isDeleted);
            return Ok(response);
        }
    }
}
