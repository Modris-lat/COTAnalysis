using System;
using System.Collections.Generic;
using System.Linq;
using CoreLibrary.Interfaces;

namespace CoreLibrary.Services
{
    public class FilterData: IFilterData
    {
        public IList<double> Filter(string inputData, string symbol)
        {
            var list = new List<double>{};
            var count = 0;
            string[] text = inputData.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            for (int i = 0; i < text.Length; i++)
            {
                count++;
                if (text[i].StartsWith(symbol))
                {
                    count = 0;
                }

                if (i > 10 && count == 9)
                {
                    string[] data = text[i].Split(" ");
                    var filteredData = data.Where(d => d.Length > 0)
                        .ToList()
                        .ConvertAll(d=>double.Parse(d));
                    return filteredData;
                }
            };
            return list;
        }
    }
}
