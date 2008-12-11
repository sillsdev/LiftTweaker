namespace Tweaker
{
    partial class FilterByPartsOfSpeechControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this._targetTable = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 337);
            this.label1.MaximumSize = new System.Drawing.Size(350, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(350, 39);
            this.label1.TabIndex = 5;
            this.label1.Text = "Uncheck any Parts Of Speech which you don\'t want in this version of the dictionar" +
                "y.  Sense with those Parts Of Speech will not be included.  Entries with no othe" +
                "r senses will not be included.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 9);
            this.label4.MaximumSize = new System.Drawing.Size(90, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Parts Of Speech";
            // 
            // _targetTable
            // 
            this._targetTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._targetTable.BackColor = System.Drawing.SystemColors.Window;
            this._targetTable.ColumnCount = 1;
            this._targetTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._targetTable.Font = new System.Drawing.Font("Charis SIL", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._targetTable.Location = new System.Drawing.Point(11, 25);
            this._targetTable.Name = "_targetTable";
            this._targetTable.RowCount = 1;
            this._targetTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._targetTable.Size = new System.Drawing.Size(372, 298);
            this._targetTable.TabIndex = 4;
            // 
            // FilterByPartsOfSpeechControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this._targetTable);
            this.Name = "FilterByPartsOfSpeechControl";
            this.Size = new System.Drawing.Size(386, 382);
            this.Load += new System.EventHandler(this.OnLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TableLayoutPanel _targetTable;

    }
}
