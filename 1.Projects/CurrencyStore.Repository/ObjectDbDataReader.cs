using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using CurrencyStore.Utility.Dynamic;

namespace CurrencyStore.Repository
{
    public class ObjectDbDataReader<T> : IDataReader where T : class
    {
        IEnumerator<T> _ie;
        List<PropertyDescription> _properties;

        public ObjectDbDataReader(IEnumerator<T> dataSource)
        {
            _ie = dataSource;
            _properties = ObjectFactory.GetProperties(typeof(T)).ToList();
        }

        #region IDataReader Members

        public virtual void Close()
        {
            _ie = null;
        }

        public virtual int Depth
        {
            get { throw new NotImplementedException(); }
        }

        public virtual DataTable GetSchemaTable()
        {
            //throw new NotImplementedException();
            var dt = new DataTable();
            dt.Columns.AddRange(_properties.Select(c =>
                new DataColumn(c.Name, c.Type)).ToArray());
            return dt;
        }

        public virtual bool IsClosed
        {
            get { return _ie == null; }
        }

        public virtual bool NextResult()
        {
            return false;
        }

        public virtual bool Read()
        {
            return _ie.MoveNext();
        }

        public virtual int RecordsAffected
        {
            get { return 1; }
        }

        #endregion

        #region IDisposable Members

        public virtual void Dispose()
        {
            _ie = null;
        }

        #endregion

        #region IDataRecord Members

        public virtual int FieldCount
        {
            get
            {
                return _properties.Count;
            }
        }

        public virtual bool GetBoolean(int i)
        {
            return Convert.ToBoolean(GetValue(i));
        }

        public virtual byte GetByte(int i)
        {
            return Convert.ToByte(GetValue(i));
        }

        public virtual long GetBytes(int i, long fieldOffset, byte[] buffer, int bufferoffset, int length)
        {
            throw new NotImplementedException();
        }

        public virtual char GetChar(int i)
        {
            return Convert.ToChar(GetValue(i));
        }

        public virtual long GetChars(int i, long fieldoffset, char[] buffer, int bufferoffset, int length)
        {
            throw new NotImplementedException();
        }

        public virtual IDataReader GetData(int i)
        {
            throw new NotImplementedException();
        }

        public virtual string GetDataTypeName(int i)
        {
            return _properties[i].Type.Name;
        }

        public virtual DateTime GetDateTime(int i)
        {
            return Convert.ToDateTime(GetValue(i));
        }

        public virtual decimal GetDecimal(int i)
        {
            return Convert.ToDecimal(GetValue(i));
        }

        public virtual double GetDouble(int i)
        {
            return Convert.ToDouble(GetValue(i));
        }

        public virtual Type GetFieldType(int i)
        {
            return Type.GetType(GetDataTypeName(i));
        }

        public virtual float GetFloat(int i)
        {
            return (float)Convert.ToDouble(i);
        }

        public virtual Guid GetGuid(int i)
        {
            return new Guid(GetString(i));
        }

        public virtual short GetInt16(int i)
        {
            return Convert.ToInt16(GetValue(i));
        }

        public virtual int GetInt32(int i)
        {
            return Convert.ToInt32(GetValue(i));
        }

        public virtual long GetInt64(int i)
        {
            return Convert.ToInt64(GetValue(i));
        }

        public virtual string GetName(int i)
        {
            return _properties[i].Name;
        }

        public int GetOrdinal(string name)
        {
            for (int i = 0; i < _properties.Count; i++)
            {
                if (name == _properties[i].Name)
                    return i;
            }
            return -1;
        }

        public virtual string GetString(int i)
        {
            var obj = GetValue(i);
            if (obj == null)
                return string.Empty;
            return obj.ToString();
        }

        public object GetValue(int i)
        {
            var p = _properties[i];
            var obj = _ie.Current.GetValue(p.Name);
            return obj;
        }


        public int GetValues(object[] values)
        {
            throw new NotImplementedException();
        }

        public bool IsDBNull(int i)
        {
            return string.IsNullOrEmpty(GetString(i));
        }

        public virtual object this[string name]
        {
            get
            {
                return this[GetOrdinal(name)];
            }
        }

        public virtual object this[int i]
        {
            get
            {
                return GetValue(i);
            }
        }

        #endregion
    }
}
