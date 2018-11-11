using System.Net;
using System;
using Twilio.Jwt;
using Twilio.Jwt.Client;
using System.Text;
using System.Collections.Generic;

public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, TraceWriter log)
{
    const string accountSid = "AC975c33dd917924c0576f20cc6411781c";
    const string authToken = "38560b2c60dac5d1b64952848d60f0a3";

    // Put your Twilio Application SID here
    const string appSid = "AP8a8e104c52262db9355872e098612b55";

    var scopes = new HashSet<IScope>
    {
        new OutgoingClientScope(appSid)
    };
    var capability = new ClientCapability(accountSid, authToken, scopes: scopes);

    return new HttpResponseMessage
    {
        Content = new StringContent(capability.ToJwt(), Encoding.UTF8, "application/jwt")
    };
}
