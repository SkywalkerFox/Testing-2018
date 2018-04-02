namespace Testing_2018
{
    public class Note
    {
        private string text;
        private string settings;

        public Note(string text)
        {
            this.text = text;
        }

        public Note(string text, string settings)
        {
            this.text = text;
            this.settings = settings;
        }

        public string GetText()
        {
            return this.text;
        }

        public void SetText(string text)
        {
            this.text = text;
        }

        public string GetSettings()
        {
            return this.settings;
        }

        public void SetSettings(string settings)
        {
            this.settings = settings;
        }
    }
}