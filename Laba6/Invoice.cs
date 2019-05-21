using System;
using System.Linq;
using System.Text;


namespace Laba6
{
    [Serializable]
    public struct Invoice : IComparable<Invoice>
    {
        public int numberOfInvoice { get; set; }
        public string date { get; set; }
        public string counterparty { get; set; }
        public int numberOfContract { get; set; }
        public int sum { get; set; }

        public int CompareTo(Invoice that)
        {
            return numberOfInvoice.CompareTo(that.numberOfInvoice);
        }

        public Invoice(string allData)
        {
            while (allData.Contains("  "))
            {
                allData = allData.Replace("  ", " ");
            }

            string[] array = allData.Split(' ').ToArray();

            numberOfInvoice = Convert.ToInt32(array[0]);
            date = array[1];
            counterparty = array[2];
            numberOfContract = Convert.ToInt32(array[3]);
            sum = Convert.ToInt32(array[4]);
        }
    }


}
