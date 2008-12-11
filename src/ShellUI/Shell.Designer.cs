namespace Tweaker
{
    partial class Shell
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Shell));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this._openLiftButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.label = new System.Windows.Forms.ToolStripLabel();
            this._targetDocumentCombo = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this._openInLexiqueProButton = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this._areaTreeControl = new Tweaker.AreaTree();
            this.toolStrip1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Azure;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._openLiftButton,
            this.toolStripSeparator1,
            this.label,
            this._targetDocumentCombo,
            this.toolStripSeparator2,
            this._openInLexiqueProButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(670, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // _openLiftButton
            // 
            this._openLiftButton.Image = ((System.Drawing.Image)(resources.GetObject("_openLiftButton.Image")));
            this._openLiftButton.ImageTransparentColor = System.Drawing.Color.Black;
            this._openLiftButton.Name = "_openLiftButton";
            this._openLiftButton.Size = new System.Drawing.Size(23, 22);
            this._openLiftButton.ToolTipText = "Choose LIFT file to tweak";
            this._openLiftButton.Click += new System.EventHandler(this.OnOpenLiftButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // label
            // 
            this.label.Enabled = false;
            this.label.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(130, 22);
            this.label.Text = "Output Dictionary Style:";
            // 
            // _targetDocumentCombo
            // 
            this._targetDocumentCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._targetDocumentCombo.Items.AddRange(new object[] {
            "Normal",
            "Categorized by Semantic Domain",
            "Children\'s",
            "Proper Names",
            "Religous Terms"});
            this._targetDocumentCombo.Name = "_targetDocumentCombo";
            this._targetDocumentCombo.Size = new System.Drawing.Size(121, 25);
            this._targetDocumentCombo.SelectedIndexChanged += new System.EventHandler(this.OnChangedTargetChoice);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // _openInLexiqueProButton
            // 
            this._openInLexiqueProButton.Image = ((System.Drawing.Image)(resources.GetObject("_openInLexiqueProButton.Image")));
            this._openInLexiqueProButton.ImageTransparentColor = System.Drawing.Color.White;
            this._openInLexiqueProButton.Name = "_openInLexiqueProButton";
            this._openInLexiqueProButton.Size = new System.Drawing.Size(23, 22);
            this._openInLexiqueProButton.ToolTipText = "Open Tweaked File in Lexique Pro";
            this._openInLexiqueProButton.Click += new System.EventHandler(this.OnOpenInLexiqueProButton_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.Azure;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.AliceBlue;
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this._areaTreeControl);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.AliceBlue;
            this.splitContainer1.Size = new System.Drawing.Size(670, 374);
            this.splitContainer1.SplitterDistance = 118;
            this.splitContainer1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tweaks";
            // 
            // _areaTreeControl
            // 
            this._areaTreeControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._areaTreeControl.BackColor = System.Drawing.Color.AliceBlue;
            this._areaTreeControl.Location = new System.Drawing.Point(0, 26);
            this._areaTreeControl.Name = "_areaTreeControl";
            this._areaTreeControl.Size = new System.Drawing.Size(118, 348);
            this._areaTreeControl.TabIndex = 0;
            // 
            // Shell
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 399);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Shell";
            this.Text = "LIFT Tweaker";
            this.Load += new System.EventHandler(this.Shell_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private AreaTree _areaTreeControl;
        private System.Windows.Forms.ToolStripButton _openInLexiqueProButton;
        private System.Windows.Forms.ToolStripButton _openLiftButton;
        private System.Windows.Forms.ToolStripComboBox _targetDocumentCombo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel label;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Label label1;
    }
}

