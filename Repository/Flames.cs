using CSIT.Flames.Api.DTO;
using CSIT.Flames.Api.Models;
using CSIT.Flames.Api.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSIT.Flames.Api
{
    public class Flames:IFlames,IDisposable
    {
        private readonly FlamesContext _dbContext;
        private IsolationLevel _isolationLevel { get { return IsolationLevel.ReadCommitted; } }
        public Flames(FlamesContext dbcontext)
        {
            _dbContext = dbcontext;
        }
        
        public async Task < string> check(Person person)
        { 


            string Flame = "FLAMES";
            string guy1 = person.Boy;
            string gal1 = person.Girl;
        
                
            StringBuilder sb = new StringBuilder(guy1);
            StringBuilder sb1 = new StringBuilder(gal1);
            StringBuilder sb2 = new StringBuilder(Flame);
            int x = sb.Length;
            int y = sb1.Length;
            if ((x == 1) || (y == 1) || (x == 0) || (y == 0))
            {
                return ("");
            }
                
            else
            {
            begin:
                for (int i = 0; i < gal1.Length; i++)
                {
                    int xx = guy1.IndexOf(gal1[i]);
                    if (xx != -1)
                    {
                        sb.Remove(xx, 1);
                        sb1.Remove(i, 1);
                        guy1 = sb.ToString();
                        gal1 = sb1.ToString();
                        goto begin;
                    }
                }
                int count = sb.Length + sb1.Length;
                //checking in FLAMES
                if (count != 0)
                {
                    int c = 0;
                    int c1 = 0;
                    --count;
                    int u = Flame.Length;
                    do
                    {
                        if (c1 == count)
                        {
                            sb2.Remove(c, 1);
                            Flame = sb2.ToString();
                            c1 = 0;
                        }
                        u = Flame.Length;
                        --u;
                        if (c > u) c = 0;
                        if (c == u) c = -1;
                        ++c;
                        ++c1;
                    }
                    while (Flame.Length != 1);
                }
               
            }
            switch (Flame)
            {
                case "F":
                    Flame = "Friendship!";
                    break;
                case "L":
                    Flame = "Love!";
                    break;
                case "A":
                    Flame = "Affection!";
                    break;
                case "M":
                    Flame = "Marriage!";
                    break;
                case "E":
                    Flame = "Enemy!";
                    break;
                case "S":
                    Flame = "Sibilings!";
                    break;

            }


            try
            {

                using (IDbContextTransaction _dbContextTransaction = _dbContext.Database.BeginTransaction(_isolationLevel))
                {
                    DataDetails t = new DataDetails()

                    {
                        Bname = person.Boy,
                        Gname = person.Girl,
                        Flames = Flame
                    };
                     await _dbContext.DataDetails.AddAsync(t);
                    if (await _dbContext.SaveChangesAsync() < 0)
                    {
                         await _dbContextTransaction.RollbackAsync();
                        return "failed";

                    }
                    await _dbContextTransaction.CommitAsync();
                     return Flame;
                }
                

            }  
            catch(Exception Ex)
            {
                return Ex.Message;
            }
           
        }

        public void Dispose()
        {
            
        }
    }
}
