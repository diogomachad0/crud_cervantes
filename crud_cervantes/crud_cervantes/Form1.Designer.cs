namespace crud_cervantes
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            dgFuncionario = new DataGridView();
            Nome = new TextBox();
            label2 = new Label();
            label3 = new Label();
            buttonEditar = new Button();
            buttonRemover = new Button();
            buttonAdd = new Button();
            pictureBox1 = new PictureBox();
            imageList1 = new ImageList(components);
            Telefone = new MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)dgFuncionario).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // dgFuncionario
            // 
            dgFuncionario.BackgroundColor = SystemColors.ButtonHighlight;
            dgFuncionario.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgFuncionario.Location = new Point(12, 271);
            dgFuncionario.Name = "dgFuncionario";
            dgFuncionario.RowHeadersWidth = 51;
            dgFuncionario.RowTemplate.Height = 29;
            dgFuncionario.Size = new Size(767, 199);
            dgFuncionario.TabIndex = 0;
            dgFuncionario.CellClick += dgFuncionario_CellClick;
            dgFuncionario.CellContentClick += dataGridView1_CellContentClick;
            // 
            // Nome
            // 
            Nome.Cursor = Cursors.IBeam;
            Nome.Location = new Point(117, 65);
            Nome.Name = "Nome";
            Nome.Size = new Size(174, 27);
            Nome.TabIndex = 4;
            Nome.TextChanged += Nome_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 65);
            label2.Name = "label2";
            label2.Size = new Size(50, 20);
            label2.TabIndex = 3;
            label2.Text = "Nome";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 123);
            label3.Name = "label3";
            label3.Size = new Size(66, 20);
            label3.TabIndex = 5;
            label3.Text = "Telefone";
            // 
            // buttonEditar
            // 
            buttonEditar.Cursor = Cursors.Hand;
            buttonEditar.Location = new Point(558, 225);
            buttonEditar.Name = "buttonEditar";
            buttonEditar.Size = new Size(94, 29);
            buttonEditar.TabIndex = 8;
            buttonEditar.Text = "Editar";
            buttonEditar.TextImageRelation = TextImageRelation.ImageAboveText;
            buttonEditar.UseVisualStyleBackColor = true;
            buttonEditar.Click += buttonEditar_Click;
            // 
            // buttonRemover
            // 
            buttonRemover.Cursor = Cursors.Hand;
            buttonRemover.Location = new Point(676, 225);
            buttonRemover.Name = "buttonRemover";
            buttonRemover.Size = new Size(94, 29);
            buttonRemover.TabIndex = 9;
            buttonRemover.Text = "Remover";
            buttonRemover.UseVisualStyleBackColor = true;
            buttonRemover.Click += buttonRemover_Click;
            // 
            // buttonAdd
            // 
            buttonAdd.Cursor = Cursors.Hand;
            buttonAdd.FlatAppearance.BorderColor = Color.White;
            buttonAdd.FlatAppearance.BorderSize = 10;
            buttonAdd.FlatAppearance.MouseDownBackColor = Color.Gainsboro;
            buttonAdd.FlatStyle = FlatStyle.System;
            buttonAdd.Location = new Point(438, 225);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(94, 29);
            buttonAdd.TabIndex = 10;
            buttonAdd.Text = "Adicionar";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.logo;
            pictureBox1.Location = new Point(438, 65);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(332, 142);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 11;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth8Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "logo.jpg");
            // 
            // Telefone
            // 
            Telefone.Location = new Point(117, 123);
            Telefone.Mask = "000000000000";
            Telefone.Name = "Telefone";
            Telefone.Size = new Size(174, 27);
            Telefone.TabIndex = 13;
            Telefone.ValidatingType = typeof(int);
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.FromArgb(217, 71, 31);
            ClientSize = new Size(792, 478);
            Controls.Add(Telefone);
            Controls.Add(pictureBox1);
            Controls.Add(buttonAdd);
            Controls.Add(buttonRemover);
            Controls.Add(buttonEditar);
            Controls.Add(label3);
            Controls.Add(Nome);
            Controls.Add(label2);
            Controls.Add(dgFuncionario);
            MinimumSize = new Size(810, 525);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cadastro de funcionários";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgFuncionario).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgFuncionario;
        private TextBox Nome;
        private Label label2;
        private Label label3;
        private Button buttonEditar;
        private Button buttonRemover;
        private Button buttonAdd;
        private PictureBox pictureBox1;
        private ImageList imageList1;
        private Label label1;
        private MaskedTextBox Telefone;
    }
}
