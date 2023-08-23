using Npgsql;

namespace Garage.Models
{
    public class Experience
    {
    
        public Experience(int id, string precedent , int duree , string societe){
            this.Idexperience = id;
            this.PostePrecedent= precedent;
            this.Duree = duree;
            this.Societe = societe;
        }

        public Experience(int idexp,int idemp, string precedent , int duree , string societe){
            this.Idexperience = idexp;
            this.IdEmploye = idemp;
            this.PostePrecedent= precedent;
            this.Duree = duree;
            this.Societe = societe;
        }

        private int _idexperience;
        public int  Idexperience { get => _idexperience; 
            set{
                if (value>=0) _idexperience = value;else throw new ArgumentException("Invalid Idexperience value"); 
            }
        }
        
        private int _idEmploye;
        public int IdEmploye { get => _idEmploye; 
            set { 
                if(value >=1 ) _idEmploye = value;else throw new ArgumentException("Invalid IdEmploye value");
            }
        }
        public string PostePrecedent { get; set;} 
        
        private int _duree;
        public int Duree { get => _duree; 
            set{
                if (value>=0) _duree = value;else throw new ArgumentException("Invalid duree value"); 
            }
        }
        public string Societe { get; set; }

        public void InsertExperience(ConnectionBase connection){
            string query = "INSERT INTO Experience (Idemploye,PostePrecedent, Duree, Societe) VALUES (@IdEmploye,@PostePrecedent, @Duree, @Societe)";
            NpgsqlConnection con= connection.giveConnection();
            using NpgsqlCommand command = new (query, con);
            command.Parameters.AddWithValue("@IdEmploye",this.IdEmploye);
            command.Parameters.AddWithValue("@PostePrecedent", this.PostePrecedent);
            command.Parameters.AddWithValue("@Duree", this.Duree);
            command.Parameters.AddWithValue("@Societe", this.Societe);
            command.ExecuteNonQuery();
            con.Close();
        } 
    }
}