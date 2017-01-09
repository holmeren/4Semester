using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksamensStats.Model
{
    public class StudentStats
    {
        public int StudentStatsId { get; set; }
        public List<Student> Students { get; set; }
        public double Average { get; set; }
    }
}
