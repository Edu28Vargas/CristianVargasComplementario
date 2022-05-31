using SQLite;


namespace CristianVargasComplementario.Models
{
    public class Estudiante
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(225)]
        public string Nombre { get; set; }
        [MaxLength(225)]
        public string Apellido { get; set; }
        [MaxLength(225)]
        public string Curso { get; set; }
        [MaxLength(225)]
        public string Paralelo { get; set; }

        public decimal Nota { get; set; }
    }
}
