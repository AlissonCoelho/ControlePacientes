namespace Trabalho_POO.Formularios
{
    partial class AddPaciente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddPaciente));
            this.texNascimento = new System.Windows.Forms.MaskedTextBox();
            this.texTel = new System.Windows.Forms.MaskedTextBox();
            this.texNum = new System.Windows.Forms.TextBox();
            this.texCidade = new System.Windows.Forms.TextBox();
            this.labelCidade = new System.Windows.Forms.Label();
            this.labelNum = new System.Windows.Forms.Label();
            this.texEstado = new System.Windows.Forms.ComboBox();
            this.botSalvarClient = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.labelTelefone = new System.Windows.Forms.Label();
            this.texBairro = new System.Windows.Forms.TextBox();
            this.labelEstado = new System.Windows.Forms.Label();
            this.labelBairro = new System.Windows.Forms.Label();
            this.texLogra = new System.Windows.Forms.TextBox();
            this.labeLogradouro = new System.Windows.Forms.Label();
            this.texEmail = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.texNome = new System.Windows.Forms.TextBox();
            this.labelNome = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // texNascimento
            // 
            this.texNascimento.Location = new System.Drawing.Point(105, 224);
            this.texNascimento.Mask = "00/00/0000";
            this.texNascimento.Name = "texNascimento";
            this.texNascimento.Size = new System.Drawing.Size(61, 20);
            this.texNascimento.TabIndex = 9;
            this.texNascimento.ValidatingType = typeof(System.DateTime);
            this.texNascimento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.texNascimento_KeyPress);
            // 
            // texTel
            // 
            this.texTel.Location = new System.Drawing.Point(105, 172);
            this.texTel.Mask = "(99) 00000-0000";
            this.texTel.Name = "texTel";
            this.texTel.Size = new System.Drawing.Size(93, 20);
            this.texTel.TabIndex = 7;
            // 
            // texNum
            // 
            this.texNum.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.texNum.Location = new System.Drawing.Point(105, 68);
            this.texNum.Name = "texNum";
            this.texNum.Size = new System.Drawing.Size(152, 20);
            this.texNum.TabIndex = 3;
            // 
            // texCidade
            // 
            this.texCidade.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.texCidade.Location = new System.Drawing.Point(105, 94);
            this.texCidade.Name = "texCidade";
            this.texCidade.Size = new System.Drawing.Size(238, 20);
            this.texCidade.TabIndex = 4;
            // 
            // labelCidade
            // 
            this.labelCidade.AutoSize = true;
            this.labelCidade.Cursor = System.Windows.Forms.Cursors.Default;
            this.labelCidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCidade.Location = new System.Drawing.Point(12, 96);
            this.labelCidade.Name = "labelCidade";
            this.labelCidade.Size = new System.Drawing.Size(62, 16);
            this.labelCidade.TabIndex = 51;
            this.labelCidade.Text = "Cidade:";
            // 
            // labelNum
            // 
            this.labelNum.AutoSize = true;
            this.labelNum.Cursor = System.Windows.Forms.Cursors.Default;
            this.labelNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNum.Location = new System.Drawing.Point(12, 70);
            this.labelNum.Name = "labelNum";
            this.labelNum.Size = new System.Drawing.Size(66, 16);
            this.labelNum.TabIndex = 50;
            this.labelNum.Text = "Número:";
            // 
            // texEstado
            // 
            this.texEstado.BackColor = System.Drawing.Color.White;
            this.texEstado.Cursor = System.Windows.Forms.Cursors.Default;
            this.texEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.texEstado.FormattingEnabled = true;
            this.texEstado.Items.AddRange(new object[] {
            "Acre",
            "Alagoas",
            "Amapá",
            "Amazonas\t",
            "Bahia",
            "Ceará",
            "Distrito Federal",
            "Espírito Santo",
            "Goiás",
            "Maranhão\t",
            "Mato Grosso do Sul",
            "Mato Grosso",
            "Minas Gerais",
            "Pará",
            "Paraíba",
            "Paraná",
            "Pernambuco",
            "Piauí",
            "Rio de Janeiro",
            "Rio Grande do Norte",
            "Rio Grande do Sul",
            "Rondônia",
            "Roraima",
            "Santa Catarina",
            "São Paulo",
            "Sergipe",
            "Tocantins"});
            this.texEstado.Location = new System.Drawing.Point(105, 146);
            this.texEstado.Name = "texEstado";
            this.texEstado.Size = new System.Drawing.Size(238, 21);
            this.texEstado.TabIndex = 6;
            // 
            // botSalvarClient
            // 
            this.botSalvarClient.Cursor = System.Windows.Forms.Cursors.Hand;
            this.botSalvarClient.Location = new System.Drawing.Point(136, 259);
            this.botSalvarClient.Name = "botSalvarClient";
            this.botSalvarClient.Size = new System.Drawing.Size(94, 32);
            this.botSalvarClient.TabIndex = 10;
            this.botSalvarClient.Text = "Salvar Paciente";
            this.botSalvarClient.UseVisualStyleBackColor = true;
            this.botSalvarClient.Click += new System.EventHandler(this.botSalvarClient_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 226);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 16);
            this.label2.TabIndex = 47;
            this.label2.Text = "Nascimento";
            // 
            // labelTelefone
            // 
            this.labelTelefone.AutoSize = true;
            this.labelTelefone.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTelefone.Location = new System.Drawing.Point(12, 174);
            this.labelTelefone.Name = "labelTelefone";
            this.labelTelefone.Size = new System.Drawing.Size(70, 16);
            this.labelTelefone.TabIndex = 46;
            this.labelTelefone.Text = "Telefone";
            // 
            // texBairro
            // 
            this.texBairro.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.texBairro.Location = new System.Drawing.Point(105, 120);
            this.texBairro.Name = "texBairro";
            this.texBairro.Size = new System.Drawing.Size(238, 20);
            this.texBairro.TabIndex = 5;
            // 
            // labelEstado
            // 
            this.labelEstado.AutoSize = true;
            this.labelEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEstado.Location = new System.Drawing.Point(12, 148);
            this.labelEstado.Name = "labelEstado";
            this.labelEstado.Size = new System.Drawing.Size(61, 16);
            this.labelEstado.TabIndex = 43;
            this.labelEstado.Text = "Estado:";
            // 
            // labelBairro
            // 
            this.labelBairro.AutoSize = true;
            this.labelBairro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBairro.Location = new System.Drawing.Point(12, 122);
            this.labelBairro.Name = "labelBairro";
            this.labelBairro.Size = new System.Drawing.Size(54, 16);
            this.labelBairro.TabIndex = 40;
            this.labelBairro.Text = "Bairro:";
            // 
            // texLogra
            // 
            this.texLogra.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.texLogra.Location = new System.Drawing.Point(105, 42);
            this.texLogra.Name = "texLogra";
            this.texLogra.Size = new System.Drawing.Size(238, 20);
            this.texLogra.TabIndex = 2;
            // 
            // labeLogradouro
            // 
            this.labeLogradouro.AutoSize = true;
            this.labeLogradouro.Cursor = System.Windows.Forms.Cursors.Default;
            this.labeLogradouro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labeLogradouro.Location = new System.Drawing.Point(12, 44);
            this.labeLogradouro.Name = "labeLogradouro";
            this.labeLogradouro.Size = new System.Drawing.Size(92, 16);
            this.labeLogradouro.TabIndex = 37;
            this.labeLogradouro.Text = "Logradouro:";
            // 
            // texEmail
            // 
            this.texEmail.Location = new System.Drawing.Point(105, 198);
            this.texEmail.Name = "texEmail";
            this.texEmail.Size = new System.Drawing.Size(238, 20);
            this.texEmail.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 200);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 33;
            this.label1.Text = "E-mail:";
            // 
            // texNome
            // 
            this.texNome.Location = new System.Drawing.Point(105, 16);
            this.texNome.Name = "texNome";
            this.texNome.Size = new System.Drawing.Size(238, 20);
            this.texNome.TabIndex = 1;
            // 
            // labelNome
            // 
            this.labelNome.AutoSize = true;
            this.labelNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNome.Location = new System.Drawing.Point(12, 18);
            this.labelNome.Name = "labelNome";
            this.labelNome.Size = new System.Drawing.Size(53, 16);
            this.labelNome.TabIndex = 32;
            this.labelNome.Text = "Nome:";
            // 
            // AddPaciente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 303);
            this.Controls.Add(this.texNascimento);
            this.Controls.Add(this.texTel);
            this.Controls.Add(this.texNum);
            this.Controls.Add(this.texCidade);
            this.Controls.Add(this.labelCidade);
            this.Controls.Add(this.labelNum);
            this.Controls.Add(this.texEstado);
            this.Controls.Add(this.botSalvarClient);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelTelefone);
            this.Controls.Add(this.texBairro);
            this.Controls.Add(this.labelEstado);
            this.Controls.Add(this.labelBairro);
            this.Controls.Add(this.texLogra);
            this.Controls.Add(this.labeLogradouro);
            this.Controls.Add(this.texEmail);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.texNome);
            this.Controls.Add(this.labelNome);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddPaciente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Novo Paciente";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox texNascimento;
        private System.Windows.Forms.MaskedTextBox texTel;
        private System.Windows.Forms.TextBox texNum;
        private System.Windows.Forms.TextBox texCidade;
        private System.Windows.Forms.Label labelCidade;
        private System.Windows.Forms.Label labelNum;
        private System.Windows.Forms.ComboBox texEstado;
        private System.Windows.Forms.Button botSalvarClient;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelTelefone;
        private System.Windows.Forms.TextBox texBairro;
        private System.Windows.Forms.Label labelEstado;
        private System.Windows.Forms.Label labelBairro;
        private System.Windows.Forms.TextBox texLogra;
        private System.Windows.Forms.Label labeLogradouro;
        private System.Windows.Forms.TextBox texEmail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox texNome;
        private System.Windows.Forms.Label labelNome;
    }
}