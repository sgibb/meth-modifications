﻿// /* Options.cs
//  *
//  * Copyright (C) 2016 Thermo Fisher Scientific
//  *
//  * This software may be modified and distributed under the terms
//  * of the MIT license.  See the LICENSE file for details.
//  */
using CommandLine;
using CommandLine.Text;

namespace XmlMethodChanger.Cmd
{
    internal class Options
    {
        [VerbOption("status", HelpText = "Print status information about system")]
        public bool GetInfo { get; set; }

        [VerbOption("validate", HelpText = "Validate a file (.meth | .xml)", MetaValue = "<METHOD|XML>")]
        public string Validate { get; set; }

        [Option('i', "input", HelpText = "Path of template file (.meth)", MetaValue = "<METHOD>")]
        public string MethodTemplate { get; set; }

        [Option('m', "modification", HelpText = "Path of modification file (.xml)", MetaValue = "<XML>")]
        public string MethodModification { get; set; }

        [Option('o', "output", HelpText = "Path of modified file (.meth)", MetaValue = "<METHOD>")]
        public string OutputFile { get; set; }

        [Option('c', "create", HelpText = "Create a method from xml (Only for TSQ)", MetaValue="<XML>")]
        public string CreateMethodXML { get; set; }

        [Option("model", Required = false, HelpText = "Instrument Model (will auto find if not specified)", MetaValue = "\"OrbitrapFusion\"")]
        public string InstrumentModel { get; set; }

        [Option("version", Required = false, HelpText = "Instrument Model Version (will use latest version by default)", MetaValue = "\"2.0\"")]
        public string InstrumentVersion { get; set; }

        [HelpOption]
        public string GetUsage()
        {
            HelpText text = HelpText.AutoBuild(this, (current) => HelpText.DefaultParsingErrorsHandler(this, current));
            text.AddPostOptionsLine("Examples:");
            text.AddPostOptionsLine("  -i template.meth -m mods.xml -o result.meth");
            text.AddPostOptionsLine("  --validate result.meth");
            text.AddPostOptionsLine("  --validate mods.xml");
            text.AddPostOptionsLine(@"  -c method.xml --model=""TSQEndura""");    
            return text;
        }
    }
}