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

    /// <summary>
    /// Получить статус после запроса
    /// </summary>
    /// <returns></returns>
        public int GetStatus()
        {
            return _statusCode;
        }


        /// <summary>
        /// Cинхронный запрос доступности ресурса
        /// </summary>
        /// <param name="href">Адрес сайта</param>
        /// <returns></returns>
        public void Request(string href)
        {

            if (href != null)
            {
                HttpWebResponse response = null;
                try
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(href);
                    response = (HttpWebResponse)request.GetResponse();
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


        /// <summary>
        /// Асинхронный запрос доступности ресурса
        /// </summary>
        /// <param name="href">Адрес сайта</param>
        /// <returns></returns>
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
