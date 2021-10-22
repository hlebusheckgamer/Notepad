using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notepad.Wpf.Models
{
    public class NotifyEntity : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public bool TrackChanges { get; set; } = true;

        protected void NotifyPropertyChanged(string propertyName)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        protected bool SetValue<T>(ref T property, T value, string propertyName)
            => SetValue(ref property, value, propertyName, null);
        protected bool SetValue<T>(ref T property, T value, string propertyName, Action<T> action)
        {
            if (Equals(property, value)) return false;

            property = value;

            if (TrackChanges)
                NotifyPropertyChanged(propertyName);

            action?.Invoke(value);

            return true;
        }
    }
}
