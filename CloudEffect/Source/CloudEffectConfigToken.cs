using System;

namespace PaintDotNet.Effects
{
    public class CloudEffectConfigToken : EffectConfigToken
    {
        private double frequency;
        public double Frequency
        {
            get { return frequency; }
            set { this.frequency = value; }
        }

        private double persistance;
        public double Persistance
        {
            get { return persistance; }
            set { this.persistance = value; }
        }

        private double amplitude;
        public double Amplitude
        {
            get { return amplitude; }
            set { this.amplitude = value; }
        }

        private double cloudCoverage;
        public double CloudCoverage
        {
            get { return cloudCoverage; }
            set { this.cloudCoverage = value; }
        }

        private double cloudDensity;
        public double CloudDensity
        {
            get { return cloudDensity; }
            set { this.cloudDensity = value; }
        }

        private int octaves;
        public int Octaves
        {
            get { return octaves; }
            set { this.octaves = value; }
        }

        private int displayOption;
        public int DisplayOption
        {
            get { return displayOption; }
            set { this.displayOption = value; }
        }

        private int r1;
        public int R1
        {
            get { return r1; }
            set { r1 = value; }
        }

        private int r2;
        public int R2
        {
            get { return r2; }
            set { r2 = value; }
        }

        private int r3;
        public int R3
        {
            get { return r3; }
            set { r3 = value; }
        }

        public CloudEffectConfigToken()
            : base()
        {
            this.frequency = 0.015;
            this.persistance = 0.65;
            this.octaves = 8;
            this.amplitude = 1.00;
            this.cloudCoverage = 0.0;
            this.cloudDensity = 1.0;
            this.displayOption = CloudEffect.REPLACE_TRANSPARENT;
            this.r1 = 15731;
            this.r2 = 789221;
            this.r3 = 1376312589;
        }

        public CloudEffectConfigToken(double frequency, double persistance, int octaves, double amplitude, double cloudCoverage, double cloudDensity, int displayOption, int r1, int r2, int r3)
            : base()
        {
            this.frequency = frequency;
            this.persistance = persistance;
            this.octaves = octaves;
            this.amplitude = amplitude;
            this.cloudCoverage = cloudCoverage;
            this.cloudDensity = cloudDensity;
            this.displayOption = displayOption;
            this.r1 = r1;
            this.r2 = r2;
            this.r3 = r3;
        }

        protected CloudEffectConfigToken(CloudEffectConfigToken copyMe)
            : base(copyMe)
        {
            this.frequency = copyMe.frequency;
            this.persistance = copyMe.persistance;
            this.amplitude = copyMe.amplitude;
            this.cloudCoverage = copyMe.cloudCoverage;
            this.cloudDensity = copyMe.cloudDensity;
            this.octaves = copyMe.octaves;
            this.displayOption = copyMe.displayOption;
            this.r1 = copyMe.r1;
            this.r2 = copyMe.r2;
            this.r3 = copyMe.r3;
        }

        public override object Clone()
        {
            return new CloudEffectConfigToken(this);
        }
    }
}