using DemoWASM.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;

namespace DemoWASM.Pages.GameView
{
    public partial class UpdateGame
    {
        [Parameter]
        public Game GameForm { get; set; }
        [Parameter]
        public EventCallback<Game> Update { get; set; }
        public void SendGame()
        {
            Update.InvokeAsync(GameForm);
        }
    }
}
