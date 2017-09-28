using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace MIMEtype
{
	class Program
	{
		static void Main(string[] args)
		{
			int N = int.Parse(Console.ReadLine()); // Number of elements which make up the association table.
			int Q = int.Parse(Console.ReadLine()); // Number Q of file names to be analyzed.

			List<KeyValuePair<string, string>> pairs = new List<KeyValuePair<string, string>>();
			List<string> answers = new List<string>();

			for (int i = 0; i < N; i++)
			{
				string[] inputs = Console.ReadLine().Split(' ');
				string EXT = inputs[0]; // file extension
				string MT = inputs[1]; // MIME type.
				pairs.Add(new KeyValuePair<string, string>(EXT.ToLower(), MT));
			}
			for (int i = 0; i < Q; i++)
			{
				string FNAME = Console.ReadLine(); // One file name per line.
				Console.Error.WriteLine("FNAME: " + FNAME);
				if (string.IsNullOrEmpty(FNAME))
				{
					answers.Add("UNKNOWN");
					continue;
				}

				string toCompare = FNAME.Substring(FNAME.LastIndexOf('.') + 1).ToLower();
				string toAnswers = "";
				Console.Error.WriteLine("toCompare: " + toCompare);
				foreach (var pair in pairs)
					if (pair.Key.Equals(toCompare))
					{
						toAnswers = pair.Value;
						break;
					}
					else
					{
						toAnswers = "UNKNOWN";
					}

				Console.Error.WriteLine("toAnswer: " + toAnswers);
				Console.Error.WriteLine("========================");
				answers.Add(toAnswers);
			}

			// Write an action using Console.WriteLine()
			// To debug: Console.Error.WriteLine("Debug messages...");


			// For each of the Q filenames, display on a line the corresponding MIME type. If there is no corresponding type, then display UNKNOWN.
			foreach (var answer in answers)
				Console.WriteLine(answer);
		}
	}
}