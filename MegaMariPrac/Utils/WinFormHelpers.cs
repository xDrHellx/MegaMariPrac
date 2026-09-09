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
        public static Label CreateLabel(string name, string text, Point position, Size size, Font font, bool autoSize = true, Control control = null, string textAlignment = "MiddleLeft")
        {
            Label lbl = new Label()
            {
                Name = name,
                Text = text,
                Location = position,
                Size = size,
                Font = font,
                AutoSize = autoSize,
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
        public static Button CreateButton(string name, string text, Point position, Size size, Font font, bool autoSize = true, Control control = null, string textAlignment = "MiddleLeft", bool enabled = true)
        {
            Button btn = new Button()
            {
                Name = name,
                Text = text,
                Location = position,
                Size = size,
                Font = font,
                AutoSize = autoSize,
                Enabled = enabled,
                TextAlign = GetTextAlignment(textAlignment)
            };

            control?.Controls.Add(btn);
            return btn;
        }

        /// <summary>Simplified method for creating a GroupBox</summary>
        /// <param name="name">Field name</param>
        /// <param name="text">Field text</param>
        /// <param name="position">Position</param>
        /// <param name="size">Size</param>
        /// <param name="font">Font</params>
        /// <param name="control">Control instance if the element is to be attached to it directly</param>
        /// <returns><c>GroupBox</c>Instance</returns>
        public static GroupBox CreateGroupBox(string name, string text, Point position, Size size, Font font, Control control = null)
        {
            GroupBox checkGroupBox = new GroupBox()
            {
                Name = name,
                Text = text,
                Location = position,
                Size = size,
                Font = font
            };

            // If a Control instance is passed, add the generated element to it
            control?.Controls.Add(checkGroupBox);
            return checkGroupBox;
        }

        /// <summary>Simplified method for creating a PictureBox</summary>
        /// <param name="name">PictureBox name</param>
        /// <param name="image">PictureBox image</param>
        /// <param name="position">Position</param>
        /// <param name="size">Size</param>
        /// <param name="control"></param>
        /// <param name="sizeMode">SizeMode, by default "AutoSize" (see System.Windows.Forms.PictureBoxSizeMode for possible values)</param>
        /// <param name="enabled">True if it should be enabled (True by default)</param>
        /// <returns><c>PictureBox</c>Instance</returns>
        public static PictureBox CreatePictureBox(string name, Image image, Point position, Size size, Control control = null, string sizeMode = "AutoSize", bool enabled = true)
        {
            PictureBox pictureBox = new PictureBox()
            {
                Name = name,
                Image = image,
                Location = position,
                Size = size,
                SizeMode = GetSizeMode(sizeMode),
                Enabled = enabled
            };

            control?.Controls.Add(pictureBox);
            return pictureBox;
        }

        /// <summary>Simplified method for creating a CheckBox</summary>
        /// <param name="name">Field name</param>
        /// <param name="text">Field text</param>
        /// <param name="position">Position</param>
        /// <param name="size">Size</param>m>
        /// <param name="isCheckedByDefault">Indicate if the CheckBox has to be checked when initiated (False by default)</param>
        /// <param name="checkboxOnRight">Indicate if the Checkbox has to be on the right of the text (False by default)</param>
        /// <param name="control">Control instance if the element is to be attached to it directly</param>
        /// <param name="enabled">True if it should be enabled (True by default)</param>
        /// <returns><c>CheckBox</c>Instance</returns>
        public static CheckBox CreateCheckBox(string name, string text, Point position, Size size, bool isCheckedByDefault = false, bool checkboxOnRight = false, Control control = null, bool enabled = true)
        {
            CheckBox checkBox = new CheckBox()
            {
                Name = name,
                Text = text,
                Checked = isCheckedByDefault,
                RightToLeft = checkboxOnRight == true ? RightToLeft.Yes : RightToLeft.No,
                Location = position,
                Size = size,
                Enabled = enabled
            };

            control?.Controls.Add(checkBox);
            return checkBox;
        }

        /// <summary>Simplified method for creating a dropdown list</summary>
        /// <param name="name">Dropdown name</param>
        /// <param name="position">Position</param>
        /// <param name="size">Size</param>m>
        /// <param name="font">Font</params>
        /// <param name="control">Control instance if the element is to be attached to it directly</param>
        /// <param name="dropDownWidth">Dropdown Width (in pixels, if not specified will take use the element's width as reference)</param>
        /// <param name="dropDownHeight">Dropdown Height (in pixels, if not specified will take use the element's height as reference)</param>
        /// <param name="visibleOptions">Amount of options visible without needing to scroll (will take priority over dropDownHeight parameters if specified)</param>
        /// <param name="enabled">True if it should be enabled (True by default)</param>
        /// <returns><c>ComboBox</c>Instance</returns>
        public static ComboBox CreateDropDownList(string name, Point position, Size size, Font font, Control control = null, int dropDownWidth = 0, int dropDownHeight = 0, int visibleOptions = 0, bool enabled = true)
        {
            ComboBox dropDownList = new ComboBox()
            {
                Name = name,
                Location = position,
                Size = size,
                Font = font,
                DropDownStyle = ComboBoxStyle.DropDownList,
                // If DropDownWidth was specified, use it, otherwise use the element's width
                DropDownWidth = dropDownWidth > 0 ? dropDownWidth : size.Width,
                Enabled = enabled
            };

            /**
             * If the number of options to show without needed to scroll is specified, use it
             * Otherwise handle the DropDownHeight the same way as the DropDownWidth
             */
            if (visibleOptions > 0) {
                dropDownList.DropDownHeight = (size.Height - 4) * visibleOptions;
            } else {
                dropDownList.DropDownHeight = dropDownHeight > 0 ? dropDownHeight : size.Height;
            }

            // If a Control instance is passed, add the generated element to it
            control?.Controls.Add(dropDownList);
            return dropDownList;
        }

        /// <summary>Simplified method for creating a StatusStrip</summary>
        /// <param name="name">Name</param>
        /// <param name="text">Text</param>
        /// <param name="position">Position</param>
        /// <param name="size">Size</param>
        /// <param name="sizingGrip">SizingGrip (False by default)</params>
        /// <param name="control">Control instance if the element is to be attached to it directly</param>
        /// <returns><c>StatusStrip</c>Instance</returns>
        public static StatusStrip CreateToolStatusStrip(string name, string text, Point position, Size size, bool sizingGrip = false, Control control = null)
        {
            StatusStrip strip = new StatusStrip()
            {
                Name = name,
                Text = text,
                Location = position,
                Size = size,
                SizingGrip = sizingGrip
            };

            control?.Controls.Add(strip);
            return strip;
        }

        /// <summary>Simplified method for creating a ToolStripStatusLabel</summary>
        /// <param name="name">Name</param>
        /// <param name="text">Text</param>
        /// <param name="toolTipText">Text on hover / tooltip</param>
        /// <returns><c>ToolStripStatusLabel</c>Instance</returns>
        public static ToolStripStatusLabel CreateToolStripStatusLabel(string name, string text, Size size, string toolTipText = "")
        {
            return new ToolStripStatusLabel()
            {
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
        private static ContentAlignment GetTextAlignment(string value)
        {
            switch (value)
            {
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

        /// <summary>Get the corresponding PictureBoxSizeMode based on a string</summary>
        /// <param name="value">SizeMode string</param>
        /// <returns><c>System.Windows.Forms.PictureBoxSizeMode</c>SizeMode object</returns>
        private static PictureBoxSizeMode GetSizeMode(string value)
        {
            switch (value)
            {
                case "CenterImage":     return PictureBoxSizeMode.CenterImage;
                case "Normal":          return PictureBoxSizeMode.Normal;
                case "StretchImage":    return PictureBoxSizeMode.StretchImage;
                case "Zoom":            return PictureBoxSizeMode.Zoom;
                default:                return PictureBoxSizeMode.AutoSize;
            };
        }

        public static Bitmap GetResourceImage(string name)
        {
            return name != "" ? (Bitmap)global::MegaMariPrac.Properties.Resources.ResourceManager.GetObject(name) : null;
        }

        #endregion
    }
}
