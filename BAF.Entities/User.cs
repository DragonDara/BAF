using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BAF.Entities
{
    public class User
    {
        [Key]
        public string AuthId { get; set; }
        [Required]
        public string ApiKeyHash { get; set; }
        [Required]
        public string ApiSecretValueHash { get; set; }
    }
}
