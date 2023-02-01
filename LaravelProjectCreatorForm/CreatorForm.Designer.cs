namespace LaravelProjectCreatorForm
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
            this.vueComponentsPathTextBox = new System.Windows.Forms.TextBox();
            this.vueComponentsPathLabel = new System.Windows.Forms.Label();
            this.laravelModulesTextBox = new System.Windows.Forms.TextBox();
            this.laravelModulesLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // projectNameTextBox
            // 
            this.projectNameTextBox.Location = new System.Drawing.Point(134, 22);
            this.projectNameTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.projectNameTextBox.Name = "projectNameTextBox";
            this.projectNameTextBox.Size = new System.Drawing.Size(288, 23);
            this.projectNameTextBox.TabIndex = 3;
            // 
            // projectNameLabel
            // 
            this.projectNameLabel.AutoSize = true;
            this.projectNameLabel.Location = new System.Drawing.Point(45, 24);
            this.projectNameLabel.Name = "projectNameLabel";
            this.projectNameLabel.Size = new System.Drawing.Size(77, 15);
            this.projectNameLabel.TabIndex = 2;
            this.projectNameLabel.Text = "Project name";
            // 
            // projectsPathTextBox
            // 
            this.projectsPathTextBox.Location = new System.Drawing.Point(134, 46);
            this.projectsPathTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.projectsPathTextBox.Name = "projectsPathTextBox";
            this.projectsPathTextBox.Size = new System.Drawing.Size(288, 23);
            this.projectsPathTextBox.TabIndex = 5;
            this.projectsPathTextBox.TextChanged += new System.EventHandler(this.projectsPathTextBox_TextChanged);
            // 
            // projectsPathLabel
            // 
            this.projectsPathLabel.AutoSize = true;
            this.projectsPathLabel.Location = new System.Drawing.Point(46, 49);
            this.projectsPathLabel.Name = "projectsPathLabel";
            this.projectsPathLabel.Size = new System.Drawing.Size(76, 15);
            this.projectsPathLabel.TabIndex = 4;
            this.projectsPathLabel.Text = "Projects path";
            // 
            // createButton
            // 
            this.createButton.Location = new System.Drawing.Point(196, 160);
            this.createButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(82, 22);
            this.createButton.TabIndex = 6;
            this.createButton.Text = "Create";
            this.createButton.UseVisualStyleBackColor = true;
            this.createButton.Click += new System.EventHandler(this.createButton_Click);
            // 
            // adminTemplateLabel
            // 
            this.adminTemplateLabel.AutoSize = true;
            this.adminTemplateLabel.Location = new System.Drawing.Point(26, 130);
            this.adminTemplateLabel.Name = "adminTemplateLabel";
            this.adminTemplateLabel.Size = new System.Drawing.Size(93, 15);
            this.adminTemplateLabel.TabIndex = 7;
            this.adminTemplateLabel.Text = "Admin template";
            // 
            // adminTemplateComboBox
            // 
            this.adminTemplateComboBox.FormattingEnabled = true;
            this.adminTemplateComboBox.Items.AddRange(new object[] {
            "None",
            "Blue admin"});
            this.adminTemplateComboBox.Location = new System.Drawing.Point(134, 127);
            this.adminTemplateComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.adminTemplateComboBox.Name = "adminTemplateComboBox";
            this.adminTemplateComboBox.Size = new System.Drawing.Size(288, 23);
            this.adminTemplateComboBox.TabIndex = 8;
            // 
            // vueComponentsPathTextBox
            // 
            this.vueComponentsPathTextBox.Location = new System.Drawing.Point(134, 73);
            this.vueComponentsPathTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.vueComponentsPathTextBox.Name = "vueComponentsPathTextBox";
            this.vueComponentsPathTextBox.Size = new System.Drawing.Size(288, 23);
            this.vueComponentsPathTextBox.TabIndex = 10;
            // 
            // vueComponentsPathLabel
            // 
            this.vueComponentsPathLabel.AutoSize = true;
            this.vueComponentsPathLabel.Location = new System.Drawing.Point(4, 76);
            this.vueComponentsPathLabel.Name = "vueComponentsPathLabel";
            this.vueComponentsPathLabel.Size = new System.Drawing.Size(124, 15);
            this.vueComponentsPathLabel.TabIndex = 9;
            this.vueComponentsPathLabel.Text = "Vue components path";
            // 
            // laravelModulesTextBox
            // 
            this.laravelModulesTextBox.Location = new System.Drawing.Point(134, 100);
            this.laravelModulesTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.laravelModulesTextBox.Name = "laravelModulesTextBox";
            this.laravelModulesTextBox.Size = new System.Drawing.Size(288, 23);
            this.laravelModulesTextBox.TabIndex = 12;
            // 
            // laravelModulesLabel
            // 
            this.laravelModulesLabel.AutoSize = true;
            this.laravelModulesLabel.Location = new System.Drawing.Point(8, 103);
            this.laravelModulesLabel.Name = "laravelModulesLabel";
            this.laravelModulesLabel.Size = new System.Drawing.Size(120, 15);
            this.laravelModulesLabel.TabIndex = 11;
            this.laravelModulesLabel.Text = "Laravel modules path";
            // 
            // CreatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 200);
            this.Controls.Add(this.laravelModulesTextBox);
            this.Controls.Add(this.laravelModulesLabel);
            this.Controls.Add(this.vueComponentsPathTextBox);
            this.Controls.Add(this.vueComponentsPathLabel);
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
        private TextBox vueComponentsPathTextBox;
        private Label vueComponentsPathLabel;
        private TextBox laravelModulesTextBox;
        private Label laravelModulesLabel;
    }
}