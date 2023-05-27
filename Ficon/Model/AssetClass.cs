using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Ficon.Model
{
    internal class AssetClass : INotifyPropertyChanged
    {
        string index_name;
        public string Name
        {
            get
            {
                return index_name;
            }
            set
            {
                index_name = value;
                RaisePropertyChanged(nameof(Name));
            }
        }
        public float Value { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string n)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(n));
        }

        public static List<AssetClass> ConstructTestData()
        {
            List<AssetClass> assetClasses = new List<AssetClass>();
            assetClasses.Add(new AssetClass() { Name = "Property status", Value = 72 });
            assetClasses.Add(new AssetClass() { Name = "Financial stability", Value = 72 });
            assetClasses.Add(new AssetClass() { Name = "Liquidity and solvency", Value = 72 });
            assetClasses.Add(new AssetClass() { Name = "Business Activity", Value = 72 });
            assetClasses.Add(new AssetClass() { Name = "Profitability", Value = 72 });
            return assetClasses;
        }
    }
}
