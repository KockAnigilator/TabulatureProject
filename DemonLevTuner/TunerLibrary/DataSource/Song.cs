namespace TunerLibrary
{
    public class Song
    {
        private string author;
        private string songName;
        private string genre;
        private int id;
        private int bpm;

        public Song(int id, string songName, string genre, string author, int bpm)
        {
            this.author = author;
            this.songName = songName;
            this.genre = genre;
            this.id = id;
            this.BPM = bpm;
        }

        public string Author { get => author; set => author = value; }
        public string SongName { get => songName; set => songName = value; }
        public string Genre { get => genre; set => genre = value; }
        public int Id { get => id; set => id = value; }
        public int BPM { get => bpm; set => bpm = value; }

        public override string ToString()
        {
            return Author +" " + SongName;
        }
    }


}