﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IISLogMuncher
{
    public class CommandLineOptions
    {
        private Dictionary<char, string> options = null;
        private List<string> nonOptions = null;

        /// <summary>
        /// Create a standard object
        /// </summary>
        public CommandLineOptions()
        {
            options = new Dictionary<char, string>();
            nonOptions = new List<string>();
        }

        /// <summary>
        /// Has the requested option been set by the user?
        /// </summary>
        /// <param name="option"></param>
        /// <returns></returns>
        public bool IsOptionSet(char option)
        {
            return options.ContainsKey(option);
        }

        /// <summary>
        /// Return the value supplied with an option. String.Empty if none supplied. Exception if it doesn't exist.
        /// </summary>
        /// <param name="option"></param>
        /// <returns></returns>
        public string GetOption(char option)
        {
            if (IsOptionSet(option))
            {
                return options[option];
            }
            else
            {
                throw new InvalidOperationException("Option: " + option + " does not exist.");
            }
        }

        /// <summary>
        /// Set the value of an option to value.
        /// </summary>
        /// <param name="option"></param>
        /// <param name="value"></param>
        public void SetOption(char option, string value)
        {
            options[option] = value;
        }

        /// <summary>
        /// Return the number of options that are known.
        /// </summary>
        /// <returns></returns>
        public int GetOptionCount()
        {
            return options.Count;
        }

        /// <summary>
        /// Return a list of options which aren't of this form: -s
        /// </summary>
        /// <returns></returns>
        public List<string> GetNonOptions()
        {
            return nonOptions;
        }

        /// <summary>
        /// Add an option which isn't of the form: -s
        /// </summary>
        /// <param name="param"></param>
        public void AddNonOption(string param)
        {
            nonOptions.Add(param);
        }
    }
}
