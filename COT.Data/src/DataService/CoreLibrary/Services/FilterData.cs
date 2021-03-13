using System;
using System.Collections.Generic;
using System.Linq;
using CoreLibrary.Exceptions;
using CoreLibrary.Interfaces;

namespace CoreLibrary.Services
{
    public class FilterData: IFilterData
    {
        public IList<int> Filter(string inputData, string symbol)
        {
            if (string.IsNullOrEmpty(inputData))
            {
                throw new HtmlInputTextNullException($"Empty downloaded data.");
            }
            string line = FindLine(symbol, inputData);
            return GetFilteredData(line);
        }

        string FindLine(string symbol, string text)
        {
            var count = 0;
            string[] textArray = text.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            for (int i = 0; i < textArray.Length; i++)
            {
                count++;
                if (textArray[i].StartsWith(symbol))
                {
                    count = 0;
                }

                if (i > 10 && count == 9)
                {
                    return textArray[i];
                }
            }
            return string.Empty;
        }
        List<int> GetFilteredData(string line)
        {
            try
            {
                string[] data = line.Replace(",", "")
                    .Split(" ");

                return data.Where(d => d.Length > 0)
                    .ToList()
                    .ConvertAll(d => int.Parse(d));
            }
            catch
            {
                throw new InvalidTextLineException($"Invalid data for parsing HTML line.");
            }
        }
    }
}
