namespace Trabalho_POO.Formularios
{
    partial class EditarConsulta
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditarConsulta));
            this.texData = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.labeLogradouro = new System.Windows.Forms.Label();
            this.labelNome = new System.Windows.Forms.Label();
            this.texHorario = new System.Windows.Forms.ComboBox();
            this.botSalvarClient = new System.Windows.Forms.Button();
            this.bindingSourceNome = new System.Windows.Forms.BindingSource(this.components);
            this.texNome = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceNome)).BeginInit();
            this.SuspendLayout();
            // 
            // texData
            // 
            this.texData.Location = new System.Drawing.Point(114, 40);
            this.texData.Mask = "00/00/0000";
            this.texData.Name = "texData";
            this.texData.Size = new System.Drawing.Size(61, 20);
            this.texData.TabIndex = 2;
            this.texData.ValidatingType = typeof(System.DateTime);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 63;
            this.label2.Text = "Horário:";
            this.label2.UseWaitCursor = true;
            // 
            // labeLogradouro
            // 
            this.labeLogradouro.AutoSize = true;
            this.labeLogradouro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labeLogradouro.Location = new System.Drawing.Point(21, 42);
            this.labeLogradouro.Name = "labeLogradouro";
            this.labeLogradouro.Size = new System.Drawing.Size(45, 16);
            this.labeLogradouro.TabIndex = 61;
            this.labeLogradouro.Text = "Data:";
            // 
            // labelNome
            // 
            this.labelNome.AutoSize = true;
            this.labelNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNome.Location = new System.Drawing.Point(21, 16);
            this.labelNome.Name = "labelNome";
            this.labelNome.Size = new System.Drawing.Size(53, 16);
            this.labelNome.TabIndex = 59;
            this.labelNome.Text = "Nome:";
            // 
            // texHorario
            // 
            this.texHorario.BackColor = System.Drawing.Color.White;
            this.texHorario.Cursor = System.Windows.Forms.Cursors.Default;
            this.texHorario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.texHorario.FormattingEnabled = true;
            this.texHorario.Items.AddRange(new object[] {
            "08:00",
            "09:00",
            "10:00",
            "11:00",
            "13:00",
            "14:00",
            "15:00",
            "16:00",
            "17:00",
            "18:00"});
            this.texHorario.Location = new System.Drawing.Point(114, 67);
            this.texHorario.Name = "texHorario";
            this.texHorario.Size = new System.Drawing.Size(72, 21);
            this.texHorario.TabIndex = 3;
            // 
            // botSalvarClient
            // 
            this.botSalvarClient.Cursor = System.Windows.Forms.Cursors.Hand;
            this.botSalvarClient.Location = new System.Drawing.Point(129, 104);
            this.botSalvarClient.Name = "botSalvarClient";
            this.botSalvarClient.Size = new System.Drawing.Size(116, 39);
            this.botSalvarClient.TabIndex = 4;
            this.botSalvarClient.Text = "Salvar Alterações";
            this.botSalvarClient.UseVisualStyleBackColor = true;
            this.botSalvarClient.Click += new System.EventHandler(this.botSalvarClient_Click);
            // 
            // bindingSourceNome
            // 
            this.bindingSourceNome.DataSource = typeof(Trabalho_POO.Classes.Paciente);
            // 
            // texNome
            // 
            this.texNome.DataSource = this.bindingSourceNome;
            this.texNome.DisplayMember = "Nome";
            this.texNome.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.texNome.FormattingEnabled = true;
            this.texNome.Location = new System.Drawing.Point(114, 14);
            this.texNome.Name = "texNome";
            this.texNome.Size = new System.Drawing.Size(238, 21);
            this.texNome.TabIndex = 1;
            // 
            // EditarConsulta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 150);
            this.Controls.Add(this.texNome);
            this.Controls.Add(this.botSalvarClient);
            this.Controls.Add(this.texData);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labeLogradouro);
            this.Controls.Add(this.labelNome);
            this.Controls.Add(this.texHorario);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EditarConsulta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editar Consulta";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceNome)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox texData;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labeLogradouro;
        private System.Windows.Forms.Label labelNome;
        private System.Windows.Forms.ComboBox texHorario;
        private System.Windows.Forms.Button botSalvarClient;
        private System.Windows.Forms.BindingSource bindingSourceNome;
        private System.Windows.Forms.ComboBox texNome;
    }
}