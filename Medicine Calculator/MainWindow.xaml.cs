using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections;

namespace Medicine_Calculator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int point = 0;
        Dictionary<string,bool?> answer_firstsecond_expander = new Dictionary<string,bool?>();
        Dictionary<string, bool?> answer_third_expander = new Dictionary<string, bool?>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void close_window(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void calculate_risk(object sender, RoutedEventArgs e)
        {
            calculate_points_from_answer_expander();

            points_block.Text = "Баллы риска ВТЭО: " + point + " балла";

            if (point == 0 || point == 1)
            {
                group_risk_block.Text = "Группа риска: Низкий риск";
                prescription_block.Text = "Назначения:  Компрессионный трикотаж или эластическое бинтование конечностей\r\n Ранняя активизация после родов и адекватная гидратация.";
            }
            if(point == 2)
            {
                group_risk_block.Text = "Группа риска: Средний риск";
                prescription_block.Text = "Назначения:  Компрессионный трикотаж или эластическое бинтование конечностей\r\n Ранняя активизация после родов и адекватная гидратация.\r\n Назначение НМГ: Эноксапарин натрия в дозировке (расчет от веса) – 1 р/д подкожно в\r\nтечение 10 дней после родов";
            }
            if (point >= 3)
            {
                group_risk_block.Text = "Группа риска: Высокий риск";
                if (point == 3)
                {
                    prescription_block.Text = "Назначения:  Компрессионный трикотаж или эластическое бинтование конечностей\r\n Ранняя активизация после родов и адекватная гидратация.\r\n Назначение НМГ: Эноксапарин натрия в дозировке (расчет от веса) – 1 р/д подкожно с 28-й\r\nнедели беременности до родов и в течение 6 недель после родов."; 
                }
                else
                {
                    prescription_block.Text = "Назначения:  Компрессионный трикотаж или эластическое бинтование конечностей\r\n Ранняя активизация после родов и адекватная гидратация.\r\n Назначение НМГ: Эноксапарин натрия в дозировке (расчет от веса) – 1 р/д подкожно в\r\nтечение всей беременности до родов и 6 недель послеродового периода ";
                }
            }
            answer_firstsecond_expander.Clear();
            answer_third_expander.Clear();

        }

        

        private void calculate_BMI(object sender, RoutedEventArgs e)
        {
            int weight;
            int rost;
            bool isWeight = int.TryParse(weight_box.Text, out weight);
            bool isRost = int.TryParse(rost_box.Text, out rost);
            if (isWeight && isRost)
            {
                weight = int.Parse(weight_box.Text);
                rost = int.Parse(rost_box.Text);

            }

            double bmi = weight / Math.Pow(rost * 0.01, 2);
            
            if(bmi>=30 && bmi>0)
            {
                if (bmi >= 40)
                {
                    add_two_point();
                }
                else {
                    add_one_point();
                }
            }
             imt_box.Text = bmi.ToString();
        }

      

        private void add_one_point_expander(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            answer_third_expander.Add(checkBox.Name, checkBox.IsChecked);

        }
        private void add_answer_expander(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            answer_firstsecond_expander.Add(checkBox.Name,checkBox.IsChecked);
        }
        private void minus_one_point_expander(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            answer_third_expander.Remove(checkBox.Name);

        }
        private void minus_answer_expander(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            answer_firstsecond_expander.Remove(checkBox.Name);
        }

        private void add_one_point(object sender, RoutedEventArgs e)
        {
            add_one_point();
        }
        private void add_one_point()
        {
            point++;
        }
        private void add_two_point(object sender, RoutedEventArgs e)
        {
            add_one_point();
        }
        private void add_two_point()
        {
            point = point + 2;
        }
        private void add_three_point(object sender, RoutedEventArgs e)
        {
            add_three_point();
        }
        private void add_three_point()
        {
            point = point + 3;
        }
        private void add_four_point(object sender, RoutedEventArgs e)
        {
            point = point + 4;
        }
        private void minus_one_point(object sender, RoutedEventArgs e)
        {
            point--;
        }
        private void minus_two_point(object sender, RoutedEventArgs e)
        {
            point = point - 2;
        }
        private void minus_three_point(object sender, RoutedEventArgs e)
        {
            point = point - 3;

        }
        private void minus_four_point(object sender, RoutedEventArgs e)
        {
            point = point - 4;

        }

        private void calculate_points_from_answer_expander(object sender, RoutedEventArgs e)
        {
            calculate_points_from_answer_expander();
        }

        private void calculate_points_from_answer_expander()
        {
            bool?[] values_three_points = new bool?[answer_firstsecond_expander.Count];
            answer_firstsecond_expander.Values.CopyTo(values_three_points, 0);
            bool?[] values_one_point = new bool?[answer_third_expander.Count];
            answer_third_expander.Values.CopyTo(values_one_point, 0);

            for (int i = 0; i < answer_firstsecond_expander.Count; i++)
            {
                if (values_three_points[i] == true)
                {
                    add_three_point();
                }
            }
            for (int i = 0; i < answer_third_expander.Count; i++)
            {
                if (values_one_point[i] == true)
                {
                    add_three_point();
                }
            }

        }
    }
}
