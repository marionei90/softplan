using System.Globalization;

namespace Calculate.Domain
{
    public class Calculate
    {
        private readonly double _initialValue;
        private readonly double _fee;
        private readonly byte _months;

        private double CalculateResult()
        {
            return _initialValue * Math.Pow(1 + _fee, _months);
        }

        public string Result
        {
            get 
            { 
                return CalculateResult().ToString("0.00");
            }
        }

        public Calculate(string fee, byte months, double initialValue)
        {
            CultureInfo info = new("pt-BR");
            info.NumberFormat.NumberDecimalSeparator = ".";

            _fee = Convert.ToDouble(fee, info);
            _months = months;
            _initialValue = initialValue;
        }
    }
}