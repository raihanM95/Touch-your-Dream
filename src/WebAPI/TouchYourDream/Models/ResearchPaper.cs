using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TouchYourDream.Models
{
    public class ResearchPaper
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public DateTime? Date { get; set; }
    }
}
