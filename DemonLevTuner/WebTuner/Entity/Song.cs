namespace WebTuner.Entity
{
    public class Song
    {
        public string Author { get; set; } = string.Empty;
        public string SongName { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public int Id { get; set; }
        public int Bpm { get; set; }

    }
}
