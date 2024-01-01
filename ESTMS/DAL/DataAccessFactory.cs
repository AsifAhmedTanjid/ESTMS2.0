using DAL.EF.Models;
using DAL.Interfaces;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        public static IRepo<User, int, User> UserData()
        {
            return new UserRepo();
        }
        public static IAuth<bool> AuthData()
        {
            return new UserRepo();
        }
        public static IRepo<Player, int, Player> PlayerData()
        {
            return new PlayerRepo();
        }

        public static IRepo<Organizer, int, Organizer> OrganizerData()
        {
            return new OrganizerRepo();
        }

        public static IRepo<Sponsor, int, Sponsor> SponsorData()
        {
            return new SponsorRepo();
        }        
        public static IRepo<Game, int, Game> GameData()
        {
            return new GameRepo();
        }        
        public static IRepo<Organization, int, Organization> OrganizationData()
        {
            return new OrganizationRepo();
        }
    }
}
