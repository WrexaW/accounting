namespace accounting.entities
{
    public class UserPackageEntity
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public UserEntity User { get; set; }

        public int PackageId { get; set; }

        public PackageEntity Package { get; set; }

        public long Price { get; set; }

        public int Duration { get; set; }

        public DateTime CrateDate { get; set; }

        public string TransactionId { get; set; }
    }
}
