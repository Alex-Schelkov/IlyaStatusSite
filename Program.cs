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
        /// <param name="args">Для адреса сайт ввести например https://google.com , а далее через пробел букву -r для автозавершения (name.exe https://google.com -r)</param>
        static async Task Main(string[] args)
        {
            string site = "https://google.com";
            bool ready = true;
            if (args.Length > 0)
            {
                 site = args[0];

                if (args.Length > 1 && args[1]=="-r" )
                { 
                    ready = false;
                }

                   
            }

            StatusService service = new StatusService();
            await service.RequestAsync(site);

            if(service.GetStatus()==200)
            {
                Console.WriteLine("1");
            } else
            {
                Console.WriteLine("0");
            }

            if (ready)
            {
                Console.ReadKey();    
            }
                

        }
    }
}
