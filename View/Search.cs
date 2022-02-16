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
    public partial class Search : Form
    {
        List<Figure> figures;
        ListFigures listFigures;
        TypeFigure type;
        public List<Figure> Figures => figures;
        public Search(ListFigures listFigures)
        {
            InitializeComponent();
            comboBoxType.Text = comboBoxType.Items[0].ToString();
            comboBoxType2.Text = comboBoxType2.Items[0].ToString();
            radioButtonType.Checked = true;
            this.listFigures = listFigures;
            figures = new List<Figure>();
        }

        private void radioButtonType_CheckedChanged(object sender, EventArgs e)
        {
            panelType.Enabled = true;
            panelValue.Enabled = false;
            panelSquare.Enabled = false;
        }

        private void radioButtonValue_CheckedChanged(object sender, EventArgs e)
        {
            panelType.Enabled = false;
            panelValue.Enabled = true;
            panelSquare.Enabled = false;

        }

        private void radioButtonSquare_CheckedChanged(object sender, EventArgs e)
        {
            panelType.Enabled = false;
            panelValue.Enabled = false;
            panelSquare.Enabled = true;
        }

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
                ActivateControl(comboBoxType2.SelectedIndex);
            }
        }
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

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            if(radioButtonType.Checked)
            {
                type = (TypeFigure)comboBoxType.SelectedIndex;
                switch (type)
                {
                    case TypeFigure.Circle:
                        figures = listFigures.Search(typeof(Circle));
                        break;
                    case TypeFigure.Rectangle:
                        figures = listFigures.Search(typeof(GeometryFigures.Rectangle));
                        break;
                    case TypeFigure.Triangle:
                        figures = listFigures.Search(typeof(Triangle));
                        break;
                }
            }
            else if(radioButtonValue.Checked)
            {
                type = (TypeFigure)comboBoxType2.SelectedIndex;
                switch (type)
                {
                    case TypeFigure.Circle:
                        double radius = ValidationClass.TryParse("Радиус", textBox1.Text);
                        figures = listFigures.Search(new Circle(radius));
                        break;
                    case TypeFigure.Rectangle:
                        double lenght = ValidationClass.TryParse("Длина", textBox1.Text);
                        double width = ValidationClass.TryParse("Ширина", textBox2.Text);
                        figures = listFigures.Search(new GeometryFigures.Rectangle(lenght, width));
                        break;
                    case TypeFigure.Triangle:
                        double base_value = ValidationClass.TryParse("Основание", textBox1.Text);
                        double height = ValidationClass.TryParse("Высота", textBox2.Text);
                        figures = listFigures.Search(new Triangle(height, base_value));
                        break;
                }
            }
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
