using BankingDomain;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankKiosk
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var container = new Container();

            container.Register<Form1>();
            container.Register<BankAccount>();
            container.Register<ICalculateAccountBonuses, CovidBonusCalculator>();
            container.Register<INotifyTheFeds, NotifyFederalRegulators>();

            var time = new SystemTime();
            container.RegisterInstance<ISystemTime>(time);

            if(time.GetCurrent() < new DateTime(2020, 7, 2))
            {
                container.Register<ICalculateAccountBonuses, CovidBonusCalculator>();
            }
            else
            {
                container.Register<ICalculateAccountBonuses, StandardBonusCalculator>();
            }

            Application.Run(container.GetInstance<Form1>());
        }
    }
}
