namespace surprise
{
    partial class addFuncForm
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
            this.cancelB = new System.Windows.Forms.Button();
            this.saveB = new System.Windows.Forms.Button();
            this.funcBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cancelB
            // 
            this.cancelB.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelB.Location = new System.Drawing.Point(12, 44);
            this.cancelB.Name = "cancelB";
            this.cancelB.Size = new System.Drawing.Size(113, 23);
            this.cancelB.TabIndex = 0;
            this.cancelB.Text = "Cancel";
            this.cancelB.UseVisualStyleBackColor = true;
            this.cancelB.Click += new System.EventHandler(this.cancelB_Click);
            // 
            // saveB
            // 
            this.saveB.Location = new System.Drawing.Point(131, 44);
            this.saveB.Name = "saveB";
            this.saveB.Size = new System.Drawing.Size(106, 23);
            this.saveB.TabIndex = 1;
            this.saveB.Text = "Save";
            this.saveB.UseVisualStyleBackColor = true;
            this.saveB.Click += new System.EventHandler(this.saveB_Click);
            // 
            // funcBox
            // 
            this.funcBox.Location = new System.Drawing.Point(13, 12);
            this.funcBox.Name = "funcBox";
            this.funcBox.Size = new System.Drawing.Size(224, 20);
            this.funcBox.TabIndex = 2;
            // 
            // addFuncForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(249, 79);
            this.Controls.Add(this.funcBox);
            this.Controls.Add(this.saveB);
            this.Controls.Add(this.cancelB);
            this.Name = "addFuncForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Function";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelB;
        private System.Windows.Forms.Button saveB;
        private System.Windows.Forms.TextBox funcBox;
    }
}