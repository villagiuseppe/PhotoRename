﻿namespace PhotoRename
{
    partial class PhotoRename
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
            this.btn_Rename = new System.Windows.Forms.Button();
            this.lbl_Source = new System.Windows.Forms.Label();
            this.btn_Source = new System.Windows.Forms.Button();
            this.txt_Source = new System.Windows.Forms.TextBox();
            this.prg_Image = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // btn_Rename
            // 
            this.btn_Rename.Location = new System.Drawing.Point(500, 17);
            this.btn_Rename.Name = "btn_Rename";
            this.btn_Rename.Size = new System.Drawing.Size(106, 46);
            this.btn_Rename.TabIndex = 7;
            this.btn_Rename.Text = "RINOMINA";
            this.btn_Rename.UseVisualStyleBackColor = true;
            this.btn_Rename.Click += new System.EventHandler(this.btn_Rename_Click);
            // 
            // lbl_Source
            // 
            this.lbl_Source.AutoSize = true;
            this.lbl_Source.Location = new System.Drawing.Point(3, 17);
            this.lbl_Source.Name = "lbl_Source";
            this.lbl_Source.Size = new System.Drawing.Size(89, 13);
            this.lbl_Source.TabIndex = 6;
            this.lbl_Source.Text = "Directory sorgenti";
            // 
            // btn_Source
            // 
            this.btn_Source.Location = new System.Drawing.Point(444, 33);
            this.btn_Source.Name = "btn_Source";
            this.btn_Source.Size = new System.Drawing.Size(30, 23);
            this.btn_Source.TabIndex = 5;
            this.btn_Source.Text = "...";
            this.btn_Source.UseVisualStyleBackColor = true;
            this.btn_Source.Click += new System.EventHandler(this.btn_Source_Click);
            // 
            // txt_Source
            // 
            this.txt_Source.Location = new System.Drawing.Point(6, 33);
            this.txt_Source.Name = "txt_Source";
            this.txt_Source.Size = new System.Drawing.Size(432, 20);
            this.txt_Source.TabIndex = 4;
            // 
            // prg_Image
            // 
            this.prg_Image.Location = new System.Drawing.Point(6, 59);
            this.prg_Image.Name = "prg_Image";
            this.prg_Image.Size = new System.Drawing.Size(468, 23);
            this.prg_Image.TabIndex = 8;
            // 
            // PhotoRename
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 90);
            this.Controls.Add(this.prg_Image);
            this.Controls.Add(this.btn_Rename);
            this.Controls.Add(this.lbl_Source);
            this.Controls.Add(this.btn_Source);
            this.Controls.Add(this.txt_Source);
            this.Name = "PhotoRename";
            this.Text = "PhotoRename";
            this.Load += new System.EventHandler(this.PhotoRename_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Rename;
        private System.Windows.Forms.Label lbl_Source;
        private System.Windows.Forms.Button btn_Source;
        private System.Windows.Forms.TextBox txt_Source;
        private System.Windows.Forms.ProgressBar prg_Image;
    }
}