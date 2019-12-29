using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceBot.Model
{
   [Serializable]
   public class Cabana
    {
        [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CabanaID { get; set; }
        public string CabanaName { get; set; }

        [ForeignKey("Location")]
        public int LocationID { get; set; }

        public int Rating { get; set; }
        public int NumberOfReviews { get; set; }
        public int PriceStarting { get; set; }
        public string Image { get; set; }


        public virtual Location Location { get; set; }
    }
}
