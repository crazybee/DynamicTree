﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

public partial class VehicleSubType
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int VehicleTypeId { get; set; }
    public string Description { get; set; }
    public System.DateTime TimeStamp { get; set; }

    public virtual VehicleType VehicleType { get; set; }
}

public partial class VehicleType
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public VehicleType()
    {
        this.VehicleSubTypes = new HashSet<VehicleSubType>();
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public System.DateTime TimeStamp { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<VehicleSubType> VehicleSubTypes { get; set; }
}
