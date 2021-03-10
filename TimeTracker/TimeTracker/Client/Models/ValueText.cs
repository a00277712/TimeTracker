namespace TimeTracker.Client.Models
{
    public class ValueText
    {
        public ValueText(int value, string text)
        {
            Value = value;
            Text = text;
        }

        public int Value { get; set; }
        public string Text { get; set; }
    }
}
