using health_check_bot;

var message = new SlackMessage
{
    Level = SeverityLevel.Critical,
    Message = "Tes213123t",
    ErrorReportedTime = DateTime.Now
};
var send = new Send();
await send.SendMessage(message);