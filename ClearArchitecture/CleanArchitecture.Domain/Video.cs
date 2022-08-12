using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain
{
    public class Video
    {
        public  int Id { get; set; }
        public string? Name { get; set; }

        public int? StrimerId { get; set; }
        public virtual Streamer? Streamer { get; set; }
    }
}
