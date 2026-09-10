using System;
using System.Reflection;
using System.Windows.Forms;

namespace MegaMariPrac.About
{
    partial class AboutBox : Form
    {
        public AboutBox()
        {
            InitializeComponent();
            CenterToScreen();
            Text = String.Format("About {0}", AssemblyTitle);
            _labelProductName.Text = AssemblyProduct;
            _labelVersion.Text = String.Format("Version {0}", AssemblyVersion);
            _labelCopyright.Text = AssemblyCopyright;
            _labelGameDev.Text = "Game made by Twilight Frontier";
            _textBoxDescription.Text = "Github repo: https://github.com/shadax1/MegaMariPrac" +
                                        "\r\n\r\nI added a lot of information about this game's memory addresses in the wiki if you're interested." +
                                        "\r\n\r\nFeel free to open an issue in case of issues/bugs or contact me via discord @shadax1." +
                                        "\r\n\r\nAlthough things should be self-explanatory, you can hover over certain elements of the window to have explanations about what they do.";
        }

        #region Assembly Attribute Accessors

        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                return attributes.Length == 0 ? "" : ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                return attributes.Length == 0 ? "" : ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                return attributes.Length == 0 ? "" : ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                return attributes.Length == 0 ? "" : ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion
    }
}
