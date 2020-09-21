namespace HAD_NEBOLI_SNAKE
{
    partial class Form1
    {
        /// <summary>
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pbHracipole = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelScore = new System.Windows.Forms.Label();
            this.hracicas = new System.Windows.Forms.Timer(this.components);
            this.lblGameOver = new System.Windows.Forms.Label();
            this.checkBoxSettingsZdi = new System.Windows.Forms.CheckBox();
            this.labelSettings = new System.Windows.Forms.Label();
            this.radioButtonSettingsEasy = new System.Windows.Forms.RadioButton();
            this.radioButtonSettingsMed = new System.Windows.Forms.RadioButton();
            this.radioButtonSettingsHard = new System.Windows.Forms.RadioButton();
            this.labelDiff = new System.Windows.Forms.Label();
            this.panelDiff = new System.Windows.Forms.Panel();
            this.panelSettings = new System.Windows.Forms.Panel();
            this.labelControls = new System.Windows.Forms.Label();
            this.labelControls1 = new System.Windows.Forms.Label();
            this.labelControls2 = new System.Windows.Forms.Label();
            this.lblpocetjidla = new System.Windows.Forms.Label();
            this.labelpocetj = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbHracipole)).BeginInit();
            this.panelDiff.SuspendLayout();
            this.panelSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbHracipole
            // 
            this.pbHracipole.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.pbHracipole.Location = new System.Drawing.Point(13, 13);
            this.pbHracipole.Name = "pbHracipole";
            this.pbHracipole.Size = new System.Drawing.Size(1000, 500);
            this.pbHracipole.TabIndex = 0;
            this.pbHracipole.TabStop = false;
            this.pbHracipole.Paint += new System.Windows.Forms.PaintEventHandler(this.pbHraciPole_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1019, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 51);
            this.label1.TabIndex = 0;
            this.label1.Text = "Skóre:";
            // 
            // labelScore
            // 
            this.labelScore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelScore.Font = new System.Drawing.Font("Comic Sans MS", 26.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelScore.Location = new System.Drawing.Point(1167, 14);
            this.labelScore.Name = "labelScore";
            this.labelScore.Size = new System.Drawing.Size(178, 50);
            this.labelScore.TabIndex = 0;
            this.labelScore.Text = "0";
            this.labelScore.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.labelScore.Click += new System.EventHandler(this.labelScore_Click);
            // 
            // lblGameOver
            // 
            this.lblGameOver.AutoSize = true;
            this.lblGameOver.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.lblGameOver.Font = new System.Drawing.Font("Comic Sans MS", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGameOver.Location = new System.Drawing.Point(159, 114);
            this.lblGameOver.Name = "lblGameOver";
            this.lblGameOver.Size = new System.Drawing.Size(231, 49);
            this.lblGameOver.TabIndex = 0;
            this.lblGameOver.Text = "lblGameOver";
            this.lblGameOver.Click += new System.EventHandler(this.lblGameOver_Click);
            // 
            // checkBoxSettingsZdi
            // 
            this.checkBoxSettingsZdi.AutoSize = true;
            this.checkBoxSettingsZdi.Checked = true;
            this.checkBoxSettingsZdi.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxSettingsZdi.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxSettingsZdi.Location = new System.Drawing.Point(10, 56);
            this.checkBoxSettingsZdi.Name = "checkBoxSettingsZdi";
            this.checkBoxSettingsZdi.Size = new System.Drawing.Size(202, 33);
            this.checkBoxSettingsZdi.TabIndex = 0;
            this.checkBoxSettingsZdi.TabStop = false;
            this.checkBoxSettingsZdi.Text = "Smrtelné okraje?";
            // 
            // labelSettings
            // 
            this.labelSettings.AutoSize = true;
            this.labelSettings.Font = new System.Drawing.Font("Comic Sans MS", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSettings.Location = new System.Drawing.Point(3, 13);
            this.labelSettings.Name = "labelSettings";
            this.labelSettings.Size = new System.Drawing.Size(151, 40);
            this.labelSettings.TabIndex = 0;
            this.labelSettings.Text = "Nastavení";
            // 
            // radioButtonSettingsEasy
            // 
            this.radioButtonSettingsEasy.AutoSize = true;
            this.radioButtonSettingsEasy.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonSettingsEasy.Location = new System.Drawing.Point(10, 30);
            this.radioButtonSettingsEasy.Name = "radioButtonSettingsEasy";
            this.radioButtonSettingsEasy.Size = new System.Drawing.Size(70, 27);
            this.radioButtonSettingsEasy.TabIndex = 0;
            this.radioButtonSettingsEasy.Text = "Lehká";
            this.radioButtonSettingsEasy.UseVisualStyleBackColor = true;
            // 
            // radioButtonSettingsMed
            // 
            this.radioButtonSettingsMed.AutoSize = true;
            this.radioButtonSettingsMed.Checked = true;
            this.radioButtonSettingsMed.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonSettingsMed.Location = new System.Drawing.Point(10, 50);
            this.radioButtonSettingsMed.Name = "radioButtonSettingsMed";
            this.radioButtonSettingsMed.Size = new System.Drawing.Size(84, 27);
            this.radioButtonSettingsMed.TabIndex = 0;
            this.radioButtonSettingsMed.TabStop = true;
            this.radioButtonSettingsMed.Text = "Střední";
            this.radioButtonSettingsMed.UseVisualStyleBackColor = true;
            // 
            // radioButtonSettingsHard
            // 
            this.radioButtonSettingsHard.AutoSize = true;
            this.radioButtonSettingsHard.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonSettingsHard.Location = new System.Drawing.Point(10, 70);
            this.radioButtonSettingsHard.Name = "radioButtonSettingsHard";
            this.radioButtonSettingsHard.Size = new System.Drawing.Size(73, 27);
            this.radioButtonSettingsHard.TabIndex = 0;
            this.radioButtonSettingsHard.Text = "Těžká";
            this.radioButtonSettingsHard.UseVisualStyleBackColor = true;
            // 
            // labelDiff
            // 
            this.labelDiff.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDiff.Location = new System.Drawing.Point(5, 0);
            this.labelDiff.Name = "labelDiff";
            this.labelDiff.Size = new System.Drawing.Size(111, 27);
            this.labelDiff.TabIndex = 0;
            this.labelDiff.Text = "Obtížnost";
            // 
            // panelDiff
            // 
            this.panelDiff.Controls.Add(this.radioButtonSettingsEasy);
            this.panelDiff.Controls.Add(this.radioButtonSettingsMed);
            this.panelDiff.Controls.Add(this.radioButtonSettingsHard);
            this.panelDiff.Controls.Add(this.labelDiff);
            this.panelDiff.Location = new System.Drawing.Point(0, 95);
            this.panelDiff.Name = "panelDiff";
            this.panelDiff.Size = new System.Drawing.Size(218, 110);
            this.panelDiff.TabIndex = 10;
            // 
            // panelSettings
            // 
            this.panelSettings.Controls.Add(this.labelSettings);
            this.panelSettings.Controls.Add(this.panelDiff);
            this.panelSettings.Controls.Add(this.checkBoxSettingsZdi);
            this.panelSettings.Location = new System.Drawing.Point(1028, 175);
            this.panelSettings.Name = "panelSettings";
            this.panelSettings.Size = new System.Drawing.Size(218, 208);
            this.panelSettings.TabIndex = 10;
            // 
            // labelControls
            // 
            this.labelControls.AutoSize = true;
            this.labelControls.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControls.Location = new System.Drawing.Point(1033, 431);
            this.labelControls.Name = "labelControls";
            this.labelControls.Size = new System.Drawing.Size(86, 26);
            this.labelControls.TabIndex = 11;
            this.labelControls.Text = "Ovládání";
            // 
            // labelControls1
            // 
            this.labelControls1.AutoSize = true;
            this.labelControls1.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControls1.Location = new System.Drawing.Point(1034, 457);
            this.labelControls1.Name = "labelControls1";
            this.labelControls1.Size = new System.Drawing.Size(158, 20);
            this.labelControls1.TabIndex = 12;
            this.labelControls1.Text = "Pohyb: WASD/ŠIPKY";
            // 
            // labelControls2
            // 
            this.labelControls2.AutoSize = true;
            this.labelControls2.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControls2.Location = new System.Drawing.Point(1034, 477);
            this.labelControls2.Name = "labelControls2";
            this.labelControls2.Size = new System.Drawing.Size(117, 20);
            this.labelControls2.TabIndex = 13;
            this.labelControls2.Text = "Konec Hry: ESC";
            this.labelControls2.Click += new System.EventHandler(this.labelControls2_Click);
            // 
            // lblpocetjidla
            // 
            this.lblpocetjidla.AutoSize = true;
            this.lblpocetjidla.Font = new System.Drawing.Font("Comic Sans MS", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblpocetjidla.Location = new System.Drawing.Point(1019, 64);
            this.lblpocetjidla.Name = "lblpocetjidla";
            this.lblpocetjidla.Size = new System.Drawing.Size(228, 51);
            this.lblpocetjidla.TabIndex = 14;
            this.lblpocetjidla.Text = "Počet jídla:";
            // 
            // labelpocetj
            // 
            this.labelpocetj.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelpocetj.Font = new System.Drawing.Font("Comic Sans MS", 26.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelpocetj.Location = new System.Drawing.Point(1242, 65);
            this.labelpocetj.Name = "labelpocetj";
            this.labelpocetj.Size = new System.Drawing.Size(103, 50);
            this.labelpocetj.TabIndex = 15;
            this.labelpocetj.Text = "0";
            this.labelpocetj.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1357, 524);
            this.Controls.Add(this.labelpocetj);
            this.Controls.Add(this.lblpocetjidla);
            this.Controls.Add(this.labelControls2);
            this.Controls.Add(this.labelControls1);
            this.Controls.Add(this.labelControls);
            this.Controls.Add(this.panelSettings);
            this.Controls.Add(this.lblGameOver);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelScore);
            this.Controls.Add(this.pbHracipole);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "HAD NEBOLI SNAKE ";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pbHracipole)).EndInit();
            this.panelDiff.ResumeLayout(false);
            this.panelDiff.PerformLayout();
            this.panelSettings.ResumeLayout(false);
            this.panelSettings.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbHracipole;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelScore;
        private System.Windows.Forms.Timer hracicas;
        private System.Windows.Forms.Label lblGameOver;
        private System.Windows.Forms.CheckBox checkBoxSettingsZdi;
        private System.Windows.Forms.Label labelSettings;
        private System.Windows.Forms.RadioButton radioButtonSettingsEasy;
        private System.Windows.Forms.RadioButton radioButtonSettingsMed;
        private System.Windows.Forms.RadioButton radioButtonSettingsHard;
        private System.Windows.Forms.Label labelDiff;
        private System.Windows.Forms.Panel panelDiff;
        private System.Windows.Forms.Panel panelSettings;
        private System.Windows.Forms.Label labelControls;
        private System.Windows.Forms.Label labelControls1;
        private System.Windows.Forms.Label labelControls2;
        private System.Windows.Forms.Label lblpocetjidla;
        private System.Windows.Forms.Label labelpocetj;
    }
}

