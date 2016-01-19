﻿using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daramkun.DaramRenamer.Processors.Extension
{
	public class AddExtensionAutomatedProcessor : IProcessor
	{
		public string Name { get { return "process_add_extension_automatically"; } }
		public bool CannotMultithreadProcess { get { return false; } }

		public bool Process ( FileInfo file )
		{
			if ( !File.Exists ( file.OriginalFullPath ) ) return false;

			using ( Stream stream = File.OpenRead ( file.OriginalFullPath ) )
			{


			}

			return true;
		}
	}
}