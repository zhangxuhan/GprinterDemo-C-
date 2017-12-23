namespace POSdllDemo
{
    partial class Form1
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cb_SaveFile = new System.Windows.Forms.CheckBox();
            this.cb_1D_76_30 = new System.Windows.Forms.ComboBox();
            this.gb76BlackMark = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btPrintGoNextCut = new System.Windows.Forms.Button();
            this.btPrintGoNext = new System.Windows.Forms.Button();
            this.tbCutMarkBack = new System.Windows.Forms.TextBox();
            this.btCutMarkBack = new System.Windows.Forms.Button();
            this.tbCutMarkGo = new System.Windows.Forms.TextBox();
            this.btCutMarkGo = new System.Windows.Forms.Button();
            this.tbCheckMarkBack = new System.Windows.Forms.TextBox();
            this.btCheckMarkBack = new System.Windows.Forms.Button();
            this.tbCheckMarkGo = new System.Windows.Forms.TextBox();
            this.btCheckMarkGo = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.gb76BlackMark.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(9, 30);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 34);
            this.button1.TabIndex = 0;
            this.button1.Text = "网口测试";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(9, 248);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(128, 34);
            this.button2.TabIndex = 1;
            this.button2.Text = "USB 票据测试";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(9, 30);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(128, 34);
            this.button3.TabIndex = 1;
            this.button3.Text = "USB 条码测试";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(9, 74);
            this.button4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(128, 34);
            this.button4.TabIndex = 2;
            this.button4.Text = "打印光栅位图";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cb_SaveFile);
            this.groupBox1.Controls.Add(this.cb_1D_76_30);
            this.groupBox1.Controls.Add(this.gb76BlackMark);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Location = new System.Drawing.Point(18, 18);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(706, 302);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "票据打印机";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // cb_SaveFile
            // 
            this.cb_SaveFile.AutoSize = true;
            this.cb_SaveFile.Location = new System.Drawing.Point(9, 117);
            this.cb_SaveFile.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cb_SaveFile.Name = "cb_SaveFile";
            this.cb_SaveFile.Size = new System.Drawing.Size(106, 22);
            this.cb_SaveFile.TabIndex = 390;
            this.cb_SaveFile.Text = "保存数据";
            this.cb_SaveFile.UseVisualStyleBackColor = true;
            // 
            // cb_1D_76_30
            // 
            this.cb_1D_76_30.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_1D_76_30.FormattingEnabled = true;
            this.cb_1D_76_30.Items.AddRange(new object[] {
            "原始大小",
            "双倍宽",
            "双倍高",
            "倍宽、倍高"});
            this.cb_1D_76_30.Location = new System.Drawing.Point(9, 150);
            this.cb_1D_76_30.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cb_1D_76_30.Name = "cb_1D_76_30";
            this.cb_1D_76_30.Size = new System.Drawing.Size(126, 26);
            this.cb_1D_76_30.TabIndex = 362;
            this.cb_1D_76_30.Text = "原始大小";
            this.cb_1D_76_30.SelectedIndexChanged += new System.EventHandler(this.cb_1D_76_30_SelectedIndexChanged);
            // 
            // gb76BlackMark
            // 
            this.gb76BlackMark.Controls.Add(this.label5);
            this.gb76BlackMark.Controls.Add(this.label4);
            this.gb76BlackMark.Controls.Add(this.btPrintGoNextCut);
            this.gb76BlackMark.Controls.Add(this.btPrintGoNext);
            this.gb76BlackMark.Controls.Add(this.tbCutMarkBack);
            this.gb76BlackMark.Controls.Add(this.btCutMarkBack);
            this.gb76BlackMark.Controls.Add(this.tbCutMarkGo);
            this.gb76BlackMark.Controls.Add(this.btCutMarkGo);
            this.gb76BlackMark.Controls.Add(this.tbCheckMarkBack);
            this.gb76BlackMark.Controls.Add(this.btCheckMarkBack);
            this.gb76BlackMark.Controls.Add(this.tbCheckMarkGo);
            this.gb76BlackMark.Controls.Add(this.btCheckMarkGo);
            this.gb76BlackMark.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gb76BlackMark.Location = new System.Drawing.Point(146, 15);
            this.gb76BlackMark.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gb76BlackMark.Name = "gb76BlackMark";
            this.gb76BlackMark.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gb76BlackMark.Size = new System.Drawing.Size(542, 279);
            this.gb76BlackMark.TabIndex = 7;
            this.gb76BlackMark.TabStop = false;
            this.gb76BlackMark.Text = "76黑标定位偏移量设置(串口)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(440, 30);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 18);
            this.label5.TabIndex = 21;
            this.label5.Text = "毫米处";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(440, 156);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 18);
            this.label4.TabIndex = 20;
            this.label4.Text = "毫米处";
            // 
            // btPrintGoNextCut
            // 
            this.btPrintGoNextCut.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btPrintGoNextCut.Location = new System.Drawing.Point(9, 232);
            this.btPrintGoNextCut.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btPrintGoNextCut.Name = "btPrintGoNextCut";
            this.btPrintGoNextCut.Size = new System.Drawing.Size(351, 34);
            this.btPrintGoNextCut.TabIndex = 15;
            this.btPrintGoNextCut.Text = "打印并走纸到下一个切撕纸位置";
            this.btPrintGoNextCut.UseVisualStyleBackColor = true;
            this.btPrintGoNextCut.Click += new System.EventHandler(this.btPrintGoNextCut_Click);
            // 
            // btPrintGoNext
            // 
            this.btPrintGoNext.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btPrintGoNext.Location = new System.Drawing.Point(9, 190);
            this.btPrintGoNext.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btPrintGoNext.Name = "btPrintGoNext";
            this.btPrintGoNext.Size = new System.Drawing.Size(351, 34);
            this.btPrintGoNext.TabIndex = 12;
            this.btPrintGoNext.Text = "打印并走纸到下一个起始打印位置";
            this.btPrintGoNext.UseVisualStyleBackColor = true;
            this.btPrintGoNext.Click += new System.EventHandler(this.btPrintGoNext_Click);
            // 
            // tbCutMarkBack
            // 
            this.tbCutMarkBack.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbCutMarkBack.Location = new System.Drawing.Point(364, 150);
            this.tbCutMarkBack.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbCutMarkBack.MaxLength = 5;
            this.tbCutMarkBack.Name = "tbCutMarkBack";
            this.tbCutMarkBack.Size = new System.Drawing.Size(72, 28);
            this.tbCutMarkBack.TabIndex = 11;
            this.tbCutMarkBack.Text = "0";
            // 
            // btCutMarkBack
            // 
            this.btCutMarkBack.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btCutMarkBack.Location = new System.Drawing.Point(9, 148);
            this.btCutMarkBack.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btCutMarkBack.Name = "btCutMarkBack";
            this.btCutMarkBack.Size = new System.Drawing.Size(351, 34);
            this.btCutMarkBack.TabIndex = 9;
            this.btCutMarkBack.Text = "切/撕纸位置在检测到黑标位置后后退";
            this.btCutMarkBack.UseVisualStyleBackColor = true;
            this.btCutMarkBack.Click += new System.EventHandler(this.btCutMarkBack_Click);
            // 
            // tbCutMarkGo
            // 
            this.tbCutMarkGo.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbCutMarkGo.Location = new System.Drawing.Point(364, 108);
            this.tbCutMarkGo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbCutMarkGo.MaxLength = 5;
            this.tbCutMarkGo.Name = "tbCutMarkGo";
            this.tbCutMarkGo.Size = new System.Drawing.Size(72, 28);
            this.tbCutMarkGo.TabIndex = 8;
            this.tbCutMarkGo.Text = "0";
            // 
            // btCutMarkGo
            // 
            this.btCutMarkGo.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btCutMarkGo.Location = new System.Drawing.Point(9, 106);
            this.btCutMarkGo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btCutMarkGo.Name = "btCutMarkGo";
            this.btCutMarkGo.Size = new System.Drawing.Size(351, 34);
            this.btCutMarkGo.TabIndex = 6;
            this.btCutMarkGo.Text = "切/撕纸位置在检测到黑标位置后前进";
            this.btCutMarkGo.UseVisualStyleBackColor = true;
            this.btCutMarkGo.Click += new System.EventHandler(this.btCutMarkGo_Click);
            // 
            // tbCheckMarkBack
            // 
            this.tbCheckMarkBack.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbCheckMarkBack.Location = new System.Drawing.Point(364, 66);
            this.tbCheckMarkBack.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbCheckMarkBack.MaxLength = 5;
            this.tbCheckMarkBack.Name = "tbCheckMarkBack";
            this.tbCheckMarkBack.Size = new System.Drawing.Size(72, 28);
            this.tbCheckMarkBack.TabIndex = 5;
            this.tbCheckMarkBack.Text = "0";
            // 
            // btCheckMarkBack
            // 
            this.btCheckMarkBack.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btCheckMarkBack.Location = new System.Drawing.Point(9, 64);
            this.btCheckMarkBack.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btCheckMarkBack.Name = "btCheckMarkBack";
            this.btCheckMarkBack.Size = new System.Drawing.Size(351, 34);
            this.btCheckMarkBack.TabIndex = 3;
            this.btCheckMarkBack.Text = "起始打印位置在检测到黑标位置后后退";
            this.btCheckMarkBack.UseVisualStyleBackColor = true;
            this.btCheckMarkBack.Click += new System.EventHandler(this.btCheckMarkBack_Click);
            // 
            // tbCheckMarkGo
            // 
            this.tbCheckMarkGo.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbCheckMarkGo.Location = new System.Drawing.Point(364, 24);
            this.tbCheckMarkGo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbCheckMarkGo.MaxLength = 5;
            this.tbCheckMarkGo.Name = "tbCheckMarkGo";
            this.tbCheckMarkGo.Size = new System.Drawing.Size(72, 28);
            this.tbCheckMarkGo.TabIndex = 2;
            this.tbCheckMarkGo.Text = "0";
            // 
            // btCheckMarkGo
            // 
            this.btCheckMarkGo.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btCheckMarkGo.Location = new System.Drawing.Point(9, 22);
            this.btCheckMarkGo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btCheckMarkGo.Name = "btCheckMarkGo";
            this.btCheckMarkGo.Size = new System.Drawing.Size(351, 34);
            this.btCheckMarkGo.TabIndex = 0;
            this.btCheckMarkGo.Text = "起始打印位置在检测到黑标位置后前进";
            this.btCheckMarkGo.UseVisualStyleBackColor = true;
            this.btCheckMarkGo.Click += new System.EventHandler(this.btCheckMarkGo_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button5);
            this.groupBox2.Controls.Add(this.button6);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Location = new System.Drawing.Point(18, 328);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(706, 104);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "标签打印机";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(291, 30);
            this.button5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(128, 34);
            this.button5.TabIndex = 3;
            this.button5.Text = "串口条码测试";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click_1);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(154, 30);
            this.button6.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(128, 34);
            this.button6.TabIndex = 2;
            this.button6.Text = "BITMAP指令";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 543);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gb76BlackMark.ResumeLayout(false);
            this.gb76BlackMark.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.GroupBox gb76BlackMark;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btPrintGoNextCut;
        private System.Windows.Forms.Button btPrintGoNext;
        private System.Windows.Forms.TextBox tbCutMarkBack;
        private System.Windows.Forms.Button btCutMarkBack;
        private System.Windows.Forms.TextBox tbCutMarkGo;
        private System.Windows.Forms.Button btCutMarkGo;
        private System.Windows.Forms.TextBox tbCheckMarkBack;
        private System.Windows.Forms.Button btCheckMarkBack;
        private System.Windows.Forms.TextBox tbCheckMarkGo;
        private System.Windows.Forms.Button btCheckMarkGo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.ComboBox cb_1D_76_30;
        public System.Windows.Forms.CheckBox cb_SaveFile;
        private System.Windows.Forms.Button button5;
    }
}

