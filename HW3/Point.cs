namespace HW3
{
    public class PointClass
    {
        private float _xf;
        private float _yf;
    
        private double _xd;
        private double _yd;

        public float Xf
        {
            get => _xf;
            set => _xf = value;
        }

        public float Yf
        {
            get => _yf;
            set => _yf = value;
        }

        public double Xd
        {
            get => _xd;
            set => _xd = value;
        }

        public double Yd
        {
            get => _yd;
            set => _yd = value;
        }
    }

    public struct PointStruct 
    {
        private float _xf;
        private float _yf;
    
        private double _xd;
        private double _yd;

        public float Xf
        {
            get => _xf;
            set => _xf = value;
        }

        public float Yf
        {
            get => _yf;
            set => _yf = value;
        }

        public double Xd
        {
            get => _xd;
            set => _xd = value;
        }

        public double Yd
        {
            get => _yd;
            set => _yd = value;
        }
    }
}