namespace GamerLibrary.Common.Domain
{
    public class NotFoundException : BaseException
    {
        private const string NotFoundMessage = "The entity {0} with Id '{1}' could not be found";

        public NotFoundException(string entity, string id) : base(string.Format(NotFoundMessage, entity, id))
        {
        }
    }
}
