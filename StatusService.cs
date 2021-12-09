using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Reflection;

namespace IlyaStatusSite
{
  public class StatusService
    {
        private int _statusCode;

    
        public int GetStatus()
        {
            return _statusCode;
        }

        public async Task RequestAsync(string href)
        {
           
            if (href != null)
            {
                HttpWebResponse response = null;
                try
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(href);
                    response = (HttpWebResponse)await request.GetResponseAsync();
                }
                catch (WebException)
                {
                    response = null;
                }

                finally
                {
                    if (response != null)
                    {
                        _statusCode = (int)response.StatusCode;
                    }


                }
            }
  
        }

    }
}
