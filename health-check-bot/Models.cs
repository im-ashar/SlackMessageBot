using SlackNet;
using SlackNet.WebApi;

namespace health_check_bot
{
    public class SlackMessage
    {
        public SeverityLevel Level { get; set; }
        public string Message { get; set; }
        public DateTime ErrorReportedTime { get; set; }
    }
    public enum SeverityLevel
    {
        Info,
        Warning,
        Danger,
        Critical
    }
    public class Send
    {
        public async Task SendMessage(SlackMessage slackMessage)
        {
            var slackClient = new SlackApiClient(SlackConfig.SlackAccessToken);
            var sendMessage = new Message
            {
                Text = "*Severity* : " + slackMessage.Level + "\n" + "*Message* : " + slackMessage.Message + "\n" + "*Error Reported On* : " + slackMessage.ErrorReportedTime,
                Channel = SlackConfig.ChannelName
            };
            await slackClient.Chat.PostMessage(sendMessage);
        }
    }
    public class SlackConfig
    {
        public static string SlackAccessToken { get; } = "xoxb-4117886868225-5854761771878-KXoaxF3l02EurQsg2aHwLxIN";
        public static string ChannelName { get; } = "testing-bot-channel";
    }
}
