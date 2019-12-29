using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommerceBot.Model
{
    public class Location
    {
        [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LocationID { get; set; }
        public string LocationName { get; set; }
    }
}
