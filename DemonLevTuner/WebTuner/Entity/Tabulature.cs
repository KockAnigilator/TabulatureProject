namespace WebTuner.Entity
{
    public class Tabulature
    {
        public int Id { get; set; }
        public int Fret { get; set; }
        public int SongId { get; set; }
        public int Position { get; set; }
        public int StringId { get; set; }
        public string StringName { get; set; }  = string.Empty;

    }
}
