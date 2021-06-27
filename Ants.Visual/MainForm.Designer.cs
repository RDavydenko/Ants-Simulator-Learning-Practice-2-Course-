namespace Ants.Visual
{
	partial class MainForm
	{
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.mainPanel = new System.Windows.Forms.Panel();
			this.pictureBox = new System.Windows.Forms.PictureBox();
			this.gameTimer = new System.Windows.Forms.Timer(this.components);
			this.startButton = new System.Windows.Forms.Button();
			this.pauseButton = new System.Windows.Forms.Button();
			this.continueButton = new System.Windows.Forms.Button();
			this.resetButton = new System.Windows.Forms.Button();
			this.intervalInput = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.hideStatsButton = new System.Windows.Forms.Button();
			this.configureButton = new System.Windows.Forms.Button();
			this.mainPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.intervalInput)).BeginInit();
			this.SuspendLayout();
			// 
			// mainPanel
			// 
			this.mainPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.mainPanel.Controls.Add(this.pictureBox);
			this.mainPanel.Location = new System.Drawing.Point(0, 41);
			this.mainPanel.Name = "mainPanel";
			this.mainPanel.Size = new System.Drawing.Size(602, 602);
			this.mainPanel.TabIndex = 0;
			// 
			// pictureBox
			// 
			this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pictureBox.Location = new System.Drawing.Point(0, 0);
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new System.Drawing.Size(600, 600);
			this.pictureBox.TabIndex = 0;
			this.pictureBox.TabStop = false;
			this.pictureBox.Click += new System.EventHandler(this.AboutEntity);
			// 
			// gameTimer
			// 
			this.gameTimer.Tick += new System.EventHandler(this.Update);
			// 
			// startButton
			// 
			this.startButton.Location = new System.Drawing.Point(12, 12);
			this.startButton.Name = "startButton";
			this.startButton.Size = new System.Drawing.Size(75, 23);
			this.startButton.TabIndex = 1;
			this.startButton.Text = "Start";
			this.startButton.UseVisualStyleBackColor = true;
			this.startButton.Click += new System.EventHandler(this.Start);
			// 
			// pauseButton
			// 
			this.pauseButton.Enabled = false;
			this.pauseButton.Location = new System.Drawing.Point(93, 12);
			this.pauseButton.Name = "pauseButton";
			this.pauseButton.Size = new System.Drawing.Size(75, 23);
			this.pauseButton.TabIndex = 1;
			this.pauseButton.Text = "Pause";
			this.pauseButton.UseVisualStyleBackColor = true;
			this.pauseButton.Click += new System.EventHandler(this.Pause);
			// 
			// continueButton
			// 
			this.continueButton.Enabled = false;
			this.continueButton.Location = new System.Drawing.Point(174, 12);
			this.continueButton.Name = "continueButton";
			this.continueButton.Size = new System.Drawing.Size(75, 23);
			this.continueButton.TabIndex = 1;
			this.continueButton.Text = "Continue";
			this.continueButton.UseVisualStyleBackColor = true;
			this.continueButton.Click += new System.EventHandler(this.Continue);
			// 
			// resetButton
			// 
			this.resetButton.Enabled = false;
			this.resetButton.Location = new System.Drawing.Point(255, 12);
			this.resetButton.Name = "resetButton";
			this.resetButton.Size = new System.Drawing.Size(75, 23);
			this.resetButton.TabIndex = 1;
			this.resetButton.Text = "Reset";
			this.resetButton.UseVisualStyleBackColor = true;
			this.resetButton.Click += new System.EventHandler(this.Reset);
			// 
			// intervalInput
			// 
			this.intervalInput.Location = new System.Drawing.Point(410, 15);
			this.intervalInput.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.intervalInput.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.intervalInput.Name = "intervalInput";
			this.intervalInput.Size = new System.Drawing.Size(56, 20);
			this.intervalInput.TabIndex = 2;
			this.intervalInput.Value = new decimal(new int[] {
            17,
            0,
            0,
            0});
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(361, 18);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(45, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "Interval:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.label2.Location = new System.Drawing.Point(635, 18);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 17);
			this.label2.TabIndex = 4;
			this.label2.Text = "Statistics";
			// 
			// hideStatsButton
			// 
			this.hideStatsButton.Location = new System.Drawing.Point(836, 17);
			this.hideStatsButton.Name = "hideStatsButton";
			this.hideStatsButton.Size = new System.Drawing.Size(75, 23);
			this.hideStatsButton.TabIndex = 5;
			this.hideStatsButton.Text = "Hide";
			this.hideStatsButton.UseVisualStyleBackColor = true;
			this.hideStatsButton.Click += new System.EventHandler(this.HideStatsButton_Click);
			// 
			// configureButton
			// 
			this.configureButton.Location = new System.Drawing.Point(472, 13);
			this.configureButton.Name = "configureButton";
			this.configureButton.Size = new System.Drawing.Size(75, 23);
			this.configureButton.TabIndex = 6;
			this.configureButton.Text = "Configure";
			this.configureButton.UseVisualStyleBackColor = true;
			this.configureButton.Click += new System.EventHandler(this.ConfigureButton_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(925, 643);
			this.Controls.Add(this.configureButton);
			this.Controls.Add(this.hideStatsButton);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.intervalInput);
			this.Controls.Add(this.resetButton);
			this.Controls.Add(this.continueButton);
			this.Controls.Add(this.pauseButton);
			this.Controls.Add(this.startButton);
			this.Controls.Add(this.mainPanel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.HelpButton = true;
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Ants Simulator";
			this.mainPanel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.intervalInput)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel mainPanel;
		private System.Windows.Forms.PictureBox pictureBox;
		private System.Windows.Forms.Timer gameTimer;
		private System.Windows.Forms.Button startButton;
		private System.Windows.Forms.Button pauseButton;
		private System.Windows.Forms.Button continueButton;
		private System.Windows.Forms.Button resetButton;
		private System.Windows.Forms.NumericUpDown intervalInput;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button hideStatsButton;
		private System.Windows.Forms.Button configureButton;
	}
}

