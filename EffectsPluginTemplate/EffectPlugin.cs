using System;
using System.Collections;
using System.Drawing;
using PaintDotNet;
using PaintDotNet.Effects;

namespace $safeprojectname$
{
    public class EffectPlugin
        : PaintDotNet.Effects.Effect
    {
        public static string StaticName
        {
            get
            {
                return "Effect Plugin";
            }
        }

        public static Bitmap StaticIcon
        {
            get
            {
                return new Bitmap(typeof(EffectPlugin), "EffectPluginIcon.png");
            }
        }

        public static string StaticSubMenuName
        {
            get
            {
                return null; // Use for no submenu
                // return "My SubMenu"; // Use for custom submenu
            }
        }

        public EffectPlugin()
            : base(EffectPlugin.StaticName, EffectPlugin.StaticIcon, EffectPlugin.StaticSubMenuName, true)
        {

        }

        public override EffectConfigDialog CreateConfigDialog()
        {
            return new EffectPluginConfigDialog();
        }

        public override void Render(EffectConfigToken parameters, RenderArgs dstArgs, RenderArgs srcArgs, Rectangle[] rois, int startIndex, int length)
        {
            PdnRegion selectionRegion = EnvironmentParameters.GetSelection(srcArgs.Bounds);

            for (int i = startIndex; i < startIndex + length; ++i)
            {
                Rectangle rect = rois[i];

                for (int y = rect.Top; y < rect.Bottom; ++y)
                {
                    for (int x = rect.Left; x < rect.Right; ++x)
                    {
                        // Render Code Here
                    }
                }
            }
        }
    }
}