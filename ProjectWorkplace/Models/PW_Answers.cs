//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjectWorkplace.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PW_Answers
    {
        public System.Guid AnswerID { get; set; }
        public System.Guid QuestionID { get; set; }
        public string AnswerDesc { get; set; }
        public bool IsActive { get; set; }
        public bool IsCorrect { get; set; }
    
        public virtual PW_Questions PW_Questions { get; set; }
    }
}
