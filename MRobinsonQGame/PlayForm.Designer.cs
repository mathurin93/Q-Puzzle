namespace MRobinsonQGame
{
    partial class PlayForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayForm));
            this.gamePanel = new System.Windows.Forms.Panel();
            this.btnUp = new System.Windows.Forms.Button();
            this.lblNumofMoves = new System.Windows.Forms.Label();
            this.txtboxNumofMoves = new System.Windows.Forms.TextBox();
            this.lblRemainingMen = new System.Windows.Forms.Label();
            this.txtboxRemaingMen = new System.Windows.Forms.TextBox();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.File = new System.Windows.Forms.ToolStripSplitButton();
            this.loadGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gamePanel
            // 
            this.gamePanel.Location = new System.Drawing.Point(11, 54);
            this.gamePanel.Margin = new System.Windows.Forms.Padding(2);
            this.gamePanel.Name = "gamePanel";
            this.gamePanel.Size = new System.Drawing.Size(974, 527);
            this.gamePanel.TabIndex = 0;
            // 
            // btnUp
            // 
            this.btnUp.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnUp.Location = new System.Drawing.Point(1090, 359);
            this.btnUp.Margin = new System.Windows.Forms.Padding(2);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(56, 38);
            this.btnUp.TabIndex = 1;
            this.btnUp.Text = "Up\r\n";
            this.btnUp.UseVisualStyleBackColor = false;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // lblNumofMoves
            // 
            this.lblNumofMoves.AutoSize = true;
            this.lblNumofMoves.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumofMoves.ForeColor = System.Drawing.Color.Red;
            this.lblNumofMoves.Location = new System.Drawing.Point(1021, 54);
            this.lblNumofMoves.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNumofMoves.Name = "lblNumofMoves";
            this.lblNumofMoves.Size = new System.Drawing.Size(136, 20);
            this.lblNumofMoves.TabIndex = 2;
            this.lblNumofMoves.Text = "Number Of Moves";
            // 
            // txtboxNumofMoves
            // 
            this.txtboxNumofMoves.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtboxNumofMoves.Location = new System.Drawing.Point(1025, 97);
            this.txtboxNumofMoves.Margin = new System.Windows.Forms.Padding(2);
            this.txtboxNumofMoves.Name = "txtboxNumofMoves";
            this.txtboxNumofMoves.Size = new System.Drawing.Size(76, 20);
            this.txtboxNumofMoves.TabIndex = 3;
            // 
            // lblRemainingMen
            // 
            this.lblRemainingMen.AutoSize = true;
            this.lblRemainingMen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemainingMen.ForeColor = System.Drawing.Color.Red;
            this.lblRemainingMen.Location = new System.Drawing.Point(1021, 119);
            this.lblRemainingMen.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRemainingMen.Name = "lblRemainingMen";
            this.lblRemainingMen.Size = new System.Drawing.Size(201, 20);
            this.lblRemainingMen.TabIndex = 4;
            this.lblRemainingMen.Text = "Number Of Remaining Men";
            // 
            // txtboxRemaingMen
            // 
            this.txtboxRemaingMen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtboxRemaingMen.Location = new System.Drawing.Point(1025, 153);
            this.txtboxRemaingMen.Margin = new System.Windows.Forms.Padding(2);
            this.txtboxRemaingMen.Name = "txtboxRemaingMen";
            this.txtboxRemaingMen.Size = new System.Drawing.Size(76, 20);
            this.txtboxRemaingMen.TabIndex = 5;
            // 
            // btnDown
            // 
            this.btnDown.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnDown.Location = new System.Drawing.Point(1090, 443);
            this.btnDown.Margin = new System.Windows.Forms.Padding(2);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(56, 38);
            this.btnDown.TabIndex = 6;
            this.btnDown.Text = "Down";
            this.btnDown.UseVisualStyleBackColor = false;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnRight
            // 
            this.btnRight.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnRight.Location = new System.Drawing.Point(1133, 401);
            this.btnRight.Margin = new System.Windows.Forms.Padding(2);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(41, 38);
            this.btnRight.TabIndex = 7;
            this.btnRight.Text = "Right";
            this.btnRight.UseVisualStyleBackColor = false;
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // btnLeft
            // 
            this.btnLeft.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnLeft.Location = new System.Drawing.Point(1051, 401);
            this.btnLeft.Margin = new System.Windows.Forms.Padding(2);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(41, 38);
            this.btnLeft.TabIndex = 8;
            this.btnLeft.Text = "Left";
            this.btnLeft.UseVisualStyleBackColor = false;
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.File});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1242, 32);
            this.toolStrip1.TabIndex = 9;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // File
            // 
            this.File.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadGameToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.File.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.File.ForeColor = System.Drawing.Color.Red;
            this.File.Image = ((System.Drawing.Image)(resources.GetObject("File.Image")));
            this.File.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.File.Name = "File";
            this.File.Size = new System.Drawing.Size(57, 29);
            this.File.Text = "File";
            // 
            // loadGameToolStripMenuItem
            // 
            this.loadGameToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.loadGameToolStripMenuItem.ForeColor = System.Drawing.Color.Navy;
            this.loadGameToolStripMenuItem.Name = "loadGameToolStripMenuItem";
            this.loadGameToolStripMenuItem.Size = new System.Drawing.Size(161, 26);
            this.loadGameToolStripMenuItem.Text = "Load Game";
            this.loadGameToolStripMenuItem.Click += new System.EventHandler(this.loadGameToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeToolStripMenuItem.ForeColor = System.Drawing.Color.Navy;
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(161, 26);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // PlayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1242, 592);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.btnLeft);
            this.Controls.Add(this.btnRight);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.txtboxRemaingMen);
            this.Controls.Add(this.lblRemainingMen);
            this.Controls.Add(this.txtboxNumofMoves);
            this.Controls.Add(this.lblNumofMoves);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.gamePanel);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "PlayForm";
            this.Text = "PlayForm";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel gamePanel;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Label lblNumofMoves;
        private System.Windows.Forms.TextBox txtboxNumofMoves;
        private System.Windows.Forms.Label lblRemainingMen;
        private System.Windows.Forms.TextBox txtboxRemaingMen;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSplitButton File;
        private System.Windows.Forms.ToolStripMenuItem loadGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
    }
}