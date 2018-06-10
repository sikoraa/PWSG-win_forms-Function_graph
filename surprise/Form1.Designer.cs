namespace surprise
{
    partial class Form1
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
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.mapa = new System.Windows.Forms.PictureBox();
            this.funcBox = new System.Windows.Forms.CheckedListBox();
            this.drawB = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.fromBox = new System.Windows.Forms.TextBox();
            this.toBox = new System.Windows.Forms.TextBox();
            this.domainB = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.minY = new System.Windows.Forms.Label();
            this.maxY = new System.Windows.Forms.Label();
            this.asyncB = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.mapa)).BeginInit();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.progressBar1.Location = new System.Drawing.Point(0, 510);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1174, 39);
            this.progressBar1.TabIndex = 0;
            // 
            // mapa
            // 
            this.mapa.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.mapa.Location = new System.Drawing.Point(0, 0);
            this.mapa.Name = "mapa";
            this.mapa.Size = new System.Drawing.Size(1024, 512);
            this.mapa.TabIndex = 1;
            this.mapa.TabStop = false;
            // 
            // funcBox
            // 
            this.funcBox.FormattingEnabled = true;
            this.funcBox.Location = new System.Drawing.Point(1031, 13);
            this.funcBox.Name = "funcBox";
            this.funcBox.Size = new System.Drawing.Size(130, 94);
            this.funcBox.TabIndex = 2;
            this.funcBox.SelectedIndexChanged += new System.EventHandler(this.funcBox_SelectedIndexChanged);
            // 
            // drawB
            // 
            this.drawB.Location = new System.Drawing.Point(1031, 130);
            this.drawB.Name = "drawB";
            this.drawB.Size = new System.Drawing.Size(130, 23);
            this.drawB.TabIndex = 3;
            this.drawB.Text = "Draw";
            this.drawB.UseVisualStyleBackColor = true;
            this.drawB.Click += new System.EventHandler(this.drawB_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1028, 167);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "From";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1030, 200);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "To";
            // 
            // fromBox
            // 
            this.fromBox.Location = new System.Drawing.Point(1061, 160);
            this.fromBox.Name = "fromBox";
            this.fromBox.Size = new System.Drawing.Size(100, 20);
            this.fromBox.TabIndex = 6;
            this.fromBox.Text = "-2";
            // 
            // toBox
            // 
            this.toBox.Location = new System.Drawing.Point(1061, 193);
            this.toBox.Name = "toBox";
            this.toBox.Size = new System.Drawing.Size(100, 20);
            this.toBox.TabIndex = 7;
            this.toBox.Text = "3";
            // 
            // domainB
            // 
            this.domainB.Location = new System.Drawing.Point(1033, 232);
            this.domainB.Name = "domainB";
            this.domainB.Size = new System.Drawing.Size(128, 23);
            this.domainB.TabIndex = 8;
            this.domainB.Text = "Change domain";
            this.domainB.UseVisualStyleBackColor = true;
            this.domainB.Click += new System.EventHandler(this.domainB_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1031, 279);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Max Y: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1033, 310);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Min Y: ";
            // 
            // minY
            // 
            this.minY.AutoSize = true;
            this.minY.Location = new System.Drawing.Point(1079, 310);
            this.minY.Name = "minY";
            this.minY.Size = new System.Drawing.Size(0, 13);
            this.minY.TabIndex = 11;
            // 
            // maxY
            // 
            this.maxY.AutoSize = true;
            this.maxY.Location = new System.Drawing.Point(1080, 279);
            this.maxY.Name = "maxY";
            this.maxY.Size = new System.Drawing.Size(0, 13);
            this.maxY.TabIndex = 12;
            // 
            // asyncB
            // 
            this.asyncB.Location = new System.Drawing.Point(1036, 344);
            this.asyncB.Name = "asyncB";
            this.asyncB.Size = new System.Drawing.Size(125, 23);
            this.asyncB.TabIndex = 13;
            this.asyncB.Text = "Draw async";
            this.asyncB.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1173, 547);
            this.Controls.Add(this.asyncB);
            this.Controls.Add(this.maxY);
            this.Controls.Add(this.minY);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.domainB);
            this.Controls.Add(this.toBox);
            this.Controls.Add(this.fromBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.drawB);
            this.Controls.Add(this.funcBox);
            this.Controls.Add(this.mapa);
            this.Controls.Add(this.progressBar1);
            this.Name = "Form1";
            this.Text = "Integral1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.mapa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.PictureBox mapa;
        private System.Windows.Forms.CheckedListBox funcBox;
        private System.Windows.Forms.Button drawB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox fromBox;
        private System.Windows.Forms.TextBox toBox;
        private System.Windows.Forms.Button domainB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label minY;
        private System.Windows.Forms.Label maxY;
        private System.Windows.Forms.Button asyncB;
    }
}

