namespace DAL.Entities
{
    public sealed class FileInfo
    {
        public int Id { get; set; }
        public string Port { get; set; }
        public string FilePath { get; set; }
        public int StartIndex { get; set; }
        public int EndIndex { get; set; }
        public DateTime DateTime { get; set; }
    }
}
