using System;
using System.ComponentModel;
using System.Windows.Forms;
using GeometryFigures;
using GeometryFigures.Figures;

namespace View
{
    public partial class MainForm : Form
    {
        ListFigures list;//Класс набора фигур
        BindingList<IFigure> bindignList;//Список с привязкой данных
        public MainForm()
        {
            InitializeComponent();
            list = new ListFigures();
            //Настройка привязки данных к таблице
            bindignList = new BindingList<IFigure>(list.Figures);
            figureBindingSource.DataSource = bindignList;
            dataGridView1.DataSource = figureBindingSource;
            //Настройка типов сохраняемых/открываемых данных в диалоговых окнах
            openFileDialog1.Filter = "(*.fig)|*.fig";
            saveFileDialog1.Filter = "(*.fig)|*.fig";
        }
        //Добавление фигуры в список фигур
        private void toolStripButtonAdd_Click(object sender, EventArgs e)
        {
            //Создание и отображение формы добаления фигуры
            Add add = new Add();
            add.ShowDialog();
            //Добавление фигуры в список фигур
            if(add.Figure!=null)
            {
                bindignList.Add(add.Figure);
            }
            add.Close();
        }
        //Удаление фигуры их списка фигур
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
        //Обновление номера фигуры в таблицы при добавлении фигуры
        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dataGridView1["ColumnNumber", e.RowIndex].Value = e.RowIndex + 1;
        }
        //Обновление номера фигуры в таблицы при удалении фигуры
        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            for(int i=e.RowIndex;i< dataGridView1.Rows.Count; i++)
            {
                dataGridView1["ColumnNumber", i].Value = i + 1;
            }
        }
        //Открытие файла со списком фигур
        private void MenuItemOpen_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string url = openFileDialog1.FileName;
                    list.Load(url);
                    bindignList = new BindingList<IFigure>(list.Figures);
                    figureBindingSource.DataSource = bindignList;
                    UpdateNumbers();
                }
                catch (ArgumentException error)
                {
                    MessageBox.Show(error.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        //Сохранение файла со списом фигур
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
                catch(ArgumentException error)
                {
                    MessageBox.Show(error.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch(Exception error)
                {
                    MessageBox.Show(error.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                }
            }
        //Поиск фигур
        private void toolStripButtonSearch_Click(object sender, EventArgs e)
        {
            Search search = new Search(list);
            if (search.ShowDialog() != DialogResult.Cancel)
            {
                if (search.Figures.Count > 0)
                {
                    bindignList = new BindingList<IFigure>(search.Figures);
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
        //Метод обновления номеров фигур в таблице
        void UpdateNumbers()
        {
            for (int i = 0; i < bindignList.Count; i++)
            {
                dataGridView1["ColumnNumber", i].Value = i + 1;
            }
        }
        //Обновление данных в таблице
        private void toolStripButtonUpdate_Click(object sender, EventArgs e)
        {
            bindignList = new BindingList<IFigure>(list.Figures);
            figureBindingSource.DataSource = bindignList;
            dataGridView1.DataSource = figureBindingSource;
            UpdateNumbers();
        }
    }
}
