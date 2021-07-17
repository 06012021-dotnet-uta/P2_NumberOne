using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using data_models.custom;
using data_models;

namespace utilities.forum
{
    public interface IForumHandler
    {
        Forum CreateNewForum(ForumCustom newForum, out string error);
        bool DeletedForum(int forumID, out string error);
        List<ForumCustom> ShowForumList(out string error);
        Forum SearchForumID(int forumID, out string error);
        Forum SearchForumPetID(int petID, out string error);
        Post CreatePost(int id, CreatePostRequest createPostRequest, out string error);
        List<Post> GetPosts(int id, out string error);
        Post GetPost(int forumId, int postId, out string error);
    }
}
