namespace Domain.Entities
{
    public class SolarSytem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public bool IsValid() => Name != null;
    }
}
