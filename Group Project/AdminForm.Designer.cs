namespace Group_Project
{
    partial class AdminForm
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
            this.UserButtonsGroupBox = new System.Windows.Forms.GroupBox();
            this.AdminUserButton = new System.Windows.Forms.Button();
            this.InstructorUserButton = new System.Windows.Forms.Button();
            this.StudentUserButton = new System.Windows.Forms.Button();
            this.UsersListBox = new System.Windows.Forms.ListBox();
            this.ExitEditGroupBox = new System.Windows.Forms.GroupBox();
            this.DropButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.EditPersonalInformationButton = new System.Windows.Forms.Button();
            this.InfoLabel = new System.Windows.Forms.Label();
            this.ExitButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.AddNewClassButton = new System.Windows.Forms.Button();
            this.DeleteExistingClassButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.UserButtonsGroupBox.SuspendLayout();
            this.ExitEditGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // UserButtonsGroupBox
            // 
            this.UserButtonsGroupBox.Controls.Add(this.AdminUserButton);
            this.UserButtonsGroupBox.Controls.Add(this.InstructorUserButton);
            this.UserButtonsGroupBox.Controls.Add(this.StudentUserButton);
            this.UserButtonsGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserButtonsGroupBox.Location = new System.Drawing.Point(45, 27);
            this.UserButtonsGroupBox.Name = "UserButtonsGroupBox";
            this.UserButtonsGroupBox.Size = new System.Drawing.Size(472, 85);
            this.UserButtonsGroupBox.TabIndex = 0;
            this.UserButtonsGroupBox.TabStop = false;
            this.UserButtonsGroupBox.Text = "Select Type of User:";
            // 
            // AdminUserButton
            // 
            this.AdminUserButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AdminUserButton.Location = new System.Drawing.Point(360, 24);
            this.AdminUserButton.Name = "AdminUserButton";
            this.AdminUserButton.Size = new System.Drawing.Size(97, 43);
            this.AdminUserButton.TabIndex = 2;
            this.AdminUserButton.Text = "Admin";
            this.AdminUserButton.UseVisualStyleBackColor = true;
            this.AdminUserButton.Click += new System.EventHandler(this.AdminUserButton_Click);
            // 
            // InstructorUserButton
            // 
            this.InstructorUserButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InstructorUserButton.Location = new System.Drawing.Point(242, 24);
            this.InstructorUserButton.Name = "InstructorUserButton";
            this.InstructorUserButton.Size = new System.Drawing.Size(96, 43);
            this.InstructorUserButton.TabIndex = 1;
            this.InstructorUserButton.Text = "Instructor";
            this.InstructorUserButton.UseVisualStyleBackColor = true;
            this.InstructorUserButton.Click += new System.EventHandler(this.InstructorUserButton_Click);
            // 
            // StudentUserButton
            // 
            this.StudentUserButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StudentUserButton.Location = new System.Drawing.Point(130, 24);
            this.StudentUserButton.Name = "StudentUserButton";
            this.StudentUserButton.Size = new System.Drawing.Size(94, 43);
            this.StudentUserButton.TabIndex = 0;
            this.StudentUserButton.Text = "Student";
            this.StudentUserButton.UseVisualStyleBackColor = true;
            this.StudentUserButton.Click += new System.EventHandler(this.StudentUserButton_Click);
            // 
            // UsersListBox
            // 
            this.UsersListBox.FormattingEnabled = true;
            this.UsersListBox.ItemHeight = 16;
            this.UsersListBox.Location = new System.Drawing.Point(45, 151);
            this.UsersListBox.Name = "UsersListBox";
            this.UsersListBox.Size = new System.Drawing.Size(599, 164);
            this.UsersListBox.TabIndex = 1;
            // 
            // ExitEditGroupBox
            // 
            this.ExitEditGroupBox.Controls.Add(this.DropButton);
            this.ExitEditGroupBox.Controls.Add(this.AddButton);
            this.ExitEditGroupBox.Controls.Add(this.EditPersonalInformationButton);
            this.ExitEditGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitEditGroupBox.Location = new System.Drawing.Point(45, 333);
            this.ExitEditGroupBox.Name = "ExitEditGroupBox";
            this.ExitEditGroupBox.Size = new System.Drawing.Size(327, 122);
            this.ExitEditGroupBox.TabIndex = 2;
            this.ExitEditGroupBox.TabStop = false;
            this.ExitEditGroupBox.Tag = "";
            this.ExitEditGroupBox.Text = "Edit User:";
            // 
            // DropButton
            // 
            this.DropButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DropButton.Location = new System.Drawing.Point(117, 30);
            this.DropButton.Name = "DropButton";
            this.DropButton.Size = new System.Drawing.Size(86, 72);
            this.DropButton.TabIndex = 3;
            this.DropButton.Text = "Drop Classes";
            this.DropButton.UseVisualStyleBackColor = true;
            this.DropButton.Click += new System.EventHandler(this.DropButton_Click);
            // 
            // AddButton
            // 
            this.AddButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddButton.Location = new System.Drawing.Point(15, 28);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(86, 74);
            this.AddButton.TabIndex = 1;
            this.AddButton.Text = "Add Classes";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.EditClassesButton_Click);
            // 
            // EditPersonalInformationButton
            // 
            this.EditPersonalInformationButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditPersonalInformationButton.Location = new System.Drawing.Point(219, 28);
            this.EditPersonalInformationButton.Name = "EditPersonalInformationButton";
            this.EditPersonalInformationButton.Size = new System.Drawing.Size(90, 74);
            this.EditPersonalInformationButton.TabIndex = 0;
            this.EditPersonalInformationButton.Text = "Edit Personal Information";
            this.EditPersonalInformationButton.UseVisualStyleBackColor = true;
            this.EditPersonalInformationButton.Click += new System.EventHandler(this.EditPersonalInformationButton_Click);
            // 
            // InfoLabel
            // 
            this.InfoLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.InfoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InfoLabel.Location = new System.Drawing.Point(45, 129);
            this.InfoLabel.Name = "InfoLabel";
            this.InfoLabel.Size = new System.Drawing.Size(599, 23);
            this.InfoLabel.TabIndex = 3;
            this.InfoLabel.Text = "Select A User From List";
            this.InfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(146, 28);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(86, 74);
            this.ExitButton.TabIndex = 2;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.AddNewClassButton);
            this.groupBox1.Controls.Add(this.DeleteExistingClassButton);
            this.groupBox1.Controls.Add(this.ExitButton);
            this.groupBox1.Location = new System.Drawing.Point(390, 333);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(254, 122);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // AddNewClassButton
            // 
            this.AddNewClassButton.Location = new System.Drawing.Point(18, 20);
            this.AddNewClassButton.Name = "AddNewClassButton";
            this.AddNewClassButton.Size = new System.Drawing.Size(109, 42);
            this.AddNewClassButton.TabIndex = 3;
            this.AddNewClassButton.Text = "Add New Class";
            this.AddNewClassButton.UseVisualStyleBackColor = true;
            this.AddNewClassButton.Click += new System.EventHandler(this.AddNewClassButton_Click);
            // 
            // DeleteExistingClassButton
            // 
            this.DeleteExistingClassButton.Location = new System.Drawing.Point(18, 68);
            this.DeleteExistingClassButton.Name = "DeleteExistingClassButton";
            this.DeleteExistingClassButton.Size = new System.Drawing.Size(109, 42);
            this.DeleteExistingClassButton.TabIndex = 1;
            this.DeleteExistingClassButton.Text = "Delete Existing Class";
            this.DeleteExistingClassButton.UseVisualStyleBackColor = true;
            this.DeleteExistingClassButton.Click += new System.EventHandler(this.DeleteExistingClassButton_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 32);
            this.label1.TabIndex = 6;
            this.label1.Text = "Logged In:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(539, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(105, 88);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.label2.Location = new System.Drawing.Point(5, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 42);
            this.label2.TabIndex = 7;
            this.label2.Text = "UserName";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 475);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.InfoLabel);
            this.Controls.Add(this.ExitEditGroupBox);
            this.Controls.Add(this.UsersListBox);
            this.Controls.Add(this.UserButtonsGroupBox);
            this.Name = "AdminForm";
            this.Text = "AdminForm";
            this.Load += new System.EventHandler(this.AdminForm_Load);
            this.UserButtonsGroupBox.ResumeLayout(false);
            this.ExitEditGroupBox.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox UserButtonsGroupBox;
        private System.Windows.Forms.Button AdminUserButton;
        private System.Windows.Forms.Button InstructorUserButton;
        private System.Windows.Forms.Button StudentUserButton;
        private System.Windows.Forms.ListBox UsersListBox;
        private System.Windows.Forms.GroupBox ExitEditGroupBox;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button EditPersonalInformationButton;
        private System.Windows.Forms.Label InfoLabel;
        private System.Windows.Forms.Button DropButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button AddNewClassButton;
        private System.Windows.Forms.Button DeleteExistingClassButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
    }
}

