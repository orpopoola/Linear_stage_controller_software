namespace csharp
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

        public SerialPortLibrary.SPLibClass mMCcard = new SerialPortLibrary.SPLibClass();

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.xaxis = new System.Windows.Forms.Button();
            this.yaxis = new System.Windows.Forms.Button();
            this.zaxis = new System.Windows.Forms.Button();
            this.reset = new System.Windows.Forms.Button();
            this.xyaxis = new System.Windows.Forms.Button();
            this.xzaxis = new System.Windows.Forms.Button();
            this.yzaxis = new System.Windows.Forms.Button();
            this.unload = new System.Windows.Forms.Button();
            this.roll = new System.Windows.Forms.Button();
            this.rollpitch = new System.Windows.Forms.Button();
            this.pitch = new System.Windows.Forms.Button();
            this.rollyaw = new System.Windows.Forms.Button();
            this.yaw = new System.Windows.Forms.Button();
            this.pitchyaw = new System.Windows.Forms.Button();
            this.rpy = new System.Windows.Forms.Button();
            this.statStrip = new System.Windows.Forms.StatusStrip();
            this.statStripText = new System.Windows.Forms.ToolStripStatusLabel();
            this.stop = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ztext = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ytext = new System.Windows.Forms.TextBox();
            this.xtext = new System.Windows.Forms.TextBox();
            this.rtext = new System.Windows.Forms.TextBox();
            this.yawtext = new System.Windows.Forms.TextBox();
            this.ptext = new System.Windows.Forms.TextBox();
            this.statStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // xaxis
            // 
            this.xaxis.Location = new System.Drawing.Point(12, 218);
            this.xaxis.Name = "xaxis";
            this.xaxis.Size = new System.Drawing.Size(75, 23);
            this.xaxis.TabIndex = 0;
            this.xaxis.Tag = "x_axis";
            this.xaxis.Text = "X_axis";
            this.xaxis.UseVisualStyleBackColor = true;
            this.xaxis.Click += new System.EventHandler(this.xaxis_Click);
            // 
            // yaxis
            // 
            this.yaxis.Location = new System.Drawing.Point(93, 218);
            this.yaxis.Name = "yaxis";
            this.yaxis.Size = new System.Drawing.Size(75, 23);
            this.yaxis.TabIndex = 1;
            this.yaxis.Tag = "y_axis";
            this.yaxis.Text = "Y_axis";
            this.yaxis.UseVisualStyleBackColor = true;
            this.yaxis.Click += new System.EventHandler(this.yaxis_Click);
            // 
            // zaxis
            // 
            this.zaxis.Location = new System.Drawing.Point(174, 218);
            this.zaxis.Name = "zaxis";
            this.zaxis.Size = new System.Drawing.Size(75, 23);
            this.zaxis.TabIndex = 2;
            this.zaxis.Tag = "z_axis";
            this.zaxis.Text = "Z_axis";
            this.zaxis.UseVisualStyleBackColor = true;
            this.zaxis.Click += new System.EventHandler(this.zaxis_Click);
            // 
            // reset
            // 
            this.reset.Location = new System.Drawing.Point(255, 276);
            this.reset.Name = "reset";
            this.reset.Size = new System.Drawing.Size(75, 23);
            this.reset.TabIndex = 3;
            this.reset.Text = "Reset";
            this.reset.UseVisualStyleBackColor = true;
            this.reset.Click += new System.EventHandler(this.reset_Click);
            // 
            // xyaxis
            // 
            this.xyaxis.Location = new System.Drawing.Point(12, 247);
            this.xyaxis.Name = "xyaxis";
            this.xyaxis.Size = new System.Drawing.Size(75, 23);
            this.xyaxis.TabIndex = 4;
            this.xyaxis.Tag = "xy_axis";
            this.xyaxis.Text = "XY_axis";
            this.xyaxis.UseVisualStyleBackColor = true;
            this.xyaxis.Click += new System.EventHandler(this.xyaxis_Click);
            // 
            // xzaxis
            // 
            this.xzaxis.Location = new System.Drawing.Point(93, 247);
            this.xzaxis.Name = "xzaxis";
            this.xzaxis.Size = new System.Drawing.Size(75, 23);
            this.xzaxis.TabIndex = 5;
            this.xzaxis.Tag = "xz_axis";
            this.xzaxis.Text = "XZ_axis";
            this.xzaxis.UseVisualStyleBackColor = true;
            this.xzaxis.Click += new System.EventHandler(this.xzaxis_Click);
            // 
            // yzaxis
            // 
            this.yzaxis.Location = new System.Drawing.Point(174, 247);
            this.yzaxis.Name = "yzaxis";
            this.yzaxis.Size = new System.Drawing.Size(75, 23);
            this.yzaxis.TabIndex = 6;
            this.yzaxis.Tag = "yz_axis";
            this.yzaxis.Text = "YZ_axis";
            this.yzaxis.UseVisualStyleBackColor = true;
            this.yzaxis.Click += new System.EventHandler(this.yzaxis_Click);
            // 
            // unload
            // 
            this.unload.Location = new System.Drawing.Point(255, 247);
            this.unload.Name = "unload";
            this.unload.Size = new System.Drawing.Size(75, 23);
            this.unload.TabIndex = 7;
            this.unload.Text = "Unload";
            this.unload.UseVisualStyleBackColor = true;
            this.unload.Click += new System.EventHandler(this.unload_Click);
            // 
            // roll
            // 
            this.roll.Location = new System.Drawing.Point(174, 276);
            this.roll.Name = "roll";
            this.roll.Size = new System.Drawing.Size(75, 23);
            this.roll.TabIndex = 8;
            this.roll.Tag = "roll";
            this.roll.Text = "Roll";
            this.roll.UseVisualStyleBackColor = true;
            // 
            // rollpitch
            // 
            this.rollpitch.Location = new System.Drawing.Point(12, 305);
            this.rollpitch.Name = "rollpitch";
            this.rollpitch.Size = new System.Drawing.Size(75, 23);
            this.rollpitch.TabIndex = 9;
            this.rollpitch.Tag = "roll_pitch";
            this.rollpitch.Text = "Roll Pitch";
            this.rollpitch.UseVisualStyleBackColor = true;
            // 
            // pitch
            // 
            this.pitch.Location = new System.Drawing.Point(12, 276);
            this.pitch.Name = "pitch";
            this.pitch.Size = new System.Drawing.Size(75, 23);
            this.pitch.TabIndex = 10;
            this.pitch.Tag = "pitch";
            this.pitch.Text = "Pitch";
            this.pitch.UseVisualStyleBackColor = true;
            // 
            // rollyaw
            // 
            this.rollyaw.Location = new System.Drawing.Point(93, 305);
            this.rollyaw.Name = "rollyaw";
            this.rollyaw.Size = new System.Drawing.Size(75, 23);
            this.rollyaw.TabIndex = 11;
            this.rollyaw.Tag = "roll_yaw";
            this.rollyaw.Text = "Roll Yaw";
            this.rollyaw.UseVisualStyleBackColor = true;
            // 
            // yaw
            // 
            this.yaw.Location = new System.Drawing.Point(93, 276);
            this.yaw.Name = "yaw";
            this.yaw.Size = new System.Drawing.Size(75, 23);
            this.yaw.TabIndex = 12;
            this.yaw.Tag = "yaw";
            this.yaw.Text = "Yaw";
            this.yaw.UseVisualStyleBackColor = true;
            // 
            // pitchyaw
            // 
            this.pitchyaw.Location = new System.Drawing.Point(174, 305);
            this.pitchyaw.Name = "pitchyaw";
            this.pitchyaw.Size = new System.Drawing.Size(75, 23);
            this.pitchyaw.TabIndex = 13;
            this.pitchyaw.Tag = "pitch_yaw";
            this.pitchyaw.Text = "Pi Yaw";
            this.pitchyaw.UseVisualStyleBackColor = true;
            // 
            // rpy
            // 
            this.rpy.Location = new System.Drawing.Point(255, 305);
            this.rpy.Name = "rpy";
            this.rpy.Size = new System.Drawing.Size(75, 23);
            this.rpy.TabIndex = 14;
            this.rpy.Tag = "r_p_y";
            this.rpy.Text = "RPY";
            this.rpy.UseVisualStyleBackColor = true;
            this.rpy.Click += new System.EventHandler(this.rpy_Click);
            // 
            // statStrip
            // 
            this.statStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statStripText});
            this.statStrip.Location = new System.Drawing.Point(0, 343);
            this.statStrip.Name = "statStrip";
            this.statStrip.Size = new System.Drawing.Size(336, 22);
            this.statStrip.TabIndex = 15;
            this.statStrip.Tag = "statStrip";
            this.statStrip.Text = "statusStrip";
            // 
            // statStripText
            // 
            this.statStripText.Name = "statStripText";
            this.statStripText.Size = new System.Drawing.Size(0, 16);
            // 
            // stop
            // 
            this.stop.Location = new System.Drawing.Point(255, 218);
            this.stop.Name = "stop";
            this.stop.Size = new System.Drawing.Size(75, 23);
            this.stop.TabIndex = 16;
            this.stop.Tag = "stop";
            this.stop.Text = "Stop";
            this.stop.UseVisualStyleBackColor = true;
            this.stop.Click += new System.EventHandler(this.stop_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 167);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 17;
            this.label1.Text = "Z Axis";
            // 
            // ztext
            // 
            this.ztext.Location = new System.Drawing.Point(61, 162);
            this.ztext.Name = "ztext";
            this.ztext.Size = new System.Drawing.Size(107, 22);
            this.ztext.TabIndex = 18;
            this.ztext.Tag = "z_text";
            this.ztext.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 17);
            this.label2.TabIndex = 19;
            this.label2.Text = "Y Axis";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 17);
            this.label3.TabIndex = 20;
            this.label3.Tag = "x_val";
            this.label3.Text = "X Axis";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(177, 167);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 17);
            this.label4.TabIndex = 21;
            this.label4.Text = "Roll";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(177, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 17);
            this.label5.TabIndex = 22;
            this.label5.Text = "Yaw";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(177, 110);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 17);
            this.label6.TabIndex = 23;
            this.label6.Text = "Pitch";
            // 
            // ytext
            // 
            this.ytext.Location = new System.Drawing.Point(61, 136);
            this.ytext.Name = "ytext";
            this.ytext.Size = new System.Drawing.Size(107, 22);
            this.ytext.TabIndex = 24;
            this.ytext.Tag = "y_text";
            this.ytext.Text = "0";
            // 
            // xtext
            // 
            this.xtext.Location = new System.Drawing.Point(61, 110);
            this.xtext.Name = "xtext";
            this.xtext.Size = new System.Drawing.Size(107, 22);
            this.xtext.TabIndex = 25;
            this.xtext.Tag = "x_text";
            this.xtext.Text = "0";
            // 
            // rtext
            // 
            this.rtext.Location = new System.Drawing.Point(227, 162);
            this.rtext.Name = "rtext";
            this.rtext.Size = new System.Drawing.Size(100, 22);
            this.rtext.TabIndex = 26;
            this.rtext.Tag = "r_text";
            this.rtext.Text = "0";
            // 
            // yawtext
            // 
            this.yawtext.Location = new System.Drawing.Point(227, 136);
            this.yawtext.Name = "yawtext";
            this.yawtext.Size = new System.Drawing.Size(100, 22);
            this.yawtext.TabIndex = 27;
            this.yawtext.Tag = "yaw_text";
            this.yawtext.Text = "0";
            this.yawtext.TextChanged += new System.EventHandler(this.yawtext_TextChanged);
            // 
            // ptext
            // 
            this.ptext.Location = new System.Drawing.Point(227, 110);
            this.ptext.Name = "ptext";
            this.ptext.Size = new System.Drawing.Size(100, 22);
            this.ptext.TabIndex = 28;
            this.ptext.Tag = "p_text";
            this.ptext.Text = "0";
            this.ptext.TextChanged += new System.EventHandler(this.ptext_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 365);
            this.Controls.Add(this.ptext);
            this.Controls.Add(this.yawtext);
            this.Controls.Add(this.rtext);
            this.Controls.Add(this.xtext);
            this.Controls.Add(this.ytext);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ztext);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.stop);
            this.Controls.Add(this.statStrip);
            this.Controls.Add(this.rpy);
            this.Controls.Add(this.pitchyaw);
            this.Controls.Add(this.yaw);
            this.Controls.Add(this.rollyaw);
            this.Controls.Add(this.pitch);
            this.Controls.Add(this.rollpitch);
            this.Controls.Add(this.roll);
            this.Controls.Add(this.unload);
            this.Controls.Add(this.yzaxis);
            this.Controls.Add(this.xzaxis);
            this.Controls.Add(this.xyaxis);
            this.Controls.Add(this.reset);
            this.Controls.Add(this.zaxis);
            this.Controls.Add(this.yaxis);
            this.Controls.Add(this.xaxis);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statStrip.ResumeLayout(false);
            this.statStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button xaxis;
        private System.Windows.Forms.Button yaxis;
        private System.Windows.Forms.Button zaxis;
        private System.Windows.Forms.Button reset;
        private System.Windows.Forms.Button xyaxis;
        private System.Windows.Forms.Button xzaxis;
        private System.Windows.Forms.Button yzaxis;
        private System.Windows.Forms.Button unload;
        private System.Windows.Forms.Button roll;
        private System.Windows.Forms.Button rollpitch;
        private System.Windows.Forms.Button pitch;
        private System.Windows.Forms.Button rollyaw;
        private System.Windows.Forms.Button yaw;
        private System.Windows.Forms.Button pitchyaw;
        private System.Windows.Forms.Button rpy;
        private System.Windows.Forms.StatusStrip statStrip;
        private System.Windows.Forms.Button stop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ztext;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox ytext;
        private System.Windows.Forms.TextBox xtext;
        private System.Windows.Forms.TextBox rtext;
        private System.Windows.Forms.TextBox yawtext;
        private System.Windows.Forms.TextBox ptext;
        private System.Windows.Forms.ToolStripStatusLabel statStripText;
    }
}

