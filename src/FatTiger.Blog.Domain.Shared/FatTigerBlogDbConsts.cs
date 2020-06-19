using System;
using System.Collections.Generic;
using System.Text;

namespace FatTiger.Blog.Domain.Shared
{
    public class FatTigerBlogDbConsts
    {
        public static class DbTableName
        {
            public const string Posts = "Posts";

            public const string Categories = "Categories";

            public const string Tags = "Tags";

            public const string PostTags = "Post_Tags";

            public const string Friendlinks = "Friendlinks";
        }
    }
}
