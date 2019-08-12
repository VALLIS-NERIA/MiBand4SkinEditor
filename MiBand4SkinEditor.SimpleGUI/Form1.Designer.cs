using System.Drawing;

namespace MiBand4SkinEditor.SimpleGUI {
    partial class Form1 {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent() {
            this.editingPictureBox = new System.Windows.Forms.PictureBox();
            this.originBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.editingPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.originBox)).BeginInit();
            this.SuspendLayout();
            // 
            // editingPictureBox
            // 
            this.editingPictureBox.AllowDrop = true;
            this.editingPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.editingPictureBox.Location = new System.Drawing.Point(12, 12);
            this.editingPictureBox.Name = "editingPictureBox";
            this.editingPictureBox.Size = new System.Drawing.Size(120, 240);
            this.editingPictureBox.TabIndex = 0;
            this.editingPictureBox.TabStop = false;
            // 
            // originBox
            // 
            this.originBox.AllowDrop = true;
            this.originBox.BackColor = System.Drawing.Color.Transparent;
            this.originBox.Location = new System.Drawing.Point(138, 12);
            this.originBox.Name = "originBox";
            this.originBox.Size = new System.Drawing.Size(120, 240);
            this.originBox.TabIndex = 1;
            this.originBox.TabStop = false;
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 264);
            this.Controls.Add(this.originBox);
            this.Controls.Add(this.editingPictureBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            ((System.ComponentModel.ISupportInitialize)(this.editingPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.originBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox editingPictureBox;
        private System.Windows.Forms.PictureBox originBox;
    }
}

