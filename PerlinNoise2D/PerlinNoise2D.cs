void Render(Surface dst, Surface src, Rectangle rect)
{
    for(int y = rect.Top; y < rect.Bottom; y++)
    {
        for (int x = rect.Left; x < rect.Right; x++)
        {
            ColorBgra srcBgra = src[x, y];
            byte c = (byte)(PerlinNoise2d(x, y) * 255);
            dst[x, y] = ColorBgra.FromBgra(srcBgra.B, srcBgra.G, srcBgra.R, c);
        }
    }
}

static Random r = new Random();
int r1 = r.Next(1000, 10000);
int r2 = r.Next(100000, 1000000);
int r3 = r.Next(1000000000, 2000000000);

double PerlinNoise2d(int x, int y)
{
    double total = 0.0;
    double frequency = .015;    // USER ADJUSTABLE
    double persistence = .65;   // USER ADJUSTABLE
    double octaves = 8;         // USER ADJUSTABLE
    double amplitude = 1;       // USER ADJUSTABLE

    double cloudCoverage = 0;   // USER ADJUSTABLE
    double cloudDensity = 1;    // USER ADJUSTABLE
        
    for(int lcv = 0; lcv < octaves; lcv++)
    {
        total = total + Smooth(x * frequency, y * frequency) * amplitude;
        frequency = frequency * 2;
        amplitude = amplitude * persistence;
    }

    total = (total + cloudCoverage) * cloudDensity;

    if(total < 0) total = 0.0;
    if(total > 1) total = 1.0;

    return total;
}

double Smooth(double x, double y)
{
    double n1 = Noise((int)x, (int)y);
    double n2 = Noise((int)x + 1, (int)y);
    double n3 = Noise((int)x, (int)y + 1);
    double n4 = Noise((int)x + 1, (int)y + 1);

    double i1 = Interpolate(n1, n2, x - (int)x);
    double i2 = Interpolate(n3, n4, x - (int)x);

    return Interpolate(i1, i2, y - (int)y);
}

double Noise(int x, int y)
{
    int n = x + y * 57;
    n = (n<<13) ^ n;

    return ( 1.0 - ( (n * (n * n * r1 + r2) + r3) & 0x7fffffff) / 1073741824.0);
}

double Interpolate(double x, double y, double a)
{
    double val = (1 - Math.Cos(a * Math.PI)) * .5;
    return  x * (1 - val) + y * val;
}