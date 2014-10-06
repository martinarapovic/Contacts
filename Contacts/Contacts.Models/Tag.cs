
namespace Contacts.Models
{
    public class Tag
    {
        public int TagId { get; set; }
        public int ContactId { get; set; }
        public string Name { get; set; }

        public virtual Contact Contact { get; set; }
    }
}