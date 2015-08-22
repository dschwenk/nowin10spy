using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FixMy10
{
    class errorDialogs
    {

        public void ShowErrorMessage(Exception e, string Title)
        {
                MessageBox.Show(e.Message,
                        Title
                        , MessageBoxButton.OK
                        , MessageBoxImage.Error);
        }

    }
}
