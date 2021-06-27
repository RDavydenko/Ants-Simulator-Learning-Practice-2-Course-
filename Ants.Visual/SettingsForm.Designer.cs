namespace Ants.Visual
{
	partial class SettingsForm
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
			this.OkButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.antMaxStamina = new System.Windows.Forms.NumericUpDown();
			this.antMaxFood = new System.Windows.Forms.NumericUpDown();
			this.label6 = new System.Windows.Forms.Label();
			this.antMaxUpgradedVision = new System.Windows.Forms.NumericUpDown();
			this.label7 = new System.Windows.Forms.Label();
			this.antAgePerVisionUpgrade = new System.Windows.Forms.NumericUpDown();
			this.label8 = new System.Windows.Forms.Label();
			this.antMaxUpgradedFood = new System.Windows.Forms.NumericUpDown();
			this.label9 = new System.Windows.Forms.Label();
			this.antMaxUpgradedStamina = new System.Windows.Forms.NumericUpDown();
			this.label10 = new System.Windows.Forms.Label();
			this.antStaminaPerStep = new System.Windows.Forms.NumericUpDown();
			this.label11 = new System.Windows.Forms.Label();
			this.antHillChanceSpawnAntHill = new System.Windows.Forms.NumericUpDown();
			this.label12 = new System.Windows.Forms.Label();
			this.antHillChanceSpawnAnt = new System.Windows.Forms.NumericUpDown();
			this.label13 = new System.Windows.Forms.Label();
			this.antHillBaseCount = new System.Windows.Forms.NumericUpDown();
			this.label14 = new System.Windows.Forms.Label();
			this.antHillFoodPerSpawnAntHill = new System.Windows.Forms.NumericUpDown();
			this.label15 = new System.Windows.Forms.Label();
			this.antHillFoodPerSpawnAnt = new System.Windows.Forms.NumericUpDown();
			this.label16 = new System.Windows.Forms.Label();
			this.label17 = new System.Windows.Forms.Label();
			this.foodCount = new System.Windows.Forms.NumericUpDown();
			this.label18 = new System.Windows.Forms.Label();
			this.foodChanceGrowth = new System.Windows.Forms.NumericUpDown();
			this.label19 = new System.Windows.Forms.Label();
			this.foodChanceSpawn = new System.Windows.Forms.NumericUpDown();
			this.button3 = new System.Windows.Forms.Button();
			this.allEnemiesButton = new System.Windows.Forms.RadioButton();
			this.allFriendsButton = new System.Windows.Forms.RadioButton();
			this.allNeutralsButton = new System.Windows.Forms.RadioButton();
			((System.ComponentModel.ISupportInitialize)(this.antMaxStamina)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.antMaxFood)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.antMaxUpgradedVision)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.antAgePerVisionUpgrade)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.antMaxUpgradedFood)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.antMaxUpgradedStamina)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.antStaminaPerStep)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.antHillChanceSpawnAntHill)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.antHillChanceSpawnAnt)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.antHillBaseCount)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.antHillFoodPerSpawnAntHill)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.antHillFoodPerSpawnAnt)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.foodCount)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.foodChanceGrowth)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.foodChanceSpawn)).BeginInit();
			this.SuspendLayout();
			// 
			// OkButton
			// 
			this.OkButton.Location = new System.Drawing.Point(743, 411);
			this.OkButton.Name = "OkButton";
			this.OkButton.Size = new System.Drawing.Size(75, 23);
			this.OkButton.TabIndex = 0;
			this.OkButton.Text = "OK";
			this.OkButton.UseVisualStyleBackColor = true;
			this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
			// 
			// cancelButton
			// 
			this.cancelButton.Location = new System.Drawing.Point(649, 411);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(75, 23);
			this.cancelButton.TabIndex = 0;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(24, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(61, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "AntSettings";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(233, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(75, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "AntHillSettings";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(446, 24);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(69, 13);
			this.label3.TabIndex = 1;
			this.label3.Text = "FoodSettings";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(659, 24);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(93, 13);
			this.label4.TabIndex = 1;
			this.label4.Text = "BehaviourSettings";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(12, 49);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(68, 13);
			this.label5.TabIndex = 3;
			this.label5.Text = "MaxStamina:";
			// 
			// antMaxStamina
			// 
			this.antMaxStamina.Location = new System.Drawing.Point(128, 47);
			this.antMaxStamina.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
			this.antMaxStamina.Name = "antMaxStamina";
			this.antMaxStamina.Size = new System.Drawing.Size(63, 20);
			this.antMaxStamina.TabIndex = 4;
			// 
			// antMaxFood
			// 
			this.antMaxFood.Location = new System.Drawing.Point(128, 74);
			this.antMaxFood.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
			this.antMaxFood.Name = "antMaxFood";
			this.antMaxFood.Size = new System.Drawing.Size(63, 20);
			this.antMaxFood.TabIndex = 6;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(12, 76);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(54, 13);
			this.label6.TabIndex = 5;
			this.label6.Text = "MaxFood:";
			// 
			// antMaxUpgradedVision
			// 
			this.antMaxUpgradedVision.Location = new System.Drawing.Point(128, 101);
			this.antMaxUpgradedVision.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.antMaxUpgradedVision.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.antMaxUpgradedVision.Name = "antMaxUpgradedVision";
			this.antMaxUpgradedVision.Size = new System.Drawing.Size(63, 20);
			this.antMaxUpgradedVision.TabIndex = 8;
			this.antMaxUpgradedVision.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(12, 103);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(105, 13);
			this.label7.TabIndex = 7;
			this.label7.Text = "MaxUpgradedVision:";
			// 
			// antAgePerVisionUpgrade
			// 
			this.antAgePerVisionUpgrade.Location = new System.Drawing.Point(128, 129);
			this.antAgePerVisionUpgrade.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
			this.antAgePerVisionUpgrade.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.antAgePerVisionUpgrade.Name = "antAgePerVisionUpgrade";
			this.antAgePerVisionUpgrade.Size = new System.Drawing.Size(63, 20);
			this.antAgePerVisionUpgrade.TabIndex = 10;
			this.antAgePerVisionUpgrade.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(12, 131);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(114, 13);
			this.label8.TabIndex = 9;
			this.label8.Text = "AgePerVisionUpgrade:";
			// 
			// antMaxUpgradedFood
			// 
			this.antMaxUpgradedFood.Location = new System.Drawing.Point(128, 157);
			this.antMaxUpgradedFood.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
			this.antMaxUpgradedFood.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.antMaxUpgradedFood.Name = "antMaxUpgradedFood";
			this.antMaxUpgradedFood.Size = new System.Drawing.Size(63, 20);
			this.antMaxUpgradedFood.TabIndex = 12;
			this.antMaxUpgradedFood.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(12, 159);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(101, 13);
			this.label9.TabIndex = 11;
			this.label9.Text = "MaxUpgradedFood:";
			// 
			// antMaxUpgradedStamina
			// 
			this.antMaxUpgradedStamina.Location = new System.Drawing.Point(128, 185);
			this.antMaxUpgradedStamina.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
			this.antMaxUpgradedStamina.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.antMaxUpgradedStamina.Name = "antMaxUpgradedStamina";
			this.antMaxUpgradedStamina.Size = new System.Drawing.Size(63, 20);
			this.antMaxUpgradedStamina.TabIndex = 14;
			this.antMaxUpgradedStamina.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(12, 187);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(115, 13);
			this.label10.TabIndex = 13;
			this.label10.Text = "MaxUpgradedStamina:";
			// 
			// antStaminaPerStep
			// 
			this.antStaminaPerStep.Location = new System.Drawing.Point(128, 214);
			this.antStaminaPerStep.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
			this.antStaminaPerStep.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.antStaminaPerStep.Name = "antStaminaPerStep";
			this.antStaminaPerStep.Size = new System.Drawing.Size(63, 20);
			this.antStaminaPerStep.TabIndex = 16;
			this.antStaminaPerStep.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(12, 216);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(86, 13);
			this.label11.TabIndex = 15;
			this.label11.Text = "StaminaPerStep:";
			// 
			// antHillChanceSpawnAntHill
			// 
			this.antHillChanceSpawnAntHill.Location = new System.Drawing.Point(338, 157);
			this.antHillChanceSpawnAntHill.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
			this.antHillChanceSpawnAntHill.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.antHillChanceSpawnAntHill.Name = "antHillChanceSpawnAntHill";
			this.antHillChanceSpawnAntHill.Size = new System.Drawing.Size(63, 20);
			this.antHillChanceSpawnAntHill.TabIndex = 26;
			this.antHillChanceSpawnAntHill.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(222, 159);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(110, 13);
			this.label12.TabIndex = 25;
			this.label12.Text = "ChanceSpawnAntHill:";
			// 
			// antHillChanceSpawnAnt
			// 
			this.antHillChanceSpawnAnt.Location = new System.Drawing.Point(338, 129);
			this.antHillChanceSpawnAnt.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
			this.antHillChanceSpawnAnt.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.antHillChanceSpawnAnt.Name = "antHillChanceSpawnAnt";
			this.antHillChanceSpawnAnt.Size = new System.Drawing.Size(63, 20);
			this.antHillChanceSpawnAnt.TabIndex = 24;
			this.antHillChanceSpawnAnt.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(222, 131);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(96, 13);
			this.label13.TabIndex = 23;
			this.label13.Text = "ChanceSpawnAnt:";
			// 
			// antHillBaseCount
			// 
			this.antHillBaseCount.Location = new System.Drawing.Point(338, 101);
			this.antHillBaseCount.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
			this.antHillBaseCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.antHillBaseCount.Name = "antHillBaseCount";
			this.antHillBaseCount.Size = new System.Drawing.Size(63, 20);
			this.antHillBaseCount.TabIndex = 22;
			this.antHillBaseCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(222, 103);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(62, 13);
			this.label14.TabIndex = 21;
			this.label14.Text = "BaseCount:";
			// 
			// antHillFoodPerSpawnAntHill
			// 
			this.antHillFoodPerSpawnAntHill.Location = new System.Drawing.Point(338, 74);
			this.antHillFoodPerSpawnAntHill.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.antHillFoodPerSpawnAntHill.Name = "antHillFoodPerSpawnAntHill";
			this.antHillFoodPerSpawnAntHill.Size = new System.Drawing.Size(63, 20);
			this.antHillFoodPerSpawnAntHill.TabIndex = 20;
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(222, 76);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(113, 13);
			this.label15.TabIndex = 19;
			this.label15.Text = "FoodPerSpawnAntHill:";
			// 
			// antHillFoodPerSpawnAnt
			// 
			this.antHillFoodPerSpawnAnt.Location = new System.Drawing.Point(338, 47);
			this.antHillFoodPerSpawnAnt.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.antHillFoodPerSpawnAnt.Name = "antHillFoodPerSpawnAnt";
			this.antHillFoodPerSpawnAnt.Size = new System.Drawing.Size(63, 20);
			this.antHillFoodPerSpawnAnt.TabIndex = 18;
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Location = new System.Drawing.Point(222, 49);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(99, 13);
			this.label16.TabIndex = 17;
			this.label16.Text = "FoodPerSpawnAnt:";
			// 
			// label17
			// 
			this.label17.AutoSize = true;
			this.label17.Location = new System.Drawing.Point(432, 49);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(38, 13);
			this.label17.TabIndex = 17;
			this.label17.Text = "Count:";
			// 
			// foodCount
			// 
			this.foodCount.Location = new System.Drawing.Point(548, 47);
			this.foodCount.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
			this.foodCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.foodCount.Name = "foodCount";
			this.foodCount.Size = new System.Drawing.Size(63, 20);
			this.foodCount.TabIndex = 18;
			this.foodCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// label18
			// 
			this.label18.AutoSize = true;
			this.label18.Location = new System.Drawing.Point(432, 76);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(81, 13);
			this.label18.TabIndex = 19;
			this.label18.Text = "ChanceGrowth:";
			// 
			// foodChanceGrowth
			// 
			this.foodChanceGrowth.Location = new System.Drawing.Point(548, 74);
			this.foodChanceGrowth.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
			this.foodChanceGrowth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.foodChanceGrowth.Name = "foodChanceGrowth";
			this.foodChanceGrowth.Size = new System.Drawing.Size(63, 20);
			this.foodChanceGrowth.TabIndex = 20;
			this.foodChanceGrowth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// label19
			// 
			this.label19.AutoSize = true;
			this.label19.Location = new System.Drawing.Point(432, 103);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(80, 13);
			this.label19.TabIndex = 21;
			this.label19.Text = "ChanceSpawn:";
			// 
			// foodChanceSpawn
			// 
			this.foodChanceSpawn.Location = new System.Drawing.Point(548, 101);
			this.foodChanceSpawn.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
			this.foodChanceSpawn.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.foodChanceSpawn.Name = "foodChanceSpawn";
			this.foodChanceSpawn.Size = new System.Drawing.Size(63, 20);
			this.foodChanceSpawn.TabIndex = 22;
			this.foodChanceSpawn.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// button3
			// 
			this.button3.Enabled = false;
			this.button3.Location = new System.Drawing.Point(15, 40);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(800, 2);
			this.button3.TabIndex = 27;
			this.button3.TabStop = false;
			this.button3.Text = "button3";
			this.button3.UseVisualStyleBackColor = true;
			// 
			// allEnemiesButton
			// 
			this.allEnemiesButton.AutoSize = true;
			this.allEnemiesButton.Location = new System.Drawing.Point(652, 52);
			this.allEnemiesButton.Name = "allEnemiesButton";
			this.allEnemiesButton.Size = new System.Drawing.Size(79, 17);
			this.allEnemiesButton.TabIndex = 28;
			this.allEnemiesButton.TabStop = true;
			this.allEnemiesButton.Text = "All Enemies";
			this.allEnemiesButton.UseVisualStyleBackColor = true;
			// 
			// allFriendsButton
			// 
			this.allFriendsButton.AutoSize = true;
			this.allFriendsButton.Location = new System.Drawing.Point(652, 72);
			this.allFriendsButton.Name = "allFriendsButton";
			this.allFriendsButton.Size = new System.Drawing.Size(73, 17);
			this.allFriendsButton.TabIndex = 28;
			this.allFriendsButton.TabStop = true;
			this.allFriendsButton.Text = "All Friends";
			this.allFriendsButton.UseVisualStyleBackColor = true;
			// 
			// allNeutralsButton
			// 
			this.allNeutralsButton.AutoSize = true;
			this.allNeutralsButton.Location = new System.Drawing.Point(652, 92);
			this.allNeutralsButton.Name = "allNeutralsButton";
			this.allNeutralsButton.Size = new System.Drawing.Size(78, 17);
			this.allNeutralsButton.TabIndex = 28;
			this.allNeutralsButton.TabStop = true;
			this.allNeutralsButton.Text = "All Neutrals";
			this.allNeutralsButton.UseVisualStyleBackColor = true;
			// 
			// SettingsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(834, 450);
			this.Controls.Add(this.allNeutralsButton);
			this.Controls.Add(this.allFriendsButton);
			this.Controls.Add(this.allEnemiesButton);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.antHillChanceSpawnAntHill);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.antHillChanceSpawnAnt);
			this.Controls.Add(this.label13);
			this.Controls.Add(this.foodChanceSpawn);
			this.Controls.Add(this.antHillBaseCount);
			this.Controls.Add(this.label19);
			this.Controls.Add(this.label14);
			this.Controls.Add(this.foodChanceGrowth);
			this.Controls.Add(this.antHillFoodPerSpawnAntHill);
			this.Controls.Add(this.label18);
			this.Controls.Add(this.foodCount);
			this.Controls.Add(this.label15);
			this.Controls.Add(this.label17);
			this.Controls.Add(this.antHillFoodPerSpawnAnt);
			this.Controls.Add(this.label16);
			this.Controls.Add(this.antStaminaPerStep);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.antMaxUpgradedStamina);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.antMaxUpgradedFood);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.antAgePerVisionUpgrade);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.antMaxUpgradedVision);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.antMaxFood);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.antMaxStamina);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.OkButton);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "SettingsForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Settings";
			((System.ComponentModel.ISupportInitialize)(this.antMaxStamina)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.antMaxFood)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.antMaxUpgradedVision)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.antAgePerVisionUpgrade)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.antMaxUpgradedFood)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.antMaxUpgradedStamina)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.antStaminaPerStep)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.antHillChanceSpawnAntHill)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.antHillChanceSpawnAnt)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.antHillBaseCount)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.antHillFoodPerSpawnAntHill)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.antHillFoodPerSpawnAnt)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.foodCount)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.foodChanceGrowth)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.foodChanceSpawn)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button OkButton;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.NumericUpDown antMaxStamina;
		private System.Windows.Forms.NumericUpDown antMaxFood;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.NumericUpDown antMaxUpgradedVision;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.NumericUpDown antAgePerVisionUpgrade;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.NumericUpDown antMaxUpgradedFood;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.NumericUpDown antMaxUpgradedStamina;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.NumericUpDown antStaminaPerStep;
		private System.Windows.Forms.NumericUpDown antHillChanceSpawnAntHill;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.NumericUpDown antHillChanceSpawnAnt;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.NumericUpDown antHillBaseCount;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.NumericUpDown antHillFoodPerSpawnAntHill;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.NumericUpDown antHillFoodPerSpawnAnt;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.NumericUpDown foodCount;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.NumericUpDown foodChanceGrowth;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.NumericUpDown foodChanceSpawn;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.RadioButton allEnemiesButton;
		private System.Windows.Forms.RadioButton allFriendsButton;
		private System.Windows.Forms.RadioButton allNeutralsButton;
	}
}