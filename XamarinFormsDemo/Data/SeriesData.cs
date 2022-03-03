﻿using DevExpress.XamarinForms.Charts;
using System;
using Xamarin.Forms;

namespace XamarinFormsDemo.Data
{
    public class XYSeriesData : IXYSeriesData
    {
        StockPrices stockPrices;
        SeriesDataType seriesDataType;

        public XYSeriesData(StockPrices stockPrices, SeriesDataType seriesDataType)
        {
            this.stockPrices = stockPrices;
            this.seriesDataType = seriesDataType;
        }

        public int GetDataCount() => stockPrices.Count;
        public SeriesDataType GetDataType() => seriesDataType;
        public DateTime GetDateTimeArgument(int index) => stockPrices[index].Date;
        public double GetValue(DevExpress.XamarinForms.Charts.ValueType valueType, int index)
        {
            switch (valueType)
            {
                case DevExpress.XamarinForms.Charts.ValueType.Value: return stockPrices[index].Volume;
                case DevExpress.XamarinForms.Charts.ValueType.High: return stockPrices[index].High;
                case DevExpress.XamarinForms.Charts.ValueType.Low: return stockPrices[index].Low;
                case DevExpress.XamarinForms.Charts.ValueType.Open: return stockPrices[index].Open;
                case DevExpress.XamarinForms.Charts.ValueType.Close: return stockPrices[index].Close;
            }
            return 0;
        }
        public double GetNumericArgument(int index) { return 0; }
        public string GetQualitativeArgument(int index) { return string.Empty; }
        public object GetKey(int index) => null;
    }

    public class CalculatedSeriesData : BindableObject, ICalculatedSeriesData
    {
        public CalculatedSeriesData()
        {
        }

        public Series Series
        {
            get => null;
        }
    }
}
