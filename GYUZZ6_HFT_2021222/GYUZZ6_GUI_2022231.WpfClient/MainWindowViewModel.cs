using GYUZZ6_HFT_2021222.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYUZZ6_GUI_2022231.WpfClient
{
    public class MainWindowViewModel
    {
        public RestCollection<Car> Cars { get; set; }

        public MainWindowViewModel()
        {
            Cars = new RestCollection<Car>("http://localhost:18131/", "car");
        }
    }
}
