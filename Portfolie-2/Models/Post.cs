using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portfolie_2.Models
{
    public class Post
    {
        //public string Url { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime CreationDate { get; set; }
        public int PostTypeId { get; set; }
        public int? ParentId { get; set; }
        public int? AcceptedAnswersId { get; set; }
        public int? UserId { get; set; }

        public class User
        {
            public int UserId { get; set; }
            public string Name { get; set; }
        }

        public User UserInstance { get; set; }

        public Post()
        {
            UserInstance = new User();
        }


        //public Post()
        //{
        //    this.User = new User() { UserId = -1 };
        //}
    }

    //public class PostUser
    //{
    //    public int UserId { get; set; }
    //    public string Name { get; set; }

        //Car car = new Car
        //{
        //    Name = "Chevrolet Corvette",
        //    Color = Color.Yellow,
        //    Manufacturer = new CarManufacturer
        //    {
        //        Name = "Chevrolet",
        //        Country = "USA"
        //    }
        //};
    //}

}