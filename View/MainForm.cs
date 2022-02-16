using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GeometryFigures;

namespace View
{
    public partial class MainForm : Form
    {
        ListFigures list;
        BindingList<Figure> bindignList;
        public MainForm()
        {
            InitializeComponent();
            list = new ListFigures();
            bindignList = new BindingList<Figure>(list.Figures);
            figureBindingSource.DataSource = bindignList;
            dataGridView1.DataSource = figureBindingSource;
            openFileDialog1.Filter = "(*.fig)|*.fig";
            saveFileDialog1.Filter = "(*.fig)|*.fig";
        }

        private void toolStripButtonAdd_Click(object sender, EventArgs e)
        {
            Add add = new Add();
            add.ShowDialog();
            if(add.Figure!=null)
            {
                bindignList.Add(add.Figure);
            }
            add.Close();
        }

        private void toolStripButtonRemove_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                if (dataGridView1.SelectedRows[0].Index >= 0)
                {
                    bindignList.RemoveAt(dataGridView1.SelectedRows[0].Index);
                }
            }
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dataGridView1["ColumnNumber", e.RowIndex].Value = e.RowIndex + 1;
        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            for(int i=e.RowIndex;i< dataGridView1.Rows.Count; i++)
            {
                dataGridView1["ColumnNumber", i].Value = i + 1;
            }
        }

        private void MenuItemOpen_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string url = openFileDialog1.FileName;
                    list.Load(url);
                    bindignList = new BindingList<Figure>(list.Figures);
                    figureBindingSource.DataSource = bindignList;
                    UpdateNumbers();
                }
                catch
                {
                    MessageBox.Show("Ошибка при открытии файла", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void MenuItemSave_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string url = saveFileDialog1.FileName;
                    list.Save(url);

                    MessageBox.Show("Данные сохранены", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("Ошибка при сохранении файла", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                }
            }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Search search = new Search(list);
            if (search.ShowDialog() != DialogResult.Cancel)
            {
                if (search.Figures.Count > 0)
                {
                    bindignList = new BindingList<Figure>(search.Figures);
                    figureBindingSource.DataSource = bindignList;
                    UpdateNumbers();
                }
                else
                {
                    MessageBox.Show("Ничего не найдено", "Результат поиска", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            search.Close();

        }
        void UpdateNumbers()
        {
            for (int i = 0; i < bindignList.Count; i++)
            {
                dataGridView1["ColumnNumber", i].Value = i + 1;
            }
        }

        private void toolStripButtonUpdate_Click(object sender, EventArgs e)
        {
            bindignList = new BindingList<Figure>(list.Figures);
            figureBindingSource.DataSource = bindignList;
            dataGridView1.DataSource = figureBindingSource;
            UpdateNumbers();
        }
    }
}
