using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace FormattedText.ViewModels
{
    class MainViewModel:BaseViewModel
    {
        public MainViewModel()
        {
            var generator = new Random((int)DateTime.Now.Ticks);
            var items = Enumerable.Range(1, generator.Next(4, 10))
                .Select(i=>new IstructionItemViewModel()
                {
                    Index = i,
                    Description = "Replace 10% bleach bottle with bottle with contain 170 ml of deionized water (diHˇ2O).",
                });
            Istructions = new ObservableCollection<IstructionItemViewModel>(items);            
        }
        public ObservableCollection<IstructionItemViewModel> Istructions { get; private set; }
    }
}
