//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Device
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Device()
        {
            this.Requests = new HashSet<Request>();
        }
    
        public int DeviceId { get; set; }
        public string DeviceName { get; set; }
        public string PublicIP { get; set; }
        public string LocalIP { get; set; }
        public string OperatingSystem { get; set; }
        public bool Condition { get; set; }
        public System.TimeSpan DurationOnline { get; set; }
        public int Status { get; set; }
        public int LastUserId { get; set; }
    
        public virtual DeviceStatus DeviceStatus { get; set; }
        public virtual User User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Request> Requests { get; set; }
    }
}
