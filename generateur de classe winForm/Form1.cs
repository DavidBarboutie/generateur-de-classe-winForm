using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Channels;
using System.Xml.Linq;
using MySql.Data.MySqlClient;
using System.IO;

namespace generateur_de_classe_winForm
{
    public partial class Form1 : Form
    {
        bool php = false;
        bool c_Sharp = false;
        bool CRUD = false;
        string path = "";

        //liste des attributs a mettre dans la classe qui se genere
        List<string> attribut = new List<string>();
        List<string> types = new List<string>();

        //nombre d'attribut a ajouter a la classe
        int index_attribut = 0;

        //chaine de caractere
        string? Chaine;

        public Form1()
        {
            InitializeComponent();
            generateType();
            hideAttrib();

        }

        //ajouter les element aux comboBoxs
        private void generateType()
        {
            CB_type.Items.Add("int");
            CB_type.Items.Add("float");
            CB_type.Items.Add("bool");
            CB_type.Items.Add("string");
            CB_type.Items.Add("Char");
            CB_CRUD.Items.Add("oui");
            CB_CRUD.Items.Add("non");
        }

        //cacher les elements au chargement de la page
        private void hideAttrib()
        {
            //attribut
            CB_type.Hide();
            TB_NameAttrib.Hide();
            B_ajoutAttrib.Hide();

            //choix si crud
            L_CRUD.Hide();
            CB_CRUD.Hide();
            B_validation.Hide();

            //informatio, pour la connexion a la BDD
            L_user.Hide();
            L_mdp.Hide();
            L_database.Hide();
            TB_user.Hide();
            TB_pass.Hide();
            TB_Database.Hide();

            //bouton final
            B_creation.Hide();
        }

        //afficher les elements lier aux attributs
        private void showAttrib()
        {
            CB_type.Show();
            TB_NameAttrib.Show();
            B_ajoutAttrib.Show();
        }

        //converti les espaces en "_"
        private string Conversion(string element)
        {
            string element_converti = "";
            for (int i = 0; i < element.Length; i++)
            {
                if (element[i].ToString() == " ")
                {
                    element_converti += "_";
                }
                else
                {
                    element_converti += element[i];
                }
            }
            return element_converti;
        }

        //generation de classe
        private void affichage()
        {
            TB_name.Enabled = false;
            if (TB_name.Text != "")
            {
                show_crud();
                LV_attrib.Items.Add("Name : " + TB_name.Text);
            }
        }
        //generation de classe en PHP
        private void B_php_Click(object sender, EventArgs e)
        {
            php = true;
            B_php.Enabled = false;
            B_cSharp.Enabled = false;
            affichage();
        }

        //generation de classe en C#    
        private void B_cSharp_Click(object sender, EventArgs e)
        {
            c_Sharp = true;
            B_cSharp.Enabled = false;
            B_php.Enabled = false;
            affichage();
        }

        //tester l'entree utilisateur
        private bool est_present(List<string> list, string var)
        {
            for (int i = 0; i < list.Count; i++)
            {
               
                if (list[i].ToString() == var)
                {
                    return true;
                }
            }
            return false;
        }
        private void show_database()
        {
            L_user.Show();
            L_mdp.Show();
            L_database.Show();
            TB_user.Show();
            TB_pass.Show();
            TB_Database.Show();
        }
        private void show_crud()
        {
            L_CRUD.Show();
            CB_CRUD.Show();
            B_validation.Show();
        }
        private void B_validation_Click(object sender, EventArgs e)
        {
            //verifie si la classe generer comportera des CRUD
            if (CB_CRUD.Text == "oui") { CRUD = true; }

            if (CRUD)
            {
                show_database();
                showAttrib();
            }
            else
            {
                showAttrib();
            }
        }
        private void attrib_client()
        {
            if (est_present(attribut, Conversion(TB_NameAttrib.Text)) == false)
            {
                //affiche les elements dans une listeview
                LV_attrib.Items.Add(CB_type.Text + " " + Conversion(TB_NameAttrib.Text));

                //ajoute l'attribut a l'array
                attribut.Add(Conversion(TB_NameAttrib.Text));

                //clear la textbox de nom d'attribut
                TB_NameAttrib.Clear();

                //ajout du type de l'attribut a l'array types
                types.Add(CB_type.Text);

                index_attribut += 1;

                //permettre de creer la class si au minimum un attribut a ete ajouter
                B_creation.Show();

                //lock lentree utilisateur concernant la BDD
                TB_Database.Enabled = false;
                TB_user.Enabled = false;
                TB_pass.Enabled = false;
            }
            else
            {
                MessageBox.Show("la variable '" + TB_NameAttrib.Text + "' existe déjà");
                TB_NameAttrib.Clear();
            }
        }
        //liste les attributs
        private void B_ajoutAttrib_Click(object sender, EventArgs e)
        {
            //demande les information pour la connexion a la BDD
            if (CRUD)
            {
                //verifie que tout les champs sont completer
                if (TB_NameAttrib.Text != "" && CB_type.Text != "" && CB_CRUD.Text != "" && TB_Database.Text != "" && TB_user.Text != "")
                {
                    attrib_client();
                }
            }
            else
            {
                //verifie que tout les champs sont completer
                if (TB_NameAttrib.Text != "" && CB_type.Text != "" && CB_CRUD.Text != "")
                {
                    attrib_client();
                }
            }          
        }

        private void diff_id(StreamWriter sw, string attrib, string chaine)
        {
            if (attrib != "id")
            {
                sw.Write(chaine);
            }
        }

        private void virgule(StreamWriter sw, int i)
        {
            if (i != index_attribut - 1)
            {
                sw.Write(", ");
            }
        }


        //genere les getters php avec l'attribut
        private void GetterPhp(StreamWriter sw, string attrib)
        {
            sw.WriteLine("\tpublic function get_" + attrib + "()\n\t{\n\t\treturn $this -> " + attrib + ";\n\t}\n");
        }

        //genere les setters php avec l'attribut
        private void SetterPhp(StreamWriter sw, string attrib)
        {
            sw.WriteLine("\tpublic function set_" + attrib + "($" + attrib + "2)\n\t{\n\t\t$this -> " + attrib + " = $" + attrib + "2;\n\t}\n");
        }

        private void PHP()
        {
            StreamWriter swPHP = new StreamWriter(path + "\\classe " + TB_name.Text + " PHP.php");

            //debut de fichier
            swPHP.WriteLine("<?PHP");
            swPHP.WriteLine("class " + Conversion(TB_name.Text) + "\n{");

            //attributs
            for (int i = 0; i < index_attribut; i++)
            {
                swPHP.WriteLine("\tprivate $" + attribut[i] + ";");
            }

            //constructeur
            swPHP.Write("\n\tfunction __construct(");
            for (int i = 0; i < index_attribut; i++)
            {
                swPHP.Write("$" + attribut[i] + "2");
                virgule(swPHP, i);
            }
            swPHP.Write(")\n\t{\n");

            for (int i = 0; i < index_attribut; i++)
            {
                swPHP.WriteLine("\t\t$this -> " + attribut[i] + " = $" + attribut[i] + "2;");
            }
            swPHP.WriteLine("\t}\n");

            //getters
            for (int i = 0; i < index_attribut; i++)
            {
                GetterPhp(swPHP, attribut[i]);
            }

            //setters
            for (int i = 0; i < index_attribut; i++)
            {
                SetterPhp(swPHP, attribut[i]);
            }

            if (CRUD)
            {
                //CRUD
                //CREATE
                //requete sql
                swPHP.Write("\tpublic function CREATE()\n\t{\n\t\t//requete sql\n\t\t$database = new PDO('mysql:host=localhost;dbname=" + TB_Database.Text + "','"+TB_user.Text+"','"+TB_pass.Text+"');\n\t\t$req = 'INSERT INTO " + Conversion(TB_name.Text) + "(");

                for (int i = 0; i < index_attribut; i++)
                {
                    diff_id(swPHP, attribut[i], Conversion(attribut[i]));
                    virgule(swPHP, i);
                }

                swPHP.Write(") VALUES (");

                //placeholders
                for (int i = 0; i < index_attribut; i++)
                {
                    diff_id(swPHP, attribut[i], ":" + Conversion(attribut[i]));
                    virgule(swPHP, i);
                }

                swPHP.Write(")';\n\t\t$statement = $database->prepare($req);\n\n\t\t//recuperation des données\n");

                //recuparation des donnees
                for (int i = 0; i < index_attribut; i++)
                {
                    diff_id(swPHP, attribut[i], "");

                }

                for (int i = 0; i < index_attribut; i++)
                {
                    Chaine = "\t\t$" + Conversion(attribut[i]) + "1 = $this->get_" + Conversion(attribut[i]) + "();\n";
                    diff_id(swPHP, attribut[i], Chaine);
                }
                swPHP.WriteLine("\n\t\t//remplacement des placeholders");

                //remplacement des placeholders
                for (int i = 0; i < index_attribut; i++)
                {
                    Chaine = "\t\t$statement->bindparam(':" + Conversion(attribut[i]) + "', " + Conversion(attribut[i]) + "1);\n";
                    diff_id(swPHP, attribut[i], Chaine);
                }
                swPHP.Write("\n\t\t//execution\n\t\t$statement->execute();");


                //RETRIEVE
                swPHP.Write("\n\n\tpublic function RETRIEVE($id2)\n\t{\n\t\t$database = new PDO('mysql:host=localhost;dbname=" + TB_Database.Text + "','"+TB_user.Text+"','"+TB_pass.Text+"');\n\t\t$req = 'select * from " + Conversion(TB_name.Text) + " where id = :id';\n\t\t$statement = $database->prepare($req);\n\t\t$statement->bindparam(':id',$id2);\n\t\t$statement->execute();\n\t\t$res = $statement->fetch(PDO::FETCH_ASSOC);");
                for (int i = 0; i < index_attribut; i++) { swPHP.Write("\n\t\t$this -> " + Conversion(attribut[i]) + " = $res['" + Conversion(attribut[i]) + "'];"); }
                swPHP.Write("\n\t}");


                //UPDATE
                //requete sql
                swPHP.Write("\n\n\tpublic function UPDATE()\n\t{\n\t\t//requete sql\n\t\t$database = new PDO('mysql:host=localhost;dbname=" + TB_Database.Text + "','"+TB_user.Text+"','"+TB_pass.Text+"');\n\t\t$req = 'UPDATE " + Conversion(TB_name.Text) + " set ");
                for (int i = 0; i < index_attribut; i++)
                {
                    diff_id(swPHP, attribut[i], Conversion(attribut[i]) + " = :" + Conversion(attribut[i]));
                    virgule(swPHP, i);
                }

                //recuperation des donnees
                swPHP.Write(" where id = :id';\n\t\t$statement = $database->prepare($req);\n\n\t\t//recuperation des donnees");
                for (int i = 0; i < index_attribut; i++)
                {
                    swPHP.Write("\n\t\t$" + Conversion(attribut[i] + "1 = $this->get_" + Conversion(attribut[i]) + "();"));
                }

                //remplacement des placeholders
                swPHP.Write("\n\n\t\t//rempalcement des placeholders");
                for (int i = 0; i < index_attribut; i++)
                {
                    swPHP.Write("\n\t\t$statement->bindparam(':" + Conversion(attribut[i]) + "', $" + Conversion(attribut[i]) + "1);");
                }

                //execution
                swPHP.Write("\n\n\t\t//execution\n\t\t$statement -> execute();");


                //DELETE
                swPHP.Write("\n\n\tpublic function DELETE_USER()\n\t{\n\t\t//requete sql\n\t\t$database = new PDO('mysql:host=localhost;dbname=" + TB_Database.Text + "','"+TB_user.Text+"','"+TB_pass.Text+"');" +
                    "\n\t\t$req = 'DELETE FROM " + Conversion(TB_name.Text) + " WHERE \"id\" = :id';\n\t\t$statement = $database->prepare($req);\n\t\t$statement->bindparam(':id',$this->get_id();" +
                    "\n\t\t$statement->execute();\n\t}");
            }


            //fin de fichier
            swPHP.WriteLine("\n\n}\n?>");
            swPHP.Close();
        }

        //getters/setters charp
        private void GetterCSharp(StreamWriter sw, string attrib, string type)
        {
            sw.Write("\n\tpublic " + type + " get_" + Conversion(attrib) + "(){return this." + attrib + ";}");
        }
        private void SetterCSharp(StreamWriter sw, string attrib, string type)
        {
            sw.Write("\n\tpublic void set_" + Conversion(attrib) + "(" + type + " " + Conversion(attrib) + "0){this." + attrib + " = " + Conversion(attrib) + "0;}");
        }

        //CRUD CSharp
        //Create
        private void CREATE_CSharp(StreamWriter swCSharp)
        {
            swCSharp.Write("\n\n\tpublic void CREATE(){\n\t\tusing (MySqlConnection conn = new MySqlConnection(BDD.connString))\n\t\t{\n\t\t\tconn.Open();\n\t\t\tstring req = \"INSERT INTO " + Conversion(TB_name.Text) + " VALUES (");
            for (int i = 0; i < index_attribut; i++)
            {
                swCSharp.Write("@" + Conversion(attribut[i]));
                if (i < index_attribut - 1)
                {
                    swCSharp.Write(", ");
                }
            }
            swCSharp.Write(")\";\n\t\t\tMySqlCommand cmd = new MySqlCommand(req, conn);");
            for (int i = 0; i < index_attribut; i++)
            {
                swCSharp.Write("\n\t\t\tcmd.Parameters.AddWithValue(\"@" + Conversion(attribut[i]) + "\", this.get_" + Conversion(attribut[i]) + "());");
            }
            swCSharp.Write("\n\t\t\tcmd.ExecuteNonQuery();\n\t\t}\n\t}");
        }

        //RETRIEVE
        private void RETRIEVE_CSharp(StreamWriter swCSharp)
        {
            swCSharp.Write("\n\n\tpublic void RETRIEVE(int id){\n\t\tusing (MySqlConnection conn = new MySqlConnection(BDD.connString))\n\t\t{\n\t\t\tconn.Open();\n\t\t\tstring req = \"SELECT * FROM " + Conversion(TB_name.Text) + " WHERE id = @id\";\n\t\t\tMySqlCommand cmd = new MySqlCommand(req, conn);\n\t\t\tcmd.Parameters.AddWithValue(\"@id\", id);\n\t\t\tMySqlDataReader reader = cmd.ExecuteReader();\n\t\t\tif(reader.Read()){\n");
            for (int i = 0; i < index_attribut; i++)
            {
                swCSharp.Write("\n\t\t\t\tthis.set_" + Conversion(attribut[i]) + "(reader.Get" + types[i] + "(\"" + Conversion(attribut[i]) + "\"));");
            }
            swCSharp.Write("\n\t\t\t}\n\t\t}\n\t}");
        }
        //UPDATE
        private void UPDATE_CSharp(StreamWriter swCSharp)
        {
            swCSharp.Write("\n\n\tpublic void UPDATE(int id){\n\t\tusing (MySqlConnection conn = new MySqlConnection(BDD.connString))\n\t\t{\n\t\t\tconn.Open();\n\t\t\tstring req = \"UPDATE " + Conversion(TB_name.Text) + " SET ");
            for (int i = 0; i < index_attribut; i++)
            {
                swCSharp.Write(Conversion(attribut[i]) + " = @" + Conversion(attribut[i]));
                if (i < index_attribut - 1)
                {
                    swCSharp.Write(", ");
                }
            }
            swCSharp.Write(" WHERE id = @id\";\n\t\t\tMySqlCommand cmd = new MySqlCommand(req, conn);\n");
            for (int i = 0; i < index_attribut; i++)
            {
                swCSharp.Write("\n\t\t\tcmd.Parameters.AddWithValue(\"@" + Conversion(attribut[i]) + "\", this.get_" + Conversion(attribut[i]) + "());");
            }
            swCSharp.Write("\n\t\t\tcmd.Parameters.AddWithValue(\"@id\", id);\n\t\t\tcmd.ExecuteNonQuery();\n\t\t}\n\t}");
        }
        //DELETE
        private void DELETE_CSharp(StreamWriter swCSharp)
        {
            swCSharp.Write("\n\n\tpublic void DELETE(int id){\n\t\tusing (MySqlConnection conn = new MySqlConnection(BDD.connString))\n\t\t{\n\t\t\tconn.Open();\n\t\t\tstring req = \"DELETE FROM " + Conversion(TB_name.Text) + " WHERE id = @id\";\n\t\t\tMySqlCommand cmd = new MySqlCommand(req, conn);\n\t\t\tcmd.Parameters.AddWithValue(\"@id\", id);\n\t\t\tcmd.ExecuteNonQuery();\n\t\t}\n\t}");

        }
        //FINDALL
        private void FINDALL_CSharp(StreamWriter swCSharp)
        {
            swCSharp.Write("\n\n\tpublic List<" + Conversion(TB_name.Text) + "> findAll(){\n\t\tList<" + Conversion(TB_name.Text) + "> list = new List<" + Conversion(TB_name.Text) + ">();\n\t\tusing (MySqlConnection conn = new MySqlConnection(BDD.connString))\n\t\t{\n\t\t\tconn.Open();\n\t\t\tstring req = \"SELECT * FROM " + Conversion(TB_name.Text) + "\";\n\t\t\tMySqlCommand cmd = new MySqlCommand(req, conn);\n\t\t\tMySqlDataReader reader = cmd.ExecuteReader();\n\t\t\twhile(reader.Read()){\n\t\t\t\tlist.Add(new " + Conversion(TB_name.Text) + "(");
            for (int i = 0; i < index_attribut; i++)
            {
                swCSharp.Write("reader.Get" + types[i] + "(\"" + Conversion(attribut[i]) + "\")");
                if (i < index_attribut - 1)
                {
                    swCSharp.Write(", ");
                }
            }
            swCSharp.Write("));\n\t\t\t}\n\t\t}\n\t\treturn list;\n\t}");
        }

        private void BDD_conn(StreamWriter swCSharp)
        {
            // Fonction de connexion à la BDD
            swCSharp.Write("\n\n\tinternal class BDD\n\t{\n\t\t" +
                "// Connexion à la base de données infrarad\n\t\t" +
                "private static string chaineConnexion = \"Server=localhost;uid="+TB_user.Text.ToString()+";pwd="+TB_pass.Text.ToString()+";Database="+TB_Database.Text.ToString()+"\";\n\t\t" +
                "public static MySqlConnection maconnexion = new MySqlConnection(chaineConnexion);\n\t}\n");
        }

        private void cSharp()
        {
            StreamWriter swCSharp = new StreamWriter(path + "\\classe " + TB_name.Text + " cSharp.cs");
            //utiliser mysql.Data si necessaire
            if (CRUD) { swCSharp.WriteLine("using MySql.Data.MySqlClient;"); }
            swCSharp.WriteLine("class " + Conversion(TB_name.Text) + "\n");
            swCSharp.Write("{");

            // Attributs
            for (int i = 0; i < index_attribut; i++)
            {
                swCSharp.Write("\n\tprivate " + types[i] + " " + Conversion(attribut[i]) + ";");
            }

            // Constructeurs
            swCSharp.Write("\n\n\tpublic " + Conversion(TB_name.Text) + "(){}\n\n\tpublic " + Conversion(TB_name.Text) + "(");
            for (int i = 0; i < index_attribut; i++)
            {
                swCSharp.Write(types[i] + " " + Conversion(attribut[i]) + "0");
                if (i != index_attribut - 1)
                {
                    swCSharp.Write(", ");
                }
            }
            swCSharp.Write(")\n\t{");
            for (int i = 0; i < index_attribut; i++)
            {
                swCSharp.Write("\n\t\tthis." + Conversion(attribut[i]) + " = " + Conversion(attribut[i]) + "0;");
            }
            swCSharp.Write("\n\t}\n");

            // Getters & Setters
            for (int i = 0; i < index_attribut; i++)
            {
                GetterCSharp(swCSharp, attribut[i], types[i]);
            }
            swCSharp.Write("\n");
            for (int i = 0; i < index_attribut; i++)
            {
                SetterCSharp(swCSharp, attribut[i], types[i]);
            }

            if (CRUD)
            {
                // CREATE
                CREATE_CSharp(swCSharp);

                // RETRIEVE
                RETRIEVE_CSharp(swCSharp);

                // UPDATE
                UPDATE_CSharp(swCSharp);

                // DELETE
                DELETE_CSharp(swCSharp);

                // findAll
                FINDALL_CSharp(swCSharp);

                BDD_conn(swCSharp);
                
            }

            // Fermeture classe
            swCSharp.WriteLine("\n\n}");

            swCSharp.Close();

        }


        private void B_creation_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                //choisir l'emplacement du fichier generer
                folderDialog.Description = "Sélectionnez un dossier";
                folderDialog.ShowNewFolderButton = true;

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    //creer un dossier pour les classes generer
                    path = folderDialog.SelectedPath;
                    Directory.CreateDirectory(path+"\\Classes generer");
                    path += "\\Classes generer";


                }
            }
            if (php)
            {
                PHP();
            }
            else
            {
                if (c_Sharp)
                {
                    cSharp();
                }
            }
            Application.Exit();
        }

        
    }
}
