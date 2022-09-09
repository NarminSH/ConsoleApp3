using System;
using System.Collections.Generic;
using System.Text;


public class NotFoundException: Exception
{
    public NotFoundException(string message) : base(message)
    {
    }
}

