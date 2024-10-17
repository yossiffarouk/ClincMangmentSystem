namespace ClinicMangmentSystem.Entites
{
    public class Office
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;

        // 1 Doctor With 1 Office (1 to 1 [Optional RelationShip])
        public Doctor? Doctor { get; set; }
    }
}
