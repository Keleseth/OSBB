using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class CompanyProduct
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Company Company { get; set; }
        public Guid CompanyId { get; set; }
        public Product Product { get; set; }
        public Guid ProductId { get; set; }
        public int Amount { get; set; }
    }
}