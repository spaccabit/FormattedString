using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormattedText.ViewModels
{
    class IstructionItemViewModel : BaseViewModel
    {
        int _Index =0;
        public int Index
        {
            get => _Index;
            set => SetProperty(ref _Index, value);
        }

        string _Description;
        public string Description
        {
            get => _Description;
            set => SetProperty(ref _Description, value);
        }
    }
}
