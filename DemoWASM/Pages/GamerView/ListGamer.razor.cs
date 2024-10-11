using DemoWASM.Models;
using Microsoft.AspNetCore.Components;

namespace DemoWASM.Pages.GamerView
{
    public partial class ListGamer
    {
        [Parameter]
        public Dictionary<int, Gamer> List { get; set; }
        public int Id { get; set; }
        public void getIdCurrent(int id)
        {
            Id = id;
        }
        [Parameter]
        public EventCallback<DetailUpdateNotification> EventActionUpdate { get; set; }
        public void SendEventUpdate(DetailUpdateNotification data)
        {
            EventActionUpdate.InvokeAsync(data);
        }

        [Parameter]
        public EventCallback<DetailUpdateNotification> EventActionDetails { get; set; }
        public void SendEventDetails(DetailUpdateNotification data)
        {
            EventActionDetails.InvokeAsync(data);
        }
    }
}
