namespace Mouse_Escalator
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.serialPortSelect = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.fileSelectButton = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.resultFilePath = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.stopButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.trainTime = new System.Windows.Forms.TextBox();
            this.speedSelect5 = new System.Windows.Forms.NumericUpDown();
            this.speedSelect4 = new System.Windows.Forms.NumericUpDown();
            this.speedSelect3 = new System.Windows.Forms.NumericUpDown();
            this.speedSelect2 = new System.Windows.Forms.NumericUpDown();
            this.speedSelect1 = new System.Windows.Forms.NumericUpDown();
            this.speedSelect10 = new System.Windows.Forms.NumericUpDown();
            this.speedSelect9 = new System.Windows.Forms.NumericUpDown();
            this.speedSelect8 = new System.Windows.Forms.NumericUpDown();
            this.speedSelect7 = new System.Windows.Forms.NumericUpDown();
            this.speedSelect6 = new System.Windows.Forms.NumericUpDown();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.speedChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.locationChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.resultFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.controlTimer = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.manualStartButton = new System.Windows.Forms.Button();
            this.manualStopButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.speedSelect5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedSelect4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedSelect3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedSelect2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedSelect1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedSelect10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedSelect9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedSelect8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedSelect7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedSelect6)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.speedChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.locationChart)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("PMingLiU", 11F);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1160, 437);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.manualStopButton);
            this.tabPage1.Controls.Add(this.manualStartButton);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.serialPortSelect);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.fileSelectButton);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.resultFilePath);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.stopButton);
            this.tabPage1.Controls.Add(this.startButton);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.trainTime);
            this.tabPage1.Controls.Add(this.speedSelect5);
            this.tabPage1.Controls.Add(this.speedSelect4);
            this.tabPage1.Controls.Add(this.speedSelect3);
            this.tabPage1.Controls.Add(this.speedSelect2);
            this.tabPage1.Controls.Add(this.speedSelect1);
            this.tabPage1.Controls.Add(this.speedSelect10);
            this.tabPage1.Controls.Add(this.speedSelect9);
            this.tabPage1.Controls.Add(this.speedSelect8);
            this.tabPage1.Controls.Add(this.speedSelect7);
            this.tabPage1.Controls.Add(this.speedSelect6);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1152, 408);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "設定";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // serialPortSelect
            // 
            this.serialPortSelect.FormattingEnabled = true;
            this.serialPortSelect.Location = new System.Drawing.Point(700, 283);
            this.serialPortSelect.Name = "serialPortSelect";
            this.serialPortSelect.Size = new System.Drawing.Size(121, 23);
            this.serialPortSelect.TabIndex = 50;
            this.serialPortSelect.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.serialPortSelectKeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("PMingLiU", 11F);
            this.label1.Location = new System.Drawing.Point(623, 286);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 15);
            this.label1.TabIndex = 49;
            this.label1.Text = "RS232 Port:";
            // 
            // fileSelectButton
            // 
            this.fileSelectButton.Location = new System.Drawing.Point(944, 210);
            this.fileSelectButton.Name = "fileSelectButton";
            this.fileSelectButton.Size = new System.Drawing.Size(56, 23);
            this.fileSelectButton.TabIndex = 47;
            this.fileSelectButton.Text = "瀏覽";
            this.fileSelectButton.UseVisualStyleBackColor = true;
            this.fileSelectButton.Click += new System.EventHandler(this.fileSelectButton_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("PMingLiU", 11F);
            this.label9.Location = new System.Drawing.Point(507, 214);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 15);
            this.label9.TabIndex = 46;
            this.label9.Text = "儲存位置:";
            // 
            // resultFilePath
            // 
            this.resultFilePath.BackColor = System.Drawing.Color.White;
            this.resultFilePath.Location = new System.Drawing.Point(584, 208);
            this.resultFilePath.Name = "resultFilePath";
            this.resultFilePath.ReadOnly = true;
            this.resultFilePath.Size = new System.Drawing.Size(354, 25);
            this.resultFilePath.TabIndex = 45;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("PMingLiU", 11F);
            this.label8.Location = new System.Drawing.Point(987, 139);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 15);
            this.label8.TabIndex = 44;
            this.label8.Text = "m/min";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("PMingLiU", 11F);
            this.label7.Location = new System.Drawing.Point(795, 56);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 15);
            this.label7.TabIndex = 43;
            this.label7.Text = "minute(s)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("PMingLiU", 11F);
            this.label4.Location = new System.Drawing.Point(507, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 15);
            this.label4.TabIndex = 40;
            this.label4.Text = "各點速度:";
            // 
            // stopButton
            // 
            this.stopButton.Enabled = false;
            this.stopButton.Font = new System.Drawing.Font("PMingLiU", 11F);
            this.stopButton.Location = new System.Drawing.Point(787, 356);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(174, 35);
            this.stopButton.TabIndex = 39;
            this.stopButton.Text = "停止";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // startButton
            // 
            this.startButton.Font = new System.Drawing.Font("PMingLiU", 11F);
            this.startButton.Location = new System.Drawing.Point(565, 356);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(174, 35);
            this.startButton.TabIndex = 38;
            this.startButton.Text = "開始";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("PMingLiU", 11F);
            this.label3.Location = new System.Drawing.Point(656, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 15);
            this.label3.TabIndex = 37;
            this.label3.Text = "訓練時間:";
            // 
            // trainTime
            // 
            this.trainTime.Location = new System.Drawing.Point(733, 53);
            this.trainTime.MaxLength = 4;
            this.trainTime.Name = "trainTime";
            this.trainTime.Size = new System.Drawing.Size(56, 25);
            this.trainTime.TabIndex = 36;
            // 
            // speedSelect5
            // 
            this.speedSelect5.Location = new System.Drawing.Point(745, 129);
            this.speedSelect5.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.speedSelect5.Minimum = new decimal(new int[] {
            30,
            0,
            0,
            -2147483648});
            this.speedSelect5.Name = "speedSelect5";
            this.speedSelect5.Size = new System.Drawing.Size(34, 25);
            this.speedSelect5.TabIndex = 31;
            // 
            // speedSelect4
            // 
            this.speedSelect4.Location = new System.Drawing.Point(705, 129);
            this.speedSelect4.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.speedSelect4.Minimum = new decimal(new int[] {
            30,
            0,
            0,
            -2147483648});
            this.speedSelect4.Name = "speedSelect4";
            this.speedSelect4.Size = new System.Drawing.Size(34, 25);
            this.speedSelect4.TabIndex = 30;
            // 
            // speedSelect3
            // 
            this.speedSelect3.Location = new System.Drawing.Point(665, 129);
            this.speedSelect3.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.speedSelect3.Minimum = new decimal(new int[] {
            30,
            0,
            0,
            -2147483648});
            this.speedSelect3.Name = "speedSelect3";
            this.speedSelect3.Size = new System.Drawing.Size(34, 25);
            this.speedSelect3.TabIndex = 29;
            // 
            // speedSelect2
            // 
            this.speedSelect2.Location = new System.Drawing.Point(625, 129);
            this.speedSelect2.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.speedSelect2.Minimum = new decimal(new int[] {
            30,
            0,
            0,
            -2147483648});
            this.speedSelect2.Name = "speedSelect2";
            this.speedSelect2.Size = new System.Drawing.Size(34, 25);
            this.speedSelect2.TabIndex = 28;
            // 
            // speedSelect1
            // 
            this.speedSelect1.Location = new System.Drawing.Point(585, 129);
            this.speedSelect1.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.speedSelect1.Minimum = new decimal(new int[] {
            30,
            0,
            0,
            -2147483648});
            this.speedSelect1.Name = "speedSelect1";
            this.speedSelect1.Size = new System.Drawing.Size(34, 25);
            this.speedSelect1.TabIndex = 27;
            // 
            // speedSelect10
            // 
            this.speedSelect10.Location = new System.Drawing.Point(947, 129);
            this.speedSelect10.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.speedSelect10.Minimum = new decimal(new int[] {
            30,
            0,
            0,
            -2147483648});
            this.speedSelect10.Name = "speedSelect10";
            this.speedSelect10.Size = new System.Drawing.Size(34, 25);
            this.speedSelect10.TabIndex = 26;
            // 
            // speedSelect9
            // 
            this.speedSelect9.Location = new System.Drawing.Point(907, 129);
            this.speedSelect9.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.speedSelect9.Minimum = new decimal(new int[] {
            30,
            0,
            0,
            -2147483648});
            this.speedSelect9.Name = "speedSelect9";
            this.speedSelect9.Size = new System.Drawing.Size(34, 25);
            this.speedSelect9.TabIndex = 25;
            // 
            // speedSelect8
            // 
            this.speedSelect8.Location = new System.Drawing.Point(867, 129);
            this.speedSelect8.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.speedSelect8.Minimum = new decimal(new int[] {
            30,
            0,
            0,
            -2147483648});
            this.speedSelect8.Name = "speedSelect8";
            this.speedSelect8.Size = new System.Drawing.Size(34, 25);
            this.speedSelect8.TabIndex = 24;
            // 
            // speedSelect7
            // 
            this.speedSelect7.Location = new System.Drawing.Point(827, 129);
            this.speedSelect7.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.speedSelect7.Minimum = new decimal(new int[] {
            30,
            0,
            0,
            -2147483648});
            this.speedSelect7.Name = "speedSelect7";
            this.speedSelect7.Size = new System.Drawing.Size(34, 25);
            this.speedSelect7.TabIndex = 23;
            // 
            // speedSelect6
            // 
            this.speedSelect6.Location = new System.Drawing.Point(787, 129);
            this.speedSelect6.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.speedSelect6.Minimum = new decimal(new int[] {
            30,
            0,
            0,
            -2147483648});
            this.speedSelect6.Name = "speedSelect6";
            this.speedSelect6.Size = new System.Drawing.Size(34, 25);
            this.speedSelect6.TabIndex = 22;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.speedChart);
            this.tabPage2.Controls.Add(this.locationChart);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1152, 408);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "監測";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // speedChart
            // 
            chartArea5.Name = "ChartArea1";
            this.speedChart.ChartAreas.Add(chartArea5);
            legend5.Name = "Legend1";
            this.speedChart.Legends.Add(legend5);
            this.speedChart.Location = new System.Drawing.Point(585, 6);
            this.speedChart.Name = "speedChart";
            this.speedChart.Size = new System.Drawing.Size(550, 396);
            this.speedChart.TabIndex = 1;
            this.speedChart.Text = "chart2";
            // 
            // locationChart
            // 
            chartArea6.Name = "ChartArea1";
            this.locationChart.ChartAreas.Add(chartArea6);
            legend6.Name = "Legend1";
            this.locationChart.Legends.Add(legend6);
            this.locationChart.Location = new System.Drawing.Point(6, 6);
            this.locationChart.Name = "locationChart";
            this.locationChart.Size = new System.Drawing.Size(550, 396);
            this.locationChart.TabIndex = 0;
            this.locationChart.Text = "chart1";
            // 
            // resultFileDialog
            // 
            this.resultFileDialog.Filter = "文字檔 (*.txt)|*.txt|所有檔案 (*.*)|*.*";
            this.resultFileDialog.Title = "Save a result File";
            this.resultFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.resulfFileDialog_FileOk);
            // 
            // controlTimer
            // 
            this.controlTimer.Tick += new System.EventHandler(this.controlTimer_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(45, 173);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(319, 16);
            this.label2.TabIndex = 52;
            this.label2.Text = "請先選擇儲存位置與RS232 Port再啟用本功能";
            // 
            // manualStartButton
            // 
            this.manualStartButton.Location = new System.Drawing.Point(53, 203);
            this.manualStartButton.Name = "manualStartButton";
            this.manualStartButton.Size = new System.Drawing.Size(133, 34);
            this.manualStartButton.TabIndex = 0;
            this.manualStartButton.Text = "開始 (手動調速)";
            this.manualStartButton.UseVisualStyleBackColor = true;
            this.manualStartButton.Click += new System.EventHandler(this.manualStartButton_Click);
            // 
            // manualStopButton
            // 
            this.manualStopButton.Location = new System.Drawing.Point(212, 203);
            this.manualStopButton.Name = "manualStopButton";
            this.manualStopButton.Size = new System.Drawing.Size(133, 34);
            this.manualStopButton.TabIndex = 53;
            this.manualStopButton.Text = "停止 (手動調速)";
            this.manualStopButton.UseVisualStyleBackColor = true;
            this.manualStopButton.Click += new System.EventHandler(this.manualStopButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("PMingLiU", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(58, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(271, 27);
            this.label5.TabIndex = 54;
            this.label5.Text = "手動調速(含紀錄功能)";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 461);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Mouse Escalator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.speedSelect5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedSelect4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedSelect3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedSelect2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedSelect1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedSelect10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedSelect9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedSelect8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedSelect7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedSelect6)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.speedChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.locationChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox trainTime;
        private System.Windows.Forms.NumericUpDown speedSelect5;
        private System.Windows.Forms.NumericUpDown speedSelect4;
        private System.Windows.Forms.NumericUpDown speedSelect3;
        private System.Windows.Forms.NumericUpDown speedSelect2;
        private System.Windows.Forms.NumericUpDown speedSelect1;
        private System.Windows.Forms.NumericUpDown speedSelect10;
        private System.Windows.Forms.NumericUpDown speedSelect9;
        private System.Windows.Forms.NumericUpDown speedSelect8;
        private System.Windows.Forms.NumericUpDown speedSelect7;
        private System.Windows.Forms.NumericUpDown speedSelect6;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataVisualization.Charting.Chart speedChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart locationChart;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.SaveFileDialog resultFileDialog;
        private System.Windows.Forms.Button fileSelectButton;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox resultFilePath;
        private System.Windows.Forms.Timer controlTimer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox serialPortSelect;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button manualStopButton;
        private System.Windows.Forms.Button manualStartButton;
    }
}

