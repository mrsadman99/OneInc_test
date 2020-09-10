namespace OneInc_test.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Policy")]
    public partial class Policy
    {
        public int Id { get; set; }

        [Column(TypeName = "date")]
        [Display(Name="Start date")]
        public DateTime StartDate { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "End date")]
        public DateTime EndDate { get; set; }

        [Column(TypeName = "date")]
        [Display(Name="Date of birth")]
        public DateTime BirthDate { get; set; }

        [Required]
        [StringLength(40)]
        public string ObjectName { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public int? PolicyNumber { get; set; }

        public int? MonthCreated { get; set; }

        public int Type { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Update date")]
        public DateTime UpdateDate { get; set; }
    }
}
