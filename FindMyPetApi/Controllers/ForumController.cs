using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using utilities;
using data_models;
using data_models.custom;
using Microsoft.AspNetCore.Http;
using utilities.forum;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FindMyPetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForumController : ControllerBase
    {

        db_fetch Fetch = new db_fetch();

        private readonly ILogger<ForumController> _logger;
        private readonly IForumHandler _forumHandler;

        public ForumController(IForumHandler forumHandler, ILogger<ForumController> logger)
        {
            _logger = logger;
            _forumHandler = forumHandler;
        }


        /// <summary>
        /// Method for Create a Forum
        /// </summary>
        /// <param name="newForum"></param>
        /// <returns></returns>
        [HttpPost("Create")]
        public IActionResult NewForum(ForumCustom newForum) {
            string error;
            var forum = _forumHandler.CreateNewForum(newForum, out  error);

            if(forum == null)
            {
                return StatusCode(400, error);
            }
            else
            {
                return StatusCode(200, forum);
            }
  
        }


        [HttpGet("Delete")]
        public IActionResult DeleteForum(int forumID)
        {
            string error;
            bool delforum = _forumHandler.DeletedForum(forumID, out error);

            if (delforum)
            {
                return StatusCode(200);
            }
            else
            {
                return StatusCode(400, error);
            }
        }


        [HttpGet("List")]
        public IActionResult ForumList()
        {

            string error;
            List<ForumCustom> forumList = _forumHandler.ShowForumList(out error);

            if(forumList == null)
            {
                return StatusCode(400, error);
            }
            else
            {
                return StatusCode(200);
            }

        }


        [HttpGet("{id}")]
        public IActionResult SearchByForumId(int forumID)
        {
            string error;

            var forum = _forumHandler.SearchForum(forumID, out error);

            if (forum == null)
            {
                return StatusCode(400, error);
            }
            else
            {
                return StatusCode(200);
            }
        }


        [HttpGet("ForumDetailsByPet/{id}")]
        public IActionResult SearchForumByPetId(int petID)
        {
            string error;

            var forum = _forumHandler.SearchForum(petID, out error);

            if (forum == null)
            {
                return StatusCode(400, error);
            }
            else
            {
                return StatusCode(200);
            }
        }

        [HttpPost("{id}/Posts/Create")]
        public IActionResult CreatePost(int id, CreatePostRequest createPostRequest)
        {
            string error;
            bool success = _forumHandler.CreatePost(id, createPostRequest, out error);

            if (success)
                return StatusCode(200);
            else
                return StatusCode(400, error);
        }

        [HttpGet("{id}/Posts/List")]
        public IActionResult ListPosts(int id)
        {
            string error;
            var posts = _forumHandler.GetPosts(id, out error);

            if (posts.Count > 0)
                return StatusCode(200, posts);
            else
                return StatusCode(400, error);
        }

























        // GET: api/<ForumController>
        /*[HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ForumController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ForumController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ForumController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ForumController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}
