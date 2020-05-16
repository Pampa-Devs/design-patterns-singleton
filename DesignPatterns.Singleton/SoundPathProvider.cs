using System;
using System.Collections.Generic;

namespace DesignPatterns.Singleton
{
    public class SoundPathProvider
    {
        public readonly Guid Id;
        private SoundPathProvider()
        {
            Id = Guid.NewGuid();
        }

        private static readonly object _lock = new object();

        private static SoundPathProvider _instance;
        public static SoundPathProvider Instance
        {
            get
            {
                lock(_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new SoundPathProvider();
                    }
                }

                return _instance;
            }
        }

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
