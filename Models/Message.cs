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
    
    public partial class Message
    {
        public int MessageId { get; set; }
        public string MessageText { get; set; }
        public int DialogueId { get; set; }
        public string Sender { get; set; }
        public bool MessageIsRead { get; set; }
        public System.DateTime MessageTime { get; set; }
    
        public virtual Dialogue Dialogue { get; set; }
    }
}
