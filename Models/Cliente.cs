using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TriaCSharp.Models
{
    public class Cliente
    {   
        public Cliente () { }
        public Cliente(int id, string name, string company, DateTime createdAt, DateTime updatedAt, string phone, string mail, string notes, int produtoId)
        {
            this.Id = id;
            this.Name = name;
            this.company = company;
            this.createdAt = createdAt;
            this.updatedAt = updatedAt;
            this.phone = phone;
            this.mail = mail;
            this.notes = notes;
            this.ProdutoId = produtoId;
            this.Produto = Produto;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string company { get; set; }
        public Produto Produto { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public string phone { get; set; }
        public string mail { get; set; }
        public string notes { get; set; }
        public int ProdutoId {get; set;}
    }
}
