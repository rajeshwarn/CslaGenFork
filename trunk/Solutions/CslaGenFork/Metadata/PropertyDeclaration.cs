﻿using System.ComponentModel;
using CslaGenerator.Design;

namespace CslaGenerator.Metadata
{
    /// <summary>
    /// Declaration mode of the property.
    /// </summary>
    [TypeConverter(typeof(EnumDescriptionOrCaseConverter))]
    public enum PropertyDeclaration
    {
        Managed,
        [Description("Managed with Type Conversion")]
        ManagedWithTypeConversion,
        Unmanaged,
        [Description("Unmanaged with Type Conversion")]
        UnmanagedWithTypeConversion,
        AutoProperty,
        ClassicProperty,
        [Description("Classic Property with Type Conversion")]
        ClassicPropertyWithTypeConversion,
        NoProperty
    }
}