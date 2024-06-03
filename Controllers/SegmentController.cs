using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TestAPI.Controllers
{
    public class Segment
    {
        public double X;
        public double Y;
        public double X1;
        public double Y1;
    }

    public class SegmentController : ApiController
    {
        // GET: api/Segment
        [HttpPost]
        [Route("api/Segment/SearchSegment")]
        public List<Segment> SearchSegment(double x, double y, double x1, double y1)
        {
            List<Segment> data = null;
            using (var db = new DataClassesDataContext(@"Data Source=DESKTOP-8U3LNMG\SQLEXPRESS2017;Initial Catalog=TestAPI;Integrated Security=True"))
            {
                data = db.ExecuteQuery<Segment>(string.Format("exec SearchSegments {0},{1},{2},{3}", x, y, x1, y1)).ToList();
            }

            return data;
        }

        // POST: api/Segment
        public void Post(double x, double y, double x1, double y1)
        {
            using (var db = new DataClassesDataContext())
            {
                //while adding we determine left upper corner and right bottom conner for further faster segments search
                db.Segments.InsertOnSubmit(new TestAPI.Segment() 
                    { 
                        X =  (x > x1 ? x1 : x), 
                        X1 = (x > x1 ? x :  x1), 
                        Y =  (y > y1 ? y1 : y),
                        Y1 = (y > y1 ? y : y1)
                    });
                db.SubmitChanges();
            }
        }
    }
}
