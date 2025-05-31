using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace SimulatorSampleApp.MVVM
{
    public abstract class ViewModelWrapper<T> : ViewModelBase where T : class
    {
        public T Model { get; }

        protected ViewModelWrapper(T model)
        {
            Model = model ?? throw new ArgumentNullException(nameof(model));
        }

        protected bool SetProperty<TValue>(
            TValue currentValue,
            TValue newValue,
            Action<TValue> setAction,
            [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<TValue>.Default.Equals(currentValue, newValue)) return false;

            setAction(newValue);
            OnPropertyChanged(propertyName);
            return true;
        }

        protected bool SetProperty<TValue>(
            Func<TValue> getter,
            Action<TValue> setter,
            TValue newValue,
            [CallerMemberName] string propertyName = null)
        {
            return SetProperty(getter(), newValue, setter, propertyName);
        }
    }
}
