using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageAppFrontend.Common
{
    public interface IViewNavigation
    {
        void NavigateTo<TViewModel>() where TViewModel : class;
    }
}
