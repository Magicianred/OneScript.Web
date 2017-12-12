﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OneScript.WebHost.Application;
using ScriptEngine;
using ScriptEngine.HostedScript.Library;

namespace OneScript.WebHost.Infrastructure
{
    public class WebApplicationEngine
    {
        public WebApplicationEngine()
        {
            Engine = new ScriptingEngine();
            Environment = new RuntimeEnvironment();
            Engine.Environment = Environment;

            Engine.AttachAssembly(System.Reflection.Assembly.GetExecutingAssembly(), Environment);
            Engine.AttachAssembly(typeof(SystemGlobalContext).Assembly, Environment);
            Environment.InjectObject(new WebGlobalContext());
        }
        
        public ScriptingEngine Engine { get; }
        public RuntimeEnvironment Environment { get; }


    }
}