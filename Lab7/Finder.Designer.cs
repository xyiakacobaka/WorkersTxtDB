namespace Lab7
{
    partial class Finder
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            FindFamily = new TextBox();
            Find = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 15.75F);
            label1.Location = new Point(26, 28);
            label1.Name = "label1";
            label1.Size = new Size(91, 23);
            label1.TabIndex = 0;
            label1.Text = "Фамилия";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 15.75F);
            label2.Location = new Point(26, 51);
            label2.Name = "label2";
            label2.Size = new Size(93, 23);
            label2.TabIndex = 1;
            label2.Text = "искомого";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 15.75F);
            label3.Location = new Point(26, 74);
            label3.Name = "label3";
            label3.Size = new Size(115, 23);
            label3.TabIndex = 2;
            label3.Text = "сотрудника:";
            // 
            // FindFamily
            // 
            FindFamily.Location = new Point(199, 77);
            FindFamily.Name = "FindFamily";
            FindFamily.Size = new Size(200, 23);
            FindFamily.TabIndex = 3;
            FindFamily.TextChanged += FindFamily_TextChanged;
            // 
            // Find
            // 
            Find.Font = new Font("Times New Roman", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Find.Location = new Point(284, 25);
            Find.Name = "Find";
            Find.Size = new Size(115, 46);
            Find.TabIndex = 4;
            Find.Text = "Искать";
            Find.UseVisualStyleBackColor = true;
            Find.Click += Find_Click;
            // 
            // Finder
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(411, 112);
            Controls.Add(Find);
            Controls.Add(FindFamily);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Finder";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Поиск";
            TopMost = true;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox FindFamily;
        private Button Find;
    }
}