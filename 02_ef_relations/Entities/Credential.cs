namespace _02_ef_relations
{
    class Credential
    {
        public string Login { get; set; }
        public string Password { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
