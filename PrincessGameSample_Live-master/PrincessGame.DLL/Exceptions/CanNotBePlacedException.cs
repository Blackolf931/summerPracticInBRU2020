using System;

namespace PrincessGame.DLL.Exceptions
{
    public class CanNotBePlacedException : Exception
    {
        public CanNotBePlacedException()
        {
        }

        public CanNotBePlacedException(string message) : base(message)
        {
        }
    }
}
