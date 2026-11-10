using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace Jaeger.Contable.Domain.Abstractions {
    public abstract class BasePropertyChangeImplementation : INotifyPropertyChanged {
        [DebuggerNonUserCode]
        protected BasePropertyChangeImplementation() {
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            PropertyChangedEventHandler propertyChangedEventHandler = this.PropertyChanged;
            if (propertyChangedEventHandler != null) {
                propertyChangedEventHandler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        protected virtual void OnPropertyChanged<T>(Expression<Func<T>> propertyExpression) {
            this.OnPropertyChanged(((MemberExpression)propertyExpression.Body).Member.Name);
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
