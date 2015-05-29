using System;
using System.Collections;
using System.Drawing;

namespace PaintDotNet.Effects
{
    public class CloudEffect
        : Effect
    {
        public const int REPLACE_TRANSPARENT = 1;
        public const int REPLACE_SOURCE = 2;
        public const int OVERLAY_PRIMARY = 3;
        public const int OVERLAY_SECONDARY = 4;

        private int r1 = 15731;
        private int r2 = 789221;
        private int r3 = 1376312589;

        public static string StaticName
        {
            get
            {
                return "Clouds";
            }
        }

        public static Bitmap StaticIcon
        {
            get
            {
                return new Bitmap(typeof(CloudEffect), "CloudEffectIcon.png");
            }
        }

        public CloudEffect()
            : base(CloudEffect.StaticName, CloudEffect.StaticIcon, true)
        {
            
        }

        public override EffectConfigDialog CreateConfigDialog()
        {
            return new CloudEffectConfigDialog();
        }

        public override void Render(EffectConfigToken parameters, RenderArgs dstArgs, RenderArgs srcArgs, Rectangle[] rois, int startIndex, int length)
        {
            CloudEffectConfigToken token = (CloudEffectConfigToken)parameters;
            PdnRegion selectionRegion = EnvironmentParameters.GetSelection(srcArgs.Bounds);
            
            this.r1 = token.R1;
            this.r2 = token.R2;
            this.r3 = token.R3;
            
            for (int i = startIndex; i < startIndex + length; ++i)
            {
                Rectangle rect = rois[i];

                for (int y = rect.Top; y < rect.Bottom; ++y)
                {
                    for (int x = rect.Left; x < rect.Right; ++x)
                    {
                        if (selectionRegion.IsVisible(x, y))
                        {
                            ColorBgra srcBgra = srcArgs.Surface[x, y];
                            byte c = (byte)(PerlinNoise2d(x, y, token) * 255);

                            switch (token.DisplayOption)
                            {
                                case CloudEffect.REPLACE_SOURCE:
                                    dstArgs.Surface[x, y] = ColorBgra.FromBgra(srcBgra.B, srcBgra.G, srcBgra.R, c);
                                    break;
                                case CloudEffect.OVERLAY_PRIMARY:
                                    ColorBgra primary = (ColorBgra)EnvironmentParameters.ForeColor;
                                    dstArgs.Surface[x, y] = ColorBgra.FromBgra(primary.B, primary.G, primary.R, c);
                                    break;
                                case CloudEffect.OVERLAY_SECONDARY:
                                    ColorBgra secondary = (ColorBgra)EnvironmentParameters.BackColor;
                                    dstArgs.Surface[x, y] = ColorBgra.FromBgra(secondary.B, secondary.G, secondary.R, c);
                                    break;
                                case CloudEffect.REPLACE_TRANSPARENT:
                                    dstArgs.Surface[x, y] = (0 == srcBgra.A) ? ColorBgra.FromBgra(srcBgra.B, srcBgra.G, srcBgra.R, c) : srcArgs.Surface[x, y];
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                }
            }
        }

        private double PerlinNoise2d(int x, int y, CloudEffectConfigToken configToken)
        {
            double total = 0.0;
            double frequency = configToken.Frequency;
            double persistence = configToken.Persistance;
            double octaves = configToken.Octaves;
            double amplitude = configToken.Amplitude;

            double cloudCoverage = configToken.CloudCoverage;
            double cloudDensity = configToken.CloudDensity;

            for (int lcv = 0; lcv < octaves; lcv++)
            {
                total = total + Smooth(x * frequency, y * frequency) * amplitude;
                frequency = frequency * 2;
                amplitude = amplitude * persistence;
            }

            total = (total + cloudCoverage) * cloudDensity;

            if (total < 0) total = 0.0;
            if (total > 1) total = 1.0;

            return total;
        }

        private double Smooth(double x, double y)
        {
            double n1 = Noise((int)x, (int)y);
            double n2 = Noise((int)x + 1, (int)y);
            double n3 = Noise((int)x, (int)y + 1);
            double n4 = Noise((int)x + 1, (int)y + 1);

            double i1 = Interpolate(n1, n2, x - (int)x);
            double i2 = Interpolate(n3, n4, x - (int)x);

            return Interpolate(i1, i2, y - (int)y);
        }

        private double Noise(int x, int y)
        {
            int n = x + y * 57;
            n = (n << 13) ^ n;
            return (1.0 - ((n * (n * n * r1 + r2) + r3) & 0x7fffffff) / 1073741824.0);
        }

        private double Interpolate(double x, double y, double a)
        {
            double val = (1 - Math.Cos(a * Math.PI)) * .5;
            return x * (1 - val) + y * val;
        }
    }
}