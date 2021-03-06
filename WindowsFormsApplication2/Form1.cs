﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int columns = Convert.ToInt32(textBox5.Text);
            int precColumn = Convert.ToInt32(textBox6.Text);
            int recallColumn = Convert.ToInt32(textBox7.Text);

            string input = textBox1.Text;

            string[] lines = input.Split((char[])null, StringSplitOptions.RemoveEmptyEntries);

            int[] numbers = new int[] { 44, 15, 15, 13, 25, 3, 2, 9, 50, 0, 0, 0, 4, 5 };

            int index = 1;
            int count = 0;
            double sum = 0;
            label2.Text = string.Empty;

            foreach (var line in lines)
            {
                if (index == precColumn)
                {
                    textBox2.Text = line;
                }

                if (index == 15 * columns + precColumn)
                {
                    textBox4.Text = line;
                }

                if (index == recallColumn || (index - recallColumn) % columns == 0)
                {
                    if (count > 0 && count < 15)
                    {
                        sum += GetValue(line) * numbers[count - 1];
                        label2.Text += line + "*" + numbers[count - 1] + " + ";
                    }

                    count++;
                }

                index++;
            }

            label2.Text.TrimEnd(' ', '+');

            textBox3.Text = (sum / numbers.Sum()).ToString();
        }

        private double GetValue(string x)
        {
            if (x.Equals("?"))
                return 0;
            else
                return Convert.ToDouble(x);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox4.Text = string.Empty;
            label2.Text = string.Empty;
        }
    }
}
