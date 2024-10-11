using DemoWASM.Models;
using Microsoft.AspNetCore.Components;

namespace DemoWASM.Pages.GamerView
{
    public partial class AjoutGamer
    {
        [Parameter]
        public int Id { get; set; }
        public Gamer GamerForm { get; set; }
        [Parameter]
        public EventCallback<Gamer> NewGamer { get; set; }
        public AjoutGamer()
        {
            GamerForm = new Gamer() { Id = Id };
        }
        public void SendGamer()
        {
            NewGamer.InvokeAsync(GamerForm);
        }
    }
}
