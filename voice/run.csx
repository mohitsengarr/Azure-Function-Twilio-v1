using System.Net;
using System;
using Twilio.TwiML;
using System.Text;

public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, TraceWriter log)
{
    
    log.Info("C# HTTP trigger function processed a request.");

    var response = new VoiceResponse();
    response.Say("Hello World");
    var twiml = response.ToString();
    twiml = twiml.Replace("utf-16", "utf-8");
 
    return new HttpResponseMessage
    {
        Content = new StringContent(twiml, Encoding.UTF8, "application/xml")
    };;
}
