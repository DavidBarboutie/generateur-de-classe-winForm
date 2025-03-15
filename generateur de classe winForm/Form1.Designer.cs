namespace generateur_de_classe_winForm
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            L_name = new Label();
            TB_name = new TextBox();
            B_php = new Button();
            B_cSharp = new Button();
            L_attributs = new Label();
            TB_NameAttrib = new TextBox();
            CB_type = new ComboBox();
            B_ajoutAttrib = new Button();
            LV_attrib = new ListView();
            B_creation = new Button();
            L_CRUD = new Label();
            CB_CRUD = new ComboBox();
            TB_user = new TextBox();
            TB_pass = new TextBox();
            TB_Database = new TextBox();
            L_user = new Label();
            L_mdp = new Label();
            L_database = new Label();
            B_validation = new Button();
            SuspendLayout();
            // 
            // L_name
            // 
            L_name.AutoSize = true;
            L_name.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            L_name.Location = new Point(63, 48);
            L_name.Name = "L_name";
            L_name.Size = new Size(153, 22);
            L_name.TabIndex = 0;
            L_name.Text = "nom de la classe";
            L_name.TextAlign = ContentAlignment.TopCenter;
            // 
            // TB_name
            // 
            TB_name.Location = new Point(82, 108);
            TB_name.Name = "TB_name";
            TB_name.Size = new Size(100, 23);
            TB_name.TabIndex = 1;
            // 
            // B_php
            // 
            B_php.Location = new Point(30, 166);
            B_php.Name = "B_php";
            B_php.Size = new Size(75, 23);
            B_php.TabIndex = 2;
            B_php.Text = "PHP";
            B_php.UseVisualStyleBackColor = true;
            B_php.Click += B_php_Click;
            // 
            // B_cSharp
            // 
            B_cSharp.Location = new Point(153, 166);
            B_cSharp.Name = "B_cSharp";
            B_cSharp.Size = new Size(75, 23);
            B_cSharp.TabIndex = 3;
            B_cSharp.Text = "c#";
            B_cSharp.UseVisualStyleBackColor = true;
            B_cSharp.Click += B_cSharp_Click;
            // 
            // L_attributs
            // 
            L_attributs.AutoSize = true;
            L_attributs.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            L_attributs.Location = new Point(400, 48);
            L_attributs.Name = "L_attributs";
            L_attributs.Size = new Size(79, 22);
            L_attributs.TabIndex = 4;
            L_attributs.Text = "Attributs";
            // 
            // TB_NameAttrib
            // 
            TB_NameAttrib.Location = new Point(449, 108);
            TB_NameAttrib.Name = "TB_NameAttrib";
            TB_NameAttrib.Size = new Size(100, 23);
            TB_NameAttrib.TabIndex = 5;
            // 
            // CB_type
            // 
            CB_type.DropDownStyle = ComboBoxStyle.DropDownList;
            CB_type.FormattingEnabled = true;
            CB_type.Location = new Point(309, 108);
            CB_type.Name = "CB_type";
            CB_type.Size = new Size(121, 23);
            CB_type.TabIndex = 7;
            // 
            // B_ajoutAttrib
            // 
            B_ajoutAttrib.Location = new Point(360, 166);
            B_ajoutAttrib.Name = "B_ajoutAttrib";
            B_ajoutAttrib.Size = new Size(141, 23);
            B_ajoutAttrib.TabIndex = 8;
            B_ajoutAttrib.Text = "ajouter attribut";
            B_ajoutAttrib.UseVisualStyleBackColor = true;
            B_ajoutAttrib.Click += B_ajoutAttrib_Click;
            // 
            // LV_attrib
            // 
            LV_attrib.Location = new Point(293, 209);
            LV_attrib.Name = "LV_attrib";
            LV_attrib.Size = new Size(283, 174);
            LV_attrib.TabIndex = 9;
            LV_attrib.UseCompatibleStateImageBehavior = false;
            LV_attrib.View = View.Tile;
            // 
            // B_creation
            // 
            B_creation.Location = new Point(206, 403);
            B_creation.Name = "B_creation";
            B_creation.Size = new Size(148, 23);
            B_creation.TabIndex = 10;
            B_creation.Text = "Creation de la classe";
            B_creation.UseVisualStyleBackColor = true;
            B_creation.Click += B_creation_Click;
            // 
            // L_CRUD
            // 
            L_CRUD.AutoSize = true;
            L_CRUD.Location = new Point(46, 217);
            L_CRUD.Name = "L_CRUD";
            L_CRUD.Size = new Size(46, 15);
            L_CRUD.TabIndex = 11;
            L_CRUD.Text = "CRUD ?";
            // 
            // CB_CRUD
            // 
            CB_CRUD.DropDownStyle = ComboBoxStyle.DropDownList;
            CB_CRUD.FormattingEnabled = true;
            CB_CRUD.Location = new Point(127, 209);
            CB_CRUD.Name = "CB_CRUD";
            CB_CRUD.Size = new Size(121, 23);
            CB_CRUD.TabIndex = 12;
            // 
            // TB_user
            // 
            TB_user.Location = new Point(127, 302);
            TB_user.Name = "TB_user";
            TB_user.Size = new Size(121, 23);
            TB_user.TabIndex = 13;
            // 
            // TB_pass
            // 
            TB_pass.Location = new Point(127, 331);
            TB_pass.Name = "TB_pass";
            TB_pass.Size = new Size(121, 23);
            TB_pass.TabIndex = 14;
            // 
            // TB_Database
            // 
            TB_Database.Location = new Point(127, 360);
            TB_Database.Name = "TB_Database";
            TB_Database.Size = new Size(121, 23);
            TB_Database.TabIndex = 15;
            // 
            // L_user
            // 
            L_user.AutoSize = true;
            L_user.Font = new Font("Segoe UI", 12F);
            L_user.Location = new Point(46, 300);
            L_user.Name = "L_user";
            L_user.Size = new Size(44, 21);
            L_user.TabIndex = 16;
            L_user.Text = "user ";
            // 
            // L_mdp
            // 
            L_mdp.AutoSize = true;
            L_mdp.Font = new Font("Segoe UI", 12F);
            L_mdp.Location = new Point(46, 333);
            L_mdp.Name = "L_mdp";
            L_mdp.Size = new Size(42, 21);
            L_mdp.TabIndex = 17;
            L_mdp.Text = "mdp";
            // 
            // L_database
            // 
            L_database.AutoSize = true;
            L_database.Font = new Font("Segoe UI", 12F);
            L_database.Location = new Point(46, 362);
            L_database.Name = "L_database";
            L_database.Size = new Size(72, 21);
            L_database.TabIndex = 18;
            L_database.Text = "database";
            // 
            // B_validation
            // 
            B_validation.Location = new Point(94, 247);
            B_validation.Name = "B_validation";
            B_validation.Size = new Size(75, 23);
            B_validation.TabIndex = 19;
            B_validation.Text = "validation";
            B_validation.UseVisualStyleBackColor = true;
            B_validation.Click += B_validation_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(605, 445);
            Controls.Add(B_validation);
            Controls.Add(L_database);
            Controls.Add(L_mdp);
            Controls.Add(L_user);
            Controls.Add(TB_Database);
            Controls.Add(TB_pass);
            Controls.Add(TB_user);
            Controls.Add(CB_CRUD);
            Controls.Add(L_CRUD);
            Controls.Add(B_creation);
            Controls.Add(LV_attrib);
            Controls.Add(B_ajoutAttrib);
            Controls.Add(CB_type);
            Controls.Add(TB_NameAttrib);
            Controls.Add(L_attributs);
            Controls.Add(B_cSharp);
            Controls.Add(B_php);
            Controls.Add(TB_name);
            Controls.Add(L_name);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label L_name;
        private TextBox TB_name;
        private Button B_php;
        private Button B_cSharp;
        private Label L_attributs;
        private TextBox TB_NameAttrib;
        private ComboBox CB_type;
        private Button B_ajoutAttrib;
        private ListView LV_attrib;
        private Button B_creation;
        private Label L_CRUD;
        private ComboBox CB_CRUD;
        private TextBox TB_user;
        private TextBox TB_pass;
        private TextBox TB_Database;
        private Label L_user;
        private Label L_mdp;
        private Label L_database;
        private Button B_validation;
    }
}
