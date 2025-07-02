using System;
using System.Collections.Generic;

namespace LucVanSon_231090087_Net.Models;

public partial class LvsEmployee
{
    public int LvsEmpId { get; set; }

    public string LvsEmpName { get; set; } = null!;

    public DateOnly LvsEmpStartDate { get; set; }

    public bool LvsEmpStats { get; set; }
}
