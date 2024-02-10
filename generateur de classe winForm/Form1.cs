using System.Collections.Generic;
using System.Diagnostics;

namespace generateur_de_classe_winForm
{
    public partial class Form1 : Form
    {
        bool php = false;
        bool c_Sharp = false;


        //liste des attributs a mettre dans la classe qui se genere
        List<string> attribut = new List<string>();

        //nombre d'attribut a ajouter a la classe
        int index_attribut = 0;

        public Form1()
        {
            InitializeComponent();
            generateType();
            hideAttrib();
        }

        //ajouter les element a la comboBox
        private void generateType()
        {
            CB_type.Items.Add("int");
            CB_type.Items.Add("bool");
            CB_type.Items.Add("string");
            CB_type.Items.Add("Char");
        }

        //cacher les elements lier aux attributs au chargement de la page
        private void hideAttrib()
        {
            CB_type.Hide();
            TB_NameAttrib.Hide();
            B_ajoutAttrib.Hide();
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

        //generation de classe en PHP
        private void B_php_Click(object sender, EventArgs e)
        {
            php = true;
            TB_name.Enabled = false;
            if (TB_name.Text != "")
            {
                showAttrib();
                LV_attrib.Items.Add("Name : " + TB_name.Text);
            }

        }

        //generation de classe en C#    
        private void B_cSharp_Click(object sender, EventArgs e)
        {
            c_Sharp = true;
            TB_name.Enabled = false;
            if (TB_name.Text != "")
            {
                showAttrib();
                LV_attrib.Items.Add("Name : " + TB_name.Text);
            }
        }

        //liste les attributs
        private void B_ajoutAttrib_Click(object sender, EventArgs e)
        {
            string type = CB_type.Text;
            string VarName = TB_NameAttrib.Text;
            string element = type + " " + VarName;

            

            if (VarName != "" && type != "")
            {
                //affiche les elements dans une listeview
                LV_attrib.Items.Add(element);

                //clear la textbox de nom d'attribut
                TB_NameAttrib.Clear();

                //ajoute l'attribut a l'array
                attribut.Add(Conversion(VarName));
                index_attribut += 1;

                //permettre de creer la class si au minimum un attribut a ete ajouter
                B_creation.Show();
            }

        }

        //genere les getters php avec l'attribut
        private void GetterPhp(StreamWriter sw, string attrib)
        {
            sw.WriteLine("\tpublic function get_"+attrib+"()\n\t{\n\t\treturn $this -> "+attrib+";\n\t}\n");
        }

        //genere les setters php avec l'attribut
        private void SetterPhp(StreamWriter sw, string attrib)
        {
            sw.WriteLine("\tpublic function set_" + attrib + "($"+attrib.ToUpper()+")\n\t{\n\t\t$this -> " + attrib + " = $"+attrib.ToUpper()+";\n\t}\n");
        }

        private void PHP()
        {
            StreamWriter sw = new StreamWriter("E:\\backup clé david\\classe generer\\phase de test\\classe " + TB_name.Text+" PHP.php");

            //debut de fichier
            sw.WriteLine("<?PHP");
            sw.WriteLine("$database = new PDO('mysql:host=localhost;dbname=NOM_DATABASE','user','caribou');\n");
            sw.WriteLine("class " + Conversion(TB_name.Text)+ "\n{");
            
            //attributs
            for (int i = 0; i < index_attribut; i++)
            {
                sw.WriteLine("\tprivate $" + attribut[i] + ";");
            }

            //constructeur
            sw.Write("\n\tfunction __construct(");
            for(int i = 0;i < index_attribut; i++) {
                sw.Write("$" + attribut[i].ToUpper());
                if (i != index_attribut - 1)
                {
                    sw.Write(", ");
                }
            }
            sw.Write(")\n\t{\n");

            for (int i = 0; i < index_attribut; i++)
            {
                sw.WriteLine("\t\t$this -> " + attribut[i] + " = $" + attribut[i].ToUpper()+";");
            }
            sw.WriteLine("\t}\n");
            //getters
            for (int i = 0; i < index_attribut ; i++)
            {
                GetterPhp(sw,attribut[i]);
            }

            //setters
            for (int i = 0; i < index_attribut; i++)
            {
                SetterPhp(sw, attribut[i]);
            }


            //CRUD

            //fin de fichier
            sw.WriteLine("}\n?>");
            sw.Close();
        }

        private void cSharp()
        {
            StreamWriter sw = new StreamWriter("E:\\backup clé david\\classe generer\\phase de test\\classe " + TB_name.Text + " cSharp.txt");
            
            sw.WriteLine("class "+TB_name.Text+"\n");
            sw.WriteLine("$database = new PDO(mysql:host=localhost;dbname=NOM_DATABASE,'user','caribou');\n\n");
            sw.WriteLine("{}\n");
            sw.WriteLine("\n");
            sw.Close();
        }

        private void B_creation_Click(object sender, EventArgs e)
        {
            if (php)
            {
                PHP();
            }
            else { 
                if(c_Sharp)
                {
                    cSharp();
                } 
            }
        }
    }
}
