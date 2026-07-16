using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace DentalClinicERP.Core.Entities;

public class ApplicationRole : IdentityRole
{
    public string Description { get; set; } = string.Empty;
}
