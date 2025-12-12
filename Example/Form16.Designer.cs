namespace Example
{
    partial class Form16
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

            // Khai báo các cột
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

            // --- CẤU HÌNH CỘT ---
            colId.HeaderText = "Mã NV";
            colId.DataPropertyName = "Id"; // Khớp với class Employee

            colName.HeaderText = "Tên Nhân Viên";
            colName.DataPropertyName = "Name";
            colName.Width = 200;

            colAge.HeaderText = "Tuổi";
            colAge.DataPropertyName = "Age";

            colGender.HeaderText = "Nam?";
            colGender.DataPropertyName = "Gender";

            // Thêm cột vào Grid
            this.dgvEmployee.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { colId, colName, colAge, colGender });

            // Cấu hình hiển thị Grid
            this.dgvEmployee.Dock = System.Windows.Forms.DockStyle.Fill; // Tràn đầy Form
            this.dgvEmployee.Name = "dgvEmployee";

            // 
            // Form16
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.Controls.Add(this.dgvEmployee); // Chỉ add mỗi DataGridView
            this.Name = "Form16";
            this.Text = "article 22";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Form16_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployee)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridView dgvEmployee;
    }
}