using DemoWASM.Models;

namespace DemoWASM.Services
{
    public class UserService
    {
        public Dictionary<int, Gamer> GamerList;

        public UserService()
        {
            GamerList = new Dictionary<int, Gamer>() { {0,
                    new Gamer()
                    {
                        Id = 0,
                        Pseudo = "test",
                        Email = "test",
                        Password = "testest213",
                    }
                },
                {1,
                    new Gamer()
                    {
                        Id = 1,
                        Pseudo = "test2",
                        Email = "test2",
                        Password = "testest2132",
                    }
                }
            };
        }

        public Gamer getGamerData(int id)
        {
            return GamerList[id];
        }

        public void add(Gamer gamer)
        {
            GamerList.Add(GamerList.Count, gamer);
        }

        public void Update(int id, Gamer gamer)
        {
            GamerList.Remove(id);
            GamerList.Add(id, gamer);
        }

        public Dictionary<int, Gamer> GetAll()
        {
            return GamerList;
        }
    }
}
