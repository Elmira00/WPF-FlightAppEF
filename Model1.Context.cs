﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WPF_FlightAppEF
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class FlightDbEntities : DbContext
    {
        public FlightDbEntities()
            : base("name=FlightDbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Airplane> Airplanes { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<FlightType> FlightTypes { get; set; }
        public virtual DbSet<Pilot> Pilots { get; set; }
        public virtual DbSet<Schedule> Schedules { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
    
        public virtual ObjectResult<GetTicketById_Result> GetTicketById(Nullable<int> ticket_id)
        {
            var ticket_idParameter = ticket_id.HasValue ?
                new ObjectParameter("ticket_id", ticket_id) :
                new ObjectParameter("ticket_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetTicketById_Result>("GetTicketById", ticket_idParameter);
        }
    }
}
