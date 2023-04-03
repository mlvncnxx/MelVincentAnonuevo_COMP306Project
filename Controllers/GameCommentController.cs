using MelVincentAnonuevo_COMP306Project.Models;
using MelVincentAnonuevo_COMP306Project.Services;
using MelVincentAnonuevo_COMP306Project.DTOs;
using System;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using AutoMapper;

namespace MelVincentAnonuevo_COMP306Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameCommentController : ControllerBase
    {
        private readonly IMapper _mapper;
        private IGameCommentRepository _gameCommentRepository;

        public GameCommentController(IGameCommentRepository gameCommentRepository, IMapper mapper)
        {
            _gameCommentRepository = gameCommentRepository;
            _mapper = mapper;
        }

        //GET: api<controller>
        [HttpGet]
        public async Task<ActionResult<GameInfo>> GetGameInfoes()
        {
            var gameComments = await _gameCommentRepository.GetGameComments();
            var results = _mapper.Map<IEnumerable<GameCommentsDto>>(gameComments);

            return Ok(results);
        }

        // GET: /GameComment/1
        [HttpGet("{gameId}")]
        public async Task<ActionResult> GetGameCommentByGameId(int gameId)
        {
            var comments = await _gameCommentRepository.GetGameCommentByGameId(gameId);

            var results = _mapper.Map<IEnumerable<GameCommentsDto>>(comments);

            return Ok(results);
        }

        // POST: /GameComment
        [HttpPost]
        public async Task<ActionResult> AddGameComment([FromBody] GameCommentsDto comment)
        {
            if (comment == null) return BadRequest();

            if (!ModelState.IsValid) return BadRequest();

            var commentToInsert = _mapper.Map<GameComment>(comment);
            commentToInsert.PostedAt = TimeZoneInfo.ConvertTimeToUtc(DateTime.Now);

            await _gameCommentRepository.AddGameComment(commentToInsert);

            if (!await _gameCommentRepository.Save())
            {
                return StatusCode(500, "A problem occured while processing the request");
            }

            return StatusCode(200, "Comment is submitted successfully.");
        }

        // PUT api/GameComment/5
        [HttpPut("{commentId}")]
        public async Task<ActionResult> UpadateGameComment(int commentId, [FromBody] GameCommentUpdateDto comment)
        {
            if (comment == null) return BadRequest();

            var commentToUpdate = _mapper.Map<GameComment>(comment);
            commentToUpdate.PostedAt = TimeZoneInfo.ConvertTimeToUtc(DateTime.Now);

            await _gameCommentRepository.UpadateGameComment(commentId, commentToUpdate);

            return StatusCode(200, "Comment is updated successfully.");
        }

        // PUT api/GameComment/5
        [HttpPatch("{commentId}")]
        public async Task<ActionResult> UpadateGameCommentById(int commentId, [FromBody] GameCommentUpdateDto comment)
        {
            if (comment == null) return BadRequest();

            var commentToUpdate = _mapper.Map<GameComment>(comment);
            commentToUpdate.PostedAt = TimeZoneInfo.ConvertTimeToUtc(DateTime.Now);

            await _gameCommentRepository.UpadateGameComment(commentId, commentToUpdate);

            return StatusCode(200, "Comment is updated successfully.");
        }

        // DELETE api/GameComment/5
        [HttpDelete("{commentId}")]
        public async Task<ActionResult> DeleteGameComment(int commentId)
        {
            GameComment comment = await _gameCommentRepository.GetGameCommentByCommentId(commentId);

            if (comment == null)
            {
                return NotFound();
            }

            await _gameCommentRepository.DeleteGameComment(commentId);

            return Ok(comment);
        }
    }
}
