using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lession10.Models;

public partial class LvsPost
{
    public int Lvsid { get; set; }

    public string Lvsname { get; set; } = null!;

    public string? LvsImage { get; set; }

    public string? LvsContent { get; set; }

    public bool LvsStats { get; set; }
    [NotMapped]
    public IFormFile? ImageFile { get; set; } // For file upload in the controller
}
