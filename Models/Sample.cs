using SQLite;

namespace SqliteDBManager.Models
{
    internal class Sample
    {
        [NotNull]
        [PrimaryKey]
        public int Id { get; set; }

        [NotNull]
        public string Name { get; set; }

        public string Description { get; set; }

        public string VersionNum { get; set; }
    }
}
