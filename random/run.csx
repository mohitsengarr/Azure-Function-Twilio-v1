using System.Net;
using System;
using Twilio.TwiML;
using Twilio.TwiML.Voice;
using System.Text;

public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, TraceWriter log)
{
    
    log.Info("C# HTTP trigger function processed a request.");

    var response = new VoiceResponse();
    var dial = new Dial(callerId: "+12153726702");
    dial.Number("+12153726702");
    response.Append(dial);
    var twiml = response.ToString();
    twiml = twiml.Replace("utf-16", "utf-8");
 
    return new HttpResponseMessage
    {
        Content = new StringContent(twiml, Encoding.UTF8, "application/xml")
    };
}
