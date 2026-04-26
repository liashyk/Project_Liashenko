namespace WinFormsLab6
{
    partial class MainForm
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

            // DataGridView
            dataGridViewMovies = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridViewMovies).BeginInit();

            // Panel для кнопок
            panelButtons = new System.Windows.Forms.Panel();

            // Кнопки
            buttonAdd = new System.Windows.Forms.Button();
            buttonEdit = new System.Windows.Forms.Button();
            buttonDelete = new System.Windows.Forms.Button();
            buttonSave = new System.Windows.Forms.Button();
            buttonLoad = new System.Windows.Forms.Button();

            // SaveFileDialog та OpenFileDialog
            saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            openFileDialog = new System.Windows.Forms.OpenFileDialog();

            // StatusStrip
            statusStrip = new System.Windows.Forms.StatusStrip();
            toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();

            // BindingSource
            bindingSource = new System.Windows.Forms.BindingSource(components);
            ((System.ComponentModel.ISupportInitialize)bindingSource).BeginInit();

            // 
            // dataGridViewMovies
            // 
            dataGridViewMovies.AllowUserToAddRows = false;
            dataGridViewMovies.AllowUserToDeleteRows = false;
            dataGridViewMovies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewMovies.Dock = System.Windows.Forms.DockStyle.Fill;
            dataGridViewMovies.Location = new System.Drawing.Point(0, 0);
            dataGridViewMovies.Name = "dataGridViewMovies";
            dataGridViewMovies.ReadOnly = true;
            dataGridViewMovies.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dataGridViewMovies.Size = new System.Drawing.Size(800, 350);
            dataGridViewMovies.TabIndex = 0;
            dataGridViewMovies.DataSource = bindingSource;

            // 
            // panelButtons
            // 
            panelButtons.Controls.Add(buttonAdd);
            panelButtons.Controls.Add(buttonEdit);
            panelButtons.Controls.Add(buttonDelete);
            panelButtons.Controls.Add(buttonSave);
            panelButtons.Controls.Add(buttonLoad);
            panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            panelButtons.Height = 60;
            panelButtons.Location = new System.Drawing.Point(0, 350);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new System.Drawing.Size(800, 60);
            panelButtons.TabIndex = 1;

            // 
            // buttonAdd
            // 
            buttonAdd.Location = new System.Drawing.Point(10, 10);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new System.Drawing.Size(75, 40);
            buttonAdd.TabIndex = 0;
            buttonAdd.Text = "Додати";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += ButtonAdd_Click;

            // 
            // buttonEdit
            // 
            buttonEdit.Location = new System.Drawing.Point(90, 10);
            buttonEdit.Name = "buttonEdit";
            buttonEdit.Size = new System.Drawing.Size(75, 40);
            buttonEdit.TabIndex = 1;
            buttonEdit.Text = "Редакт.";
            buttonEdit.UseVisualStyleBackColor = true;
            buttonEdit.Click += ButtonEdit_Click;

            // 
            // buttonDelete
            // 
            buttonDelete.Location = new System.Drawing.Point(170, 10);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new System.Drawing.Size(75, 40);
            buttonDelete.TabIndex = 2;
            buttonDelete.Text = "Видалити";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += ButtonDelete_Click;

            // 
            // buttonSave
            // 
            buttonSave.Location = new System.Drawing.Point(250, 10);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new System.Drawing.Size(75, 40);
            buttonSave.TabIndex = 3;
            buttonSave.Text = "Зберегти";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += ButtonSave_Click;

            // 
            // buttonLoad
            // 
            buttonLoad.Location = new System.Drawing.Point(330, 10);
            buttonLoad.Name = "buttonLoad";
            buttonLoad.Size = new System.Drawing.Size(75, 40);
            buttonLoad.TabIndex = 4;
            buttonLoad.Text = "Завант.";
            buttonLoad.UseVisualStyleBackColor = true;
            buttonLoad.Click += ButtonLoad_Click;

            // 
            // statusStrip
            // 
            statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripStatusLabel });
            statusStrip.Location = new System.Drawing.Point(0, 410);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new System.Drawing.Size(800, 22);
            statusStrip.TabIndex = 2;

            // 
            // toolStripStatusLabel
            // 
            toolStripStatusLabel.Name = "toolStripStatusLabel";
            toolStripStatusLabel.Size = new System.Drawing.Size(50, 17);
            toolStripStatusLabel.Text = "Готово";

            // 
            // saveFileDialog
            // 
            saveFileDialog.DefaultExt = "json";
            saveFileDialog.Filter = "JSON файли (*.json)|*.json|Всі файли (*.*)|*.*";
            saveFileDialog.Title = "Зберегти колекцію фільмів";

            // 
            // openFileDialog
            // 
            openFileDialog.DefaultExt = "json";
            openFileDialog.Filter = "JSON файли (*.json)|*.json|Всі файли (*.*)|*.*";
            openFileDialog.Title = "Завантажити колекцію фільмів";

            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 432);
            Controls.Add(dataGridViewMovies);
            Controls.Add(panelButtons);
            Controls.Add(statusStrip);
            Name = "MainForm";
            Text = "ЛР6 — Каталог фільмів (WinForms)";
            ((System.ComponentModel.ISupportInitialize)dataGridViewMovies).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.DataGridView dataGridViewMovies;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.BindingSource bindingSource;
    }
}
