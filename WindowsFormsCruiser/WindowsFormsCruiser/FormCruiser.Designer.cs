namespace WindowsFormscruiser
{
    partial class FormCruiser
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBoxDoki = new System.Windows.Forms.PictureBox();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.buttonCreateCruiser = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBoxTakeWarship = new System.Windows.Forms.PictureBox();
            this.buttonTakeWarship = new System.Windows.Forms.Button();
            this.maskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listBoxLevels = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDoki)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTakeWarship)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxDoki
            // 
            this.pictureBoxDoki.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBoxDoki.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxDoki.Name = "pictureBoxDoki";
            this.pictureBoxDoki.Size = new System.Drawing.Size(656, 450);
            this.pictureBoxDoki.TabIndex = 1;
            this.pictureBoxDoki.TabStop = false;
            // 
            // buttonCreate
            // 
            this.buttonCreate.Location = new System.Drawing.Point(668, 141);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(108, 23);
            this.buttonCreate.TabIndex = 2;
            this.buttonCreate.Text = "Создать корабль";
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // buttonCreateCruiser
            // 
            this.buttonCreateCruiser.Location = new System.Drawing.Point(668, 170);
            this.buttonCreateCruiser.Name = "buttonCreateCruiser";
            this.buttonCreateCruiser.Size = new System.Drawing.Size(110, 22);
            this.buttonCreateCruiser.TabIndex = 3;
            this.buttonCreateCruiser.Text = "Создать крейсер";
            this.buttonCreateCruiser.UseVisualStyleBackColor = true;
            this.buttonCreateCruiser.Click += new System.EventHandler(this.buttonCreateCruiser_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBoxTakeWarship);
            this.groupBox1.Controls.Add(this.buttonTakeWarship);
            this.groupBox1.Controls.Add(this.maskedTextBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(662, 212);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(126, 226);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Забрать корабль";
            // 
            // pictureBoxTakeWarship
            // 
            this.pictureBoxTakeWarship.Location = new System.Drawing.Point(6, 115);
            this.pictureBoxTakeWarship.Name = "pictureBoxTakeWarship";
            this.pictureBoxTakeWarship.Size = new System.Drawing.Size(114, 92);
            this.pictureBoxTakeWarship.TabIndex = 3;
            this.pictureBoxTakeWarship.TabStop = false;
            // 
            // buttonTakeWarship
            // 
            this.buttonTakeWarship.Location = new System.Drawing.Point(16, 54);
            this.buttonTakeWarship.Name = "buttonTakeWarship";
            this.buttonTakeWarship.Size = new System.Drawing.Size(75, 23);
            this.buttonTakeWarship.TabIndex = 2;
            this.buttonTakeWarship.Text = "Забрать";
            this.buttonTakeWarship.UseVisualStyleBackColor = true;
            this.buttonTakeWarship.Click += new System.EventHandler(this.ButtonTakeWarship_Click);
            // 
            // maskedTextBox
            // 
            this.maskedTextBox.Location = new System.Drawing.Point(77, 19);
            this.maskedTextBox.Name = "maskedTextBox";
            this.maskedTextBox.Size = new System.Drawing.Size(25, 20);
            this.maskedTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Место";
            // 
            // listBoxLevels
            // 
            this.listBoxLevels.FormattingEnabled = true;
            this.listBoxLevels.Location = new System.Drawing.Point(668, 12);
            this.listBoxLevels.Name = "listBoxLevels";
            this.listBoxLevels.Size = new System.Drawing.Size(126, 95);
            this.listBoxLevels.TabIndex = 5;
            this.listBoxLevels.Click += new System.EventHandler(this.listBoxLevels_SelectedIndexChanged);
            // 
            // FormCruiser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listBoxLevels);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonCreateCruiser);
            this.Controls.Add(this.buttonCreate);
            this.Controls.Add(this.pictureBoxDoki);
            this.Name = "FormCruiser";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDoki)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTakeWarship)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxDoki;
        private System.Windows.Forms.Button buttonCreate;
        private System.Windows.Forms.Button buttonCreateCruiser;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBoxTakeWarship;
        private System.Windows.Forms.Button buttonTakeWarship;
        private System.Windows.Forms.MaskedTextBox maskedTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBoxLevels;
    }
}

