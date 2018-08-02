using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicCollabWebApp.Models
{
    public class AudioFile
    {
        public int Id { get; set; }
        public string User { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }

    }
}
