namespace Convert3D
{
    partial class convert3D
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(convert3D));
            this.openBtn = new System.Windows.Forms.Button();
            this.drawChart = new ChartDirector.WinChartViewer();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.drawChart)).BeginInit();
            this.SuspendLayout();
            // 
            // openBtn
            // 
            this.openBtn.Location = new System.Drawing.Point(12, 12);
            this.openBtn.Name = "openBtn";
            this.openBtn.Size = new System.Drawing.Size(81, 34);
            this.openBtn.TabIndex = 0;
            this.openBtn.Text = "Open";
            this.openBtn.UseVisualStyleBackColor = true;
            this.openBtn.Click += new System.EventHandler(this.openBtn_Click);
            // 
            // drawChart
            // 
            this.drawChart.Location = new System.Drawing.Point(12, 52);
            this.drawChart.Name = "drawChart";
            this.drawChart.Size = new System.Drawing.Size(300, 41);
            this.drawChart.TabIndex = 1;
            this.drawChart.TabStop = false;
            this.drawChart.ViewPortChanged += new ChartDirector.WinViewPortEventHandler(this.drawChart_ViewPortChanged);
            this.drawChart.MouseDown += new System.Windows.Forms.MouseEventHandler(this.drawChart_MouseDown);
            this.drawChart.MouseMove += new System.Windows.Forms.MouseEventHandler(this.drawChart_MouseMove);
            this.drawChart.MouseUp += new System.Windows.Forms.MouseEventHandler(this.drawChart_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(115, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "파일명 : ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 669);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.drawChart);
            this.Controls.Add(this.openBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Convert3D";
            ((System.ComponentModel.ISupportInitialize)(this.drawChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button openBtn;
        private ChartDirector.WinChartViewer drawChart;
        private System.Windows.Forms.Label label1;
    }
}

