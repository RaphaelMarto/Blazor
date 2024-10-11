using DemoWASM.Models;
using Microsoft.AspNetCore.Components;

namespace DemoWASM.Pages.GamerView
{
    public partial class Details
    {
        [Parameter]
        public Gamer gamer { get; set; }
    }
}
