
namespace testNo3.UITools
{
    partial class Toggle
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Toggle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::testNo3.Properties.Resources.Toggle_off;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.DoubleBuffered = true;
            this.Name = "Toggle";
            this.Size = new System.Drawing.Size(46, 31);
            this.Click += new System.EventHandler(this.Toggle_Click);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Toggle_KeyDown);
            this.MouseEnter += new System.EventHandler(this.Toggle_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.Toggle_MouseLeave);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
