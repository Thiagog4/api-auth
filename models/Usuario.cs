using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace api_auth.models
{
    public class Usuario
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("nome")]
        public required string Nome { get; set; }
        [Column("senha")]
        public required string Senha { get; set; }
        [Column("token")]
        public string? Token { get; set; }

    }
}