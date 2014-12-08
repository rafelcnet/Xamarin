using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace FlyOutSample
{
  public class App
  {
    public static INavigation Navigation { get; set; }
    public static Page GetMainPage()
    {
      var rootPage = new MasterMainView();
      Navigation = rootPage.Navigation;
      return rootPage;
    }
  }
}
