using DemoWASM.Models;
using DemoWASM.Services;

namespace DemoWASM.Pages.GamerView
{
    public partial class GamerView
    {
        private UserService _UserService;
        public Dictionary<int, Gamer> ListGamerView;
        private bool Details = false;
        private bool Update = false;
        private Gamer _CurrentGamer { get; set; }
        public GamerView()
        {
            _UserService = new UserService();
            Refresh();
        }

        public void Refresh()
        {
            ListGamerView = _UserService.GetAll();
        }

        public void addNewGamer(Gamer gamer)
        {
            _UserService.add(gamer);
        }

        public void UpdateGamer(Gamer gamer)
        {
            _UserService.Update(gamer.Id, gamer);
        }

        public void getActionDetails(DetailUpdateNotification data)
        {
            Details = data.enable;
            Update = false;
            _CurrentGamer = _UserService.getGamerData(data.Id);
        }

        public void getActionUpdate(DetailUpdateNotification data)
        {
            Update = data.enable;
            Details = false;
            _CurrentGamer = ListGamerView[data.Id];
        }
    }
}
