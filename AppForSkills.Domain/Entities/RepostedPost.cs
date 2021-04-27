using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppForSkills.Domain.Entities
{
    public class RepostedPost
    {
        public int Id { get; set; }
        public int ReportedPostId { get; set; }
        public string UserWhoReportedPost { get; set; }
    }
}
