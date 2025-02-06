using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Selu383.SP25.Api.Entity;

public class Role : IdentityRole<int>
{
    public List<UserRole> Users { get; set; } = new();
}