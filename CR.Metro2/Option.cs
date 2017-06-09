namespace CR.Metro2 {
    public class Option {
        public Option() {}

        public Option(string k, string t) {
            Key = k;
            Text = t;
        }

        public string Key { get; set; }

        public string Text { get; set; }
    }
}
