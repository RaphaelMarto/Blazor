using Microsoft.AspNetCore.Components;

namespace DemoWASM.Pages.Quiz
{
    public partial class Question
    {
        [Parameter]
        public string name { get; set; }
        [Parameter]
        public int nb { get; set; }
        [Parameter]
        public string question { get; set; }

        [Parameter]
        public EventCallback<string> ReponseQuestion { get; set; }

        public void EnvoiReponse(string Response)
        {
            ReponseQuestion.InvokeAsync(Response);
        }
    }
}
