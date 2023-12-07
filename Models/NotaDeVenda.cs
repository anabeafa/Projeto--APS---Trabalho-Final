namespace ProjetoAna.Models
{
    public class NotaDeVenda
    {
        public DateTime Data{get; set;}

        public Boolean Tipo {get; set;}

        public bool Cancelar()
        {        
            if (Tipo == true) 
            {
                return true; 
            }
            else
            {
                return false;
            }
        }

        public bool Devolver()
        {

            if (Data.Date < DateTime.Today) 
            {
                return true; 
            }
            else
            {
                return false; 
        }
        }
    }
}
        
