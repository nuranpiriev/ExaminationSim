using Examination.DAL.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination.DAL.Models.Entities;

public class CartItem:BaseAuditable
{
    public string? Title {  get; set; }
    public string? IconUrl {  get; set; }
    public string? Description { get; set; }
    public string? ImageUrl {get; set; }  
}
