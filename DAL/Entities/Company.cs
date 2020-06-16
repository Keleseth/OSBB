using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class Company
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<CompanyProduct> CompanyProducts { get; set; }
    }
}