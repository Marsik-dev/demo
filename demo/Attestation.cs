//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace demo
{
    using System;
    using System.Collections.Generic;
    
    public partial class Attestation
    {
        public int id { get; set; }
        public int id_student { get; set; }
        public int id_subject { get; set; }
        public int first { get; set; }
        public int second { get; set; }
        public int final { get; set; }
        public Nullable<int> sum { get; set; }
        public int mark { get; set; }
    
        public virtual MarksType MarksType { get; set; }
        public virtual Student Student { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
