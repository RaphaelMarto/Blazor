using DemoWASM.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace DemoWASM.Pages.GameView
{
    public partial class AddGame
    {
        [Inject]
        public HttpClient Client { get; set; }
        [Inject]
        public IJSRuntime JS { get; set; }
        [Inject]
        public AuthenticationStateProvider StateProvider { get; set; }
        [Inject]
        public NavigationManager Nav { get; set; }
        public Game GameForm { get; set; } = new Game();

        public async Task SendGame()
        {
            string token = await JS.InvokeAsync<string>("localStorage.getItem", "token");
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            HttpResponseMessage response =
                    await Client.PostAsJsonAsync("Game/Create", GameForm);

            if (!response.IsSuccessStatusCode)
            {
                await Console.Out.WriteLineAsync("Erreur : " + response.ReasonPhrase);
            }

            string res = await response.Content.ReadAsStringAsync();
            Nav.NavigateTo("/game");
        }
    }
}
