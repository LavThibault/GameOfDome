using BuisnessLayer;
using EntitiesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebGoD.Models;

namespace WebGoD.Controllers
{
    [RoutePrefix("api/fight")]
    public class FightController : ApiController
    {
        // GET: api/Fight
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        [Route("{id}/{id2}")]
        public FightDto GetFightplayer(int id,int id2)
        {
            Fight f = ThronesTournamentManager.letsFightTwoHouse(id, id2);
            FightDto returnFightDto = new FightDto(f.Hof1.Id, f.Hof2.Id);

            if (f.WinningHouse != null)
            {
                returnFightDto.WinningHouse = f.WinningHouse.Id;
            }
            return returnFightDto;
        }



        // GET: api/Fight/5
        public FightDto Get(int id)
        {
            Fight f = ThronesTournamentManager.letsFight(id);
            FightDto returnFightDto = new FightDto(f.Hof1.Id, f.Hof2.Id);
            
            if (f.WinningHouse != null)
            {
                returnFightDto.WinningHouse = f.WinningHouse.Id;
            }
            return returnFightDto;
        }

        // GET: api/Fight/5/winner
        [Route("{id}/winner")]
        public HouseDto GetWinner(int id)
        {
            House h = ThronesTournamentManager.ReturnWinningHouse(id);
            return new HouseDto(h.Id, h.Name, h.NumberOfUnities, h.Gold);
        }

        // POST: api/Fight
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Fight/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Fight/5
        public void Delete(int id)
        {
        }
    }
}
