using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupportSystemApp.Models
{
    public class SupportListComments
    {
        public string AspNetUsersId { get; set; }
        public int Id { get; set; }
        public string Message { get; set; }
        public int TicketNoID { get; set; }
    }
}