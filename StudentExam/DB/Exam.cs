//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StudentExam.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Exam
    {
        public int ExamID { get; set; }
        public System.DateTime ExamDate { get; set; }
        public Nullable<int> DisciplineID { get; set; }
        public Nullable<int> RegID { get; set; }
        public Nullable<int> EmployeeID { get; set; }
        public string Auditorium { get; set; }
        public Nullable<int> Mark { get; set; }
    
        public virtual Discipline Discipline { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Student Student { get; set; }
    }
}
