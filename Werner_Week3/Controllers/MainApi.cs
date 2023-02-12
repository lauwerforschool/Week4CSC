using Microsoft.AspNetCore.Mvc;


namespace Werner_Week3.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MainApi : ControllerBase
    {
        [HttpPost(Name = "PostWeatherForecast")]
        public ActionResult<List<string>> intListWork(List<int> plist)
        {
            try
            {

                int counter = 0;
              
                double deviation = 0;

                List<int> clist = new List<int>();

                List<string> slist = new List<string>();

                plist.Sort();

                int length = plist.Count();

                if(length > 1 ) {
                    foreach (int i in plist)
                    {

                        counter++;


                        clist.Add(i);

                        double cLength = clist.Count();


                        double mean = clist.Average();
                        double sum = clist.Sum();
                        double square = ((sum - mean) * (sum - mean));
                        deviation = Math.Sqrt(square / cLength);
                        slist.Add("Elements: " + counter.ToString() + " Current Standard Deviation: " + deviation.ToString());

                    }


                    return Accepted(slist);
                }
                else
                {

                    List<string> shortList = new List<string>
                    {
                        "Error, Array to short"
                    };
                    return shortList;
                
                }


            }
            catch
            {
                List<string> errorList = new List<string> 
                {
                "An Error Has Occured"
                };
                return errorList;
            }
        }
    }
}