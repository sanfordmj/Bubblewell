using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Primitives
{

    public enum UserType
    {
        [Description("Unknown")]
        Unknown = 0,
        [Description("Standard")]
        Enabled = 1,
        [Description("Administrator")]
        Disabled = 2,
    }

    public enum UserStatus 
    { 
        [Description("Unknown")]
        Unknown = 0,
        [Description("Enabled")]
        Enabled = 1,
        [Description("Disabled")]
        Disabled = 2,
    }

    public enum AddressStatus{
        [Description("Unknown")]
        Unknown = 0,
        [Description("Enabled")]
        Enabled = 1,
        [Description("Disabled")]
        Disabled = 2,
    }

    public enum AddressType{
        [Description("Unknown")]
        Unknown = 0,
        [Description("Residential")]
        Residential = 1,
        [Description("Business")]
        Business = 2,
        [Description("PO Box")]
        POBox = 3,
    }

    public enum RouteStatus{
        [Description("Unknown")]
        Unknown = 0,
        [Description("Active")]
        Active = 1,
        [Description("Disabled")]
        Disabled = 2,
    }

    public enum RouteType {
        [Description("Unknown")]
        Unknown = 0,
        [Description("Paper Route")]
        Paper = 1,
    }

}
