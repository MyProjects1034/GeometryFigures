using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GeometryFigures;
using GeometryFigures.Figures;

namespace View
{
    public partial class Search : Form
    {
        List<IFigure> figures;//Список найденных фигур
        ListFigures listFigures;//Класс набора фигур
        TypeFigure type;//Тип фигуры
        public List<IFigure> Figures => figures;
        public Search(ListFigures listFigures)
        {
            InitializeComponent();
            //Настройка начального значения выпадающих списков
            comboBoxType.Text = comboBoxType.Items[0].ToString();
            comboBoxType2.Text = comboBoxType2.Items[0].ToString();
            //Выбор первого варианта поиска
            radioButtonType.Checked = true;
            //Инициализация данных
            this.listFigures = listFigures;
            figures = new List<IFigure>();
        }
        //**************************************
        //Обработка событий изменения типа поиска
        //***************************************

        //Тип поиска - по типу фигуры
        private void radioButtonType_CheckedChanged(object sender, EventArgs e)
        {
            panelType.Enabled = true;
            panelValue.Enabled = false;
            panelSquare.Enabled = false;
        }
        //Тип поиска - по характиристикам фигуры
        private void radioButtonValue_CheckedChanged(object sender, EventArgs e)
        {
            panelType.Enabled = false;
            panelValue.Enabled = true;
            panelSquare.Enabled = false;

        }
        //Тип поиска - по площади фигуры
        private void radioButtonSquare_CheckedChanged(object sender, EventArgs e)
        {
            panelType.Enabled = false;
            panelValue.Enabled = false;
            panelSquare.Enabled = true;
        }
        //Выбор типа фигуры
        private void comboBoxType2_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxType2.SelectedIndex)
            {
                case 0:
                    label1.Text = "Радиус";
                    textBox1.Text = "0";
                    break;
                case 1:
                    label1.Text = "Длина";
                    textBox1.Text = "0";
                    label2.Text = "Ширина";
                    textBox2.Text = "0";
                    break;
                case 2:
                    label1.Text = "Основание";
                    textBox1.Text = "0";
                    label2.Text = "Высота";
                    textBox2.Text = "0";
                    break;
            }
            if (comboBoxType2.SelectedIndex >= 0)
            {
                //Изменение появления полей ввода значений и надписей для каждого вида фигур
                ActivateControl(comboBoxType2.SelectedIndex);
            }
        }
        //Метод изменения появления полей ввода значений и надписей для каждого вида фигур
        //0 - Окружность
        //1 - Прямоугольник
        //2 - Треугольник
        void ActivateControl(int number)
        {
            if (number == 0)
            {
                label2.Visible = false;
                label2.Enabled = false;
                textBox2.Visible = false;
                textBox2.Enabled = false;
            }
            else if (number == 1 || number == 2)
            {
                label2.Visible = true;
                label2.Enabled = true;
                textBox2.Visible = true;
                textBox2.Enabled = true;
            }
        }
        //Поиск фигур
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            //По типу фигуры
            if (radioButtonType.Checked)
            {
                type = (TypeFigure)comboBoxType.SelectedIndex;
                switch (type)
                {
                    case TypeFigure.Circle://Для окружности
                        figures = listFigures.Search(typeof(Circle));
                        break;
                    case TypeFigure.Rectangle://Для прямоугольника
                        figures = listFigures.Search(typeof(GeometryFigures.Figures.Rectangle));
                        break;
                    case TypeFigure.Triangle://Для треугольника
                        figures = listFigures.Search(typeof(Triangle));
                        break;
                }
            }
            //По характиристикам фигуры
            else if(radioButtonValue.Checked)
            {
                type = (TypeFigure)comboBoxType2.SelectedIndex;
                switch (type)
                {
                    case TypeFigure.Circle://Для окружности
                        double radius = ValidationClass.TryParse("Радиус", textBox1.Text);
                        figures = listFigures.Search(new Circle(radius));
                        break;
                    case TypeFigure.Rectangle://Для прямоугольника
                        double lenght = ValidationClass.TryParse("Длина", textBox1.Text);
                        double width = ValidationClass.TryParse("Ширина", textBox2.Text);
                        figures = listFigures.Search(new GeometryFigures.Figures.Rectangle(lenght, width));
                        break;
                    case TypeFigure.Triangle://Для треугольника
                        double base_value = ValidationClass.TryParse("Основание", textBox1.Text);
                        double height = ValidationClass.TryParse("Высота", textBox2.Text);
                        figures = listFigures.Search(new Triangle(height, base_value));
                        break;
                }
            }
            //По площади фигуры
            else if(radioButtonSquare.Checked)
            {
                double square= ValidationClass.TryParse("Площадь", textBoxSquare.Text);
                figures=listFigures.Search(square);
            }
            DialogResult = DialogResult.OK;
            this.Hide();
        }
    }
}
