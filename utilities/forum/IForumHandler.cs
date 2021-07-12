﻿using System;
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
    }
}
