using DemoWASM.Models;
using Microsoft.AspNetCore.Components;

namespace DemoWASM.Pages.GamerView
{
    public partial class Update
    {
        [Parameter]
        public Gamer GamerForm { get; set; }
        [Parameter]
        public EventCallback<Gamer> UpdateGamer { get; set; }
        public void SendGamer()
        {
            UpdateGamer.InvokeAsync(GamerForm);
        }
    }
}
