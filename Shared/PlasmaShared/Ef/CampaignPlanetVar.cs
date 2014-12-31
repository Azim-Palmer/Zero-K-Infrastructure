namespace ZkData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CampaignPlanetVar")]
    public partial class CampaignPlanetVar
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CampaignID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PlanetID { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RequiredVarID { get; set; }

        [Required]
        public string RequiredValue { get; set; }

        public virtual Campaign Campaign { get; set; }

        public virtual CampaignPlanet CampaignPlanet { get; set; }

        public virtual CampaignVar CampaignVar { get; set; }
    }
}
