using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KioskSample.Core.Dialog
{
    public class DialogParameters
    {
        private readonly Dictionary<string, object> _parameters = new();

        public void Add(string key, object value)
        {
            if (!_parameters.ContainsKey(key))
            {
                _parameters[key] = value;
            }
            else
            {
                throw new ArgumentException($"The key '{key}' already exists.");
            }
        }

        public T GetValue<T>(string key)
        {
            if (_parameters.TryGetValue(key, out var value) && value is T typedValue)
            {
                return typedValue;
            }

            throw new KeyNotFoundException($"The key '{key}' was not found.");
        }

        public bool ContainsKey(string key) => _parameters.ContainsKey(key);

        public IEnumerable<string> Keys => _parameters.Keys;
    }
}
