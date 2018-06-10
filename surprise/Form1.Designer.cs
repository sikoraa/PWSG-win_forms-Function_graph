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
            this.components = new System.ComponentModel.Container();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.mapa = new System.Windows.Forms.PictureBox();
            this.funcBox = new System.Windows.Forms.CheckedListBox();
            this.drawB = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.fromBox = new System.Windows.Forms.TextBox();
            this.toBox = new System.Windows.Forms.TextBox();
            this.domainB = new System.Windows.Forms.Button();
            this.maxLabel = new System.Windows.Forms.Label();
            this.minLabel = new System.Windows.Forms.Label();
            this.minY = new System.Windows.Forms.Label();
            this.maxY = new System.Windows.Forms.Label();
            this.asyncB = new System.Windows.Forms.Button();
            this.stopB = new System.Windows.Forms.Button();
            this.integralLabel = new System.Windows.Forms.Label();
            this.addFuncB = new System.Windows.Forms.Button();
            this.calculations = new System.ComponentModel.BackgroundWorker();
            this.debug = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.mapa)).BeginInit();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.progressBar.Location = new System.Drawing.Point(6, 517);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(1174, 39);
            this.progressBar.TabIndex = 0;
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
            this.funcBox.CheckOnClick = true;
            this.funcBox.FormattingEnabled = true;
            this.funcBox.Location = new System.Drawing.Point(1031, 12);
            this.funcBox.Name = "funcBox";
            this.funcBox.Size = new System.Drawing.Size(149, 94);
            this.funcBox.TabIndex = 2;
            this.funcBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.funcBox_ItemCheck);
            this.funcBox.SelectedIndexChanged += new System.EventHandler(this.funcBox_SelectedIndexChanged);
            this.funcBox.SelectedValueChanged += new System.EventHandler(this.funcBox_SelectedValueChanged);
            // 
            // drawB
            // 
            this.drawB.Location = new System.Drawing.Point(1031, 165);
            this.drawB.Name = "drawB";
            this.drawB.Size = new System.Drawing.Size(149, 23);
            this.drawB.TabIndex = 3;
            this.drawB.Text = "Draw";
            this.drawB.UseVisualStyleBackColor = true;
            this.drawB.Click += new System.EventHandler(this.drawB_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1028, 204);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "From";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1030, 237);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "To";
            // 
            // fromBox
            // 
            this.fromBox.Location = new System.Drawing.Point(1064, 204);
            this.fromBox.Name = "fromBox";
            this.fromBox.Size = new System.Drawing.Size(116, 20);
            this.fromBox.TabIndex = 6;
            this.fromBox.Text = "-2";
            // 
            // toBox
            // 
            this.toBox.Location = new System.Drawing.Point(1064, 234);
            this.toBox.Name = "toBox";
            this.toBox.Size = new System.Drawing.Size(116, 20);
            this.toBox.TabIndex = 7;
            this.toBox.Text = "3";
            // 
            // domainB
            // 
            this.domainB.Location = new System.Drawing.Point(1030, 276);
            this.domainB.Name = "domainB";
            this.domainB.Size = new System.Drawing.Size(150, 23);
            this.domainB.TabIndex = 8;
            this.domainB.Text = "Change domain";
            this.domainB.UseVisualStyleBackColor = true;
            this.domainB.Click += new System.EventHandler(this.domainB_Click);
            // 
            // maxLabel
            // 
            this.maxLabel.AutoSize = true;
            this.maxLabel.Location = new System.Drawing.Point(1030, 314);
            this.maxLabel.Name = "maxLabel";
            this.maxLabel.Size = new System.Drawing.Size(43, 13);
            this.maxLabel.TabIndex = 9;
            this.maxLabel.Text = "Max Y: ";
            // 
            // minLabel
            // 
            this.minLabel.AutoSize = true;
            this.minLabel.Location = new System.Drawing.Point(1030, 344);
            this.minLabel.Name = "minLabel";
            this.minLabel.Size = new System.Drawing.Size(40, 13);
            this.minLabel.TabIndex = 10;
            this.minLabel.Text = "Min Y: ";
            // 
            // minY
            // 
            this.minY.AutoSize = true;
            this.minY.Location = new System.Drawing.Point(1091, 344);
            this.minY.Name = "minY";
            this.minY.Size = new System.Drawing.Size(0, 13);
            this.minY.TabIndex = 11;
            // 
            // maxY
            // 
            this.maxY.AutoSize = true;
            this.maxY.Location = new System.Drawing.Point(1079, 314);
            this.maxY.Name = "maxY";
            this.maxY.Size = new System.Drawing.Size(0, 13);
            this.maxY.TabIndex = 12;
            // 
            // asyncB
            // 
            this.asyncB.Location = new System.Drawing.Point(1030, 378);
            this.asyncB.Name = "asyncB";
            this.asyncB.Size = new System.Drawing.Size(150, 23);
            this.asyncB.TabIndex = 13;
            this.asyncB.Text = "Draw async";
            this.asyncB.UseVisualStyleBackColor = true;
            this.asyncB.Click += new System.EventHandler(this.asyncB_Click);
            // 
            // stopB
            // 
            this.stopB.Location = new System.Drawing.Point(1030, 407);
            this.stopB.Name = "stopB";
            this.stopB.Size = new System.Drawing.Size(150, 23);
            this.stopB.TabIndex = 14;
            this.stopB.Text = "Stop";
            this.stopB.UseVisualStyleBackColor = true;
            this.stopB.Click += new System.EventHandler(this.stopB_Click);
            // 
            // integralLabel
            // 
            this.integralLabel.AutoSize = true;
            this.integralLabel.Location = new System.Drawing.Point(1031, 446);
            this.integralLabel.Name = "integralLabel";
            this.integralLabel.Size = new System.Drawing.Size(48, 13);
            this.integralLabel.TabIndex = 15;
            this.integralLabel.Text = "Integral: ";
            // 
            // addFuncB
            // 
            this.addFuncB.Location = new System.Drawing.Point(1030, 123);
            this.addFuncB.Name = "addFuncB";
            this.addFuncB.Size = new System.Drawing.Size(150, 23);
            this.addFuncB.TabIndex = 16;
            this.addFuncB.Text = "Add new function";
            this.addFuncB.UseVisualStyleBackColor = true;
            this.addFuncB.Click += new System.EventHandler(this.addFuncB_Click);
            // 
            // calculations
            // 
            this.calculations.WorkerReportsProgress = true;
            this.calculations.WorkerSupportsCancellation = true;
            this.calculations.DoWork += new System.ComponentModel.DoWorkEventHandler(this.calculations_DoWork);
            this.calculations.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.calculations_ProgressChanged);
            this.calculations.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.calculations_RunWorkerCompleted);
            // 
            // debug
            // 
            this.debug.AutoSize = true;
            this.debug.Location = new System.Drawing.Point(1030, 488);
            this.debug.Name = "debug";
            this.debug.Size = new System.Drawing.Size(13, 13);
            this.debug.TabIndex = 17;
            this.debug.Text = ": ";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 561);
            this.Controls.Add(this.debug);
            this.Controls.Add(this.addFuncB);
            this.Controls.Add(this.integralLabel);
            this.Controls.Add(this.stopB);
            this.Controls.Add(this.asyncB);
            this.Controls.Add(this.maxY);
            this.Controls.Add(this.minY);
            this.Controls.Add(this.minLabel);
            this.Controls.Add(this.maxLabel);
            this.Controls.Add(this.domainB);
            this.Controls.Add(this.toBox);
            this.Controls.Add(this.fromBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.drawB);
            this.Controls.Add(this.funcBox);
            this.Controls.Add(this.mapa);
            this.Controls.Add(this.progressBar);
            this.Name = "Form1";
            this.Text = "Integral1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.mapa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.PictureBox mapa;
        private System.Windows.Forms.CheckedListBox funcBox;
        private System.Windows.Forms.Button drawB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox fromBox;
        private System.Windows.Forms.TextBox toBox;
        private System.Windows.Forms.Button domainB;
        private System.Windows.Forms.Label maxLabel;
        private System.Windows.Forms.Label minLabel;
        private System.Windows.Forms.Label minY;
        private System.Windows.Forms.Label maxY;
        private System.Windows.Forms.Button asyncB;
        private System.Windows.Forms.Button stopB;
        private System.Windows.Forms.Label integralLabel;
        private System.Windows.Forms.Button addFuncB;
        private System.ComponentModel.BackgroundWorker calculations;
        private System.Windows.Forms.Label debug;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}

