
namespace View
{
    partial class Search
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
            this.radioButtonType = new System.Windows.Forms.RadioButton();
            this.radioButtonValue = new System.Windows.Forms.RadioButton();
            this.radioButtonSquare = new System.Windows.Forms.RadioButton();
            this.panelType = new System.Windows.Forms.Panel();
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.labelTypeFigure1 = new System.Windows.Forms.Label();
            this.panelValue = new System.Windows.Forms.Panel();
            this.comboBoxType2 = new System.Windows.Forms.ComboBox();
            this.labelTypeFigure2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelSquare = new System.Windows.Forms.Panel();
            this.labelSquare = new System.Windows.Forms.Label();
            this.textBoxSquare = new System.Windows.Forms.TextBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.panelType.SuspendLayout();
            this.panelValue.SuspendLayout();
            this.panelSquare.SuspendLayout();
            this.SuspendLayout();
            // 
            // radioButtonType
            // 
            this.radioButtonType.AutoSize = true;
            this.radioButtonType.Font = new System.Drawing.Font("Open Sans Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonType.Location = new System.Drawing.Point(15, 10);
            this.radioButtonType.Name = "radioButtonType";
            this.radioButtonType.Size = new System.Drawing.Size(158, 26);
            this.radioButtonType.TabIndex = 0;
            this.radioButtonType.Text = "По типу фигуры";
            this.radioButtonType.UseVisualStyleBackColor = true;
            this.radioButtonType.CheckedChanged += new System.EventHandler(this.radioButtonType_CheckedChanged);
            // 
            // radioButtonValue
            // 
            this.radioButtonValue.AutoSize = true;
            this.radioButtonValue.Font = new System.Drawing.Font("Open Sans Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonValue.Location = new System.Drawing.Point(15, 103);
            this.radioButtonValue.Name = "radioButtonValue";
            this.radioButtonValue.Size = new System.Drawing.Size(143, 26);
            this.radioButtonValue.TabIndex = 0;
            this.radioButtonValue.Text = "По значениям";
            this.radioButtonValue.UseVisualStyleBackColor = true;
            this.radioButtonValue.CheckedChanged += new System.EventHandler(this.radioButtonValue_CheckedChanged);
            // 
            // radioButtonSquare
            // 
            this.radioButtonSquare.AutoSize = true;
            this.radioButtonSquare.Font = new System.Drawing.Font("Open Sans Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonSquare.Location = new System.Drawing.Point(15, 280);
            this.radioButtonSquare.Name = "radioButtonSquare";
            this.radioButtonSquare.Size = new System.Drawing.Size(129, 26);
            this.radioButtonSquare.TabIndex = 0;
            this.radioButtonSquare.Text = "По площади";
            this.radioButtonSquare.UseVisualStyleBackColor = true;
            this.radioButtonSquare.CheckedChanged += new System.EventHandler(this.radioButtonSquare_CheckedChanged);
            // 
            // panelType
            // 
            this.panelType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelType.Controls.Add(this.comboBoxType);
            this.panelType.Controls.Add(this.labelTypeFigure1);
            this.panelType.Location = new System.Drawing.Point(12, 40);
            this.panelType.Name = "panelType";
            this.panelType.Size = new System.Drawing.Size(370, 57);
            this.panelType.TabIndex = 1;
            // 
            // comboBoxType
            // 
            this.comboBoxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Items.AddRange(new object[] {
            "Окружность",
            "Прямоугольник",
            "Треугольник"});
            this.comboBoxType.Location = new System.Drawing.Point(114, 15);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(241, 28);
            this.comboBoxType.TabIndex = 0;
            // 
            // labelTypeFigure1
            // 
            this.labelTypeFigure1.AutoSize = true;
            this.labelTypeFigure1.Location = new System.Drawing.Point(10, 18);
            this.labelTypeFigure1.Name = "labelTypeFigure1";
            this.labelTypeFigure1.Size = new System.Drawing.Size(98, 20);
            this.labelTypeFigure1.TabIndex = 1;
            this.labelTypeFigure1.Text = "Тип фигуры";
            // 
            // panelValue
            // 
            this.panelValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelValue.Controls.Add(this.comboBoxType2);
            this.panelValue.Controls.Add(this.labelTypeFigure2);
            this.panelValue.Controls.Add(this.textBox2);
            this.panelValue.Controls.Add(this.textBox1);
            this.panelValue.Controls.Add(this.label2);
            this.panelValue.Controls.Add(this.label1);
            this.panelValue.Location = new System.Drawing.Point(12, 133);
            this.panelValue.Name = "panelValue";
            this.panelValue.Size = new System.Drawing.Size(370, 141);
            this.panelValue.TabIndex = 1;
            // 
            // comboBoxType2
            // 
            this.comboBoxType2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxType2.FormattingEnabled = true;
            this.comboBoxType2.Items.AddRange(new object[] {
            "Окружность",
            "Прямоугольник",
            "Треугольник"});
            this.comboBoxType2.Location = new System.Drawing.Point(114, 12);
            this.comboBoxType2.Name = "comboBoxType2";
            this.comboBoxType2.Size = new System.Drawing.Size(241, 28);
            this.comboBoxType2.TabIndex = 0;
            this.comboBoxType2.SelectedIndexChanged += new System.EventHandler(this.comboBoxType2_SelectedIndexChanged);
            // 
            // labelTypeFigure2
            // 
            this.labelTypeFigure2.AutoSize = true;
            this.labelTypeFigure2.Location = new System.Drawing.Point(10, 15);
            this.labelTypeFigure2.Name = "labelTypeFigure2";
            this.labelTypeFigure2.Size = new System.Drawing.Size(98, 20);
            this.labelTypeFigure2.TabIndex = 1;
            this.labelTypeFigure2.Text = "Тип фигуры";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(114, 100);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(125, 26);
            this.textBox2.TabIndex = 2;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(114, 61);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(125, 26);
            this.textBox1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // panelSquare
            // 
            this.panelSquare.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSquare.Controls.Add(this.labelSquare);
            this.panelSquare.Controls.Add(this.textBoxSquare);
            this.panelSquare.Location = new System.Drawing.Point(12, 310);
            this.panelSquare.Name = "panelSquare";
            this.panelSquare.Size = new System.Drawing.Size(370, 57);
            this.panelSquare.TabIndex = 2;
            // 
            // labelSquare
            // 
            this.labelSquare.Location = new System.Drawing.Point(9, 8);
            this.labelSquare.Name = "labelSquare";
            this.labelSquare.Size = new System.Drawing.Size(98, 41);
            this.labelSquare.TabIndex = 1;
            this.labelSquare.Text = "Площадь фигуры";
            // 
            // textBoxSquare
            // 
            this.textBoxSquare.Location = new System.Drawing.Point(114, 15);
            this.textBoxSquare.Name = "textBoxSquare";
            this.textBoxSquare.Size = new System.Drawing.Size(125, 26);
            this.textBoxSquare.TabIndex = 2;
            // 
            // buttonSearch
            // 
            this.buttonSearch.BackColor = System.Drawing.Color.LightSalmon;
            this.buttonSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonSearch.Location = new System.Drawing.Point(12, 383);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(372, 36);
            this.buttonSearch.TabIndex = 3;
            this.buttonSearch.Text = "Поиск";
            this.buttonSearch.UseVisualStyleBackColor = false;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // Search
            // 
            this.AcceptButton = this.buttonSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Bisque;
            this.ClientSize = new System.Drawing.Size(396, 429);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.panelSquare);
            this.Controls.Add(this.panelValue);
            this.Controls.Add(this.panelType);
            this.Controls.Add(this.radioButtonSquare);
            this.Controls.Add(this.radioButtonValue);
            this.Controls.Add(this.radioButtonType);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "Search";
            this.Text = "Поиск";
            this.panelType.ResumeLayout(false);
            this.panelType.PerformLayout();
            this.panelValue.ResumeLayout(false);
            this.panelValue.PerformLayout();
            this.panelSquare.ResumeLayout(false);
            this.panelSquare.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioButtonType;
        private System.Windows.Forms.RadioButton radioButtonValue;
        private System.Windows.Forms.RadioButton radioButtonSquare;
        private System.Windows.Forms.Panel panelType;
        private System.Windows.Forms.ComboBox comboBoxType;
        private System.Windows.Forms.Panel panelValue;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelTypeFigure1;
        private System.Windows.Forms.ComboBox comboBoxType2;
        private System.Windows.Forms.Label labelTypeFigure2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelSquare;
        private System.Windows.Forms.Label labelSquare;
        private System.Windows.Forms.TextBox textBoxSquare;
        private System.Windows.Forms.Button buttonSearch;
    }
}