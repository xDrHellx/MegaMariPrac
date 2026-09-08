using System.Drawing;
using System.Windows.Forms;

namespace MegaMariPrac.Utils
{
    public class WinFormHelpers
    {
        #region Standard elements

        /// <summary>Simplified method for creating a label</summary>
        /// <param name="name">Label name</param>
        /// <param name="text">Label text</param>
        /// <param name="position">Position</param>
        /// <param name="size">Size</param>
        /// <param name="font">Font</params>
        /// <param name="autoSize"AutoSize (True by default)</params>
        /// <param name="control">Control instance if the element is to be attached to it directly</param>
        /// <param name="textAlignment">Text alignment, by default "MiddleLeft" (see System.Drawing.ContentAlignment for possible values)</param>
        /// <returns><c>Label</c>Instance</returns>
        public static Label CreateLabel(string name, string text, Point position, Size size, Font font, bool autoSize = true, Control control = null, string textAlignment = "MiddleLeft") {
            Label lbl = new Label() {
                Name = name,
                Text = text,
                Location = position,
                Size = size,
                Font = font,
                AutoSize = autoSize,
                TabIndex = 2,
                TextAlign = GetTextAlignment(textAlignment)
            };

            // If a Control instance is passed, add the generated element to it
            control?.Controls.Add(lbl);
            return lbl;
        }

        /// <summary>Simplified method for creating a button</summary>
        /// <param name="name">Label name</param>
        /// <param name="text">Label text</param>
        /// <param name="position">Position</param>
        /// <param name="size">Size</param>
        /// <param name="font">Font</params>
        /// <param name="autoSize"AutoSize (True by default)</params>
        /// <param name="control">Control instance if the element is to be attached to it directly</param>
        /// <param name="textAlignment">Text alignment, by default "MiddleLeft" (see System.Drawing.ContentAlignment for possible values)</param>
        /// <param name="enabled">True if it should be enabled (True by default)</param>
        /// <returns><c>Button</c>Instance</returns>
        public static Button CreateButton(string name, string text, Point position, Size size, Font font, bool autoSize = true, Control control = null, string textAlignment = "MiddleLeft", bool enabled = true) {
            Button btn = new Button() {
                Name = name,
                Text = text,
                Location = position,
                Size = size,
                Font = font,
                AutoSize = autoSize,
                TabIndex = 2,
                Enabled = enabled,
                TextAlign = GetTextAlignment(textAlignment)
            };

            control?.Controls.Add(btn);
            return btn;
        }

        /// <summary>Simplified method for creating a StatusStrip</summary>
        /// <param name="name">Name</param>
        /// <param name="text">Text</param>
        /// <param name="position">Position</param>
        /// <param name="size">Size</param>
        /// <param name="sizingGrip">SizingGrip (False by default)</params>
        /// <param name="control">Control instance if the element is to be attached to it directly</param>
        /// <returns><c>StatusStrip</c>Instance</returns>
        public static StatusStrip CreateToolStatusStrip(string name, string text, Point position, Size size, bool sizingGrip = false, Control control = null) {
            StatusStrip strip = new StatusStrip() {
                Name = name,
                Text = text,
                Location = position,
                Size = size,
                SizingGrip = sizingGrip,
                AutoSize = true
            };

            control?.Controls.Add(strip);
            return strip;
        }

        /// <summary>Simplified method for creating a ToolStripStatusLabel</summary>
        /// <param name="name">Name</param>
        /// <param name="text">Text</param>
        /// <param name="toolTipText">Text on hover / tooltip</param>
        /// <returns><c>ToolStripStatusLabel</c>Instance</returns>
        public static ToolStripStatusLabel CreateToolStripStatusLabel(string name, string text, Size size, string toolTipText = "") {
            return new ToolStripStatusLabel() {
                Name = name,
                Text = text,
                Size = size,
                ToolTipText = toolTipText,
                AutoSize = true
            };
        }

        #endregion

        # region Misc

        /// <summary>Get the corresponding text alignment based on a string</summary>
        /// <param name="value">Text alignment string</param>
        /// <returns><c>System.Drawing.ContentAlignment</c>Text alignment object</returns>
        private static ContentAlignment GetTextAlignment(string value) {
            switch (value) {
                case "BottomCenter":    return ContentAlignment.BottomCenter;
                case "BottomLeft":      return ContentAlignment.BottomLeft;
                case "BottomRight":     return ContentAlignment.BottomRight;
                case "MiddleLeft":      return ContentAlignment.MiddleLeft;
                case "MiddleRight":     return ContentAlignment.MiddleRight;
                case "TopCenter":       return ContentAlignment.TopCenter;
                case "TopLeft":         return ContentAlignment.TopLeft;
                case "TopRight":        return ContentAlignment.TopRight;
                default:                return ContentAlignment.MiddleCenter;
            };
        }

        #endregion
    }
}
