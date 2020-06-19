using System;
using System.Collections.Generic;
using System.Text;

namespace FatTiger.Blog.Application.Helloworld.impl
{
    public class HelloWorldService : FatTigerBlogApplicationServiceBase, IHelloWorldService
    {
        public string HelloWorld()
        {
            return "Hello World";
        }
    }
}
