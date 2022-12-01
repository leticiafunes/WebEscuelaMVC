using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WebEscuelaMVC.Context;
using WebEscuelaMVC.Models;

namespace WebEscuelaMVC.Context
{
    public class EscuelaDBMVCContext : DbContext
    {
        public EscuelaDBMVCContext() : base("KeyEscuelaDB") { }
        public DbSet<Aula> Aulas { get; set; }
    }
}