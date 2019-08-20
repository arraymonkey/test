using BlushMe.Model;
using MailKit.Net.Smtp;
using MimeKit;
namespace BlushMe.Services
{
    public class MailHandler
    {
        private Appointment _appointment;

        public MailHandler(Appointment appointment)
        {
            _appointment = appointment;
        }
    }
}