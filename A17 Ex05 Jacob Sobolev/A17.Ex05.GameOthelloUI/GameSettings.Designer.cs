namespace A17.Ex05.GameOthelloUI
{
    public partial class GameSettings
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
            this.buttonIncBoardSize = new System.Windows.Forms.Button();
            this.buttonGamePlayPc = new System.Windows.Forms.Button();
            this.buttonGamePlayHuman = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonIncBoardSize
            // 
            this.buttonIncBoardSize.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonIncBoardSize.Location = new System.Drawing.Point(10, 10);
            this.buttonIncBoardSize.Margin = new System.Windows.Forms.Padding(5);
            this.buttonIncBoardSize.Name = "buttonIncBoardSize";
            this.buttonIncBoardSize.Size = new System.Drawing.Size(350, 39);
            this.buttonIncBoardSize.TabIndex = 0;
            this.buttonIncBoardSize.Text = "Board Size";
            this.buttonIncBoardSize.UseVisualStyleBackColor = true;
            this.buttonIncBoardSize.Click += new System.EventHandler(this.buttonIncBoardSize_Click);
            // 
            // buttonGamePlayPc
            // 
            this.buttonGamePlayPc.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonGamePlayPc.Location = new System.Drawing.Point(10, 57);
            this.buttonGamePlayPc.Name = "buttonGamePlayPc";
            this.buttonGamePlayPc.Size = new System.Drawing.Size(168, 42);
            this.buttonGamePlayPc.TabIndex = 1;
            this.buttonGamePlayPc.Text = "Play against the PC";
            this.buttonGamePlayPc.UseVisualStyleBackColor = true;
            this.buttonGamePlayPc.Click += new System.EventHandler(this.buttonGameStart_Click);
            // 
            // buttonGamePlayHuman
            // 
            this.buttonGamePlayHuman.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonGamePlayHuman.Location = new System.Drawing.Point(184, 57);
            this.buttonGamePlayHuman.Name = "buttonGamePlayHuman";
            this.buttonGamePlayHuman.Size = new System.Drawing.Size(176, 42);
            this.buttonGamePlayHuman.TabIndex = 2;
            this.buttonGamePlayHuman.Text = "Play against your friend";
            this.buttonGamePlayHuman.UseVisualStyleBackColor = true;
            this.buttonGamePlayHuman.Click += new System.EventHandler(this.buttonGameStart_Click);
            // 
            // GameSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 112);
            this.Controls.Add(this.buttonGamePlayHuman);
            this.Controls.Add(this.buttonGamePlayPc);
            this.Controls.Add(this.buttonIncBoardSize);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GameSettings";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GameSettings";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonIncBoardSize;
        private System.Windows.Forms.Button buttonGamePlayPc;
        private System.Windows.Forms.Button buttonGamePlayHuman;
    }
}