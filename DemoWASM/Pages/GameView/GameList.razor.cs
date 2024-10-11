using DemoWASM.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace DemoWASM.Pages.GameView
{
    public partial class GameList
    {
        private Game _currentGame { get; set; }
        private bool _update = false;
        [Inject]
        public HttpClient Client { get; set; }
        [Inject]
        public IJSRuntime JS { get; set; }
        public List<Game> ListGame { get; set; } = new List<Game>();
        [Inject]
        public NavigationManager Nav { get; set; }
        protected override async Task OnInitializedAsync()
        {
            await LoadData();
        }

        public async Task LoadData()
        {
            string token = await JS.InvokeAsync<string>("localStorage.getItem", "token");
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            ListGame = await Client.GetFromJsonAsync<List<Game>>("Game");
        }

        public void NavigateToAddGame()
        {
            Nav.NavigateTo("/addGame");
        }

        public void sendDataUpdate(Game game)
        {
            _currentGame = game;
            _update = true;
        }

        public async void Update(Game game)
        {
            _update = false;
            await Client.PutAsJsonAsync("Game/" + game.Id, game);
        }

        public async void Delete(int id)
        {
            ListGame.RemoveAll(g => g.Id == id);
            await Client.DeleteAsync("Game/" + id);
        }
    }
}
