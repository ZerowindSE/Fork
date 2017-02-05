﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpressionEvaluator;
using Antlr.Runtime;

namespace ProjectFork
{
    class Expression
    {

        public static Expression INSTANCE
        {
            get
            {
                if (_instance == null) _instance = new Expression();
                return _instance;
            }
        }

        private static Expression _instance;
        private TypeRegistry _registry;

        public Expression()
        {
            this._registry = new TypeRegistry();
            this._registry.Add("True", true);
            this._registry.Add("False", false);
        }

        public string CalcExp(string exp)
        {
            try
            {
                var i = new CompiledExpression(exp);
                i.TypeRegistry = this._registry;
                return i.Eval().ToString();
            }
            catch
            {
                return exp;
            }
        }

        public string ReplaceVF(string text, ScriptFile localScript = null)
        {
            var dict = DataManager.INSTANCE.GetVarsDictionary();
            foreach(var i in dict)
            {
                text = text.Replace(this.FormatString(i.Key), i.Value);
            }

            var fdict = DataManager.INSTANCE.GetFlagsDictionary();
            foreach(var i in fdict)
            {
                text = text.Replace(this.FormatString(i.Key, "FLAG"), i.Value.ToString().ToLower());
            }

            if(localScript != null)
            {
                var ldict = localScript.GetLocalVarDictionary();
                foreach (var i in ldict)
                {
                    text = text.Replace(this.FormatString(i.Key, "LOCAL"), i.Value);
                }
            }

            return text;
            
        }

        private string FormatString(string text, string type = "VAR")
        {
            return String.Format("%{0}:{1}%", type, text);
        }

    }
}