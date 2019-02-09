using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace CRUDPlay.Models
{
    class Weight
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public double Weights { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
