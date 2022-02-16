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
    public partial class Add : Form
    {
        Figure figure;//Объект фигуры
        Random rand;//Рандом
        public Figure Figure => figure;
        public Add()
        {
            InitializeComponent();
            comboBoxFigures.Text = comboBoxFigures.Items[0].ToString();
#if !DEBUG
                buttonGenerate.Visible = false;
                buttonGenerate.Enabled = false;       
#endif
            rand = new Random();
        }
        //Создание фигуры
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                switch (comboBoxFigures.SelectedIndex)
                {
                    case 0://Создание окружности
                        double radius = ValidationClass.TryParse("Радиус", textBox1.Text);
                        figure = new Circle(radius);
                        break;
                    case 1://Создание прямоугольника
                        double lenght = ValidationClass.TryParse("Длина", textBox1.Text);
                        double width = ValidationClass.TryParse("Ширина", textBox2.Text);
                        figure = new GeometryFigures.Rectangle(lenght, width);
                        break;
                    case 2://Создание треугольника
                        double base_value = ValidationClass.TryParse("Основание", textBox1.Text);
                        double height = ValidationClass.TryParse("Высота", textBox2.Text);
                        figure = new Triangle(height, base_value);
                        break;
                }
                this.Hide();
            }
            catch (ArgumentException error)
            {
                MessageBox.Show(error.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        //Выбор фигуры для создания
        private void comboBoxFigures_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxFigures.SelectedIndex)
            {
                case 0://Окружность
                    label1.Text = "Радиус";
                    textBox1.Text = "0";
                    break;
                case 1://Прямоугольник
                    label1.Text = "Длина";
                    textBox1.Text = "0";
                    label2.Text = "Ширина";
                    textBox2.Text = "0";
                    break;
                case 2://Треугольник
                    label1.Text = "Основание";
                    textBox1.Text = "0";
                    label2.Text = "Высота";
                    textBox2.Text = "0";
                    break;
            }
            if (comboBoxFigures.SelectedIndex >= 0)
            {
                //Изменение появления полей ввода значений и надписей для каждого вида фигур
                ActivateControl(comboBoxFigures.SelectedIndex);
            }
        }
        //Метод изменения появления полей ввода значений и надписей для каждого вида фигур
        //0 - Окружность
        //1 - Прямоугольник
        //2 - Треугольник
        void ActivateControl(int number)
        {
            if(number==0)
            {
                label2.Visible = false;
                label2.Enabled = false;
                textBox2.Visible = false;
                textBox2.Enabled = false;
            }
            else if(number==1 || number==2)
            {
                label2.Visible = true;
                label2.Enabled = true;
                textBox2.Visible = true;
                textBox2.Enabled = true;
            }
        }
        //Метод генерации случайных чисел
        int GenerateRandomData()
        {
            int result = rand.Next(0, 100);
            return result;
        }
        //Вызов метода генерации случайных чисел
        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            textBox1.Text = GenerateRandomData().ToString();
            textBox2.Text = GenerateRandomData().ToString();
        }
    }
}
