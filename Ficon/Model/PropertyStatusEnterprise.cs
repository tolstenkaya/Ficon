using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Ficon.Model
{
    public class PropertyStatusEnterprise
    {
        public List <Indicator> _indicators = new List<Indicator>();
        public void CalculateIndicators1TotalValueAssets(double BalanceValue_BeginRepPeriod, double BalanceValue_EndRepPeriod)
        {

                Indicator i = new Indicator();
                i.Name = "Total value of assets";
                i.Value1 = BalanceValue_BeginRepPeriod;
                i.Value2 = BalanceValue_EndRepPeriod;
            if(i.Value1<i.Value2)
            {
                i.Descriprion = "As the total value of the company's assets increases, so does its value\nproperty potential, which is a positive phenomenon for the property status of the enterprise.";
                i.Mark = 1;
            }
            else
            {
                if(i.Value1>i.Value2)
                {
                    i.Descriprion = "As the total value of the company's assets decreases, so does it\r\nproperty potential. This negatively affects the property status of the enterprise.";
                    i.Mark = 0;
                }
                else
                {
                    i.Descriprion = "The total value of the company's assets does not change, therefore\r\nproperty potential is stable during this period.";
                    i.Mark = 1;
                }
            }
            _indicators.Add(i);
        }

        public void CalculateIndicators2ResidualValueOfFixedAssets(double ResidualValue_BeginRepPeriod, double InitialValue_BeginRepPeriod, double ResidualValue_EndRepPeriod, double InitialValue_EndRepPeriod)
        {
            Indicator i = new Indicator();
            i.Name = "Residual value of fixed assets";
            if(InitialValue_BeginRepPeriod == 0 || string.IsNullOrWhiteSpace(InitialValue_BeginRepPeriod.ToString()))
            {
                MessageBox.Show("Unfortunetally, you cannot calculate indicator of Residual value of fixed assets!");
                i.Value1 = 0;
                i.Value2 = 0;
            }
            else
            {
                i.Value1 = Math.Round(ResidualValue_BeginRepPeriod / InitialValue_BeginRepPeriod, 2);
                i.Value2 = Math.Round(ResidualValue_EndRepPeriod / InitialValue_EndRepPeriod, 2);
                if (i.Value1 < i.Value2)
                {
                    i.Descriprion = "";
                    i.Mark = 1;
                }
                else
                {
                    if (i.Value1 > i.Value2)
                    {
                        i.Descriprion = "";
                        i.Mark = 0;
                    }
                    else
                    {
                        i.Descriprion = "";
                        i.Mark = 1;
                    }
                }
            }
            
            _indicators.Add(i);
        }
        public void CalculateIndicators3DepreciationRateOfFixedAssets(double DepreciationValue_BeginRepPeriod, double InitialValue_BeginRepPeriod, double DepreciationValue_EndRepPeriod, double InitialValue_EndRepPeriod)
        {
            Indicator i = new Indicator();
            i.Name = "Depreciation rate of fixed assets";
            if (InitialValue_BeginRepPeriod== 0 || string.IsNullOrWhiteSpace(InitialValue_BeginRepPeriod.ToString()))
            {
                MessageBox.Show("Unfortunetally, you cannot calculate indicator of Depreciation rate of fixed assets!");
                i.Value1 = 0;
                i.Value2 = 0;
            }
            else
            {
                i.Value1 = Math.Round(DepreciationValue_BeginRepPeriod / InitialValue_BeginRepPeriod, 2);
                i.Value2 = Math.Round(DepreciationValue_EndRepPeriod / InitialValue_EndRepPeriod, 2);
                if (i.Value1 > i.Value2)
                {
                    i.Descriprion = "";
                    i.Mark = 1;
                }
                else
                {
                    if (i.Value1 < i.Value2)
                    {
                        i.Descriprion = "";
                        i.Mark = 0;
                    }
                    else
                    {
                        i.Descriprion = "";
                        i.Mark = 1;
                    }
                }
            }
           
            _indicators.Add(i);
        }
        public List<Indicator> PropertyStatusIndicators()
        {

            List<Indicator> indicators = new List<Indicator>
            {
                new Indicator() { Name = "Total value of assets", Value1 = 0, Value2 = 0 },
                new Indicator() { Name = "Residual value of fixed assets", Value1 = 0, Value2 = 0 },
                new Indicator() { Name = "Depreciation rate of fixed assets", Value1 = 0, Value2 = 0 }
            };
            return indicators;
        }
    }
}
