using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Server.Controllers
{
    public class SSEController : ApiController
    {
        //NOT IN USE

        //static Timer _timer = default(Timer);
        //static readonly ConcurrentQueue<StreamWriter> _connectedClients = new ConcurrentQueue<StreamWriter>();
        //static List<Color> _lstColors = new List<Color>() {
        //    new Color()
        //    {
        //        Code = "#FF0000",
        //        Name = "Red"
        //    },
        //    new Color()
        //    {
        //        Code = "#008000",
        //        Name = "Green"
        //    },
        //    new Color()
        //    {
        //        Code = "#FFFF00",
        //        Name = "Yellow"
        //    }
        //};


        //public SSEController()
        //{
        //    _timer = _timer ?? new Timer(OnTimerEvent, null, 0, 1000);
        //}

        //[HttpGet]
        //public HttpResponseMessage Color()
        //{
        //    HttpResponseMessage response = Request.CreateResponse();
        //    response.Content = new PushStreamContent((Action<Stream, HttpContent, TransportContext>)OnStreamAvailable, "text/event-stream");
        //    return response;

        //}

        //public static void OnStreamAvailable(Stream stream, HttpContent headers, TransportContext context)
        //{
        //    var clientStream = new StreamWriter(stream);
        //    _connectedClients.Enqueue(clientStream);
        //}


        //static void OnTimerEvent(object state)
        //{

        //    _timer.Change(Timeout.Infinite, Timeout.Infinite);
        //    try
        //    {
        //        foreach (var clientStream in _connectedClients)
        //        {
        //            try
        //            {
        //                Random rnd = new Random();
        //                int pos = rnd.Next(0, 3);

        //                clientStream.WriteLine("data:" + JsonConvert.SerializeObject(_lstColors[pos]) + "\n\n");
        //                clientStream.Flush();
        //            }
        //            catch (Exception ex)
        //            {
        //                //Log exception
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        //Log exception
        //    }

        //    finally
        //    {
        //        Random rnd = new Random();
        //        int newDueTime = rnd.Next(1, 11);
        //        _timer.Change(newDueTime * 1000, newDueTime * 1000);
        //    }
        //}
    }
}
