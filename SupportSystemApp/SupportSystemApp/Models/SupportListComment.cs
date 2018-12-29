using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupportSystemApp.Models
{
    public class SupportListComment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SupportListComment()
        {
            this.Comments = new HashSet<Comment>();
        }

        public int TicketNo { get; set; }
        public string Title { get; set; }
        public int Status { get; set; }
        public int Category { get; set; }
        public int Severity { get; set; }
        public int Priority { get; set; }
        public string RaisedBy { get; set; }
        public System.DateTime RaisedOn { get; set; }
        public System.DateTime DueOn { get; set; }
        public Nullable<System.DateTime> ResolvedOn { get; set; }
        public Nullable<int> IDSectionList { get; set; }

        public string AspNetUsersId { get; set; }
        public List<string> Message { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }
        public virtual SupportList SupportList { get; set; }

        public virtual PriorityList PriorityList { get; set; }
        public virtual SectionsList SectionsList { get; set; }
        public virtual SeverityList SeverityList { get; set; }
        public virtual StatusesList StatusesList { get; set; }
        public virtual CategoryList CategoryList { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment> Comments { get; set; }
    }
}