using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Core.Models
{
    public class OwnerModel : BaseModel
    {
        public OwnerModel()
        {
            Contacts = new Collection<ContactModel>();
        }
        public ICollection<ContactModel> Contacts { get; set; }
    }
}
