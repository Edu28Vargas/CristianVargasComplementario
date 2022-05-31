using SQLite;


namespace CristianVargasComplementario.Models
{
    public class ESTUDIANTES_LOGIN
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
       
        public int Usuario { get; set; }

        [MaxLength(225)]
        public string Contrasena { get; set; }
       

    }
}
