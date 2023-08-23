using Npgsql;

namespace Garage.Models
{
public class Employe
{

    public Employe(int id, string nom , string adresse , string numero , string posteActuel,decimal salaire,string cv) {
        Idemploye=id;
        Nom=nom;
        Adresse=adresse;
        Numero=numero;
        PosteActuel=posteActuel;
        SalaireTJM=salaire;
        CV=cv;
    }

    public Employe( string nom , string adresse , string numero , string posteActuel,decimal salaire,string cv) {
        Nom=nom;
        Adresse=adresse;
        Numero=numero;
        PosteActuel=posteActuel;
        SalaireTJM=salaire;
        CV=cv;
    }

    private int _idemploye ;
    public int Idemploye {get => _idemploye;
        set{
            if (value >= 1) _idemploye =value;else throw new ArgumentException("Invalid Idemploye value"); 
        }
    } 
    public string Nom {get; set; } 
    public string Adresse {get; set; } 
    public string Numero {get; set; } 
    public string PosteActuel {get; set; } 
    
    private decimal _salaireTJM ;
    public decimal SalaireTJM  {get => _salaireTJM; 
        set{
            if (value >= 1) _salaireTJM =value;else throw new ArgumentException("Invalid salaireTJM value"); 
        } 
    }
    public string CV {get; set; } 
    public List <Experience>? Experience {get; set; }
    public List <Diplome>? Diplomes {get; set; } 
    
    public void InsertEmploye(ConnectionBase connection)
    {
        string query = "INSERT INTO employe(nom,adresse,numero,posteActuel,salaireTJM,CV) VALUES(@nom,@adresse,@numero,@posteActuel,@salaireTJM,@CV)";
            using NpgsqlConnection con = connection.giveConnection();
            NpgsqlCommand command = new(query, con);
            command.Parameters.AddWithValue("@nom", Nom);
            command.Parameters.AddWithValue("@adresse", Adresse);
            command.Parameters.AddWithValue("@numero", Numero);
            command.Parameters.AddWithValue("@posteActuel", PosteActuel);
            command.Parameters.AddWithValue("@salaireTJM", SalaireTJM);
            command.Parameters.AddWithValue("@CV", CV);
            command.ExecuteNonQuery();
            con.Close();
    }

    public void FullInsertEmploye(ConnectionBase connection){
        
    }

}    

}


