using DemoWASM.Models;
using Microsoft.AspNetCore.Components;

namespace DemoWASM.Pages.GamerView
{
    public partial class GamerCard
    {
        [Parameter]
        public string Pseudo { get; set; }
        [Parameter]
        public int Id { get; set; }
        [Parameter]
        public EventCallback<DetailUpdateNotification> Details { get; set; }
        [Parameter]
        public EventCallback<DetailUpdateNotification> Update { get; set; }

        public void UpdateTrigger()
        {
            Update.InvokeAsync(new DetailUpdateNotification() { Id = Id, enable = true });
        }

        public void DetailsTrigger()
        {
            Details.InvokeAsync(new DetailUpdateNotification() { Id = Id, enable = true });
        }
    }
}
