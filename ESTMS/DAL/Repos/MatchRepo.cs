using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class MatchRepo : Repo, IRepo<Match, int, Match>,IMatchStat<Match,int>
    {
        public Match Add(Match obj)
        {
            db.Matches.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            else return null;
        }

        public bool Delete(int id)
        {
            var ex = Get(id);
            db.Matches.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<Match> Get()
        {
            return db.Matches.ToList();
        }

        public Match Get(int id)
        {
            return db.Matches.Find(id);
        }

        public List<Match> Stat(int id)
        {
            var data = db.Matches.Where(m => m.Team1Id==id || m.Team2Id == id ).ToList();
            return data;
        }

        public Match Update(Match obj)
        {
            var ex = Get(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            else return null;
        }
    }
}
