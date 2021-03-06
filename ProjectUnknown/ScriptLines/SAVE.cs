﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFork.ScriptLines
{
    class SAVE : Models.ScriptLine
    {
        private string _savename;

        public override void Process(string line, ref int e, ScriptFile script)
        {
            base.Process(line, ref e, script);
            this._savename = line;
        }

        public override void Run(FConsole console)
        {
            base.Run(console);
            if(String.IsNullOrEmpty(this._savename))
                SaveManager.INSTANCE.DoSave();
            else
            {
                string s = Expression.INSTANCE.ReplaceVF(this._savename, this.ScriptFile);
                SaveManager.INSTANCE.Save(this._savename + ".sav");
            }
        }
    }
}
