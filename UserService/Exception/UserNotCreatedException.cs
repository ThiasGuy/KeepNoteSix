﻿namespace UserService.Exception
{
    public class UserNotCreatedException : ApplicationException
    {
        public UserNotCreatedException() { }
        public UserNotCreatedException(string message) : base(message) { }

    }
}
