﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable enable
using System;
using System.Collections.Generic;

namespace WeatherRepository.Models;

public partial class Region
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Weather> Weathers { get; set; } = new List<Weather>();
}