using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using PharmacyCompany.Database;
using PharmacyCompany.Data;

namespace PharmacyCompany.Commands
{
    internal abstract class CommandBase
    {
        protected IData _data;
        protected abstract List<string> Options { get; }

        protected Dictionary<string, string> optionValuePairs = new Dictionary<string, string>();

        protected DbInteraction _dbInteraction = null;

        protected void FillArgumentValuePairs(string[] args)
        {
            if (args.Count() % 2 == 0)
            {
                for (int i = 0; i < args.Length; i += 2)
                {
                    optionValuePairs.TryAdd(args[i].ToLower(), args[i + 1]);
                }
            }
            else
            {
                throw new ArgumentException("Переданы не все аргументы");
            }
        }


        protected bool InitData()
        {
            foreach (string option in Options)
            {
                if (!optionValuePairs.TryGetValue(option, out var value) || !_data.TrySetValueByName(option, value))
                {
                    return false;
                }
            }

            return true;
        }

        public CommandBase(string[] args, DbInteraction dbInteraction)
        {
            _dbInteraction = dbInteraction;

            FillArgumentValuePairs(args);
        }

        public abstract bool Execute();
    }
}
