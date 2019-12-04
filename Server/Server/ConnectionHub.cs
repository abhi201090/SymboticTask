using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace Server
{
    public class ConnectionHub : Hub
    {
        static Timer _timer = default(Timer);

        static List<Color> _lstColors = new List<Color>() {
            new Color()
            {
                Code = "#FF0000",
                Name = "Red"
            },
            new Color()
            {
                Code = "#008000",
                Name = "Green"
            },
            new Color()
            {
                Code = "#FFFF00",
                Name = "Yellow"
            }
        };

        public override Task OnConnected()
        {
            _timer = _timer ?? new Timer(OnTimerEvent, null, 0, 1000);
            return base.OnConnected();
        }

        public static void Message(Color color)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<ConnectionHub>();
            context.Clients.All.message(color);
        }

        static void OnTimerEvent(object state)
        {

            _timer.Change(Timeout.Infinite, Timeout.Infinite);
            try
            {
                Random rnd = new Random();
                int pos = rnd.Next(0, 3);
                Message(_lstColors[pos]);
            }
            catch (Exception ex)
            {
                //Log exception
            }

            finally
            {
                Random rnd = new Random();
                int newDueTime = rnd.Next(1000, 11000);
                _timer.Change(newDueTime, newDueTime);
            }
        }
    }
}