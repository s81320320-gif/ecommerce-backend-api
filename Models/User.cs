using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Ecommerece.Models;

[Index("MobileNumber", Name = "UQ_Users_MobileNumber", IsUnique = true)]
public partial class User
{
    [Key]
    public int Id { get; set; }

    [StringLength(15)]
    [Unicode(false)]
    public string MobileNumber { get; set; } = null!;

    [StringLength(6)]
    [Unicode(false)]
    public string? Otp { get; set; }

    public bool? IsVerified { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }

    [InverseProperty("User")]
    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    [InverseProperty("User")]
    public virtual ICollection<Favourite> Favourites { get; set; } = new List<Favourite>();
}
