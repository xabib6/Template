using System;

namespace Template.MVVM.Models
{
    public class CustomException : Exception
    {
        public CustomException(string message) : base(message) { }
    }
}
