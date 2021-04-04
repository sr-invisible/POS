using POS.ViewModel.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Service.IService
{
    public interface IAsideSectionService
    {
        IEnumerable<AsideSectionViewModel> GetAsideSection();
    }
}
