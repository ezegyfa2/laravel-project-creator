using System.Windows.Forms;

namespace LaravelProjectCreator
{
    partial class CreatorForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.projectNameTextBox = new System.Windows.Forms.TextBox();
            this.projectNameLabel = new System.Windows.Forms.Label();
            this.projectsPathTextBox = new System.Windows.Forms.TextBox();
            this.projectsPathLabel = new System.Windows.Forms.Label();
            this.createButton = new System.Windows.Forms.Button();
            this.adminTemplateLabel = new System.Windows.Forms.Label();
            this.adminTemplateComboBox = new System.Windows.Forms.ComboBox();
            this.nodeModulesPathTextBox = new System.Windows.Forms.TextBox();
            this.nodeModulesPathLabel = new System.Windows.Forms.Label();
            this.laravelModulesTextBox = new System.Windows.Forms.TextBox();
            this.laravelModulesLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // projectNameTextBox
            // 
            this.projectNameTextBox.Location = new System.Drawing.Point(115, 19);
            this.projectNameTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.projectNameTextBox.Name = "projectNameTextBox";
            this.projectNameTextBox.Size = new System.Drawing.Size(247, 20);
            this.projectNameTextBox.TabIndex = 3;
            // 
            // projectNameLabel
            // 
            this.projectNameLabel.AutoSize = true;
            this.projectNameLabel.Location = new System.Drawing.Point(39, 21);
            this.projectNameLabel.Name = "projectNameLabel";
            this.projectNameLabel.Size = new System.Drawing.Size(69, 13);
            this.projectNameLabel.TabIndex = 2;
            this.projectNameLabel.Text = "Project name";
            // 
            // projectsPathTextBox
            // 
            this.projectsPathTextBox.Location = new System.Drawing.Point(115, 40);
            this.projectsPathTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.projectsPathTextBox.Name = "projectsPathTextBox";
            this.projectsPathTextBox.Size = new System.Drawing.Size(247, 20);
            this.projectsPathTextBox.TabIndex = 5;
            this.projectsPathTextBox.TextChanged += new System.EventHandler(this.projectsPathTextBox_TextChanged);
            // 
            // projectsPathLabel
            // 
            this.projectsPathLabel.AutoSize = true;
            this.projectsPathLabel.Location = new System.Drawing.Point(39, 42);
            this.projectsPathLabel.Name = "projectsPathLabel";
            this.projectsPathLabel.Size = new System.Drawing.Size(69, 13);
            this.projectsPathLabel.TabIndex = 4;
            this.projectsPathLabel.Text = "Projects path";
            // 
            // createButton
            // 
            this.createButton.Location = new System.Drawing.Point(168, 139);
            this.createButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(70, 19);
            this.createButton.TabIndex = 6;
            this.createButton.Text = "Create";
            this.createButton.UseVisualStyleBackColor = true;
            this.createButton.Click += new System.EventHandler(this.createButton_Click);
            // 
            // adminTemplateLabel
            // 
            this.adminTemplateLabel.AutoSize = true;
            this.adminTemplateLabel.Location = new System.Drawing.Point(22, 113);
            this.adminTemplateLabel.Name = "adminTemplateLabel";
            this.adminTemplateLabel.Size = new System.Drawing.Size(79, 13);
            this.adminTemplateLabel.TabIndex = 7;
            this.adminTemplateLabel.Text = "Admin template";
            // 
            // adminTemplateComboBox
            // 
            this.adminTemplateComboBox.FormattingEnabled = true;
            this.adminTemplateComboBox.Items.AddRange(new object[] {
            "None",
            "Blue admin"});
            this.adminTemplateComboBox.Location = new System.Drawing.Point(115, 110);
            this.adminTemplateComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.adminTemplateComboBox.Name = "adminTemplateComboBox";
            this.adminTemplateComboBox.Size = new System.Drawing.Size(247, 21);
            this.adminTemplateComboBox.TabIndex = 8;
            // 
            // nodeModulesPathTextBox
            // 
            this.nodeModulesPathTextBox.Location = new System.Drawing.Point(115, 63);
            this.nodeModulesPathTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nodeModulesPathTextBox.Name = "nodeModulesPathTextBox";
            this.nodeModulesPathTextBox.Size = new System.Drawing.Size(247, 20);
            this.nodeModulesPathTextBox.TabIndex = 10;
            this.nodeModulesPathTextBox.TextChanged += new System.EventHandler(this.nodeModulesPathTextBox_TextChanged);
            // 
            // nodeModulesPathLabel
            // 
            this.nodeModulesPathLabel.AutoSize = true;
            this.nodeModulesPathLabel.Location = new System.Drawing.Point(10, 66);
            this.nodeModulesPathLabel.Name = "nodeModulesPathLabel";
            this.nodeModulesPathLabel.Size = new System.Drawing.Size(99, 13);
            this.nodeModulesPathLabel.TabIndex = 9;
            this.nodeModulesPathLabel.Text = "Node modules path";
            // 
            // laravelModulesTextBox
            // 
            this.laravelModulesTextBox.Location = new System.Drawing.Point(115, 87);
            this.laravelModulesTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.laravelModulesTextBox.Name = "laravelModulesTextBox";
            this.laravelModulesTextBox.Size = new System.Drawing.Size(247, 20);
            this.laravelModulesTextBox.TabIndex = 12;
            this.laravelModulesTextBox.TextChanged += new System.EventHandler(this.laravelModulesTextBox_TextChanged);
            // 
            // laravelModulesLabel
            // 
            this.laravelModulesLabel.AutoSize = true;
            this.laravelModulesLabel.Location = new System.Drawing.Point(1, 90);
            this.laravelModulesLabel.Name = "laravelModulesLabel";
            this.laravelModulesLabel.Size = new System.Drawing.Size(108, 13);
            this.laravelModulesLabel.TabIndex = 11;
            this.laravelModulesLabel.Text = "Laravel modules path";
            // 
            // CreatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 173);
            this.Controls.Add(this.laravelModulesTextBox);
            this.Controls.Add(this.laravelModulesLabel);
            this.Controls.Add(this.nodeModulesPathTextBox);
            this.Controls.Add(this.nodeModulesPathLabel);
            this.Controls.Add(this.adminTemplateComboBox);
            this.Controls.Add(this.adminTemplateLabel);
            this.Controls.Add(this.createButton);
            this.Controls.Add(this.projectsPathTextBox);
            this.Controls.Add(this.projectsPathLabel);
            this.Controls.Add(this.projectNameTextBox);
            this.Controls.Add(this.projectNameLabel);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "CreatorForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private TextBox projectNameTextBox;
        private Label projectNameLabel;
        private TextBox projectsPathTextBox;
        private Label projectsPathLabel;
        private Button createButton;
        private Label adminTemplateLabel;
        private ComboBox adminTemplateComboBox;
        private TextBox nodeModulesPathTextBox;
        private Label nodeModulesPathLabel;
        private TextBox laravelModulesTextBox;
        private Label laravelModulesLabel;
    }
}