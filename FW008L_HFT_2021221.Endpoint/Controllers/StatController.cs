using FW008L_HFT_2021221.Logic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace FW008L_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        IBookLogic bl;
        IPersonLogic pl;
        IWriterLogic wl;

        public StatController(IBookLogic bl, IPersonLogic pl, IWriterLogic wl)
        {
            this.bl = bl;
            this.pl = pl;
            this.wl = wl;
        }


        // GET: stat/autobiographiesbytitle
        [HttpGet]
        public IEnumerable<KeyValuePair<string, string>> AutobiographiesByTitle()
        {
            return bl.AutobiographiesByTitle();
        }


        // GET: stat/howmanybooksdotheyreadunder18
        [HttpGet]
        public IEnumerable<KeyValuePair<string, int>> HowManyBooksDoTheyReadUnder18()
        {
            return bl.HowManyBooksDoTheyReadUnder18();
        }


        // GET: stat/latestpublishedbooksbygeorges
        [HttpGet]
        public IEnumerable<KeyValuePair<string, int>> LatestPublishedBooksByGeorges()
        {
            return bl.LatestPublishedBooksByGeorges();
        }


        // GET: stat/hungarianreaders
        [HttpGet]
        public IEnumerable<KeyValuePair<string, int>> HungarianReaders()
        {
            return pl.HungarianReaders();
        }


        // GET: stat/top2productivewriters
        [HttpGet]
        public IEnumerable<KeyValuePair<string, int>> Top2ProductiveWriters()
        {
            return wl.Top2ProductiveWriters();
        }

    }
}
