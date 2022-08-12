using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain
{
    public class Streamer
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Url { get; set; }
    }
}
