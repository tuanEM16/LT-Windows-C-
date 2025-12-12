namespace Example
{
    partial class Form17
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvEmployee = new System.Windows.Forms.DataGridView();
            this.tbId = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbAge = new System.Windows.Forms.TextBox();
            this.ckGender = new System.Windows.Forms.CheckBox();
            this.btAddNew = new System.Windows.Forms.Button();
            this.btDelete = new System.Windows.Forms.Button();
            this.btExit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();

            // --- KHAI BÁO CỘT ---
            System.Windows.Forms.DataGridViewTextBoxColumn colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            System.Windows.Forms.DataGridViewTextBoxColumn colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            System.Windows.Forms.DataGridViewTextBoxColumn colAge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            System.Windows.Forms.DataGridViewCheckBoxColumn colGender = new System.Windows.Forms.DataGridViewCheckBoxColumn();

            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployee)).BeginInit();
            this.SuspendLayout();

            // 
            // dgvEmployee
            // 
            this.dgvEmployee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmployee.Location = new System.Drawing.Point(12, 12);
            this.dgvEmployee.Name = "dgvEmployee";
            this.dgvEmployee.Size = new System.Drawing.Size(560, 200);
            this.dgvEmployee.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEmployee.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEmployee_RowEnter);

            // --- CẤU HÌNH CỘT (MAPPING DỮ LIỆU) ---
            colId.HeaderText = "Mã NV";
            colId.DataPropertyName = "Id"; // BẮT BUỘC KHỚP VỚI CLASS EMPLOYEE

            colName.HeaderText = "Tên Nhân Viên";
            colName.DataPropertyName = "Name";
            colName.Width = 200;

            colAge.HeaderText = "Tuổi";
            colAge.DataPropertyName = "Age";

            colGender.HeaderText = "Nam?";
            colGender.DataPropertyName = "Gender";

            // Thêm cột vào Grid
            this.dgvEmployee.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { colId, colName, colAge, colGender });

            // 
            // Các Control nhập liệu
            // 
            this.label1.AutoSize = true;
            this.label1.Text = "Mã nhân viên:";
            this.label1.Location = new System.Drawing.Point(50, 240);

            this.tbId.Location = new System.Drawing.Point(160, 237);
            this.tbId.Size = new System.Drawing.Size(150, 20);

            this.label2.AutoSize = true;
            this.label2.Text = "Tên nhân viên:";
            this.label2.Location = new System.Drawing.Point(50, 280);

            this.tbName.Location = new System.Drawing.Point(160, 277);
            this.tbName.Size = new System.Drawing.Size(250, 20);

            this.label3.AutoSize = true;
            this.label3.Text = "Tuổi:";
            this.label3.Location = new System.Drawing.Point(50, 320);

            this.tbAge.Location = new System.Drawing.Point(160, 317);
            this.tbAge.Size = new System.Drawing.Size(100, 20);

            this.ckGender.AutoSize = true;
            this.ckGender.Text = "Nam";
            this.ckGender.Location = new System.Drawing.Point(160, 360);
            this.ckGender.UseVisualStyleBackColor = true;

            // 
            // Các Button
            // 
            this.btAddNew.Text = "Thêm";
            this.btAddNew.Location = new System.Drawing.Point(230, 400);
            this.btAddNew.Size = new System.Drawing.Size(90, 30);
            this.btAddNew.Click += new System.EventHandler(this.btAddNew_Click);

            this.btDelete.Text = "Xóa";
            this.btDelete.Location = new System.Drawing.Point(330, 400);
            this.btDelete.Size = new System.Drawing.Size(90, 30);
            this.btDelete.Click += new System.EventHandler(this.btDelete_Click);

            this.btExit.Text = "Thoát";
            this.btExit.Location = new System.Drawing.Point(430, 400);
            this.btExit.Size = new System.Drawing.Size(90, 30);
            this.btExit.Click += new System.EventHandler(this.btExit_Click);

            // 
            // Form17
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 460);
            this.Controls.Add(label1); this.Controls.Add(label2); this.Controls.Add(label3);
            this.Controls.Add(btExit); this.Controls.Add(btDelete); this.Controls.Add(btAddNew);
            this.Controls.Add(ckGender); this.Controls.Add(tbAge); this.Controls.Add(tbName); this.Controls.Add(tbId);
            this.Controls.Add(this.dgvEmployee);
            this.Name = "Form17";
            this.Text = "Article 22: BindingSource";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Form17_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployee)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.DataGridView dgvEmployee;
        private System.Windows.Forms.TextBox tbId, tbName, tbAge;
        private System.Windows.Forms.CheckBox ckGender;
        private System.Windows.Forms.Button btAddNew, btDelete, btExit;
        private System.Windows.Forms.Label label1, label2, label3;
    }
}