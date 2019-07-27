namespace CopyImgDemo
{
    partial class MainFrm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrm));
            this.tbBeforeCopy = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBeforeCopy = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbAfterCopy = new System.Windows.Forms.TextBox();
            this.btnAfterCopy = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnSet = new System.Windows.Forms.Button();
            this.rbSingleImg = new System.Windows.Forms.RadioButton();
            this.rbMultipleImg = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbBeforeCopy
            // 
            this.tbBeforeCopy.Enabled = false;
            this.tbBeforeCopy.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbBeforeCopy.Location = new System.Drawing.Point(137, 78);
            this.tbBeforeCopy.Name = "tbBeforeCopy";
            this.tbBeforeCopy.Size = new System.Drawing.Size(240, 30);
            this.tbBeforeCopy.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(12, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "拷贝前路径:";
            // 
            // btnBeforeCopy
            // 
            this.btnBeforeCopy.Location = new System.Drawing.Point(393, 78);
            this.btnBeforeCopy.Name = "btnBeforeCopy";
            this.btnBeforeCopy.Size = new System.Drawing.Size(72, 30);
            this.btnBeforeCopy.TabIndex = 2;
            this.btnBeforeCopy.Text = "...";
            this.btnBeforeCopy.UseVisualStyleBackColor = true;
            this.btnBeforeCopy.Click += new System.EventHandler(this.btnBeforeCopy_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(12, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "拷贝后路径:";
            // 
            // tbAfterCopy
            // 
            this.tbAfterCopy.Enabled = false;
            this.tbAfterCopy.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbAfterCopy.Location = new System.Drawing.Point(137, 134);
            this.tbAfterCopy.Name = "tbAfterCopy";
            this.tbAfterCopy.Size = new System.Drawing.Size(240, 30);
            this.tbAfterCopy.TabIndex = 4;
            // 
            // btnAfterCopy
            // 
            this.btnAfterCopy.Location = new System.Drawing.Point(393, 135);
            this.btnAfterCopy.Name = "btnAfterCopy";
            this.btnAfterCopy.Size = new System.Drawing.Size(72, 30);
            this.btnAfterCopy.TabIndex = 5;
            this.btnAfterCopy.Text = "...";
            this.btnAfterCopy.UseVisualStyleBackColor = true;
            this.btnAfterCopy.Click += new System.EventHandler(this.btnAfterCopy_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(12, 205);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(126, 59);
            this.btnStart.TabIndex = 6;
            this.btnStart.Text = "开始";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(173, 205);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(126, 59);
            this.btnStop.TabIndex = 7;
            this.btnStop.Text = "停止";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnSet
            // 
            this.btnSet.Location = new System.Drawing.Point(339, 205);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(126, 59);
            this.btnSet.TabIndex = 8;
            this.btnSet.Text = "保存设置";
            this.btnSet.UseVisualStyleBackColor = true;
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // rbSingleImg
            // 
            this.rbSingleImg.AutoSize = true;
            this.rbSingleImg.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rbSingleImg.Location = new System.Drawing.Point(14, 15);
            this.rbSingleImg.Name = "rbSingleImg";
            this.rbSingleImg.Size = new System.Drawing.Size(112, 25);
            this.rbSingleImg.TabIndex = 9;
            this.rbSingleImg.TabStop = true;
            this.rbSingleImg.Text = "单张模式";
            this.rbSingleImg.UseVisualStyleBackColor = true;
            // 
            // rbMultipleImg
            // 
            this.rbMultipleImg.AutoSize = true;
            this.rbMultipleImg.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rbMultipleImg.Location = new System.Drawing.Point(164, 15);
            this.rbMultipleImg.Name = "rbMultipleImg";
            this.rbMultipleImg.Size = new System.Drawing.Size(112, 25);
            this.rbMultipleImg.TabIndex = 10;
            this.rbMultipleImg.TabStop = true;
            this.rbMultipleImg.Text = "多张模式";
            this.rbMultipleImg.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbSingleImg);
            this.panel1.Controls.Add(this.rbMultipleImg);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(453, 47);
            this.panel1.TabIndex = 11;
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 281);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnSet);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnAfterCopy);
            this.Controls.Add(this.tbAfterCopy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnBeforeCopy);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbBeforeCopy);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(490, 320);
            this.MinimumSize = new System.Drawing.Size(490, 320);
            this.Name = "MainFrm";
            this.Text = "图像拷贝 V1.0.0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFrm_FormClosing);
            this.Load += new System.EventHandler(this.MainFrm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbBeforeCopy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBeforeCopy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbAfterCopy;
        private System.Windows.Forms.Button btnAfterCopy;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnSet;
        private System.Windows.Forms.RadioButton rbSingleImg;
        private System.Windows.Forms.RadioButton rbMultipleImg;
        private System.Windows.Forms.Panel panel1;
    }
}

