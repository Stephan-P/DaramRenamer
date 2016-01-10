﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Daramkun.DaramRenamer.Processors.Filename
{
	public class ReplaceRegexpProcessor : IProcessor
	{
		public string Name { get { return "process_replace_regex_text"; } }

		[Globalized ( "original_regex" )]
		public Regex RegularExpression { get; set; }
		[Globalized ( "replace_format" )]
		public string FormatString { get; set; }
		[Globalized ( "include_extension" )]
		public bool IncludeExtensions { get; set; }

		public ReplaceRegexpProcessor () { RegularExpression = new Regex ( "$^" ); FormatString = ""; IncludeExtensions = false; }
		public ReplaceRegexpProcessor ( Regex regexp, string format, bool includeExtensions = false )
		{
			RegularExpression = regexp;
			FormatString = format;
			IncludeExtensions = includeExtensions;
		}

		public bool Process ( FileInfo file )
		{
			try
			{
				string ext = !IncludeExtensions ? Path.GetExtension ( file.ChangedFilename ) : "";
				Match match = RegularExpression.Match ( IncludeExtensions ? file.ChangedFilename :
					Path.GetFileNameWithoutExtension ( file.ChangedFilename ) );
				GroupCollection group = match.Groups;
				object [] groupArr = new object [ group.Count ];
				for ( int i = 0; i < groupArr.Length; i++ )
					groupArr [ i ] = group [ i ].Value.Trim ();
				file.ChangedFilename = $"{string.Format ( FormatString, groupArr )}{ext}";
			}
			catch { return false; }
			return true;
		}
	}
}
