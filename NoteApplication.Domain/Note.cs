using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApplication.Domain
{
    public class Note : BaseEntity
    {
        public User? NoteCreator { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public GroupName GroupName { get; set; }
        public virtual DateTime CreatedDate { get; protected set; } = DateTime.Now;
        public virtual DateTime UpdatedDate { get; protected set; } = DateTime.Now;

    }
}
