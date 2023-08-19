namespace Framework.Domain
{
    public class DomainBase<T>
    {
        public DomainBase()
        {
            CreateDate = DateTime.Now;
        }
        public T Id { get; private set; }
        public DateTime CreateDate { get; private set; }
    }
}