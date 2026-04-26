namespace WinFormsLab6
{
    partial class EditForm
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
            components = new System.ComponentModel.Container();

            // TextBox контроли
            textBoxTitle = new System.Windows.Forms.TextBox();
            textBoxDirector = new System.Windows.Forms.TextBox();
            textBoxGenre = new System.Windows.Forms.TextBox();
            textBoxId = new System.Windows.Forms.TextBox();

            // NumericUpDown контроли
            numericUpDownYear = new System.Windows.Forms.NumericUpDown();
            numericUpDownDuration = new System.Windows.Forms.NumericUpDown();
            numericUpDownRating = new System.Windows.Forms.NumericUpDown();
            numericUpDownBudget = new System.Windows.Forms.NumericUpDown();

            // CheckBox
            checkBoxOnline = new System.Windows.Forms.CheckBox();

            // Labels
            labelTitle = new System.Windows.Forms.Label();
            labelDirector = new System.Windows.Forms.Label();
            labelGenre = new System.Windows.Forms.Label();
            labelYear = new System.Windows.Forms.Label();
            labelDuration = new System.Windows.Forms.Label();
            labelRating = new System.Windows.Forms.Label();
            labelBudget = new System.Windows.Forms.Label();
            labelId = new System.Windows.Forms.Label();

            // Buttons
            buttonOK = new System.Windows.Forms.Button();
            buttonCancel = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)numericUpDownYear).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownDuration).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownRating).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownBudget).BeginInit();
            SuspendLayout();

            // 
            // labelId
            // 
            labelId.AutoSize = true;
            labelId.Location = new System.Drawing.Point(12, 15);
            labelId.Name = "labelId";
            labelId.Size = new System.Drawing.Size(24, 15);
            labelId.TabIndex = 0;
            labelId.Text = "Id:";

            // 
            // textBoxId
            // 
            textBoxId.Location = new System.Drawing.Point(100, 12);
            textBoxId.Name = "textBoxId";
            textBoxId.ReadOnly = true;
            textBoxId.Size = new System.Drawing.Size(150, 23);
            textBoxId.TabIndex = 1;

            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Location = new System.Drawing.Point(12, 45);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new System.Drawing.Size(39, 15);
            labelTitle.TabIndex = 2;
            labelTitle.Text = "Назва:";

            // 
            // textBoxTitle
            // 
            textBoxTitle.Location = new System.Drawing.Point(100, 42);
            textBoxTitle.Name = "textBoxTitle";
            textBoxTitle.Size = new System.Drawing.Size(200, 23);
            textBoxTitle.TabIndex = 3;

            // 
            // labelDirector
            // 
            labelDirector.AutoSize = true;
            labelDirector.Location = new System.Drawing.Point(12, 75);
            labelDirector.Name = "labelDirector";
            labelDirector.Size = new System.Drawing.Size(48, 15);
            labelDirector.TabIndex = 4;
            labelDirector.Text = "Режисер:";

            // 
            // textBoxDirector
            // 
            textBoxDirector.Location = new System.Drawing.Point(100, 72);
            textBoxDirector.Name = "textBoxDirector";
            textBoxDirector.Size = new System.Drawing.Size(200, 23);
            textBoxDirector.TabIndex = 5;

            // 
            // labelGenre
            // 
            labelGenre.AutoSize = true;
            labelGenre.Location = new System.Drawing.Point(12, 105);
            labelGenre.Name = "labelGenre";
            labelGenre.Size = new System.Drawing.Size(38, 15);
            labelGenre.TabIndex = 6;
            labelGenre.Text = "Жанр:";

            // 
            // textBoxGenre
            // 
            textBoxGenre.Location = new System.Drawing.Point(100, 102);
            textBoxGenre.Name = "textBoxGenre";
            textBoxGenre.Size = new System.Drawing.Size(200, 23);
            textBoxGenre.TabIndex = 7;

            // 
            // labelYear
            // 
            labelYear.AutoSize = true;
            labelYear.Location = new System.Drawing.Point(12, 135);
            labelYear.Name = "labelYear";
            labelYear.Size = new System.Drawing.Size(40, 15);
            labelYear.TabIndex = 8;
            labelYear.Text = "Рік:";

            // 
            // numericUpDownYear
            // 
            numericUpDownYear.Location = new System.Drawing.Point(100, 132);
            numericUpDownYear.Name = "numericUpDownYear";
            numericUpDownYear.Size = new System.Drawing.Size(100, 23);
            numericUpDownYear.TabIndex = 9;
            numericUpDownYear.Minimum = 1900;
            numericUpDownYear.Maximum = 2100;
            numericUpDownYear.Value = System.DateTime.Now.Year;

            // 
            // labelDuration
            // 
            labelDuration.AutoSize = true;
            labelDuration.Location = new System.Drawing.Point(12, 165);
            labelDuration.Name = "labelDuration";
            labelDuration.Size = new System.Drawing.Size(57, 15);
            labelDuration.TabIndex = 10;
            labelDuration.Text = "Тривалість:";

            // 
            // numericUpDownDuration
            // 
            numericUpDownDuration.Location = new System.Drawing.Point(100, 162);
            numericUpDownDuration.Name = "numericUpDownDuration";
            numericUpDownDuration.Size = new System.Drawing.Size(100, 23);
            numericUpDownDuration.TabIndex = 11;
            numericUpDownDuration.Maximum = 500;

            // 
            // labelRating
            // 
            labelRating.AutoSize = true;
            labelRating.Location = new System.Drawing.Point(12, 195);
            labelRating.Name = "labelRating";
            labelRating.Size = new System.Drawing.Size(51, 15);
            labelRating.TabIndex = 12;
            labelRating.Text = "Рейтинг:";

            // 
            // numericUpDownRating
            // 
            numericUpDownRating.DecimalPlaces = 1;
            numericUpDownRating.Location = new System.Drawing.Point(100, 192);
            numericUpDownRating.Name = "numericUpDownRating";
            numericUpDownRating.Size = new System.Drawing.Size(100, 23);
            numericUpDownRating.TabIndex = 13;
            numericUpDownRating.Maximum = 10;

            // 
            // labelBudget
            // 
            labelBudget.AutoSize = true;
            labelBudget.Location = new System.Drawing.Point(12, 225);
            labelBudget.Name = "labelBudget";
            labelBudget.Size = new System.Drawing.Size(47, 15);
            labelBudget.TabIndex = 14;
            labelBudget.Text = "Бюджет:";

            // 
            // numericUpDownBudget
            // 
            numericUpDownBudget.Location = new System.Drawing.Point(100, 222);
            numericUpDownBudget.Name = "numericUpDownBudget";
            numericUpDownBudget.Size = new System.Drawing.Size(150, 23);
            numericUpDownBudget.TabIndex = 15;
            numericUpDownBudget.Maximum = 1000000000;

            // 
            // checkBoxOnline
            // 
            checkBoxOnline.AutoSize = true;
            checkBoxOnline.Location = new System.Drawing.Point(100, 255);
            checkBoxOnline.Name = "checkBoxOnline";
            checkBoxOnline.Size = new System.Drawing.Size(127, 19);
            checkBoxOnline.TabIndex = 16;
            checkBoxOnline.Text = "Доступно онлайн";
            checkBoxOnline.UseVisualStyleBackColor = true;

            // 
            // buttonOK
            // 
            buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            buttonOK.Location = new System.Drawing.Point(100, 290);
            buttonOK.Name = "buttonOK";
            buttonOK.Size = new System.Drawing.Size(75, 30);
            buttonOK.TabIndex = 17;
            buttonOK.Text = "OK";
            buttonOK.UseVisualStyleBackColor = true;
            buttonOK.Click += ButtonOK_Click;

            // 
            // buttonCancel
            // 
            buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            buttonCancel.Location = new System.Drawing.Point(180, 290);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new System.Drawing.Size(75, 30);
            buttonCancel.TabIndex = 18;
            buttonCancel.Text = "Скасувати";
            buttonCancel.UseVisualStyleBackColor = true;

            // 
            // EditForm
            // 
            AcceptButton = buttonOK;
            CancelButton = buttonCancel;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(330, 335);
            Controls.Add(buttonCancel);
            Controls.Add(buttonOK);
            Controls.Add(checkBoxOnline);
            Controls.Add(numericUpDownBudget);
            Controls.Add(labelBudget);
            Controls.Add(numericUpDownRating);
            Controls.Add(labelRating);
            Controls.Add(numericUpDownDuration);
            Controls.Add(labelDuration);
            Controls.Add(numericUpDownYear);
            Controls.Add(labelYear);
            Controls.Add(textBoxGenre);
            Controls.Add(labelGenre);
            Controls.Add(textBoxDirector);
            Controls.Add(labelDirector);
            Controls.Add(textBoxTitle);
            Controls.Add(labelTitle);
            Controls.Add(textBoxId);
            Controls.Add(labelId);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "EditForm";
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Редагування фільму";
            ((System.ComponentModel.ISupportInitialize)numericUpDownYear).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownDuration).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownRating).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownBudget).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.TextBox textBoxDirector;
        private System.Windows.Forms.TextBox textBoxGenre;
        private System.Windows.Forms.TextBox textBoxId;
        private System.Windows.Forms.NumericUpDown numericUpDownYear;
        private System.Windows.Forms.NumericUpDown numericUpDownDuration;
        private System.Windows.Forms.NumericUpDown numericUpDownRating;
        private System.Windows.Forms.NumericUpDown numericUpDownBudget;
        private System.Windows.Forms.CheckBox checkBoxOnline;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelDirector;
        private System.Windows.Forms.Label labelGenre;
        private System.Windows.Forms.Label labelYear;
        private System.Windows.Forms.Label labelDuration;
        private System.Windows.Forms.Label labelRating;
        private System.Windows.Forms.Label labelBudget;
        private System.Windows.Forms.Label labelId;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
    }
}
