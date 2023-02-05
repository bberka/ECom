namespace ECom.Domain.Exceptions
{
    public class CanNotBeUsedException : CustomException
    {
        public CanNotBeUsedException(string name) : base(name)
        {

        }
    }
}
