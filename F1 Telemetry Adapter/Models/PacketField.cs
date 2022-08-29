using NingSoft.F1TelemetryAdapter.Helpers;
using System;
using System.Collections.Generic;

namespace NingSoft.F1TelemetryAdapter.Models
{
    public class FieldList : List<PacketField>
    {
        /// <summary>
        /// 按照字节定义的顺序，对于所有“基础类型”的属性进行遍历
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="obj"></param>
        public void LoadBytes(Bytes bytes, object obj)
        {
            if (bytes == null || bytes.byteData.Length == 0) return;

            Action<PacketField, object> action = (item, entity) =>
            {
                object value = null;

                if (item.Count == 0)
                {
                    value = bytes.ConvertValue(item.TypeName);
                }
                else
                {
                    var arrayEntity = Array.CreateInstance(item.Type, item.Count);
                    for (int i = 0; i < item.Count; i++)
                    {
                        arrayEntity.SetValue(bytes.ConvertValue(item.TypeName), i);
                    }
                    value = arrayEntity;
                }

                entity.GetType().GetField(item.Name).SetValue(entity, value);
            };

            foreach (var item in this)
            {
                VisitItem(item, action, obj);
            }
        }

        public void MoveIndexToEnd(Bytes bytes, object obj)
        {
            if (bytes == null) return;

            Action<PacketField, object> action = (item, entity) =>
            {
                if (item.Count == 0)
                {
                    bytes.MoveIndexByType(item.TypeName);
                }
                else
                {
                    for (int i = 0; i < item.Count; i++)
                    {
                        bytes.MoveIndexByType(item.TypeName);
                    }
                }
            };

            foreach (var item in this)
            {
                VisitItem(item, action, obj);
            }
        }

        private void VisitItem(PacketField item, Action<PacketField, object> action, object entity)
        {
            if (!item.HasChild)
            {
                action.Invoke(item, entity);
                return;
            }
            else
            {
                if (item.Count == 0)//当子类型不是数组，直接创建实体并赋值
                {
                    var createEntity = Activator.CreateInstance(item.Type);
                    foreach (var child in item.Children)
                    {
                        VisitItem(child, action, createEntity);
                    }
                    entity.GetType().GetField(item.Name).SetValue(entity, createEntity);
                }
                else//当子类型为数组时，创建数组类型
                {
                    var arrayEntity = Array.CreateInstance(item.Type, item.Count);
                    for (int i = 0; i < item.Count; i++)
                    {
                        var createEntity = Activator.CreateInstance(item.Type);
                        foreach (var child in item.Children)
                        {
                            VisitItem(child, action, createEntity);
                        }
                        arrayEntity.SetValue(createEntity, i);
                    }
                    entity.GetType().GetField(item.Name).SetValue(entity, arrayEntity);
                }
            }
        }
    }

    public class PacketField
    {
        private Type _type;
        /// <summary>
        /// Field name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Field type in document
        /// </summary>
        public string TypeName { get; set; }
        /// <summary>
        /// Use it to create instance.
        /// </summary>
        public Type Type
        {
            get
            {
                if (_type == null)
                    _type = TypeName.ToType();
                return _type;
            }
            set { _type = value; }
        }
        /// <summary>
        /// conut > 0 means that the item is an array
        /// </summary>
        public int Count { get; set; } = 0;
        public string ClassName { get; set; }
        public PacketField[] Children { get; set; }
        public bool HasChild => Children != null && Children.Length > 0;
    }
}
