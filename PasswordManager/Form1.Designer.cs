namespace PasswordManager
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            txtPassword = new TextBox();
            btnGenerate = new Button();
            btnSave = new Button();
            SuspendLayout();
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(12, 12);
            txtPassword.Name = "txtPassword";
            txtPassword.PlaceholderText = "Пароль";
            txtPassword.Size = new Size(360, 23);
            txtPassword.TabIndex = 2;
            // 
            // btnGenerate
            // 
            btnGenerate.Location = new Point(142, 41);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(92, 23);
            btnGenerate.TabIndex = 3;
            btnGenerate.Text = "Генерировать";
            btnGenerate.UseVisualStyleBackColor = true;
            btnGenerate.Click += btnGenerate_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(112, 70);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(152, 23);
            btnSave.TabIndex = 4;
            btnSave.Text = "Сохранить пароль";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // Form1
            // 
            BackgroundImage = Properties.Resources.back;
            ClientSize = new Size(383, 133);
            Controls.Add(btnSave);
            Controls.Add(btnGenerate);
            Controls.Add(txtPassword);
            Name = "Form1";
            Text = "Менеджеропаролеинатор 3000";
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnSave;
    }
}
