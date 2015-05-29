using System;

namespace $safeprojectname$
{
    public class EffectPluginConfigToken : PaintDotNet.Effects.EffectConfigToken
    {
        // Declare variables here
        // Using getters/setters, you can manipulate the "value" before assigning it to your private variable.

        // Example using getters/setters:
        //----------------------------------------
        // private double variable;
        // public double Variable
        // {
        //     get { return variable; }
        //     set { this.variable = value; }
        // }

        // Example not using getters/setters:
        //----------------------------------------
        // public double variable;

        public EffectPluginConfigToken()
            : base()
        {
            // Set default variables here
            // this.variable = 0.0;
        }

        protected EffectPluginConfigToken(EffectPluginConfigToken copyMe)
            : base(copyMe)
        {
            // this.variable = copyMe.variable;
        }

        public override object Clone()
        {
            return new EffectPluginConfigToken(this);
        }
    }
}