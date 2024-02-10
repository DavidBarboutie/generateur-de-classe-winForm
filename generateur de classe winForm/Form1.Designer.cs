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
            LV_attrib.Size = new Size(283, 157);
            LV_attrib.TabIndex = 9;
            LV_attrib.UseCompatibleStateImageBehavior = false;
            LV_attrib.View = View.Tile;
            // 
            // B_creation
            // 
            B_creation.Location = new Point(216, 392);
            B_creation.Name = "B_creation";
            B_creation.Size = new Size(148, 23);
            B_creation.TabIndex = 10;
            B_creation.Text = "Creation de la classe";
            B_creation.UseVisualStyleBackColor = true;
            B_creation.Click += B_creation_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(636, 440);
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
    }
}
