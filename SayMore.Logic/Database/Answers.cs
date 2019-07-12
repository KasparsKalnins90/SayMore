namespace SayMore.Logic.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Answers
    {
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        public int UserId { get; set; }

        public int QuestionId { get; set; }

        public virtual Questions Questions { get; set; }

        public virtual Users Users { get; set; }
    }
}
