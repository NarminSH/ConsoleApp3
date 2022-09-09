using System;
using System.Collections.Generic;
using System.Text;


public class Post: IEntity
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }

}

