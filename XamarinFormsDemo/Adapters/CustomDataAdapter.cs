using DevExpress.XamarinForms.Charts;
using System;
using Xamarin.Forms;

namespace XamarinFormsDemo.Adapters
{
    public class CustomDataAdapter : BindableObject, IXYSeriesData, IChangeableSeriesData
    {
        const int MaxDataCount = 30;
        int dataCount = 0;
        int offset = 0;

        public event DataChangedEventHandler DataChanged;

        public void Next()
        {
            dataCount++;
            DataChanged?.Invoke(this, DataChangedEventArgs.Add());
            if (dataCount > MaxDataCount)
            {
                offset++;
                dataCount = MaxDataCount;
                DataChanged?.Invoke(this, DataChangedEventArgs.Remove(0));
            }
        }

        int IXYSeriesData.GetDataCount() => dataCount;
        SeriesDataType IXYSeriesData.GetDataType() => SeriesDataType.Numeric;
        object IXYSeriesData.GetKey(int index) => index;
        double IXYSeriesData.GetNumericArgument(int index) => offset + index;
        DateTime IXYSeriesData.GetDateTimeArgument(int index) => throw new NotImplementedException();
        string IXYSeriesData.GetQualitativeArgument(int index) => throw new NotImplementedException();

        double IXYSeriesData.GetValue(DevExpress.XamarinForms.Charts.ValueType valueType, int index)
        {
            switch (valueType)
            {
                case DevExpress.XamarinForms.Charts.ValueType.Value:
                    double argument = index + offset;
                    return Math.Sin(argument) * Math.Cos(argument);
            }
            return 0.0;
        }
    }
}
