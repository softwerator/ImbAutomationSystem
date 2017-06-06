using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace IMB
{
    public class IMBveritabani : DbContext
    {
        public DbSet<IsKazalari> IsKazalari { get; set; }
        public DbSet<MeslekHastaliklari> MeslekHastaliklari { get; set; }
        public DbSet<HastaneRaporlari> HastaneRaporlari { get; set; }
    }
}
