using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Core.Models
{
    public class Owner : BaseModel
    {
        public Owner()
        {
            Contacts = new Collection<Contact>();
        }
        public ICollection<Contact> Contacts { get; set; }
    }
}
