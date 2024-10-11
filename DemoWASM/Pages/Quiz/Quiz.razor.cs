namespace DemoWASM.Pages.Quiz
{
    public partial class Quiz
    {
        public Dictionary<int, string> ListQuestion { get; set; }
        public int Nb { get; set; } = 1;
        public int NbMax { get; set; } = 0;
        public List<string> Responses { get; set; }
        public required string Name { get; set; }
        private bool End { get; set; } = false;
        public Quiz()
        {
            Responses = new List<string>();
            ListQuestion = new Dictionary<int, string>() { { 1, "Test question" }, { 2, "New Test" }, { 3, "Test Test Test !!" } };
        }
        public void getChildResponse(string res)
        {
            if (Nb == NbMax)
            {
                Responses.Add(res);
                Responses.Add("Fin de partie");
                End = true;
            }
            else
            {
                Responses.Add(res);
                Nb++;
            }
        }

        private void RefreshComponent()
        {
            new Quiz() { Name = Name };
            /* Name = string.Empty;
             NbMax = 0;
             Responses = new List<string>();
             Nb = 1;
             End = false;*/
            //StateHasChanged();
        }
    }
}
