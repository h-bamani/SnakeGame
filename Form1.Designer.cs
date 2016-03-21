namespace SnakeGame
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
            this.pbGameBoard = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPoints = new System.Windows.Forms.Label();
            this.timerGame = new System.Windows.Forms.Timer(this.components);
            this.lblEnd = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbGameBoard)).BeginInit();
            this.SuspendLayout();
            // 
            // pbGameBoard
            // 
            this.pbGameBoard.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbGameBoard.Location = new System.Drawing.Point(12, 12);
            this.pbGameBoard.Name = "pbGameBoard";
            this.pbGameBoard.Size = new System.Drawing.Size(994, 490);
            this.pbGameBoard.TabIndex = 0;
            this.pbGameBoard.TabStop = false;
            this.pbGameBoard.Paint += new System.Windows.Forms.PaintEventHandler(this.pbGameBoard_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 528);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 33);
            this.label1.TabIndex = 1;
            this.label1.Text = "Score:";
            // 
            // lblPoints
            // 
            this.lblPoints.AutoSize = true;
            this.lblPoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPoints.Location = new System.Drawing.Point(149, 528);
            this.lblPoints.Name = "lblPoints";
            this.lblPoints.Size = new System.Drawing.Size(0, 33);
            this.lblPoints.TabIndex = 2;
            // 
            // lblEnd
            // 
            this.lblEnd.AutoSize = true;
            this.lblEnd.Font = new System.Drawing.Font("Monotype Corsiva", 26.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnd.Location = new System.Drawing.Point(243, 155);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new System.Drawing.Size(98, 43);
            this.lblEnd.TabIndex = 3;
            this.lblEnd.Text = "label2";
            this.lblEnd.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1018, 574);
            this.Controls.Add(this.lblEnd);
            this.Controls.Add(this.pbGameBoard);
            this.Controls.Add(this.lblPoints);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pbGameBoard)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbGameBoard;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPoints;
        private System.Windows.Forms.Timer timerGame;
        private System.Windows.Forms.Label lblEnd;
    }
}

