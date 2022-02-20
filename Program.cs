using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;

namespace IlyaStatusSite
{
    class Program
    {

        /// <summary>
        /// Точка входа
        /// </summary>
        /// <param name="args">Для адреса сайт ввести например https://google.com (name.exe https://google.com)</param>
        static  int Main(string[] args)
        {
            string site = "https://google.com";
       
            if (args.Length > 0)
            {
                 site = args[0];

            }

            StatusService service = new StatusService();
            service.Request(site);


            if(service.GetStatus()==200)
            {
                return 1;
            } else
            {
                return 0;
            }

       


        }
    }
}
