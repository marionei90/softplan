namespace ReturnFees.Domain
{
    public class ReturnFee
    {
        private double _fee;

        public double Fee { get { return _fee; } set { _fee = value; } }

        public ReturnFee()
        {
            _fee = 0.01;
        }
    }
}