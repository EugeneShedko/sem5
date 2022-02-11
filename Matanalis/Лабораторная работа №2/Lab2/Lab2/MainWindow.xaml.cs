using OxyPlot;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Lab2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<DataPoint> YearAndPopulation { get; set; }
        public ObservableCollection<string> TablePopAndYear { get; set; }
        public ObservableCollection<string> DoublePopulation { get; set; }
        public ObservableCollection<string> TablePopAndYearIfMinusTenPercent { get; set; }
        public ObservableCollection<string> TableTask4 { get; set; }
        public ObservableCollection<DataPoint> GraphTask4 { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            YearAndPopulation = new ObservableCollection<DataPoint>();
            TablePopAndYear = new ObservableCollection<string>();
            DoublePopulation = new ObservableCollection<string>();
            TablePopAndYearIfMinusTenPercent = new ObservableCollection<string>();
            TableTask4 = new ObservableCollection<string>();
            GraphTask4 = new ObservableCollection<DataPoint>();
            DataContext = this;
            Tasks1_3();
            Task4();
        }
        void Tasks1_3()
        {
            float alpha = 0.06f;
            float beta = 0.04f;
            float gamma = 1 + alpha - beta;
            float initialPopulation = 10000;
            float currentPopulation = initialPopulation;
            float populationOfReference = initialPopulation;
            float yearOfReference = 1;
            for (int currentYear = 0; currentYear <= 50; currentYear++)
            {
                if (currentPopulation / populationOfReference >= 2)
                {
                    DoublePopulation.Add($"од, c увелич. поп. в 2 раза: {currentYear}; прошло: {currentYear - yearOfReference}(лет)");
                    yearOfReference = currentYear;
                    populationOfReference = currentPopulation;
                }

                TablePopAndYear.Add($"Год: {currentYear}, популяция(чел.): {currentPopulation}");
                YearAndPopulation.Add(new DataPoint(currentYear, currentPopulation));
                currentPopulation = currentPopulation * gamma;
            }

            float currentPopulation2 = initialPopulation;
            float yearOfReference2 = 0;
            float populationOfReference2 = 0;
            float populationInThePreviousYear = 0;
            for (int currentYear = 0; currentYear <= 50; currentYear++)
            {
                if ((currentPopulation2 >= populationOfReference2) && (currentYear > 10))
                {
                    TablePopAndYearIfMinusTenPercent.Add($"Популяция восстановиться через {currentYear - yearOfReference2} лет ");
                    break;
                }
                if (currentYear == 10)
                {
                    currentPopulation2 = populationInThePreviousYear - (populationInThePreviousYear * 0.2f);
                    populationOfReference2 = populationInThePreviousYear;
                    yearOfReference2 = currentYear;
                }else
                {
                    TablePopAndYearIfMinusTenPercent.Add($"Год: {currentYear}, популяция(чел.): {currentPopulation2}");
                    populationInThePreviousYear = currentPopulation2;
                    currentPopulation2 = currentPopulation2 * gamma;
                }

            }
        }
        void Task4()
        {
            float x_ = 1000000f;
            float alpha = 0.02f;
            float beta = 0.5f;
            float gamma = 1 + alpha - beta;
            float curreantPopulation = 10000;
            for(int currentYear = 0; currentYear<=50; currentYear++)
            {
                TableTask4.Add($"Год: {currentYear}, популяция(чел.): {curreantPopulation}");
                curreantPopulation = curreantPopulation + gamma * (1 - curreantPopulation / x_) * curreantPopulation;
                GraphTask4.Add(new DataPoint(currentYear, curreantPopulation));
            }

        }
    }
}
