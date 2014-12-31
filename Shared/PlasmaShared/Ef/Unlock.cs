namespace ZkData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Unlock")]
    public partial class Unlock
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Unlock()
        {
            AccountUnlocks = new HashSet<AccountUnlock>();
            Commanders = new HashSet<Commander>();
            CommanderDecorations = new HashSet<CommanderDecoration>();
            CommanderModules = new HashSet<CommanderModule>();
            KudosPurchases = new HashSet<KudosPurchase>();
            StructureTypes = new HashSet<StructureType>();
            Unlock1 = new HashSet<Unlock>();
        }

        public int UnlockID { get; set; }

        [Required]
        [StringLength(100)]
        public string Code { get; set; }

        [StringLength(200)]
        public string Name { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        public int NeededLevel { get; set; }

        [StringLength(500)]
        public string LimitForChassis { get; set; }

        public int UnlockType { get; set; }

        public int? RequiredUnlockID { get; set; }

        public int MorphLevel { get; set; }

        public int MaxModuleCount { get; set; }

        public int? MetalCost { get; set; }

        public int XpCost { get; set; }

        public int? MetalCostMorph2 { get; set; }

        public int? MetalCostMorph3 { get; set; }

        public int? MetalCostMorph4 { get; set; }

        public int? MetalCostMorph5 { get; set; }

        public int? KudosCost { get; set; }

        public bool? IsKudosOnly { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AccountUnlock> AccountUnlocks { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Commander> Commanders { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CommanderDecoration> CommanderDecorations { get; set; }

        public virtual CommanderDecorationIcon CommanderDecorationIcon { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CommanderModule> CommanderModules { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KudosPurchase> KudosPurchases { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StructureType> StructureTypes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Unlock> Unlock1 { get; set; }

        public virtual Unlock Unlock2 { get; set; }
    }
}
