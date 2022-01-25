namespace Week7.WPF.Events.Pub_Sub
{
    public class Notification
    {
        public string NotificationMessage { get; set; }

        public DateTime NotificationDate { get; set; }

        public Notification(DateTime date, string message)
        {
            NotificationMessage = message;
            NotificationDate = date;
        }

        public override string ToString()
        {
            return $"{NotificationMessage} - {NotificationDate}";
        }
    }
}