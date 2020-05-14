using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace DesignPatterns.Singleton
{
    public class SoundPathProvider
    {
        #region Singleton
        public readonly Guid Id;
        private static readonly object _lock = new object();

        private SoundPathProvider()
        {
            Id = Guid.NewGuid();
        }

        public static SoundPathProvider _instance;
        public static SoundPathProvider GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new SoundPathProvider();
                    }
                }
            }

            return _instance;
        }
        #endregion

        private readonly Dictionary<string, string> _sounds = new Dictionary<string, string>();

        public void Add(string sound, string path)
        {
            lock(_lock)
            {
                if (!_sounds.ContainsKey(sound))
                {
                    _sounds.Add(sound, path);
                }
            }
        }
        public string GetPath(string sound)
        {
            if (_sounds.ContainsKey(sound))
            {
                return _sounds[sound];
            }

            return string.Empty;
        }

        public int SoundCount() => _sounds.Count;
    }
}
