﻿using NPOI.XWPFMapper.Attributes;
using NPOI.XWPFMapper.Interfaces;

namespace NPOI.XWPFMapper.Example
{
    internal class ExampleClass : IXWPFMappable // Implement the IXWPFMappable interface to make a class mappable
    {
        // Add the XWPFPropertyattribute to make a member mappable.
        [XWPFProperty("Color")]
        public ExampleEnum Enum { get; set; }

        [XWPFProperty("Name")]
        public string? Name { get; set; }

        // This child class also implements IXWPFMappable and will become a nested table.
        [XWPFProperty("Address", Enums.XWPFTableAlignment.Row)]
        public ExampleChildClass? Address { get; set; }

        // Without the XWPFPropertyAttribute a member will be ignored by the mapping.
        public string? IgnoredMember { get; set; }
    }

    internal class ExampleChildClass : IXWPFMappable
    {
        [XWPFProperty("Street")]
        public string? Address { get; set; }
        [XWPFProperty("Place")]
        public string? City { get; set; }
        [XWPFProperty("Country")]
        public string? CountryCode { get; set; }
    }

    internal enum ExampleEnum
    {
        Red, Blue, Green
    }
}
