﻿using Microsoft.EntityFrameworkCore;
using SpaApp.models;
using System;

namespace Main.Database
{
    public class ReservationDbContext : DbContext
    {
        public ReservationDbContext(DbContextOptions<ReservationDbContext> options) : base(options)
        {

        }

        public DbSet<Reservation> Reservations { get; set; }
    }
}
