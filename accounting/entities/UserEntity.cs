namespace accounting.entities
{
    public class UserEntity
    {
        public int Id { get; set; }

        public string Fullname { get; set; }

        public string Mobile { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public DateTime? Expiredate { get; set; }

        public GenderType Gender { get; set; }


    }

    public enum GenderType
    {
        Male,
        Female
    }
}
