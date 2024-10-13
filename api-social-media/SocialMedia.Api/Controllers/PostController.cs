using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Core.DTOs;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using SocialMedia.Infraestructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMedia.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        public readonly IMapper _mapper;
        private readonly IPostRepository _postRepository;

        public PostController(IMapper mapper, IPostRepository postRepository)
        {
            _mapper = mapper;
            _postRepository = postRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var posts = await _postRepository.Get();
            var postsDto = _mapper.Map<IEnumerable<PostDTO>>(posts);
            return Ok(postsDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var post = await _postRepository.GetById(id);
            var postDto = _mapper.Map<PostDTO>(post);
            return Ok(postDto);
        }

        [HttpPost]
        public async Task<IActionResult> Add(PostDTO postDto)
        {
            var post = _mapper.Map<Post>(postDto);
            await _postRepository.Add(post);
            return Ok(post);
        }
    }
}
