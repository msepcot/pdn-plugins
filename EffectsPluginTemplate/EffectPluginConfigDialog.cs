using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using PaintDotNet.Effects;
using PaintDotNet;

namespace $safeprojectname$
{
    public class EffectPluginConfigDialog : PaintDotNet.Effects.EffectConfigDialog
    {
        private Button buttonOK;
        private Button buttonCancel;

        public EffectPluginConfigDialog()
        {
            InitializeComponent();
        }

        protected override void InitialInitToken()
        {
            theEffectToken = new EffectPluginConfigToken();
        }

        protected override void InitTokenFromDialog()
        {
            // ((EffectPluginConfigToken)EffectToken).variable = dialogVariable;
        }

        protected override void InitDialogFromToken(EffectConfigToken effectToken)
        {
            // EffectPluginConfigToken token = (EffectPluginConfigToken)effectToken;
            // dialogVariable = token.variable;
        }

        private void InitializeComponent()
        {
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.Location = new System.Drawing.Point(195, 218);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.Location = new System.Drawing.Point(114, 218);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 2;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // EffectPluginConfigDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonCancel);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "EffectPluginConfigDialog";
            this.Controls.SetChildIndex(this.buttonCancel, 0);
            this.Controls.SetChildIndex(this.buttonOK, 0);
            this.ResumeLayout(false);

        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            FinishTokenUpdate();
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}