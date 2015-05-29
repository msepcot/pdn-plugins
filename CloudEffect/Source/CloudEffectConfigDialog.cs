using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PaintDotNet.Effects
{
    public class CloudEffectConfigDialog : EffectConfigDialog
    {
        private System.Windows.Forms.GroupBox groupBoxPerlinNoise;
        private System.Windows.Forms.GroupBox groupBoxCloudCoverage;
        private System.Windows.Forms.GroupBox groupBoxDisplayOptions;
        private System.Windows.Forms.RadioButton radioButtonSource;
        private System.Windows.Forms.RadioButton radioButtonTransparent;
        private System.Windows.Forms.GroupBox groupBoxCloudDensity;
        private System.Windows.Forms.RadioButton radioButtonSecondary;
        private System.Windows.Forms.RadioButton radioButtonPrimary;
        private System.Windows.Forms.NumericUpDown numericUpDownAmplitude;
        private System.Windows.Forms.NumericUpDown numericUpDownOctaves;
        private System.Windows.Forms.NumericUpDown numericUpDownPersistance;
        private System.Windows.Forms.NumericUpDown numericUpDownFrequency;
        private System.Windows.Forms.TrackBar trackBarCloudCoverage;
        private System.Windows.Forms.TrackBar trackBarCloudDensity;
        private System.Windows.Forms.Button buttonReseedNoise;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Label labelAmplitude;
        private System.Windows.Forms.Label labelOctaves;
        private System.Windows.Forms.Label labelPersistance;
        private System.Windows.Forms.Label labelFrequency;
        private GroupBox groupBoxRandom;
        private Label labelRandom1;
        private Label labelRandom2;
        private Label labelRandom3;
        private TextBox random3;
        private TextBox random2;
        private TextBox random1;
        private Label label1;
        private System.ComponentModel.IContainer components = null;

        public CloudEffectConfigDialog()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();
        }

        protected override void InitialInitToken()
        {
            theEffectToken = new CloudEffectConfigToken(0.015, 0.65, 8, 1.00, 0.0, 1.0, CloudEffect.REPLACE_SOURCE, 15731, 789221, 1376312589);
        }

        protected override void InitTokenFromDialog()
        {
            ((CloudEffectConfigToken)EffectToken).Frequency = (double)numericUpDownFrequency.Value;
            ((CloudEffectConfigToken)EffectToken).Persistance = (double)numericUpDownPersistance.Value;
            ((CloudEffectConfigToken)EffectToken).Octaves = (int)numericUpDownOctaves.Value;
            ((CloudEffectConfigToken)EffectToken).Amplitude = (double)numericUpDownAmplitude.Value;
            ((CloudEffectConfigToken)EffectToken).CloudCoverage = trackBarCloudCoverage.Value / 10.0;
            ((CloudEffectConfigToken)EffectToken).CloudDensity = trackBarCloudDensity.Value / 10.0;

            if (radioButtonTransparent.Checked)
            {
                ((CloudEffectConfigToken)EffectToken).DisplayOption = CloudEffect.REPLACE_TRANSPARENT;
            }
            else if (radioButtonSource.Checked)
            {
                ((CloudEffectConfigToken)EffectToken).DisplayOption = CloudEffect.REPLACE_SOURCE;
            }
            else if (radioButtonPrimary.Checked)
            {
                ((CloudEffectConfigToken)EffectToken).DisplayOption = CloudEffect.OVERLAY_PRIMARY;
            }
            else if (radioButtonSecondary.Checked)
            {
                ((CloudEffectConfigToken)EffectToken).DisplayOption = CloudEffect.OVERLAY_SECONDARY;
            }

            try
            {
                ((CloudEffectConfigToken)EffectToken).R1 = Convert.ToInt32(random1.Text);
            }
            catch
            {
                // Do nothing. CloudEffectConfigToken.R1 retains value.
            }

            try
            {
                ((CloudEffectConfigToken)EffectToken).R2 = Convert.ToInt32(random2.Text);
            }
            catch
            {
                // Do nothing. CloudEffectConfigToken.R2 retains value.
            }

            try
            {
                ((CloudEffectConfigToken)EffectToken).R3 = Convert.ToInt32(random3.Text);
            }
            catch
            {
                // Do nothing. CloudEffectConfigToken.R3 retains value.
            }
        }

        protected override void InitDialogFromToken(EffectConfigToken effectToken)
        {
            CloudEffectConfigToken token = (CloudEffectConfigToken)effectToken;
            numericUpDownFrequency.Value = (decimal)token.Frequency;
            numericUpDownPersistance.Value = (decimal)token.Persistance;
            numericUpDownOctaves.Value = (decimal)token.Octaves;
            numericUpDownAmplitude.Value = (decimal)token.Amplitude;
            trackBarCloudCoverage.Value = (int)(token.CloudCoverage * 10.0);
            trackBarCloudDensity.Value = (int)(token.CloudDensity * 10.0);

            switch (token.DisplayOption)
            {
                case CloudEffect.REPLACE_SOURCE:
                    radioButtonSource.Checked = true;
                    break;
                case CloudEffect.OVERLAY_PRIMARY:
                    radioButtonPrimary.Checked = true;
                    break;
                case CloudEffect.OVERLAY_SECONDARY:
                    radioButtonSecondary.Checked = true;
                    break;
                case CloudEffect.REPLACE_TRANSPARENT:
                    radioButtonTransparent.Checked = true;
                    break;
                default:
                    break;
            }

            random1.Text = Convert.ToString(token.R1);
            random2.Text = Convert.ToString(token.R2);
            random3.Text = Convert.ToString(token.R3);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                    components = null;
                }
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
            this.groupBoxPerlinNoise = new System.Windows.Forms.GroupBox();
            this.labelAmplitude = new System.Windows.Forms.Label();
            this.labelOctaves = new System.Windows.Forms.Label();
            this.labelPersistance = new System.Windows.Forms.Label();
            this.labelFrequency = new System.Windows.Forms.Label();
            this.numericUpDownAmplitude = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownOctaves = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownPersistance = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownFrequency = new System.Windows.Forms.NumericUpDown();
            this.groupBoxCloudCoverage = new System.Windows.Forms.GroupBox();
            this.trackBarCloudCoverage = new System.Windows.Forms.TrackBar();
            this.groupBoxDisplayOptions = new System.Windows.Forms.GroupBox();
            this.radioButtonSecondary = new System.Windows.Forms.RadioButton();
            this.radioButtonPrimary = new System.Windows.Forms.RadioButton();
            this.radioButtonSource = new System.Windows.Forms.RadioButton();
            this.radioButtonTransparent = new System.Windows.Forms.RadioButton();
            this.groupBoxCloudDensity = new System.Windows.Forms.GroupBox();
            this.trackBarCloudDensity = new System.Windows.Forms.TrackBar();
            this.buttonReseedNoise = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            this.groupBoxRandom = new System.Windows.Forms.GroupBox();
            this.labelRandom1 = new System.Windows.Forms.Label();
            this.labelRandom2 = new System.Windows.Forms.Label();
            this.labelRandom3 = new System.Windows.Forms.Label();
            this.random3 = new System.Windows.Forms.TextBox();
            this.random2 = new System.Windows.Forms.TextBox();
            this.random1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxPerlinNoise.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAmplitude)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOctaves)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPersistance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFrequency)).BeginInit();
            this.groupBoxCloudCoverage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarCloudCoverage)).BeginInit();
            this.groupBoxDisplayOptions.SuspendLayout();
            this.groupBoxCloudDensity.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarCloudDensity)).BeginInit();
            this.groupBoxRandom.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxPerlinNoise
            // 
            this.groupBoxPerlinNoise.Controls.Add(this.labelAmplitude);
            this.groupBoxPerlinNoise.Controls.Add(this.labelOctaves);
            this.groupBoxPerlinNoise.Controls.Add(this.labelPersistance);
            this.groupBoxPerlinNoise.Controls.Add(this.labelFrequency);
            this.groupBoxPerlinNoise.Controls.Add(this.numericUpDownAmplitude);
            this.groupBoxPerlinNoise.Controls.Add(this.numericUpDownOctaves);
            this.groupBoxPerlinNoise.Controls.Add(this.numericUpDownPersistance);
            this.groupBoxPerlinNoise.Controls.Add(this.numericUpDownFrequency);
            this.groupBoxPerlinNoise.Location = new System.Drawing.Point(12, 95);
            this.groupBoxPerlinNoise.Name = "groupBoxPerlinNoise";
            this.groupBoxPerlinNoise.Size = new System.Drawing.Size(200, 120);
            this.groupBoxPerlinNoise.TabIndex = 2;
            this.groupBoxPerlinNoise.TabStop = false;
            this.groupBoxPerlinNoise.Text = "Perlin Noise";
            // 
            // labelAmplitude
            // 
            this.labelAmplitude.AutoSize = true;
            this.labelAmplitude.Location = new System.Drawing.Point(6, 93);
            this.labelAmplitude.Name = "labelAmplitude";
            this.labelAmplitude.Size = new System.Drawing.Size(53, 13);
            this.labelAmplitude.TabIndex = 7;
            this.labelAmplitude.Text = "Amplitude";
            // 
            // labelOctaves
            // 
            this.labelOctaves.AutoSize = true;
            this.labelOctaves.Location = new System.Drawing.Point(6, 70);
            this.labelOctaves.Name = "labelOctaves";
            this.labelOctaves.Size = new System.Drawing.Size(47, 13);
            this.labelOctaves.TabIndex = 6;
            this.labelOctaves.Text = "Octaves";
            // 
            // labelPersistance
            // 
            this.labelPersistance.AutoSize = true;
            this.labelPersistance.Location = new System.Drawing.Point(6, 46);
            this.labelPersistance.Name = "labelPersistance";
            this.labelPersistance.Size = new System.Drawing.Size(62, 13);
            this.labelPersistance.TabIndex = 5;
            this.labelPersistance.Text = "Persistance";
            // 
            // labelFrequency
            // 
            this.labelFrequency.AutoSize = true;
            this.labelFrequency.Location = new System.Drawing.Point(6, 22);
            this.labelFrequency.Name = "labelFrequency";
            this.labelFrequency.Size = new System.Drawing.Size(57, 13);
            this.labelFrequency.TabIndex = 4;
            this.labelFrequency.Text = "Frequency";
            // 
            // numericUpDownAmplitude
            // 
            this.numericUpDownAmplitude.DecimalPlaces = 2;
            this.numericUpDownAmplitude.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.numericUpDownAmplitude.Location = new System.Drawing.Point(126, 91);
            this.numericUpDownAmplitude.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownAmplitude.Name = "numericUpDownAmplitude";
            this.numericUpDownAmplitude.Size = new System.Drawing.Size(68, 20);
            this.numericUpDownAmplitude.TabIndex = 3;
            this.numericUpDownAmplitude.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownAmplitude.ValueChanged += new System.EventHandler(this.numericUpDownAmplitude_ValueChanged);
            // 
            // numericUpDownOctaves
            // 
            this.numericUpDownOctaves.Location = new System.Drawing.Point(126, 68);
            this.numericUpDownOctaves.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.numericUpDownOctaves.Name = "numericUpDownOctaves";
            this.numericUpDownOctaves.Size = new System.Drawing.Size(68, 20);
            this.numericUpDownOctaves.TabIndex = 2;
            this.numericUpDownOctaves.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numericUpDownOctaves.ValueChanged += new System.EventHandler(this.numericUpDownOctaves_ValueChanged);
            // 
            // numericUpDownPersistance
            // 
            this.numericUpDownPersistance.DecimalPlaces = 2;
            this.numericUpDownPersistance.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.numericUpDownPersistance.Location = new System.Drawing.Point(126, 44);
            this.numericUpDownPersistance.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownPersistance.Name = "numericUpDownPersistance";
            this.numericUpDownPersistance.Size = new System.Drawing.Size(68, 20);
            this.numericUpDownPersistance.TabIndex = 1;
            this.numericUpDownPersistance.Value = new decimal(new int[] {
            65,
            0,
            0,
            131072});
            this.numericUpDownPersistance.ValueChanged += new System.EventHandler(this.numericUpDownPersistance_ValueChanged);
            // 
            // numericUpDownFrequency
            // 
            this.numericUpDownFrequency.DecimalPlaces = 3;
            this.numericUpDownFrequency.Increment = new decimal(new int[] {
            5,
            0,
            0,
            196608});
            this.numericUpDownFrequency.Location = new System.Drawing.Point(126, 20);
            this.numericUpDownFrequency.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownFrequency.Name = "numericUpDownFrequency";
            this.numericUpDownFrequency.Size = new System.Drawing.Size(68, 20);
            this.numericUpDownFrequency.TabIndex = 0;
            this.numericUpDownFrequency.Value = new decimal(new int[] {
            15,
            0,
            0,
            196608});
            this.numericUpDownFrequency.ValueChanged += new System.EventHandler(this.numericUpDownFrequency_ValueChanged);
            // 
            // groupBoxCloudCoverage
            // 
            this.groupBoxCloudCoverage.Controls.Add(this.trackBarCloudCoverage);
            this.groupBoxCloudCoverage.Location = new System.Drawing.Point(12, 12);
            this.groupBoxCloudCoverage.Name = "groupBoxCloudCoverage";
            this.groupBoxCloudCoverage.Size = new System.Drawing.Size(200, 77);
            this.groupBoxCloudCoverage.TabIndex = 0;
            this.groupBoxCloudCoverage.TabStop = false;
            this.groupBoxCloudCoverage.Text = "Cloud Coverage";
            // 
            // trackBarCloudCoverage
            // 
            this.trackBarCloudCoverage.Location = new System.Drawing.Point(7, 20);
            this.trackBarCloudCoverage.Minimum = -10;
            this.trackBarCloudCoverage.Name = "trackBarCloudCoverage";
            this.trackBarCloudCoverage.Size = new System.Drawing.Size(187, 45);
            this.trackBarCloudCoverage.TabIndex = 0;
            this.trackBarCloudCoverage.Scroll += new System.EventHandler(this.trackBarCloudCoverage_Scroll);
            // 
            // groupBoxDisplayOptions
            // 
            this.groupBoxDisplayOptions.Controls.Add(this.radioButtonSecondary);
            this.groupBoxDisplayOptions.Controls.Add(this.radioButtonPrimary);
            this.groupBoxDisplayOptions.Controls.Add(this.radioButtonSource);
            this.groupBoxDisplayOptions.Controls.Add(this.radioButtonTransparent);
            this.groupBoxDisplayOptions.Location = new System.Drawing.Point(218, 95);
            this.groupBoxDisplayOptions.Name = "groupBoxDisplayOptions";
            this.groupBoxDisplayOptions.Size = new System.Drawing.Size(200, 120);
            this.groupBoxDisplayOptions.TabIndex = 3;
            this.groupBoxDisplayOptions.TabStop = false;
            this.groupBoxDisplayOptions.Text = "Display Options";
            // 
            // radioButtonSecondary
            // 
            this.radioButtonSecondary.AutoSize = true;
            this.radioButtonSecondary.Location = new System.Drawing.Point(6, 91);
            this.radioButtonSecondary.Name = "radioButtonSecondary";
            this.radioButtonSecondary.Size = new System.Drawing.Size(176, 17);
            this.radioButtonSecondary.TabIndex = 3;
            this.radioButtonSecondary.Text = "Replace Using Secondary Color";
            this.radioButtonSecondary.UseVisualStyleBackColor = true;
            this.radioButtonSecondary.CheckedChanged += new System.EventHandler(this.radioButtonSecondary_CheckedChanged);
            // 
            // radioButtonPrimary
            // 
            this.radioButtonPrimary.AutoSize = true;
            this.radioButtonPrimary.Location = new System.Drawing.Point(7, 68);
            this.radioButtonPrimary.Name = "radioButtonPrimary";
            this.radioButtonPrimary.Size = new System.Drawing.Size(159, 17);
            this.radioButtonPrimary.TabIndex = 2;
            this.radioButtonPrimary.Text = "Replace Using Primary Color";
            this.radioButtonPrimary.UseVisualStyleBackColor = true;
            this.radioButtonPrimary.CheckedChanged += new System.EventHandler(this.radioButtonPrimary_CheckedChanged);
            // 
            // radioButtonSource
            // 
            this.radioButtonSource.AutoSize = true;
            this.radioButtonSource.Checked = true;
            this.radioButtonSource.Location = new System.Drawing.Point(7, 44);
            this.radioButtonSource.Name = "radioButtonSource";
            this.radioButtonSource.Size = new System.Drawing.Size(159, 17);
            this.radioButtonSource.TabIndex = 1;
            this.radioButtonSource.TabStop = true;
            this.radioButtonSource.Text = "Replace Using Source Color";
            this.radioButtonSource.UseVisualStyleBackColor = true;
            this.radioButtonSource.CheckedChanged += new System.EventHandler(this.radioButtonCurrent_CheckedChanged);
            // 
            // radioButtonTransparent
            // 
            this.radioButtonTransparent.AutoSize = true;
            this.radioButtonTransparent.Location = new System.Drawing.Point(7, 20);
            this.radioButtonTransparent.Name = "radioButtonTransparent";
            this.radioButtonTransparent.Size = new System.Drawing.Size(128, 17);
            this.radioButtonTransparent.TabIndex = 0;
            this.radioButtonTransparent.Text = "Replace Transparent ";
            this.radioButtonTransparent.UseVisualStyleBackColor = true;
            this.radioButtonTransparent.CheckedChanged += new System.EventHandler(this.radioButtonTransparent_CheckedChanged);
            // 
            // groupBoxCloudDensity
            // 
            this.groupBoxCloudDensity.Controls.Add(this.trackBarCloudDensity);
            this.groupBoxCloudDensity.Location = new System.Drawing.Point(218, 12);
            this.groupBoxCloudDensity.Name = "groupBoxCloudDensity";
            this.groupBoxCloudDensity.Size = new System.Drawing.Size(200, 77);
            this.groupBoxCloudDensity.TabIndex = 1;
            this.groupBoxCloudDensity.TabStop = false;
            this.groupBoxCloudDensity.Text = "Cloud Density";
            // 
            // trackBarCloudDensity
            // 
            this.trackBarCloudDensity.Location = new System.Drawing.Point(7, 20);
            this.trackBarCloudDensity.Maximum = 20;
            this.trackBarCloudDensity.Name = "trackBarCloudDensity";
            this.trackBarCloudDensity.Size = new System.Drawing.Size(187, 45);
            this.trackBarCloudDensity.TabIndex = 0;
            this.trackBarCloudDensity.Value = 10;
            this.trackBarCloudDensity.Scroll += new System.EventHandler(this.trackBarCloudDensity_Scroll);
            // 
            // buttonReseedNoise
            // 
            this.buttonReseedNoise.Location = new System.Drawing.Point(12, 279);
            this.buttonReseedNoise.Name = "buttonReseedNoise";
            this.buttonReseedNoise.Size = new System.Drawing.Size(93, 23);
            this.buttonReseedNoise.TabIndex = 5;
            this.buttonReseedNoise.Text = "Reseed Noise";
            this.buttonReseedNoise.UseVisualStyleBackColor = true;
            this.buttonReseedNoise.Click += new System.EventHandler(this.buttonReseedNoise_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(343, 279);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 8;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(181, 279);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 6;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(262, 279);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(75, 23);
            this.buttonReset.TabIndex = 7;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // groupBoxRandom
            // 
            this.groupBoxRandom.Controls.Add(this.labelRandom1);
            this.groupBoxRandom.Controls.Add(this.labelRandom2);
            this.groupBoxRandom.Controls.Add(this.labelRandom3);
            this.groupBoxRandom.Controls.Add(this.random3);
            this.groupBoxRandom.Controls.Add(this.random2);
            this.groupBoxRandom.Controls.Add(this.random1);
            this.groupBoxRandom.Location = new System.Drawing.Point(12, 221);
            this.groupBoxRandom.Name = "groupBoxRandom";
            this.groupBoxRandom.Size = new System.Drawing.Size(406, 52);
            this.groupBoxRandom.TabIndex = 4;
            this.groupBoxRandom.TabStop = false;
            this.groupBoxRandom.Text = "Random Noise Values";
            // 
            // labelRandom1
            // 
            this.labelRandom1.AutoSize = true;
            this.labelRandom1.Location = new System.Drawing.Point(6, 23);
            this.labelRandom1.Name = "labelRandom1";
            this.labelRandom1.Size = new System.Drawing.Size(21, 13);
            this.labelRandom1.TabIndex = 3;
            this.labelRandom1.Text = "R1";
            // 
            // labelRandom2
            // 
            this.labelRandom2.AutoSize = true;
            this.labelRandom2.Location = new System.Drawing.Point(139, 23);
            this.labelRandom2.Name = "labelRandom2";
            this.labelRandom2.Size = new System.Drawing.Size(21, 13);
            this.labelRandom2.TabIndex = 4;
            this.labelRandom2.Text = "R2";
            // 
            // labelRandom3
            // 
            this.labelRandom3.AutoSize = true;
            this.labelRandom3.Location = new System.Drawing.Point(272, 23);
            this.labelRandom3.Name = "labelRandom3";
            this.labelRandom3.Size = new System.Drawing.Size(21, 13);
            this.labelRandom3.TabIndex = 5;
            this.labelRandom3.Text = "R3";
            // 
            // random3
            // 
            this.random3.Location = new System.Drawing.Point(299, 19);
            this.random3.Name = "random3";
            this.random3.Size = new System.Drawing.Size(100, 20);
            this.random3.TabIndex = 2;
            this.random3.Text = "1376312589";
            this.random3.TextChanged += new System.EventHandler(this.random3_TextChanged);
            // 
            // random2
            // 
            this.random2.Location = new System.Drawing.Point(166, 19);
            this.random2.Name = "random2";
            this.random2.Size = new System.Drawing.Size(100, 20);
            this.random2.TabIndex = 1;
            this.random2.Text = "789221";
            this.random2.TextChanged += new System.EventHandler(this.random2_TextChanged);
            // 
            // random1
            // 
            this.random1.Location = new System.Drawing.Point(33, 19);
            this.random1.Name = "random1";
            this.random1.Size = new System.Drawing.Size(100, 20);
            this.random1.TabIndex = 0;
            this.random1.Text = "15731";
            this.random1.TextChanged += new System.EventHandler(this.random1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label1.Location = new System.Drawing.Point(124, 284);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "v1.1.0";
            // 
            // CloudEffectConfigDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 311);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBoxRandom);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.groupBoxCloudDensity);
            this.Controls.Add(this.buttonReseedNoise);
            this.Controls.Add(this.groupBoxCloudCoverage);
            this.Controls.Add(this.groupBoxPerlinNoise);
            this.Controls.Add(this.groupBoxDisplayOptions);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "CloudEffectConfigDialog";
            this.Text = "Clouds Configuration Dialog";
            this.Controls.SetChildIndex(this.groupBoxDisplayOptions, 0);
            this.Controls.SetChildIndex(this.groupBoxPerlinNoise, 0);
            this.Controls.SetChildIndex(this.groupBoxCloudCoverage, 0);
            this.Controls.SetChildIndex(this.buttonReseedNoise, 0);
            this.Controls.SetChildIndex(this.groupBoxCloudDensity, 0);
            this.Controls.SetChildIndex(this.buttonCancel, 0);
            this.Controls.SetChildIndex(this.buttonOk, 0);
            this.Controls.SetChildIndex(this.buttonReset, 0);
            this.Controls.SetChildIndex(this.groupBoxRandom, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.groupBoxPerlinNoise.ResumeLayout(false);
            this.groupBoxPerlinNoise.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAmplitude)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOctaves)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPersistance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFrequency)).EndInit();
            this.groupBoxCloudCoverage.ResumeLayout(false);
            this.groupBoxCloudCoverage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarCloudCoverage)).EndInit();
            this.groupBoxDisplayOptions.ResumeLayout(false);
            this.groupBoxDisplayOptions.PerformLayout();
            this.groupBoxCloudDensity.ResumeLayout(false);
            this.groupBoxCloudDensity.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarCloudDensity)).EndInit();
            this.groupBoxRandom.ResumeLayout(false);
            this.groupBoxRandom.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private void numericUpDownFrequency_ValueChanged(object sender, EventArgs e)
        {
            FinishTokenUpdate();
        }

        private void numericUpDownPersistance_ValueChanged(object sender, EventArgs e)
        {
            FinishTokenUpdate();
        }

        private void numericUpDownOctaves_ValueChanged(object sender, EventArgs e)
        {
            FinishTokenUpdate();
        }

        private void numericUpDownAmplitude_ValueChanged(object sender, EventArgs e)
        {
            FinishTokenUpdate();
        }

        private void radioButtonTransparent_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonTransparent.Checked)
            {
                FinishTokenUpdate();
            }
        }

        private void radioButtonCurrent_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonSource.Checked)
            {
                FinishTokenUpdate();
            }
        }

        private void radioButtonPrimary_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonPrimary.Checked)
            {
                FinishTokenUpdate();
            }
        }

        private void radioButtonSecondary_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonSecondary.Checked)
            {
                FinishTokenUpdate();
            }
        }

        private void trackBarCloudCoverage_Scroll(object sender, EventArgs e)
        {
            FinishTokenUpdate();
        }

        private void trackBarCloudDensity_Scroll(object sender, EventArgs e)
        {
            FinishTokenUpdate();
        }

        private void buttonReseedNoise_Click(object sender, EventArgs e)
        {
            RandomValues();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (IsNumeric(random1.Text))
            {
                if (IsNumeric(random2.Text))
                {
                    if (IsNumeric(random3.Text))
                    {
                        FinishTokenUpdate();
                        DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        random3.Focus();
                    }
                }
                else
                {
                    random2.Focus();
                }
            }
            else
            {
                random1.Focus();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            numericUpDownFrequency.Value = (decimal)0.015;
            numericUpDownPersistance.Value = (decimal)0.65;
            numericUpDownOctaves.Value = 8;
            numericUpDownAmplitude.Value = (decimal)1.00;
            trackBarCloudCoverage.Value = 0;
            trackBarCloudDensity.Value = 10;
            radioButtonSource.Checked = true;
            random1.Text = "15731";
            random2.Text = "789221";
            random3.Text = "1376312589";

            ((CloudEffectConfigToken)EffectToken).Frequency = 0.015;
            ((CloudEffectConfigToken)EffectToken).Persistance = 0.65;
            ((CloudEffectConfigToken)EffectToken).Octaves = 8;
            ((CloudEffectConfigToken)EffectToken).Amplitude = 1.00;
            ((CloudEffectConfigToken)EffectToken).CloudCoverage = 0.0;
            ((CloudEffectConfigToken)EffectToken).CloudDensity = 1.0;
            ((CloudEffectConfigToken)EffectToken).DisplayOption = CloudEffect.REPLACE_SOURCE;

            FinishTokenUpdate();
        }

        [ThreadStatic]
        private static Random threadRand = new Random();

        private void RandomValues()
        {
            if (threadRand == null)
            {
                threadRand = new Random(unchecked(System.Threading.Thread.CurrentThread.GetHashCode() ^ unchecked((int)DateTime.Now.Ticks)));
            }
            Random localRand = threadRand;
            random1.Text = Convert.ToString(localRand.Next(1000, 10000));
            random2.Text = Convert.ToString(localRand.Next(100000, 1000000));
            random3.Text = Convert.ToString(localRand.Next(1000000000, 2000000000));
        }

        private void random1_TextChanged(object sender, EventArgs e)
        {
            if (!IsNumeric(random1.Text))
            {
                random1.BackColor = Color.Red;
            }
            else
            {
                random1.BackColor = Color.White;
                FinishTokenUpdate();
            }
        }

        private void random2_TextChanged(object sender, EventArgs e)
        {
            if (!IsNumeric(random2.Text))
            {
                random2.BackColor = Color.Red;
            }
            else
            {
                random2.BackColor = Color.White;
                FinishTokenUpdate();
            }
        }

        private void random3_TextChanged(object sender, EventArgs e)
        {
            if (!IsNumeric(random3.Text))
            {
                random3.BackColor = Color.Red;
            }
            else
            {
                random3.BackColor = Color.White;
                FinishTokenUpdate();
            }
        }

        public static bool IsNumeric(string text)
        {
            return Regex.IsMatch(text, "^\\d+$");
        }
    }
}