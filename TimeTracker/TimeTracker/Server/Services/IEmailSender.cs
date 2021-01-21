namespace TimeTracker.Server.Services
{
    public interface IEmailSender
    {
        void SendEmail(Message message);
    }
}
