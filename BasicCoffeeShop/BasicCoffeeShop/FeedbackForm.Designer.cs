namespace BasicCoffeeShop
{
    partial class FeedbackForm
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
            this.feedbackTXB = new System.Windows.Forms.TextBox();
            this.labelFeedBack = new System.Windows.Forms.Label();
            this.XacNhanBTN = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // feedbackTXB
            // 
            this.feedbackTXB.Location = new System.Drawing.Point(39, 136);
            this.feedbackTXB.Name = "feedbackTXB";
            this.feedbackTXB.Size = new System.Drawing.Size(473, 26);
            this.feedbackTXB.TabIndex = 0;
            this.feedbackTXB.TextChanged += new System.EventHandler(this.feedbackTXB_TextChanged);
            // 
            // labelFeedBack
            // 
            this.labelFeedBack.AutoSize = true;
            this.labelFeedBack.Location = new System.Drawing.Point(98, 69);
            this.labelFeedBack.Name = "labelFeedBack";
            this.labelFeedBack.Size = new System.Drawing.Size(51, 20);
            this.labelFeedBack.TabIndex = 1;
            this.labelFeedBack.Text = "label1";
            this.labelFeedBack.Click += new System.EventHandler(this.labelFeedBack_Click);
            // 
            // XacNhanBTN
            // 
            this.XacNhanBTN.Location = new System.Drawing.Point(373, 188);
            this.XacNhanBTN.Name = "XacNhanBTN";
            this.XacNhanBTN.Size = new System.Drawing.Size(108, 42);
            this.XacNhanBTN.TabIndex = 2;
            this.XacNhanBTN.Text = "Xác nhận ";
            this.XacNhanBTN.UseVisualStyleBackColor = true;
            this.XacNhanBTN.Click += new System.EventHandler(this.XacNhanBTN_Click);
            // 
            // FeedbackForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 251);
            this.Controls.Add(this.XacNhanBTN);
            this.Controls.Add(this.labelFeedBack);
            this.Controls.Add(this.feedbackTXB);
            this.Name = "FeedbackForm";
            this.Text = "Feedback";
            this.Load += new System.EventHandler(this.FeedbackForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox feedbackTXB;
        private System.Windows.Forms.Label labelFeedBack;
        private System.Windows.Forms.Button XacNhanBTN;
    }
}