namespace BasicCoffeeShop
{
    partial class fTableList
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lsvBill = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel3 = new System.Windows.Forms.Panel();
            this.siticoneComboBox3 = new Siticone.Desktop.UI.WinForms.SiticoneComboBox();
            this.siticoneComboBox2 = new Siticone.Desktop.UI.WinForms.SiticoneComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.siticoneButton4 = new Siticone.Desktop.UI.WinForms.SiticoneButton();
            this.txbTotalPrice = new System.Windows.Forms.TextBox();
            this.siticoneButton2 = new Siticone.Desktop.UI.WinForms.SiticoneButton();
            this.SNUDdiscount = new Siticone.Desktop.UI.WinForms.SiticoneNumericUpDown();
            this.siticoneButton3 = new Siticone.Desktop.UI.WinForms.SiticoneButton();
            this.btnPayMent = new Siticone.Desktop.UI.WinForms.SiticoneButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.userNameLb = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TableNamelb = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cbxDrink = new Siticone.Desktop.UI.WinForms.SiticoneComboBox();
            this.orderDrinkBtn = new Siticone.Desktop.UI.WinForms.SiticoneButton();
            this.nmDrinkCount = new Siticone.Desktop.UI.WinForms.SiticoneNumericUpDown();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flpTable = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SNUDdiscount)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmDrinkCount)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lsvBill);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(606, -2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(609, 619);
            this.panel1.TabIndex = 19;
            // 
            // lsvBill
            // 
            this.lsvBill.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader4,
            this.columnHeader5});
            this.lsvBill.GridLines = true;
            this.lsvBill.HideSelection = false;
            this.lsvBill.Location = new System.Drawing.Point(10, 129);
            this.lsvBill.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lsvBill.Name = "lsvBill";
            this.lsvBill.Size = new System.Drawing.Size(586, 378);
            this.lsvBill.TabIndex = 33;
            this.lsvBill.UseCompatibleStateImageBehavior = false;
            this.lsvBill.View = System.Windows.Forms.View.Details;
            this.lsvBill.SelectedIndexChanged += new System.EventHandler(this.lsvBill_SelectedIndexChanged);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Tên nước";
            this.columnHeader3.Width = 160;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Số lượng";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Giá";
            this.columnHeader2.Width = 100;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Tổng tiền";
            this.columnHeader4.Width = 100;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Tên khách hàng";
            this.columnHeader5.Width = 160;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.siticoneComboBox3);
            this.panel3.Controls.Add(this.siticoneComboBox2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.siticoneButton4);
            this.panel3.Controls.Add(this.txbTotalPrice);
            this.panel3.Controls.Add(this.siticoneButton2);
            this.panel3.Controls.Add(this.SNUDdiscount);
            this.panel3.Controls.Add(this.siticoneButton3);
            this.panel3.Controls.Add(this.btnPayMent);
            this.panel3.Location = new System.Drawing.Point(3, 511);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(593, 94);
            this.panel3.TabIndex = 32;
            // 
            // siticoneComboBox3
            // 
            this.siticoneComboBox3.BackColor = System.Drawing.Color.Transparent;
            this.siticoneComboBox3.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.siticoneComboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.siticoneComboBox3.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.siticoneComboBox3.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.siticoneComboBox3.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.siticoneComboBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.siticoneComboBox3.ItemHeight = 30;
            this.siticoneComboBox3.Location = new System.Drawing.Point(106, 50);
            this.siticoneComboBox3.Name = "siticoneComboBox3";
            this.siticoneComboBox3.Size = new System.Drawing.Size(98, 36);
            this.siticoneComboBox3.TabIndex = 38;
            // 
            // siticoneComboBox2
            // 
            this.siticoneComboBox2.BackColor = System.Drawing.Color.Transparent;
            this.siticoneComboBox2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.siticoneComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.siticoneComboBox2.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.siticoneComboBox2.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.siticoneComboBox2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.siticoneComboBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.siticoneComboBox2.ItemHeight = 30;
            this.siticoneComboBox2.Location = new System.Drawing.Point(3, 49);
            this.siticoneComboBox2.Name = "siticoneComboBox2";
            this.siticoneComboBox2.Size = new System.Drawing.Size(98, 36);
            this.siticoneComboBox2.TabIndex = 37;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(326, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 16);
            this.label1.TabIndex = 40;
            this.label1.Text = "Số tiền cần thanh toán";
            // 
            // siticoneButton4
            // 
            this.siticoneButton4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.siticoneButton4.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.siticoneButton4.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.siticoneButton4.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.siticoneButton4.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.siticoneButton4.FillColor = System.Drawing.Color.Gainsboro;
            this.siticoneButton4.Font = new System.Drawing.Font("Segoe UI", 7F);
            this.siticoneButton4.ForeColor = System.Drawing.Color.DimGray;
            this.siticoneButton4.Location = new System.Drawing.Point(3, 10);
            this.siticoneButton4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.siticoneButton4.Name = "siticoneButton4";
            this.siticoneButton4.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 0, 5, 5);
            this.siticoneButton4.Size = new System.Drawing.Size(98, 35);
            this.siticoneButton4.TabIndex = 36;
            this.siticoneButton4.Text = "Switch Tables";
            // 
            // txbTotalPrice
            // 
            this.txbTotalPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txbTotalPrice.Location = new System.Drawing.Point(349, 40);
            this.txbTotalPrice.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txbTotalPrice.Multiline = true;
            this.txbTotalPrice.Name = "txbTotalPrice";
            this.txbTotalPrice.ReadOnly = true;
            this.txbTotalPrice.Size = new System.Drawing.Size(114, 38);
            this.txbTotalPrice.TabIndex = 39;
            this.txbTotalPrice.Text = "0";
            this.txbTotalPrice.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // siticoneButton2
            // 
            this.siticoneButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.siticoneButton2.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.siticoneButton2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.siticoneButton2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.siticoneButton2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.siticoneButton2.FillColor = System.Drawing.Color.Gainsboro;
            this.siticoneButton2.Font = new System.Drawing.Font("Segoe UI", 7F);
            this.siticoneButton2.ForeColor = System.Drawing.Color.DimGray;
            this.siticoneButton2.Location = new System.Drawing.Point(106, 10);
            this.siticoneButton2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.siticoneButton2.Name = "siticoneButton2";
            this.siticoneButton2.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 0, 5, 5);
            this.siticoneButton2.Size = new System.Drawing.Size(98, 35);
            this.siticoneButton2.TabIndex = 34;
            this.siticoneButton2.Text = "Combine Tables";
            // 
            // SNUDdiscount
            // 
            this.SNUDdiscount.BackColor = System.Drawing.Color.Transparent;
            this.SNUDdiscount.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.SNUDdiscount.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.SNUDdiscount.Location = new System.Drawing.Point(209, 50);
            this.SNUDdiscount.Name = "SNUDdiscount";
            this.SNUDdiscount.Size = new System.Drawing.Size(98, 36);
            this.SNUDdiscount.TabIndex = 30;
            // 
            // siticoneButton3
            // 
            this.siticoneButton3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.siticoneButton3.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.siticoneButton3.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.siticoneButton3.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.siticoneButton3.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.siticoneButton3.FillColor = System.Drawing.Color.Gainsboro;
            this.siticoneButton3.Font = new System.Drawing.Font("Segoe UI", 7F);
            this.siticoneButton3.ForeColor = System.Drawing.Color.DimGray;
            this.siticoneButton3.Location = new System.Drawing.Point(209, 10);
            this.siticoneButton3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.siticoneButton3.Name = "siticoneButton3";
            this.siticoneButton3.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 0, 5, 5);
            this.siticoneButton3.Size = new System.Drawing.Size(98, 35);
            this.siticoneButton3.TabIndex = 32;
            this.siticoneButton3.Text = "Discount";
            // 
            // btnPayMent
            // 
            this.btnPayMent.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPayMent.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnPayMent.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnPayMent.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnPayMent.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnPayMent.FillColor = System.Drawing.Color.Gainsboro;
            this.btnPayMent.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnPayMent.ForeColor = System.Drawing.Color.DimGray;
            this.btnPayMent.Location = new System.Drawing.Point(483, 10);
            this.btnPayMent.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPayMent.Name = "btnPayMent";
            this.btnPayMent.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 0, 5, 5);
            this.btnPayMent.Size = new System.Drawing.Size(98, 68);
            this.btnPayMent.TabIndex = 30;
            this.btnPayMent.Text = "Payment";
            this.btnPayMent.Click += new System.EventHandler(this.siticoneButton1_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.userNameLb);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.TableNamelb);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.cbxDrink);
            this.panel2.Controls.Add(this.orderDrinkBtn);
            this.panel2.Controls.Add(this.nmDrinkCount);
            this.panel2.Location = new System.Drawing.Point(10, 15);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(586, 108);
            this.panel2.TabIndex = 31;
            // 
            // userNameLb
            // 
            this.userNameLb.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.userNameLb.Location = new System.Drawing.Point(109, 57);
            this.userNameLb.Name = "userNameLb";
            this.userNameLb.Size = new System.Drawing.Size(260, 36);
            this.userNameLb.TabIndex = 44;
            this.userNameLb.Text = "UserName";
            this.userNameLb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.userNameLb.Click += new System.EventHandler(this.userNameLb_Click);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(21, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 36);
            this.label3.TabIndex = 43;
            this.label3.Text = "User:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TableNamelb
            // 
            this.TableNamelb.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.TableNamelb.Location = new System.Drawing.Point(452, 57);
            this.TableNamelb.Name = "TableNamelb";
            this.TableNamelb.Size = new System.Drawing.Size(122, 36);
            this.TableNamelb.TabIndex = 42;
            this.TableNamelb.Text = "TableName";
            this.TableNamelb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.label11.Location = new System.Drawing.Point(364, 57);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(92, 36);
            this.label11.TabIndex = 41;
            this.label11.Text = "Table:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbxDrink
            // 
            this.cbxDrink.BackColor = System.Drawing.Color.Transparent;
            this.cbxDrink.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbxDrink.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDrink.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbxDrink.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbxDrink.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbxDrink.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbxDrink.ItemHeight = 30;
            this.cbxDrink.Location = new System.Drawing.Point(3, 3);
            this.cbxDrink.Name = "cbxDrink";
            this.cbxDrink.Size = new System.Drawing.Size(197, 36);
            this.cbxDrink.TabIndex = 22;
            this.cbxDrink.SelectedIndexChanged += new System.EventHandler(this.siticoneComboBox1_SelectedIndexChanged);
            // 
            // orderDrinkBtn
            // 
            this.orderDrinkBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.orderDrinkBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.orderDrinkBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.orderDrinkBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.orderDrinkBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.orderDrinkBtn.FillColor = System.Drawing.Color.Gainsboro;
            this.orderDrinkBtn.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.orderDrinkBtn.ForeColor = System.Drawing.Color.DimGray;
            this.orderDrinkBtn.Location = new System.Drawing.Point(204, 3);
            this.orderDrinkBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.orderDrinkBtn.Name = "orderDrinkBtn";
            this.orderDrinkBtn.ShadowDecoration.Enabled = true;
            this.orderDrinkBtn.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 0, 5, 5);
            this.orderDrinkBtn.Size = new System.Drawing.Size(105, 36);
            this.orderDrinkBtn.TabIndex = 28;
            this.orderDrinkBtn.Text = "Order";
            this.orderDrinkBtn.Click += new System.EventHandler(this.orderDrinkBtn_Click);
            // 
            // nmDrinkCount
            // 
            this.nmDrinkCount.BackColor = System.Drawing.Color.Transparent;
            this.nmDrinkCount.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.nmDrinkCount.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.nmDrinkCount.Location = new System.Drawing.Point(342, 3);
            this.nmDrinkCount.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.nmDrinkCount.Name = "nmDrinkCount";
            this.nmDrinkCount.Size = new System.Drawing.Size(62, 36);
            this.nmDrinkCount.TabIndex = 29;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.flpTable);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(2, -2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(599, 619);
            this.flowLayoutPanel1.TabIndex = 20;
            // 
            // flpTable
            // 
            this.flpTable.AutoScroll = true;
            this.flpTable.Location = new System.Drawing.Point(3, 2);
            this.flpTable.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flpTable.Name = "flpTable";
            this.flpTable.Size = new System.Drawing.Size(588, 617);
            this.flpTable.TabIndex = 0;
            // 
            // fTableList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1212, 615);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Name = "fTableList";
            this.Text = "fTableList";
            this.Load += new System.EventHandler(this.fTableList_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SNUDdiscount)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nmDrinkCount)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private Siticone.Desktop.UI.WinForms.SiticoneComboBox cbxDrink;
        private Siticone.Desktop.UI.WinForms.SiticoneButton orderDrinkBtn;
        private Siticone.Desktop.UI.WinForms.SiticoneNumericUpDown nmDrinkCount;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel3;
        private Siticone.Desktop.UI.WinForms.SiticoneButton btnPayMent;
        private System.Windows.Forms.Panel panel2;
        private Siticone.Desktop.UI.WinForms.SiticoneNumericUpDown SNUDdiscount;
        private Siticone.Desktop.UI.WinForms.SiticoneButton siticoneButton3;
        private Siticone.Desktop.UI.WinForms.SiticoneComboBox siticoneComboBox3;
        private Siticone.Desktop.UI.WinForms.SiticoneComboBox siticoneComboBox2;
        private Siticone.Desktop.UI.WinForms.SiticoneButton siticoneButton4;
        private Siticone.Desktop.UI.WinForms.SiticoneButton siticoneButton2;
        private System.Windows.Forms.FlowLayoutPanel flpTable;
        private System.Windows.Forms.ListView lsvBill;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.TextBox txbTotalPrice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label TableNamelb;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label userNameLb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ColumnHeader columnHeader5;
    }
}