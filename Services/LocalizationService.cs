using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace SpacefinderApp.Services
{
    public class LocalizationService : INotifyPropertyChanged
    {
        private ResourceManager _resourceManager;
        public string this[string key] => _resourceManager.GetString(key);

        public object PropertyChanged { get; private set; }

        event PropertyChangedEventHandler? INotifyPropertyChanged.PropertyChanged
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

        public void SetLanguage(string cultureCode)
        {
            _resourceManager = new ResourceManager(
                $"SpacefinderApp.Resources.Strings.{cultureCode}",
                Assembly.GetExecutingAssembly()
            );
            object prop = PropertyChanged.Invoke(this, new PropertyChangedEventArgs(null));
        }
    }
}
