namespace accounting.entities
{
    public class PackageEntity
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public long Price { get; set; }

        public int Order { get; set; }
        public DateTime CrateDate { get; set; }

        public int Duration { get; set; }

        public bool isDeactive { get; set; }
    }
}
