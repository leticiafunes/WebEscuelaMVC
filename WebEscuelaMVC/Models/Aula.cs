using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebEscuelaMVC.Validation;
using System.Web.DynamicData;

namespace WebEscuelaMVC.Models
{


    [Table("Aula")]
    public class Aula
    {
        [Key]
       
        public int AulaId { get; set; }

        [Required]

        [CheckValidNumero]
        public int Numero { get; set; }

        [Required]
      
        public string Estado { get; set; }


    }
}