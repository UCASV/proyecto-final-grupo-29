
namespace Procedo_de_cita
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.bttnGeneratePDF = new System.Windows.Forms.Button();
            this.bttnform = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lbldui = new System.Windows.Forms.Label();
            this.txtbName = new System.Windows.Forms.TextBox();
            this.lbladdress = new System.Windows.Forms.Label();
            this.txtbAddress = new System.Windows.Forms.TextBox();
            this.lblphone = new System.Windows.Forms.Label();
            this.txtbPhone = new System.Windows.Forms.TextBox();
            this.lblemail = new System.Windows.Forms.Label();
            this.txtbEmail = new System.Windows.Forms.TextBox();
            this.txtbDUI = new System.Windows.Forms.TextBox();
            this.lblname = new System.Windows.Forms.Label();
            this.lblBirhDay = new System.Windows.Forms.Label();
            this.dtpBirthDay = new System.Windows.Forms.DateTimePicker();
            this.lblinstitution = new System.Windows.Forms.Label();
            this.lblDisease = new System.Windows.Forms.Label();
            this.cmbIntitution = new System.Windows.Forms.ComboBox();
            this.txtbDisease = new System.Windows.Forms.TextBox();
            this.ltbDisease = new System.Windows.Forms.ListBox();
            this.bttAdd = new System.Windows.Forms.Button();
            this.bttErase = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.bttCancel = new System.Windows.Forms.Button();
            this.bttCreate = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(801, 452);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.bttnGeneratePDF);
            this.tabPage1.Controls.Add(this.bttnform);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(793, 424);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // bttnGeneratePDF
            // 
            this.bttnGeneratePDF.Location = new System.Drawing.Point(592, 100);
            this.bttnGeneratePDF.Name = "bttnGeneratePDF";
            this.bttnGeneratePDF.Size = new System.Drawing.Size(125, 55);
            this.bttnGeneratePDF.TabIndex = 1;
            this.bttnGeneratePDF.Text = "Generar un pdf";
            this.bttnGeneratePDF.UseVisualStyleBackColor = true;
            this.bttnGeneratePDF.Click += new System.EventHandler(this.bttnGeneratePDF_Click);
            // 
            // bttnform
            // 
            this.bttnform.Location = new System.Drawing.Point(423, 100);
            this.bttnform.Name = "bttnform";
            this.bttnform.Size = new System.Drawing.Size(141, 55);
            this.bttnform.TabIndex = 0;
            this.bttnform.Text = "Crear formulario ciudadano";
            this.bttnform.UseVisualStyleBackColor = true;
            this.bttnform.Click += new System.EventHandler(this.bttnform_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tableLayoutPanel1);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(793, 424);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.5F));
            this.tableLayoutPanel1.Controls.Add(this.lblTitulo, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbldui, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtbName, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.lbladdress, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.txtbAddress, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.lblphone, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.txtbPhone, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.lblemail, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtbEmail, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtbDUI, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblname, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblBirhDay, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.dtpBirthDay, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblinstitution, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.lblDisease, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.cmbIntitution, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.txtbDisease, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.ltbDisease, 1, 9);
            this.tableLayoutPanel1.Controls.Add(this.bttAdd, 2, 8);
            this.tableLayoutPanel1.Controls.Add(this.bttErase, 2, 9);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 9);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 10;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(793, 424);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // lblTitulo
            // 
            this.lblTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.BackColor = System.Drawing.Color.RoyalBlue;
            this.tableLayoutPanel1.SetColumnSpan(this.lblTitulo, 3);
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitulo.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblTitulo.Location = new System.Drawing.Point(3, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(787, 42);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Formulario Cita";
            this.lblTitulo.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // lbldui
            // 
            this.lbldui.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbldui.AutoSize = true;
            this.lbldui.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbldui.Location = new System.Drawing.Point(3, 52);
            this.lbldui.Name = "lbldui";
            this.lbldui.Size = new System.Drawing.Size(44, 21);
            this.lbldui.TabIndex = 3;
            this.lbldui.Text = "DUI*";
            // 
            // txtbName
            // 
            this.txtbName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtbName.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtbName.Location = new System.Drawing.Point(3, 171);
            this.txtbName.Name = "txtbName";
            this.txtbName.Size = new System.Drawing.Size(258, 23);
            this.txtbName.TabIndex = 4;
            // 
            // lbladdress
            // 
            this.lbladdress.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbladdress.AutoSize = true;
            this.lbladdress.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbladdress.Location = new System.Drawing.Point(3, 220);
            this.lbladdress.Name = "lbladdress";
            this.lbladdress.Size = new System.Drawing.Size(84, 21);
            this.lbladdress.TabIndex = 5;
            this.lbladdress.Text = "Dirrecion*";
            // 
            // txtbAddress
            // 
            this.txtbAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtbAddress.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtbAddress.Location = new System.Drawing.Point(3, 255);
            this.txtbAddress.Name = "txtbAddress";
            this.txtbAddress.Size = new System.Drawing.Size(258, 23);
            this.txtbAddress.TabIndex = 6;
            // 
            // lblphone
            // 
            this.lblphone.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblphone.AutoSize = true;
            this.lblphone.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblphone.Location = new System.Drawing.Point(3, 304);
            this.lblphone.Name = "lblphone";
            this.lblphone.Size = new System.Drawing.Size(81, 21);
            this.lblphone.TabIndex = 7;
            this.lblphone.Text = "Telefono*";
            // 
            // txtbPhone
            // 
            this.txtbPhone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtbPhone.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtbPhone.Location = new System.Drawing.Point(3, 339);
            this.txtbPhone.Name = "txtbPhone";
            this.txtbPhone.Size = new System.Drawing.Size(258, 23);
            this.txtbPhone.TabIndex = 10;
            // 
            // lblemail
            // 
            this.lblemail.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblemail.AutoSize = true;
            this.lblemail.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblemail.Location = new System.Drawing.Point(399, 52);
            this.lblemail.Name = "lblemail";
            this.lblemail.Size = new System.Drawing.Size(148, 21);
            this.lblemail.TabIndex = 9;
            this.lblemail.Text = "Correo electronico";
            // 
            // txtbEmail
            // 
            this.txtbEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtbEmail.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtbEmail.Location = new System.Drawing.Point(399, 87);
            this.txtbEmail.Name = "txtbEmail";
            this.txtbEmail.Size = new System.Drawing.Size(258, 23);
            this.txtbEmail.TabIndex = 8;
            // 
            // txtbDUI
            // 
            this.txtbDUI.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtbDUI.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtbDUI.Location = new System.Drawing.Point(3, 87);
            this.txtbDUI.Name = "txtbDUI";
            this.txtbDUI.Size = new System.Drawing.Size(258, 23);
            this.txtbDUI.TabIndex = 2;
            this.txtbDUI.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // lblname
            // 
            this.lblname.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblname.AutoSize = true;
            this.lblname.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblname.Location = new System.Drawing.Point(3, 136);
            this.lblname.Name = "lblname";
            this.lblname.Size = new System.Drawing.Size(78, 21);
            this.lblname.TabIndex = 1;
            this.lblname.Text = "Nombre*";
            this.lblname.Click += new System.EventHandler(this.lblnombre_Click);
            // 
            // lblBirhDay
            // 
            this.lblBirhDay.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblBirhDay.AutoSize = true;
            this.lblBirhDay.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblBirhDay.Location = new System.Drawing.Point(399, 136);
            this.lblBirhDay.Name = "lblBirhDay";
            this.lblBirhDay.Size = new System.Drawing.Size(167, 21);
            this.lblBirhDay.TabIndex = 11;
            this.lblBirhDay.Text = "Fecha de nacimiento*";
            // 
            // dtpBirthDay
            // 
            this.dtpBirthDay.Location = new System.Drawing.Point(399, 171);
            this.dtpBirthDay.Name = "dtpBirthDay";
            this.dtpBirthDay.Size = new System.Drawing.Size(228, 23);
            this.dtpBirthDay.TabIndex = 14;
            // 
            // lblinstitution
            // 
            this.lblinstitution.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblinstitution.AutoSize = true;
            this.lblinstitution.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblinstitution.Location = new System.Drawing.Point(399, 220);
            this.lblinstitution.Name = "lblinstitution";
            this.lblinstitution.Size = new System.Drawing.Size(94, 21);
            this.lblinstitution.TabIndex = 12;
            this.lblinstitution.Text = "Institucion*";
            // 
            // lblDisease
            // 
            this.lblDisease.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDisease.AutoSize = true;
            this.lblDisease.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblDisease.Location = new System.Drawing.Point(399, 304);
            this.lblDisease.Name = "lblDisease";
            this.lblDisease.Size = new System.Drawing.Size(182, 21);
            this.lblDisease.TabIndex = 13;
            this.lblDisease.Text = "Lista de Enfermedades*";
            // 
            // cmbIntitution
            // 
            this.cmbIntitution.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIntitution.FormattingEnabled = true;
            this.cmbIntitution.Location = new System.Drawing.Point(399, 255);
            this.cmbIntitution.Name = "cmbIntitution";
            this.cmbIntitution.Size = new System.Drawing.Size(258, 23);
            this.cmbIntitution.TabIndex = 15;
            // 
            // txtbDisease
            // 
            this.txtbDisease.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtbDisease.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtbDisease.Location = new System.Drawing.Point(399, 339);
            this.txtbDisease.Name = "txtbDisease";
            this.txtbDisease.Size = new System.Drawing.Size(258, 23);
            this.txtbDisease.TabIndex = 17;
            // 
            // ltbDisease
            // 
            this.ltbDisease.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ltbDisease.FormattingEnabled = true;
            this.ltbDisease.ItemHeight = 15;
            this.ltbDisease.Location = new System.Drawing.Point(399, 381);
            this.ltbDisease.Name = "ltbDisease";
            this.ltbDisease.Size = new System.Drawing.Size(259, 34);
            this.ltbDisease.TabIndex = 21;
            // 
            // bttAdd
            // 
            this.bttAdd.BackColor = System.Drawing.Color.RoyalBlue;
            this.bttAdd.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bttAdd.Location = new System.Drawing.Point(664, 339);
            this.bttAdd.Name = "bttAdd";
            this.bttAdd.Size = new System.Drawing.Size(126, 33);
            this.bttAdd.TabIndex = 20;
            this.bttAdd.Text = "Agregar Enfermedad";
            this.bttAdd.UseVisualStyleBackColor = false;
            this.bttAdd.Click += new System.EventHandler(this.button2_Click);
            // 
            // bttErase
            // 
            this.bttErase.BackColor = System.Drawing.Color.RoyalBlue;
            this.bttErase.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bttErase.Location = new System.Drawing.Point(664, 381);
            this.bttErase.Name = "bttErase";
            this.bttErase.Size = new System.Drawing.Size(126, 33);
            this.bttErase.TabIndex = 22;
            this.bttErase.Text = "Borrar lista";
            this.bttErase.UseVisualStyleBackColor = false;
            this.bttErase.Click += new System.EventHandler(this.bttErase_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.bttCancel, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.bttCreate, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 381);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(390, 40);
            this.tableLayoutPanel2.TabIndex = 23;
            // 
            // bttCancel
            // 
            this.bttCancel.BackColor = System.Drawing.Color.RoyalBlue;
            this.bttCancel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bttCancel.Location = new System.Drawing.Point(198, 3);
            this.bttCancel.Name = "bttCancel";
            this.bttCancel.Size = new System.Drawing.Size(189, 33);
            this.bttCancel.TabIndex = 19;
            this.bttCancel.Text = "Cancelar";
            this.bttCancel.UseVisualStyleBackColor = false;
            this.bttCancel.Click += new System.EventHandler(this.bttCancel_Click);
            // 
            // bttCreate
            // 
            this.bttCreate.BackColor = System.Drawing.Color.RoyalBlue;
            this.bttCreate.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bttCreate.Location = new System.Drawing.Point(3, 3);
            this.bttCreate.Name = "bttCreate";
            this.bttCreate.Size = new System.Drawing.Size(189, 33);
            this.bttCreate.TabIndex = 18;
            this.bttCreate.Text = "Crear Formulario";
            this.bttCreate.UseVisualStyleBackColor = false;
            this.bttCreate.Click += new System.EventHandler(this.bttnAccept_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblname;
        private System.Windows.Forms.TextBox txtbDUI;
        private System.Windows.Forms.TextBox txtbPhone;
        private System.Windows.Forms.Label lbldui;
        private System.Windows.Forms.TextBox txtbName;
        private System.Windows.Forms.Label lbladdress;
        private System.Windows.Forms.TextBox txtbAddress;
        private System.Windows.Forms.Label lblphone;
        private System.Windows.Forms.Label lblemail;
        private System.Windows.Forms.TextBox txtbEmail;
        private System.Windows.Forms.Label lblBirhDay;
        private System.Windows.Forms.Label lblinstitution;
        private System.Windows.Forms.Label lblDisease;
        private System.Windows.Forms.DateTimePicker dtpBirthDay;
        private System.Windows.Forms.ComboBox cmbIntitution;
        private System.Windows.Forms.Button bttCreate;
        private System.Windows.Forms.TextBox txtbDisease;
        private System.Windows.Forms.Button bttAdd;
        private System.Windows.Forms.ListBox ltbDisease;
        private System.Windows.Forms.Button bttErase;
        private System.Windows.Forms.Button bttnform;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button bttCancel;
        private System.Windows.Forms.Button bttnGeneratePDF;
    }
}

