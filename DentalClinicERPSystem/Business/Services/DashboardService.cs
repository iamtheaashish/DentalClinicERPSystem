using Business.Interfaces;
using DentalClinicERPSystem.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services;

public class DashboardService : IDashboardService
{
    private readonly ApplicationDbContext _context;

    public DashboardService(ApplicationDbContext context)
    {
        _context = context;
    }

}
