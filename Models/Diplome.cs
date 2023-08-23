using Npgsql;

namespace Garage.Models
{
    public class Diplome{
       
        public Diplome(int iddip,int idemp,string nom){
            this.IdDiplome = iddip;
            this.Idemploye = idemp;
            this.Nom = nom;
        }

        public Diplome(int idemp,string nom){
            this.Idemploye = idemp;
            this.Nom = nom;
        }

        private int _idemploye;
        public int Idemploye {get => _idemploye;
            set{
                if (value >= 1) _idemploye =value;else throw new ArgumentException("Invalid Idemploye value"); 
            }
        } 
       
        private int _idDiplome;
        public int IdDiplome { get => _idDiplome; 
            set { 
                if (value >=1 ) _idDiplome = value;else throw new ArgumentException("Invalid IdDiplome value"); 
            } 
        }

        public string Nom {get;set;}
    
        public void InsertDiplome(ConnectionBase connection){
            string query = "INSERT INTO diplome (idemploye, nom) VALUES (@idemploye, @nom)";
            NpgsqlConnection con=connection.giveConnection();
            using NpgsqlCommand command = new (query, con);
            command.Parameters.AddWithValue("@idemploye", this.Idemploye);
            command.Parameters.AddWithValue("@nom", this.Nom);
            command.ExecuteNonQuery();
            con.Close();
        }
    
    }
}