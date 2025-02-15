﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using data_models;
using Microsoft.Extensions.Logging;
using data_models.custom;
using utilities.Mapper;

namespace utilities.forum
{
    public class ForumHandler : IForumHandler
    {
        private readonly PetTrackerDBContext _context;
        private readonly ILogger<ForumHandler> _logger;
        private readonly IGetMyLocation _IGetMyLocation;
        private Forum _forum;


        public ForumHandler(PetTrackerDBContext context, ILogger<ForumHandler> logger, IGetMyLocation getMyLocation)
        {
            _context = context;
            _logger = logger;
            _IGetMyLocation = getMyLocation;
        }


        /// <summary>
        /// Create a New Forum
        /// </summary>
        /// <param name="newForum"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public Forum CreateNewForum(ForumCustom newForum, out string error)
        {
            Forum result = null;
            try { 
                result = _context.Forums.Where(x => x.PetId == newForum.PetId).FirstOrDefault();

                if (result == null)
                {

                    var forum = ObjectMapper.Mapper.Map<ForumCustom, Forum>(newForum);
                    forum = _context.Forums.Add(forum).Entity;
                    _context.SaveChanges();

                    result = forum;

                    _forum = result;
                    error = null;
                }
                else
                {
                    error = "Forum for this pet alrady exist...!";
                }
            }
            catch (DBConcurrencyException e)
            {
                _logger.Log(LogLevel.Error, e.Message);
                _forum = null;
                error = "ConcurrencyExeption In CreateNewForum() Method.....";
            }

            return result;
        }



        /// <summary>
        /// Delete A particular Forum
        /// </summary>
        /// <param name="forumID"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public bool DeletedForum(int forumID, out string error)
        {
            Forum forum = null;
            bool succes = true;

            forum = _context.Forums.Where(x => x.ForumId == forumID).FirstOrDefault();

             _context.Forums.Remove(forum);
             succes = _context.SaveChanges() > 0;

            if(succes == false)
            {
                error = "Dont remove the forum";
                return false;
            }
            else
            {
                error = null;
                return succes;
            }
        }



        /// <summary>
        /// Display Forum list
        /// </summary>
        /// <param name="error"></param>
        /// <returns></returns>
        public List<Forum> ShowForumList(out string error)
        {
            List<Forum> forumList = null;

            try
            {
                forumList = _context.Forums.ToList();

                
            }
            catch (ArgumentNullException ex)
            {
                error = "ShowForumList problem";
                Console.WriteLine($"The was a problem on forumList display {ex.InnerException}");
              
            }

            error = null;
            return forumList;
        }



        /// <summary>
        /// Search forum by Name
        /// </summary>
        /// <param name="forumName"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public Forum SearchForumID(int forumID, out string error)
        {
            Forum forum = null;

            try
            {

                forum = _context.Forums.Where(x => x.ForumId == forumID).FirstOrDefault();

                if (forum == null)
                {
                    error = "ForumID not found in the DB";
                    
                }
                else
                {
                    error = null;
                }

            }
            catch(ArgumentNullException e)
            {
                _logger.Log(LogLevel.Error, e.Message);
                error = "Something Wrong in SearchForum() method";
            }

            return forum;
        }



        public Forum SearchForumPetID(int petID, out string error)
        {
            Forum forum = null;

            try
            {

                forum = _context.Forums.Where(x => x.PetId == petID).FirstOrDefault();

                if (forum == null)
                {
                    error = "PetID not found in the DB";

                }
                else
                {
                    error = null;

                }

            }
            catch (ArgumentNullException e)
            {
                _logger.Log(LogLevel.Error, e.Message);
                error = "Something Wrong in SearchForumPetID() method";
            }

            return forum;
        }

        public Post CreatePost(int id, CreatePostRequest createPostRequest, out string error)
        {
            error = null;
            Post newPost = null;
            try
            {
                newPost = ObjectMapper.Mapper.Map<CreatePostRequest, Post>(createPostRequest);
                newPost.ForumId = id;
                newPost.PostTime = DateTime.Now;

                _context.Posts.Add(newPost);
                _context.SaveChanges();

            }
            catch (Exception e)
            {
                _logger.Log(LogLevel.Error, e.Message);
                error = e.Message;
            }

            return newPost;

        }

        public List<Post> GetPosts(int id, out string error)
        {
            List<Post> posts;
            error = null;

            posts = _context.Posts.Where(x => x.ForumId == id).ToList();

            if (posts.Count < 1)
            {
                error = "No posts found";

                _logger.Log(LogLevel.Warning, error);
            }

            return posts;
        }

        public Post GetPost(int forumId, int postId, out string error)
        {
            Post post = null;
            error = null;
            try
            {
                post = _context.Posts.Where(x => x.ForumId == forumId && x.PostId == postId).FirstOrDefault();
            }
            catch(Exception e)
            {
                _logger.Log(LogLevel.Error, e.Message);
                error = e.Message;
            }

            return post;
        }

        public bool DeletePost(int postId, out string error)
        {
            error = null;
            try
            {
                Post p = _context.Posts.Find(postId);

                _context.Posts.Remove(p);
                _context.SaveChanges();
            }
            catch(Exception e)
            {
                _logger.Log(LogLevel.Error, e.Message);
                error = e.Message;
            }

            if (error == null) return true;
            else return false;
        }

    }
}
