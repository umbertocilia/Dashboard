
namespace Dashboard
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
            this.canvas = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnNodo = new System.Windows.Forms.Button();
            this.btnPointer = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // canvas
            // 
            this.canvas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.canvas.Location = new System.Drawing.Point(0, 46);
            this.canvas.Margin = new System.Windows.Forms.Padding(0);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(1384, 716);
            this.canvas.TabIndex = 0;
            this.canvas.TabStop = false;
            this.canvas.MouseClick += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseClick);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(69)))), ((int)(((byte)(87)))));
            this.panel1.Controls.Add(this.btnNodo);
            this.panel1.Controls.Add(this.btnPointer);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1384, 46);
            this.panel1.TabIndex = 1;
            // 
            // btnNodo
            // 
            this.btnNodo.Location = new System.Drawing.Point(93, 12);
            this.btnNodo.Name = "btnNodo";
            this.btnNodo.Size = new System.Drawing.Size(75, 23);
            this.btnNodo.TabIndex = 1;
            this.btnNodo.Text = "Nodo";
            this.btnNodo.UseVisualStyleBackColor = true;
            this.btnNodo.Click += new System.EventHandler(this.btnNodo_Click);
            // 
            // btnPointer
            // 
            this.btnPointer.Location = new System.Drawing.Point(12, 12);
            this.btnPointer.Name = "btnPointer";
            this.btnPointer.Size = new System.Drawing.Size(75, 23);
            this.btnPointer.TabIndex = 0;
            this.btnPointer.Text = "Puntatore";
            this.btnPointer.UseVisualStyleBackColor = true;
            this.btnPointer.Click += new System.EventHandler(this.btnPointer_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1384, 761);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.canvas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox canvas;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnPointer;
        private System.Windows.Forms.Button btnNodo;
    }
}

