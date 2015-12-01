using System;
using System.Collections.Generic;

namespace i18n.PostBuild
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length == 0)
            {
                Console.WriteLine("This post build task requires passing in the $(ProjectDirectory) path");
                return;
            }

            var path = new List<string>();

            foreach ( var item in args ) {
                path.Add( item.Trim( new[] { '\"' } ) );
            }
            
            string gettext = null;
            string msgmerge = null;

            //for (int i = 1; i < args.Length; i++)
            //{
            //    if (args[i].StartsWith("gettext:", StringComparison.InvariantCultureIgnoreCase))
            //        gettext = args[i].Substring(8);

            //    if (args[i].StartsWith("msgmerge:", StringComparison.InvariantCultureIgnoreCase))
            //        msgmerge = args[i].Substring(9);
            //}

            new PostBuildTask().Execute(path.ToArray(), gettext, msgmerge);
        }
    }
}
