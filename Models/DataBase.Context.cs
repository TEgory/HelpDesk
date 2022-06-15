﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HelpDesk.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public partial class HelpDeskEntities : DbContext
    {
        private static HelpDeskEntities _context;

        public static HelpDeskEntities GetContext()
        {
            if( _context == null )
                _context = new HelpDeskEntities();
            return _context;
        }

        public HelpDeskEntities()
            : base("name=HelpDeskEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Device> Devices { get; set; }
        public virtual DbSet<DeviceStatu> DeviceStatus { get; set; }
        public virtual DbSet<Dialogue> Dialogues { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Priority> Priorities { get; set; }
        public virtual DbSet<Request> Requests { get; set; }
        public virtual DbSet<RequestStatu> RequestStatus { get; set; }
        public virtual DbSet<RequestType> RequestTypes { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}