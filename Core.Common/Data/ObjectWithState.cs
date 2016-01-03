;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Core.Common.Annotations;
using Core.Common.Contracts;
using Core.Common.Core;
using Core.Common.Utils;

namespace Core.Common.Data
{

    public class ObjectWithState : NotificationObject, IObjectWithState
    {
        private ObjectState _state;

        [NotNavigable]
        public ObjectState State { get { return _state; }}

        protected ObjectWithState()
        {
            this._state = ObjectState.Added;
        }

        public void ClearEntityObjectState()
        {
            var visited = new List<ObjectWithState>();
            RecursiveSetObjectAndChildrenState(this, visited, ObjectState.Unchanged);
        }

        private void RecursiveSetObjectAndChildrenState(ObjectWithState entity, List<ObjectWithState> visited, ObjectState newState)
        {
            if (visited.Contains(entity)) return;
            if (entity == null) return;

            entity._state = newState;

            foreach (var property in entity.GetType().GetProperties())
            {
                if (property.PropertyType.IsSubclassOf(typeof (ObjectWithState)))
                {
                    var obj = (ObjectWithState) (property.GetValue(entity, null));
                    RecursiveSetObjectAndChildrenState(obj, visited, newState);
                }
                else
                {
                    var col1 = property.GetValue(entity, null) as IList;
                    if (col1 == null) continue;
                    foreach (var item in col1.OfType<ObjectWithState>())
                    {
                        RecursiveSetObjectAndChildrenState(item, visited, newState);
                    }
                }
            }
        }

        #region Property change notification

        protected override void OnPropertyChanged(string propertyName)
        {
            OnPropertyChanged(propertyName, true);
        }

        protected void OnPropertyChanged<T>(Expression<Func<T>> propertyExpression, bool makeDirty)
        {
            string propertyName = PropertySupport.ExtractPropertyName(propertyExpression);
            OnPropertyChanged(propertyName, makeDirty);
        }

        [NotifyPropertyChangedInvocator]
        protected void OnPropertyChanged<T>(Expression<Func<T>> propertyExpression)
        {
            string propertyName = PropertySupport.ExtractPropertyName(propertyExpression);
            OnPropertyChanged(propertyName, true);
        }

        protected void OnPropertyChanged(string propertyName, bool makeDirty)
        {
            if (makeDirty && State == ObjectState.Unchanged)
                _state = ObjectState.Modified;
        }
        #endregion

    }
}